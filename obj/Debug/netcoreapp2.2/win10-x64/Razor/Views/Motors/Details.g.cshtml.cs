#pragma checksum "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f049908f9a8241b66d032bf35df170b801be0030"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Motors_Details), @"mvc.1.0.view", @"/Views/Motors/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Motors/Details.cshtml", typeof(AspNetCore.Views_Motors_Details))]
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
#line 1 "C:\Dev\Isas\src\Isas\Views\_ViewImports.cshtml"
using Isas;

#line default
#line hidden
#line 6 "C:\Dev\Isas\src\Isas\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 7 "C:\Dev\Isas\src\Isas\Views\_ViewImports.cshtml"
using Syncfusion.JavaScript;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f049908f9a8241b66d032bf35df170b801be0030", @"/Views/Motors/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56b47519d9ed286534c00acb6b40cc4cb2e3d062", @"/Views/_ViewImports.cshtml")]
    public class Views_Motors_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Isas.Models.Motor>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(26, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(71, 119, true);
            WriteLiteral("\r\n<h2>Details</h2>\r\n\r\n<div>\r\n    <h4>Motor</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(191, 39, false);
#line 14 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CFG));

#line default
#line hidden
            EndContext();
            BeginContext(230, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(274, 35, false);
#line 17 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayFor(model => model.CFG));

#line default
#line hidden
            EndContext();
            BeginContext(309, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(353, 49, false);
#line 20 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ChassisNumber));

#line default
#line hidden
            EndContext();
            BeginContext(402, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(446, 45, false);
#line 23 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayFor(model => model.ChassisNumber));

#line default
#line hidden
            EndContext();
            BeginContext(491, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(535, 43, false);
#line 26 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.EndDate));

#line default
#line hidden
            EndContext();
            BeginContext(578, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(622, 39, false);
#line 29 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayFor(model => model.EndDate));

#line default
#line hidden
            EndContext();
            BeginContext(661, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(705, 48, false);
#line 32 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.EngineNumber));

#line default
#line hidden
            EndContext();
            BeginContext(753, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(797, 44, false);
#line 35 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayFor(model => model.EngineNumber));

#line default
#line hidden
            EndContext();
            BeginContext(841, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(885, 41, false);
#line 38 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Alarm));

#line default
#line hidden
            EndContext();
            BeginContext(926, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(970, 37, false);
#line 41 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayFor(model => model.Alarm));

#line default
#line hidden
            EndContext();
            BeginContext(1007, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1051, 47, false);
#line 44 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Immobiliser));

#line default
#line hidden
            EndContext();
            BeginContext(1098, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1142, 43, false);
#line 47 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayFor(model => model.Immobiliser));

#line default
#line hidden
            EndContext();
            BeginContext(1185, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1229, 47, false);
#line 50 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BusinessUse));

#line default
#line hidden
            EndContext();
            BeginContext(1276, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1320, 43, false);
#line 53 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayFor(model => model.BusinessUse));

#line default
#line hidden
            EndContext();
            BeginContext(1363, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1407, 46, false);
#line 56 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.GreyImport));

#line default
#line hidden
            EndContext();
            BeginContext(1453, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1497, 42, false);
#line 59 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayFor(model => model.GreyImport));

#line default
#line hidden
            EndContext();
            BeginContext(1539, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1583, 46, false);
#line 62 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PrivateUse));

#line default
#line hidden
            EndContext();
            BeginContext(1629, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1673, 42, false);
#line 65 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayFor(model => model.PrivateUse));

#line default
#line hidden
            EndContext();
            BeginContext(1715, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1759, 52, false);
#line 68 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ManufacturerYear));

#line default
#line hidden
            EndContext();
            BeginContext(1811, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1855, 48, false);
#line 71 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayFor(model => model.ManufacturerYear));

#line default
#line hidden
            EndContext();
            BeginContext(1903, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1947, 48, false);
#line 74 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.MotorModelID));

#line default
#line hidden
            EndContext();
            BeginContext(1995, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2039, 44, false);
#line 77 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayFor(model => model.MotorModelID));

#line default
#line hidden
            EndContext();
            BeginContext(2083, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2127, 43, false);
#line 80 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Premium));

#line default
#line hidden
            EndContext();
            BeginContext(2170, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2214, 39, false);
#line 83 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayFor(model => model.Premium));

#line default
#line hidden
            EndContext();
            BeginContext(2253, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2297, 54, false);
#line 86 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.RegistrationNumber));

#line default
#line hidden
            EndContext();
            BeginContext(2351, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2395, 50, false);
#line 89 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayFor(model => model.RegistrationNumber));

#line default
#line hidden
            EndContext();
            BeginContext(2445, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2489, 45, false);
#line 92 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.StartDate));

#line default
#line hidden
            EndContext();
            BeginContext(2534, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2578, 41, false);
#line 95 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayFor(model => model.StartDate));

#line default
#line hidden
            EndContext();
            BeginContext(2619, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2663, 52, false);
#line 98 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TerritorialLimit));

#line default
#line hidden
            EndContext();
            BeginContext(2715, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2759, 48, false);
#line 101 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayFor(model => model.TerritorialLimit));

#line default
#line hidden
            EndContext();
            BeginContext(2807, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2851, 41, false);
#line 104 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Value));

#line default
#line hidden
            EndContext();
            BeginContext(2892, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2936, 37, false);
#line 107 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
       Write(Html.DisplayFor(model => model.Value));

#line default
#line hidden
            EndContext();
            BeginContext(2973, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(3020, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f049908f9a8241b66d032bf35df170b801be003016169", async() => {
                BeginContext(3066, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 112 "C:\Dev\Isas\src\Isas\Views\Motors\Details.cshtml"
                           WriteLiteral(Model.ID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3074, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(3082, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f049908f9a8241b66d032bf35df170b801be003018461", async() => {
                BeginContext(3104, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3120, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Isas.Models.Motor> Html { get; private set; }
    }
}
#pragma warning restore 1591
