#pragma checksum "C:\Users\levin_m\source\repos\isas\Views\Payables\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b4ca7b1e694467d2142b0fd3212cdd648692115"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Payables_Delete), @"mvc.1.0.view", @"/Views/Payables/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Payables/Delete.cshtml", typeof(AspNetCore.Views_Payables_Delete))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b4ca7b1e694467d2142b0fd3212cdd648692115", @"/Views/Payables/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56b47519d9ed286534c00acb6b40cc4cb2e3d062", @"/Views/_ViewImports.cshtml")]
    public class Views_Payables_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Isas.Models.Payable>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(28, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\levin_m\source\repos\isas\Views\Payables\Delete.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(57, 29, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            EndContext();
            BeginContext(86, 101, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b4ca7b1e694467d2142b0fd3212cdd6486921154725", async() => {
                BeginContext(92, 88, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Delete</title>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(187, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(189, 1980, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b4ca7b1e694467d2142b0fd3212cdd6486921156001", async() => {
                BeginContext(195, 151, true);
                WriteLiteral("\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Payable</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
                EndContext();
                BeginContext(347, 45, false);
#line 22 "C:\Users\levin_m\source\repos\isas\Views\Payables\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Reference));

#line default
#line hidden
                EndContext();
                BeginContext(392, 43, true);
                WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
                EndContext();
                BeginContext(436, 41, false);
#line 25 "C:\Users\levin_m\source\repos\isas\Views\Payables\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Reference));

#line default
#line hidden
                EndContext();
                BeginContext(477, 43, true);
                WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
                EndContext();
                BeginContext(521, 47, false);
#line 28 "C:\Users\levin_m\source\repos\isas\Views\Payables\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PayableDate));

#line default
#line hidden
                EndContext();
                BeginContext(568, 43, true);
                WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
                EndContext();
                BeginContext(612, 43, false);
#line 31 "C:\Users\levin_m\source\repos\isas\Views\Payables\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PayableDate));

#line default
#line hidden
                EndContext();
                BeginContext(655, 43, true);
                WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
                EndContext();
                BeginContext(699, 49, false);
#line 34 "C:\Users\levin_m\source\repos\isas\Views\Payables\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PaymentTypeID));

#line default
#line hidden
                EndContext();
                BeginContext(748, 43, true);
                WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
                EndContext();
                BeginContext(792, 45, false);
#line 37 "C:\Users\levin_m\source\repos\isas\Views\Payables\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PaymentTypeID));

#line default
#line hidden
                EndContext();
                BeginContext(837, 43, true);
                WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
                EndContext();
                BeginContext(881, 42, false);
#line 40 "C:\Users\levin_m\source\repos\isas\Views\Payables\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Amount));

#line default
#line hidden
                EndContext();
                BeginContext(923, 43, true);
                WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
                EndContext();
                BeginContext(967, 38, false);
#line 43 "C:\Users\levin_m\source\repos\isas\Views\Payables\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Amount));

#line default
#line hidden
                EndContext();
                BeginContext(1005, 43, true);
                WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
                EndContext();
                BeginContext(1049, 47, false);
#line 46 "C:\Users\levin_m\source\repos\isas\Views\Payables\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.BatchNumber));

#line default
#line hidden
                EndContext();
                BeginContext(1096, 43, true);
                WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
                EndContext();
                BeginContext(1140, 43, false);
#line 49 "C:\Users\levin_m\source\repos\isas\Views\Payables\Delete.cshtml"
       Write(Html.DisplayFor(model => model.BatchNumber));

#line default
#line hidden
                EndContext();
                BeginContext(1183, 43, true);
                WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
                EndContext();
                BeginContext(1227, 40, false);
#line 52 "C:\Users\levin_m\source\repos\isas\Views\Payables\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Void));

#line default
#line hidden
                EndContext();
                BeginContext(1267, 43, true);
                WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
                EndContext();
                BeginContext(1311, 36, false);
#line 55 "C:\Users\levin_m\source\repos\isas\Views\Payables\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Void));

#line default
#line hidden
                EndContext();
                BeginContext(1347, 43, true);
                WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
                EndContext();
                BeginContext(1391, 46, false);
#line 58 "C:\Users\levin_m\source\repos\isas\Views\Payables\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.VoidReason));

#line default
#line hidden
                EndContext();
                BeginContext(1437, 43, true);
                WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
                EndContext();
                BeginContext(1481, 42, false);
#line 61 "C:\Users\levin_m\source\repos\isas\Views\Payables\Delete.cshtml"
       Write(Html.DisplayFor(model => model.VoidReason));

#line default
#line hidden
                EndContext();
                BeginContext(1523, 43, true);
                WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
                EndContext();
                BeginContext(1567, 43, false);
#line 64 "C:\Users\levin_m\source\repos\isas\Views\Payables\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Remarks));

#line default
#line hidden
                EndContext();
                BeginContext(1610, 43, true);
                WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
                EndContext();
                BeginContext(1654, 39, false);
#line 67 "C:\Users\levin_m\source\repos\isas\Views\Payables\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Remarks));

#line default
#line hidden
                EndContext();
                BeginContext(1693, 17, true);
                WriteLiteral("\r\n        </dd>\r\n");
                EndContext();
                BeginContext(1901, 21, true);
                WriteLiteral("    </dl>\r\n    \r\n    ");
                EndContext();
                BeginContext(1922, 230, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b4ca7b1e694467d2142b0fd3212cdd64869211513172", async() => {
                    BeginContext(1948, 137, true);
                    WriteLiteral("\r\n        <div class=\"form-actions no-color\">\r\n            <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\r\n            ");
                    EndContext();
                    BeginContext(2085, 38, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b4ca7b1e694467d2142b0fd3212cdd64869211513725", async() => {
                        BeginContext(2107, 12, true);
                        WriteLiteral("Back to List");
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(2123, 22, true);
                    WriteLiteral("\r\n        </div>\r\n    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2152, 10, true);
                WriteLiteral("\r\n</div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2169, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Isas.Models.Payable> Html { get; private set; }
    }
}
#pragma warning restore 1591
