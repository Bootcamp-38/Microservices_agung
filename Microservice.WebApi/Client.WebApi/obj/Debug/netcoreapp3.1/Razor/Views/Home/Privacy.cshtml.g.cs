#pragma checksum "D:\bootcamp\github\Microservices_agung\Microservice.WebApi\Client.WebApi\Views\Home\Privacy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "818444444b7433adfe6cfed6a71aa972b2e50371"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Privacy), @"mvc.1.0.view", @"/Views/Home/Privacy.cshtml")]
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
#nullable restore
#line 1 "D:\bootcamp\github\Microservices_agung\Microservice.WebApi\Client.WebApi\Views\_ViewImports.cshtml"
using Client.WebApi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\bootcamp\github\Microservices_agung\Microservice.WebApi\Client.WebApi\Views\_ViewImports.cshtml"
using Client.WebApi.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"818444444b7433adfe6cfed6a71aa972b2e50371", @"/Views/Home/Privacy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"741b8fa1756a968664e216a36fe51a248b7ec8c1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Privacy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\bootcamp\github\Microservices_agung\Microservice.WebApi\Client.WebApi\Views\Home\Privacy.cshtml"
  
    ViewData["Title"] = "Privacy Policy";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>");
#nullable restore
#line 4 "D:\bootcamp\github\Microservices_agung\Microservice.WebApi\Client.WebApi\Views\Home\Privacy.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n");
#nullable restore
#line 6 "D:\bootcamp\github\Microservices_agung\Microservice.WebApi\Client.WebApi\Views\Home\Privacy.cshtml"
   ViewBag.Title = "Role: ";
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\bootcamp\github\Microservices_agung\Microservice.WebApi\Client.WebApi\Views\Home\Privacy.cshtml"
                                  
    var RoleName = ViewBag.RoleName; 

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>");
#nullable restore
#line 9 "D:\bootcamp\github\Microservices_agung\Microservice.WebApi\Client.WebApi\Views\Home\Privacy.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h3>");
#nullable restore
#line 10 "D:\bootcamp\github\Microservices_agung\Microservice.WebApi\Client.WebApi\Views\Home\Privacy.cshtml"
Write(ViewData["Message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n<p>Use this area to provide additional information.</p>\r\n<table>\r\n");
            WriteLiteral("    <tr>\r\n        <th>Role Name</th>\r\n        <td>");
#nullable restore
#line 20 "D:\bootcamp\github\Microservices_agung\Microservice.WebApi\Client.WebApi\Views\Home\Privacy.cshtml"
       Write(RoleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n</table>\r\n© 2020 GitHub, ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
