#pragma checksum "/Users/gina/Desktop/WeddingPlanner-master/Views/Home/WeddingPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cdf89c57dd48fd0adc3d17300299120e76482fde"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_WeddingPage), @"mvc.1.0.view", @"/Views/Home/WeddingPage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/WeddingPage.cshtml", typeof(AspNetCore.Views_Home_WeddingPage))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/Users/gina/Desktop/WeddingPlanner-master/Views/_ViewImports.cshtml"
using WeddingPlanner;

#line default
#line hidden
#line 2 "/Users/gina/Desktop/WeddingPlanner-master/Views/_ViewImports.cshtml"
using WeddingPlanner.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cdf89c57dd48fd0adc3d17300299120e76482fde", @"/Views/Home/WeddingPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e9e38482b8beecdb199b7be73dfa5c3d6a2f574", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_WeddingPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Wedding>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(15, 34, true);
            WriteLiteral("\n\n<div class=\"jumbotron\">\n    <h1>");
            EndContext();
            BeginContext(50, 14, false);
#line 5 "/Users/gina/Desktop/WeddingPlanner-master/Views/Home/WeddingPage.cshtml"
   Write(Model.Wedder_1);

#line default
#line hidden
            EndContext();
            BeginContext(64, 5, true);
            WriteLiteral(" and ");
            EndContext();
            BeginContext(70, 14, false);
#line 5 "/Users/gina/Desktop/WeddingPlanner-master/Views/Home/WeddingPage.cshtml"
                       Write(Model.Wedder_2);

#line default
#line hidden
            EndContext();
            BeginContext(84, 28, true);
            WriteLiteral("\'s Wedding</h1>\n</div>\n\n<h3>");
            EndContext();
            BeginContext(113, 10, false);
#line 8 "/Users/gina/Desktop/WeddingPlanner-master/Views/Home/WeddingPage.cshtml"
Write(Model.Date);

#line default
#line hidden
            EndContext();
            BeginContext(123, 43, true);
            WriteLiteral("</h3>\n\n<h2>Guests:</h2>\n    <ul>\n         \n");
            EndContext();
#line 13 "/Users/gina/Desktop/WeddingPlanner-master/Views/Home/WeddingPage.cshtml"
         foreach (RSVP rsvp in ViewBag.GuestList){


#line default
#line hidden
            BeginContext(218, 16, true);
            WriteLiteral("            <li>");
            EndContext();
            BeginContext(235, 19, false);
#line 15 "/Users/gina/Desktop/WeddingPlanner-master/Views/Home/WeddingPage.cshtml"
           Write(rsvp.User.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(254, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(256, 18, false);
#line 15 "/Users/gina/Desktop/WeddingPlanner-master/Views/Home/WeddingPage.cshtml"
                                Write(rsvp.User.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(274, 6, true);
            WriteLiteral("</li>\n");
            EndContext();
#line 16 "/Users/gina/Desktop/WeddingPlanner-master/Views/Home/WeddingPage.cshtml"
        }

#line default
#line hidden
            BeginContext(290, 22, true);
            WriteLiteral("        \n    </ul>\n\n\n\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wedding> Html { get; private set; }
    }
}
#pragma warning restore 1591
