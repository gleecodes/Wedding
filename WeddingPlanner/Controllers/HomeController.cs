using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {

        private WeddingPlannerContext dbContext;

        public HomeController(WeddingPlannerContext context){
            dbContext = context;
        }

        [Route("/")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/Register/process")]
        public IActionResult Register(User userSubmission){
            if (ModelState.IsValid){
                if(dbContext.Users.Any(u => u.Email == userSubmission.Email)){
                    ModelState.AddModelError("Email", "Email is already in use!");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                userSubmission.Password = Hasher.HashPassword(userSubmission, userSubmission.Password);
                dbContext.Users.Add(userSubmission);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("LoggedInUserId", userSubmission.UserId);
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }


        [HttpPost("/Login/process")]
        public IActionResult Login(LoginUser loginUserSubmission){
            if (ModelState.IsValid){
                User thisUser = dbContext.Users.FirstOrDefault(u => u.Email == loginUserSubmission.Email);
                if(thisUser == null){
                    ModelState.AddModelError("Email", "No user exists with the provided email address! Please register!");
                    return View("Index");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(loginUserSubmission, thisUser.Password, loginUserSubmission.Password);
                if (result==0){
                    ModelState.AddModelError("Password", "Invalid email/password combination!");
                    return View("Index");
                }
                HttpContext.Session.SetInt32("LoggedInUserId", thisUser.UserId);
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }


        [HttpGet("Dashboard")]
        public IActionResult Dashboard(){
            List<Wedding> AllWeddings = dbContext.Weddings.ToList();
            int? userId = HttpContext.Session.GetInt32("LoggedInUserId");
            // if user is not logged in, redirect to Index
            if (userId==null){
                return RedirectToAction("Index");
            }
            int thisUserId = (int)userId;
            User thisUser = dbContext.Users.FirstOrDefault(u => u.UserId == thisUserId);

            List<Wedding> CreatedWeddings = dbContext.Weddings
                .Where(w => w.CreatorId == thisUserId)
                .ToList();

            ViewBag.CreatedWeddings = CreatedWeddings;
            
            List<Wedding> RSVPList = dbContext.getRSVPedWeddings(thisUserId);

            ViewBag.WeddingList = RSVPList;


            return View(AllWeddings);
        }

        [HttpGet("/wedding/new")]
        public IActionResult NewWedding(){
            return View();
        }

        [HttpPost("/wedding/add")]
        public IActionResult AddWedding(Wedding weddingSubmission){
            if (ModelState.IsValid){
                int thisUserId = (int)HttpContext.Session.GetInt32("LoggedInUserId");
                weddingSubmission.CreatorId = thisUserId;
                dbContext.Weddings.Add(weddingSubmission);
                dbContext.SaveChanges();
                return Redirect($"/wedding/{weddingSubmission.WeddingId}");
            }
            return View("NewWeddingView");
        }

        [HttpGet("/wedding/delete/{weddingId}")]
        public IActionResult DeleteWedding(int weddingId){
            Wedding thisWedding = dbContext.Weddings.FirstOrDefault(w => w.WeddingId == weddingId);
            dbContext.Weddings.Remove(thisWedding);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("/wedding/{weddingId}")]
        public IActionResult WeddingPage(int weddingId){
            // get instance of thisWedding
            Wedding thisWedding = dbContext.Weddings
                .Include(w => w.GuestList)
                .ThenInclude(r => r.User)
                .FirstOrDefault(w => w.WeddingId == weddingId);

            // query for guest list to this wedding, including everything we need
                // pass into ViewBag

            ViewBag.GuestList = thisWedding.GuestList;

            return View(thisWedding);
        }

        [HttpGet("/wedding/{weddingId}/RSVP")]
        public IActionResult RSVP(int weddingId){
            int thisUserId = (int)HttpContext.Session.GetInt32("LoggedInUserId");
            User thisUser = dbContext.Users.FirstOrDefault(u => u.UserId == thisUserId);
            Wedding thisWedding = dbContext.Weddings.FirstOrDefault(w => w.WeddingId == weddingId);
            RSVP thisRSVP = new RSVP();
            thisRSVP.UserId = thisUserId;
            thisRSVP.WeddingId = thisWedding.WeddingId;
            thisUser.WeddingList.Add(thisRSVP);
            dbContext.SaveChanges();

            return Redirect($"/wedding/{weddingId}");
        }

        [HttpGet("/wedding/{weddingId}/Un-RSVP")]
        public IActionResult UnRSVP(int weddingId){
            int thisUserId = (int)HttpContext.Session.GetInt32("LoggedInUserId");
            User thisUser = dbContext.Users.FirstOrDefault(u => u.UserId == thisUserId);
            Wedding thisWedding = dbContext.Weddings.FirstOrDefault(w => w.WeddingId == weddingId);

            RSVP thisRSVP = dbContext.RSVPs.FirstOrDefault(r => r.UserId == thisUser.UserId && r.WeddingId == thisWedding.WeddingId);

            dbContext.RSVPs.Remove(thisRSVP);
            dbContext.SaveChanges();

            return Redirect("/Dashboard");
        }





        [HttpGet("/logout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("/");
        }
    }
}

