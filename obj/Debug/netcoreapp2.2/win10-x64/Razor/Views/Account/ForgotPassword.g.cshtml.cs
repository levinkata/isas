#pragma checksum "C:\Users\levin_m\source\repos\isas\Views\Account\ForgotPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18ff53d3709dc346f9cc2e20b53a9e543c312584"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ForgotPassword), @"mvc.1.0.view", @"/Views/Account/ForgotPassword.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/ForgotPassword.cshtml", typeof(AspNetCore.Views_Account_ForgotPassword))]
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
#line 1 "C:\Users\levin_m\source\repos\isas\Views\_ViewImports.cshtml"
using Isas;

#line default
#line hidden
#line 6 "C:\Users\levin_m\source\repos\isas\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 7 "C:\Users\levin_m\source\repos\isas\Views\_ViewImports.cshtml"
using Syncfusion.JavaScript;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18ff53d3709dc346f9cc2e20b53a9e543c312584", @"/Views/Account/ForgotPassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56b47519d9ed286534c00acb6b40cc4cb2e3d062", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_ForgotPassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Isas.Models.AccountViewModels.ForgotPasswordViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\levin_m\source\repos\isas\Views\Account\ForgotPassword.cshtml"
  
    ViewData["Title"] = "Forgot your password?";

#line default
#line hidden
            BeginContext(119, 6, true);
            WriteLiteral("\r\n<h2>");
            EndContext();
            BeginContext(126, 17, false);
#line 6 "C:\Users\levin_m\source\repos\isas\Views\Account\ForgotPassword.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(143, 163, true);
            WriteLiteral("</h2>\r\n<p>\r\n    For more information on how to enable reset password please see this <a href=\"http://go.microsoft.com/fwlink/?LinkID=532713\">article</a>.\r\n</p>\r\n\r\n");
            EndContext();
            BeginContext(1007, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1027, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 30 "C:\Users\levin_m\source\repos\isas\Views\Account\ForgotPassword.cshtml"
       await Html.RenderPartialAsync("_ValidationScriptsPartial"); 

#line default
#line hidden
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Isas.Models.AccountViewModels.ForgotPasswordViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
