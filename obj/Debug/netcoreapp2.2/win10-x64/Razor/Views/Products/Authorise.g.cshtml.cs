#pragma checksum "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5212499a9d5b2a956072f66c33dc05a1b4752eef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_Authorise), @"mvc.1.0.view", @"/Views/Products/Authorise.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Products/Authorise.cshtml", typeof(AspNetCore.Views_Products_Authorise))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5212499a9d5b2a956072f66c33dc05a1b4752eef", @"/Views/Products/Authorise.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56b47519d9ed286534c00acb6b40cc4cb2e3d062", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_Authorise : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Isas.Models.InsurerViewModels.AuthoriseViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SetAuthorise", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("btnAuthorise"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Products", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Board", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(57, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
  
    ViewData["Title"] = "Requisitions";

#line default
#line hidden
            BeginContext(107, 383, true);
            WriteLiteral(@"
<h2>Requisitions</h2>
 <hr />

<div id=""dialog-message"" title=""Download complete"">
    <p>
        <span class=""ui-icon ui-icon-circle-check"" style=""float:left; margin:0 7px 50px 0;""></span>
        Your files have downloaded successfully into the My Downloads folder.
    </p>
    <p>
        Currently using <b>36% of your storage space</b>.
    </p>
</div>

<div>
");
            EndContext();
#line 21 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
     if (Model.UnAuthorised.Count() == 0)
    {

#line default
#line hidden
            BeginContext(540, 104, true);
            WriteLiteral("        <div>\r\n            <br /><br />No requisitions for authorisation. <br /><br />\r\n        </div>\r\n");
            EndContext();
#line 26 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(668, 105, true);
            WriteLiteral("        <table id=\"Authorise\" class=\"table table-striped\">\r\n            <caption style=\"color:royalblue\">");
            EndContext();
            BeginContext(774, 17, false);
#line 30 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                                        Write(Model.ProductName);

#line default
#line hidden
            EndContext();
            BeginContext(791, 888, true);
            WriteLiteral(@" - For Authorisation</caption>
            <thead>
                <tr>
                    <th>
                        Transaction #
                    </th>
                    <th>
                        Payee
                    </th>
                    <th>
                        Invoice Number
                    </th>
                    <th>
                        Invoice Date
                    </th>
                    <th>
                        Requisition Date
                    </th>
                    <th>
                        Amount
                    </th>
                    <th>
                        Affected
                    </th>
                    <th>
                        Authorised
                    </th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 61 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                 foreach (var item in Model.UnAuthorised)
                {

#line default
#line hidden
            BeginContext(1757, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1842, 52, false);
#line 65 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                       Write(Html.DisplayFor(modelItem => item.TransactionNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1894, 127, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td id=\"PayeeName\" class=\"btn btn-link\">\r\n                            ");
            EndContext();
            BeginContext(2022, 45, false);
#line 68 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Payee.Name));

#line default
#line hidden
            EndContext();
            BeginContext(2067, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2159, 48, false);
#line 71 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                       Write(Html.DisplayFor(modelItem => item.InvoiceNumber));

#line default
#line hidden
            EndContext();
            BeginContext(2207, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2299, 46, false);
#line 74 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                       Write(Html.DisplayFor(modelItem => item.InvoiceDate));

#line default
#line hidden
            EndContext();
            BeginContext(2345, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2437, 50, false);
#line 77 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                       Write(Html.DisplayFor(modelItem => item.RequisitionDate));

#line default
#line hidden
            EndContext();
            BeginContext(2487, 105, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td align=\"right\">\r\n                            ");
            EndContext();
            BeginContext(2593, 41, false);
#line 80 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Amount));

#line default
#line hidden
            EndContext();
            BeginContext(2634, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2726, 48, false);
#line 83 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Affected.Name));

#line default
#line hidden
            EndContext();
            BeginContext(2774, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2866, 45, false);
#line 86 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Authorised));

#line default
#line hidden
            EndContext();
            BeginContext(2911, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(3002, 669, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5212499a9d5b2a956072f66c33dc05a1b4752eef12549", async() => {
                BeginContext(3284, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 94 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                                 if (@item.Authorised == false)
                                {

#line default
#line hidden
                BeginContext(3386, 54, true);
                WriteLiteral("                                    <p>Authorise</p>\r\n");
                EndContext();
#line 97 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                                }
                                else
                                {

#line default
#line hidden
                BeginContext(3548, 56, true);
                WriteLiteral("                                    <p>Deauthorise</p>\r\n");
                EndContext();
#line 101 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                                }

#line default
#line hidden
                BeginContext(3639, 28, true);
                WriteLiteral("                            ");
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
#line 90 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                                         WriteLiteral(Model.ProductID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 91 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                                  WriteLiteral(item.ID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 92 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                                          WriteLiteral(item.Authorised);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["authorised"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-authorised", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["authorised"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3671, 60, true);
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 105 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                }

#line default
#line hidden
            BeginContext(3750, 40, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
            EndContext();
#line 108 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
    }

#line default
#line hidden
            BeginContext(3797, 27, true);
            WriteLiteral("</div>\r\n\r\n<hr />\r\n\r\n<div>\r\n");
            EndContext();
#line 114 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
     if (Model.Authorised.Count() == 0)
    {

#line default
#line hidden
            BeginContext(3872, 97, true);
            WriteLiteral("        <div>\r\n            <br /><br />No authorised requisitions. <br /><br />\r\n        </div>\r\n");
            EndContext();
#line 119 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(3993, 90, true);
            WriteLiteral("        <table class=\"table table-striped\">\r\n            <caption style=\"color:royalblue\">");
            EndContext();
            BeginContext(4084, 17, false);
#line 123 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                                        Write(Model.ProductName);

#line default
#line hidden
            EndContext();
            BeginContext(4101, 881, true);
            WriteLiteral(@" - Authorised</caption>
            <thead>
                <tr>
                    <th>
                        Transaction #
                    </th>
                    <th>
                        Payee
                    </th>
                    <th>
                        Invoice Number
                    </th>
                    <th>
                        Invoice Date
                    </th>
                    <th>
                        Requisition Date
                    </th>
                    <th>
                        Amount
                    </th>
                    <th>
                        Affected
                    </th>
                    <th>
                        Authorised
                    </th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 154 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                 foreach (var item in Model.Authorised)
                {

#line default
#line hidden
            BeginContext(5058, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(5143, 52, false);
#line 158 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                       Write(Html.DisplayFor(modelItem => item.TransactionNumber));

#line default
#line hidden
            EndContext();
            BeginContext(5195, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(5287, 45, false);
#line 161 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Payee.Name));

#line default
#line hidden
            EndContext();
            BeginContext(5332, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(5424, 48, false);
#line 164 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                       Write(Html.DisplayFor(modelItem => item.InvoiceNumber));

#line default
#line hidden
            EndContext();
            BeginContext(5472, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(5564, 46, false);
#line 167 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                       Write(Html.DisplayFor(modelItem => item.InvoiceDate));

#line default
#line hidden
            EndContext();
            BeginContext(5610, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(5702, 50, false);
#line 170 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                       Write(Html.DisplayFor(modelItem => item.RequisitionDate));

#line default
#line hidden
            EndContext();
            BeginContext(5752, 105, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td align=\"right\">\r\n                            ");
            EndContext();
            BeginContext(5858, 41, false);
#line 173 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Amount));

#line default
#line hidden
            EndContext();
            BeginContext(5899, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(5991, 48, false);
#line 176 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Affected.Name));

#line default
#line hidden
            EndContext();
            BeginContext(6039, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(6131, 45, false);
#line 179 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Authorised));

#line default
#line hidden
            EndContext();
            BeginContext(6176, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(6267, 669, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5212499a9d5b2a956072f66c33dc05a1b4752eef23956", async() => {
                BeginContext(6549, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 187 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                                 if (@item.Authorised == false)
                                {

#line default
#line hidden
                BeginContext(6651, 54, true);
                WriteLiteral("                                    <p>Authorise</p>\r\n");
                EndContext();
#line 190 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                                }
                                else
                                {

#line default
#line hidden
                BeginContext(6813, 56, true);
                WriteLiteral("                                    <p>Deauthorise</p>\r\n");
                EndContext();
#line 194 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                                }

#line default
#line hidden
                BeginContext(6904, 28, true);
                WriteLiteral("                            ");
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
#line 183 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                                         WriteLiteral(Model.ProductID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 184 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                                  WriteLiteral(item.ID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 185 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                                          WriteLiteral(item.Authorised);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["authorised"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-authorised", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["authorised"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6936, 60, true);
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 198 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
                }

#line default
#line hidden
            BeginContext(7015, 40, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
            EndContext();
#line 201 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
    }

#line default
#line hidden
            BeginContext(7062, 37, true);
            WriteLiteral("</div>\r\n\r\n<br /><br />\r\n\r\n<div>\r\n    ");
            EndContext();
            BeginContext(7099, 154, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5212499a9d5b2a956072f66c33dc05a1b4752eef29378", async() => {
                BeginContext(7227, 22, true);
                WriteLiteral("\r\n        Return\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 209 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
          WriteLiteral(Model.ProductID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(7253, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(7283, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 216 "C:\Users\levin_m\source\repos\isas\Views\Products\Authorise.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
                BeginContext(7353, 323, true);
                WriteLiteral(@"        <link rel=""stylesheet"" href=""//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"">
        <link rel=""stylesheet"" href=""/resources/demos/style.css"">
        <script src=""https://code.jquery.com/jquery-1.12.4.js""></script>
        <script src=""https://code.jquery.com/ui/1.12.1/jquery-ui.js""></script>
        ");
                EndContext();
                BeginContext(7676, 74, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5212499a9d5b2a956072f66c33dc05a1b4752eef32802", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(7750, 1597, true);
                WriteLiteral(@"
        <script type=""text/javascript"">

            $(document).ready(function () {

                //$(""#PayeeName"").click(function () {
                //    alert(""Handler for .click() called."");
                //});

                $(""#Authorise"").find('tr').click(function () {
                    var row = $(this).find(""td:first"").text();
                    alert('You clicked ' + row);
                    $(""#dialog-message"").html(""XXXXX"");

                    $(function () {
                        $(""#dialog-message2"").dialog({
                            modal: true,
                            buttons: {
                                Ok: function () {
                                    $(this).dialog(""close"");
                                }
                            }
                        });
                    });

                    $(""#dialog-message"").dialog(
                           {
                               bgiframe: true,
               ");
                WriteLiteral(@"                autoOpen: false,
                               height: 100,
                               modal: true
                           }
                    );

                });


                $(function () {
                    $(""#dialog-message"").dialog({
                        modal: true,
                        buttons: {
                            Ok: function () {
                                $(this).dialog(""close"");
                            }
                        }
                    });
                });

");
                EndContext();
                BeginContext(11671, 38, true);
                WriteLiteral("\r\n        });\r\n        </script>\r\n    ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Isas.Models.InsurerViewModels.AuthoriseViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
