#pragma checksum "C:\Dev\Isas\src\Isas\Views\Loans\LoadLoans.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dcaa693f4bf7b2857ba53b8583df8fbe9090b62c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Loans_LoadLoans), @"mvc.1.0.view", @"/Views/Loans/LoadLoans.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Loans/LoadLoans.cshtml", typeof(AspNetCore.Views_Loans_LoadLoans))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dcaa693f4bf7b2857ba53b8583df8fbe9090b62c", @"/Views/Loans/LoadLoans.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56b47519d9ed286534c00acb6b40cc4cb2e3d062", @"/Views/_ViewImports.cshtml")]
    public class Views_Loans_LoadLoans : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Isas.Models.InsurerViewModels.LoanTempsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "LoadLoans", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(57, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Dev\Isas\src\Isas\Views\Loans\LoadLoans.cshtml"
  
    ViewData["Title"] = "Load Loans";
    string loantype = Model.LoanTemps.FirstOrDefault().Component.Name;

#line default
#line hidden
            BeginContext(177, 25, true);
            WriteLiteral("\r\n<h2>Load Loans</h2>\r\n\r\n");
            EndContext();
            BeginContext(202, 503, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dcaa693f4bf7b2857ba53b8583df8fbe9090b62c4992", async() => {
                BeginContext(231, 42, true);
                WriteLiteral("\r\n    <h4>Bulk Load</h4>\r\n    <hr />\r\n    ");
                EndContext();
                BeginContext(273, 66, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dcaa693f4bf7b2857ba53b8583df8fbe9090b62c5418", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#line 13 "C:\Dev\Isas\src\Isas\Views\Loans\LoadLoans.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(339, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(345, 43, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dcaa693f4bf7b2857ba53b8583df8fbe9090b62c7175", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 14 "C:\Dev\Isas\src\Isas\Views\Loans\LoadLoans.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ProductID);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(388, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(394, 40, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dcaa693f4bf7b2857ba53b8583df8fbe9090b62c8969", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 15 "C:\Dev\Isas\src\Isas\Views\Loans\LoadLoans.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.UserID);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(434, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(440, 45, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dcaa693f4bf7b2857ba53b8583df8fbe9090b62c10760", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 16 "C:\Dev\Isas\src\Isas\Views\Loans\LoadLoans.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ComponentID);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(485, 213, true);
                WriteLiteral("\r\n\r\n    <div class=\"form-group\">\r\n        <div class=\"col-md-offset-2 col-md-10\">\r\n            <input type=\"submit\" value=\"Click button to load to database\" class=\"btn btn-default\" />\r\n        </div>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(705, 72, true);
            WriteLiteral("\r\n\r\n<div class=\"panel-title panel-group\">\r\n    <p>\r\n        Loan Total: ");
            EndContext();
            BeginContext(778, 47, false);
#line 27 "C:\Dev\Isas\src\Isas\Views\Loans\LoadLoans.cshtml"
               Write(String.Format("{0:#,##0.00}", @Model.LoanTotal));

#line default
#line hidden
            EndContext();
            BeginContext(825, 44, true);
            WriteLiteral("\r\n    </p>\r\n    <p>\r\n        Premium Total: ");
            EndContext();
            BeginContext(870, 50, false);
#line 30 "C:\Dev\Isas\src\Isas\Views\Loans\LoadLoans.cshtml"
                  Write(String.Format("{0:#,##0.00}", @Model.PremiumTotal));

#line default
#line hidden
            EndContext();
            BeginContext(920, 40, true);
            WriteLiteral("\r\n    </p>\r\n    <p>\r\n        Loan Type: ");
            EndContext();
            BeginContext(961, 8, false);
#line 33 "C:\Dev\Isas\src\Isas\Views\Loans\LoadLoans.cshtml"
              Write(loantype);

#line default
#line hidden
            EndContext();
            BeginContext(969, 670, true);
            WriteLiteral(@"
    </p>
</div>

<hr /><br />
<table class=""table table-striped table-bordered"">
    <thead>
        <tr>
            <th>
                ID Number
            </th>
            <th>
                Account Number
            </th>
            <th>
                Term
            </th>
            <th>
                Rate
            </th>
            <th>
                Loan Date
            </th>
            <th>
                Loan Amount
            </th>
            <th>
                Premium
            </th>
            <th>
                Settlement Date
            </th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 68 "C:\Dev\Isas\src\Isas\Views\Loans\LoadLoans.cshtml"
         foreach (var item in Model.LoanTemps)
        {

#line default
#line hidden
            BeginContext(1698, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1759, 43, false);
#line 72 "C:\Dev\Isas\src\Isas\Views\Loans\LoadLoans.cshtml"
               Write(Html.DisplayFor(modelItem => item.IDNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1802, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1870, 48, false);
#line 75 "C:\Dev\Isas\src\Isas\Views\Loans\LoadLoans.cshtml"
               Write(Html.DisplayFor(modelItem => item.AccountNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1918, 82, true);
            WriteLiteral("\r\n                </td>\r\n                <td align=\"center\">\r\n                    ");
            EndContext();
            BeginContext(2001, 39, false);
#line 78 "C:\Dev\Isas\src\Isas\Views\Loans\LoadLoans.cshtml"
               Write(Html.DisplayFor(modelItem => item.Term));

#line default
#line hidden
            EndContext();
            BeginContext(2040, 82, true);
            WriteLiteral("\r\n                </td>\r\n                <td align=\"center\">\r\n                    ");
            EndContext();
            BeginContext(2123, 39, false);
#line 81 "C:\Dev\Isas\src\Isas\Views\Loans\LoadLoans.cshtml"
               Write(Html.DisplayFor(modelItem => item.Rate));

#line default
#line hidden
            EndContext();
            BeginContext(2162, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2230, 43, false);
#line 84 "C:\Dev\Isas\src\Isas\Views\Loans\LoadLoans.cshtml"
               Write(Html.DisplayFor(modelItem => item.LoanDate));

#line default
#line hidden
            EndContext();
            BeginContext(2273, 81, true);
            WriteLiteral("\r\n                </td>\r\n                <td align=\"right\">\r\n                    ");
            EndContext();
            BeginContext(2355, 40, false);
#line 87 "C:\Dev\Isas\src\Isas\Views\Loans\LoadLoans.cshtml"
               Write(Html.DisplayFor(modelItem => item.Value));

#line default
#line hidden
            EndContext();
            BeginContext(2395, 81, true);
            WriteLiteral("\r\n                </td>\r\n                <td align=\"right\">\r\n                    ");
            EndContext();
            BeginContext(2477, 42, false);
#line 90 "C:\Dev\Isas\src\Isas\Views\Loans\LoadLoans.cshtml"
               Write(Html.DisplayFor(modelItem => item.Premium));

#line default
#line hidden
            EndContext();
            BeginContext(2519, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2587, 49, false);
#line 93 "C:\Dev\Isas\src\Isas\Views\Loans\LoadLoans.cshtml"
               Write(Html.DisplayFor(modelItem => item.SettlementDate));

#line default
#line hidden
            EndContext();
            BeginContext(2636, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 96 "C:\Dev\Isas\src\Isas\Views\Loans\LoadLoans.cshtml"
        }

#line default
#line hidden
            BeginContext(2691, 44, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<div>\r\n    Total: ");
            EndContext();
            BeginContext(2736, 23, false);
#line 101 "C:\Dev\Isas\src\Isas\Views\Loans\LoadLoans.cshtml"
      Write(Model.LoanTemps.Count());

#line default
#line hidden
            EndContext();
            BeginContext(2759, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Isas.Models.InsurerViewModels.LoanTempsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
