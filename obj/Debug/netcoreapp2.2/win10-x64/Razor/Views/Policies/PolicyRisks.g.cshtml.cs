#pragma checksum "C:\Users\levin_m\source\repos\isas\Views\Policies\PolicyRisks.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9657064ac6fc4244736346d6201f94bc4d4f2c3c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Policies_PolicyRisks), @"mvc.1.0.view", @"/Views/Policies/PolicyRisks.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Policies/PolicyRisks.cshtml", typeof(AspNetCore.Views_Policies_PolicyRisks))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9657064ac6fc4244736346d6201f94bc4d4f2c3c", @"/Views/Policies/PolicyRisks.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56b47519d9ed286534c00acb6b40cc4cb2e3d062", @"/Views/_ViewImports.cshtml")]
    public class Views_Policies_PolicyRisks : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Isas.Models.InsurerViewModels.PolicyRisksViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(59, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\levin_m\source\repos\isas\Views\Policies\PolicyRisks.cshtml"
  
    ViewData["Title"] = "Policy Risks";

#line default
#line hidden
            BeginContext(109, 72, true);
            WriteLiteral("\r\n<h2>Policy Risks</h2>\r\n<hr />\r\n<h5 style=\"color:royalblue; font:bold\">");
            EndContext();
            BeginContext(182, 16, false);
#line 9 "C:\Users\levin_m\source\repos\isas\Views\Policies\PolicyRisks.cshtml"
                                  Write(Model.ClientName);

#line default
#line hidden
            EndContext();
            BeginContext(198, 17, true);
            WriteLiteral(" - Risks</h5>\r\n\r\n");
            EndContext();
#line 11 "C:\Users\levin_m\source\repos\isas\Views\Policies\PolicyRisks.cshtml"
 foreach (var item in Model.Risks)
{
    

#line default
#line hidden
#line 13 "C:\Users\levin_m\source\repos\isas\Views\Policies\PolicyRisks.cshtml"
     switch (item.ID)
    {
        case 1:
            

#line default
#line hidden
            BeginContext(314, 163, false);
#line 16 "C:\Users\levin_m\source\repos\isas\Views\Policies\PolicyRisks.cshtml"
       Write(await Component.InvokeAsync("AllRisks", new {
                                ProductId = Model.ProductID, clientId = Model.ClientID, policyId = Model.PolicyID }));

#line default
#line hidden
            EndContext();
#line 17 "C:\Users\levin_m\source\repos\isas\Views\Policies\PolicyRisks.cshtml"
                                                                                                                    ;
            break;
        case 2:
            

#line default
#line hidden
            BeginContext(530, 166, false);
#line 20 "C:\Users\levin_m\source\repos\isas\Views\Policies\PolicyRisks.cshtml"
       Write(await Component.InvokeAsync("Commercials", new {
                                ProductId = Model.ProductID, clientId = Model.ClientID, policyId = Model.PolicyID }));

#line default
#line hidden
            EndContext();
#line 21 "C:\Users\levin_m\source\repos\isas\Views\Policies\PolicyRisks.cshtml"
                                                                                                                    ;
            break;
        case 3:
            

#line default
#line hidden
            BeginContext(749, 163, false);
#line 24 "C:\Users\levin_m\source\repos\isas\Views\Policies\PolicyRisks.cshtml"
       Write(await Component.InvokeAsync("Contents", new {
                                ProductId = Model.ProductID, clientId = Model.ClientID, policyId = Model.PolicyID }));

#line default
#line hidden
            EndContext();
#line 25 "C:\Users\levin_m\source\repos\isas\Views\Policies\PolicyRisks.cshtml"
                                                                                                                    ;
            break;
        case 4:
            

#line default
#line hidden
            BeginContext(965, 160, false);
#line 28 "C:\Users\levin_m\source\repos\isas\Views\Policies\PolicyRisks.cshtml"
       Write(await Component.InvokeAsync("Loans", new {
                                ProductId = Model.ProductID, clientId = Model.ClientID, policyId = Model.PolicyID }));

#line default
#line hidden
            EndContext();
#line 29 "C:\Users\levin_m\source\repos\isas\Views\Policies\PolicyRisks.cshtml"
                                                                                                                    ;
            break;
        case 5:
            

#line default
#line hidden
            BeginContext(1178, 161, false);
#line 32 "C:\Users\levin_m\source\repos\isas\Views\Policies\PolicyRisks.cshtml"
       Write(await Component.InvokeAsync("Motors", new {
                                ProductId = Model.ProductID, clientId = Model.ClientID, policyId = Model.PolicyID }));

#line default
#line hidden
            EndContext();
#line 33 "C:\Users\levin_m\source\repos\isas\Views\Policies\PolicyRisks.cshtml"
                                                                                                                    ;
            break;
        case 6:
            

#line default
#line hidden
            BeginContext(1392, 165, false);
#line 36 "C:\Users\levin_m\source\repos\isas\Views\Policies\PolicyRisks.cshtml"
       Write(await Component.InvokeAsync("Properties", new {
                                ProductId = Model.ProductID, clientId = Model.ClientID, policyId = Model.PolicyID }));

#line default
#line hidden
            EndContext();
#line 37 "C:\Users\levin_m\source\repos\isas\Views\Policies\PolicyRisks.cshtml"
                                                                                                                    ;
            break;
        default:
            break;
    }

#line default
#line hidden
#line 41 "C:\Users\levin_m\source\repos\isas\Views\Policies\PolicyRisks.cshtml"
     
}

#line default
#line hidden
            BeginContext(1628, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1631, 82, false);
#line 44 "C:\Users\levin_m\source\repos\isas\Views\Policies\PolicyRisks.cshtml"
Write(await Component.InvokeAsync("PolicyRiskTotals", new { policyId = Model.PolicyID }));

#line default
#line hidden
            EndContext();
            BeginContext(1713, 25, true);
            WriteLiteral("\r\n\r\n<hr />\r\n\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1738, 169, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9657064ac6fc4244736346d6201f94bc4d4f2c3c9567", async() => {
                BeginContext(1881, 22, true);
                WriteLiteral("\r\n        Return\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-productId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 50 "C:\Users\levin_m\source\repos\isas\Views\Policies\PolicyRisks.cshtml"
                WriteLiteral(Model.ProductID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 51 "C:\Users\levin_m\source\repos\isas\Views\Policies\PolicyRisks.cshtml"
               WriteLiteral(Model.ClientID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["clientId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-clientId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["clientId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1907, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1937, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 58 "C:\Users\levin_m\source\repos\isas\Views\Policies\PolicyRisks.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
                BeginContext(2007, 2, true);
                WriteLiteral("\r\n");
                EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Isas.Models.InsurerViewModels.PolicyRisksViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
