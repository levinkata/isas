#pragma checksum "C:\Dev\Isas\src\Isas\Views\Risks\RiskIncident.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2fee418b2dcc639a7b5204f159141203eabaec34"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Risks_RiskIncident), @"mvc.1.0.view", @"/Views/Risks/RiskIncident.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Risks/RiskIncident.cshtml", typeof(AspNetCore.Views_Risks_RiskIncident))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fee418b2dcc639a7b5204f159141203eabaec34", @"/Views/Risks/RiskIncident.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56b47519d9ed286534c00acb6b40cc4cb2e3d062", @"/Views/_ViewImports.cshtml")]
    public class Views_Risks_RiskIncident : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Isas.Models.InsurerViewModels.RiskIncidentViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-md-2 control-label"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height: 250px; width: 200px; overflow: auto;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(60, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Dev\Isas\src\Isas\Views\Risks\RiskIncident.cshtml"
   
    ViewBag.Title = "New Risk Incident";

#line default
#line hidden
            BeginContext(112, 94, true);
            WriteLiteral("\r\n<h2>New Risk Incident</h2>\r\n\r\n<h4>Risk Incident</h4>\r\n<hr />\r\n<div class=\"form-group\">\r\n    ");
            EndContext();
            BeginContext(206, 67, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2fee418b2dcc639a7b5204f159141203eabaec345655", async() => {
                BeginContext(261, 4, true);
                WriteLiteral("Risk");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 12 "C:\Dev\Isas\src\Isas\Views\Risks\RiskIncident.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.RiskID);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(273, 39, true);
            WriteLiteral("\r\n    <div class=\"col-md-10\">\r\n        ");
            EndContext();
            BeginContext(312, 81, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2fee418b2dcc639a7b5204f159141203eabaec347403", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#line 14 "C:\Dev\Isas\src\Isas\Views\Risks\RiskIncident.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.RiskID);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#line 14 "C:\Dev\Isas\src\Isas\Views\Risks\RiskIncident.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Model.Risks;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(393, 22, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
            EndContext();
            BeginContext(905, 49, true);
            WriteLiteral("\r\n<br /><br />\r\n<table class=\"table\">\r\n    <tr>\r\n");
            EndContext();
            BeginContext(1418, 90, true);
            WriteLiteral("        <td align=\"center\">\r\n                    Available Incidents\r\n                    ");
            EndContext();
            BeginContext(1508, 172, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2fee418b2dcc639a7b5204f159141203eabaec349777", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#line 43 "C:\Dev\Isas\src\Isas\Views\Risks\RiskIncident.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Available);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#line 44 "C:\Dev\Isas\src\Isas\Views\Risks\RiskIncident.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Model.IncidentList;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1680, 670, true);
            WriteLiteral(@"
        </td>
        <td align=""center"">
                    <br /><br /><br /><br />
                    <input type=""button"" value="">"" id=""right"" class=""btn btn-default"" style=""width: 50px;"" /><br />
                    <input type=""button"" value=""<"" id=""left"" class=""btn btn-default"" style=""width: 50px;"" /><br />
                    <input type=""button"" value="">>"" id=""rightAll"" class=""btn btn-default"" style=""width: 50px;"" /><br />
                    <input type=""button"" value=""<<"" id=""leftAll"" class=""btn btn-default"" style=""width: 50px;"" /><br />
        </td>
        <td align=""center"">
                    Assigned Incidents
                    ");
            EndContext();
            BeginContext(2350, 175, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2fee418b2dcc639a7b5204f159141203eabaec3412577", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#line 55 "C:\Dev\Isas\src\Isas\Views\Risks\RiskIncident.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Assigned);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#line 56 "C:\Dev\Isas\src\Isas\Views\Risks\RiskIncident.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Model.RiskIncidentList;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2525, 53, true);
            WriteLiteral("\r\n        </td>\r\n    </tr>\r\n\r\n</table>\r\n\r\n<div>\r\n    ");
            EndContext();
            BeginContext(2578, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2fee418b2dcc639a7b5204f159141203eabaec3414731", async() => {
                BeginContext(2621, 6, true);
                WriteLiteral("Return");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2631, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2661, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 67 "C:\Dev\Isas\src\Isas\Views\Risks\RiskIncident.cshtml"
       await Html.RenderPartialAsync("_ValidationScriptsPartial"); 

#line default
#line hidden
                BeginContext(2733, 4, true);
                WriteLiteral("    ");
                EndContext();
                BeginContext(2815, 819, true);
                WriteLiteral(@"
    <script type=""text/javascript"">

        //function onchange(args) {
        //    var currentRiskId = args.value

        //    var dataManager = ej.DataManager({
        //        //OData service
        //        url: ""/Risks/FillListBoxes?$riskid='"" + currentRiskId + ""'""
        //    });

        //    // create query
        //    var query = ej.Query().from(""incidents"");
        //    $('#incidents').ejListBox({
        //        dataSource: dataManager,
        //        fields: { value: ""id"", text: ""name"" },
        //        query: query
        //    });
        //};

        $(document).ready(function () {

            $('#RiskID').on('change', function () {
                var selectedRiskId = $(""#RiskID"").val();

                $.ajax({
                    url: '");
                EndContext();
                BeginContext(3636, 27, false);
#line 94 "C:\Dev\Isas\src\Isas\Views\Risks\RiskIncident.cshtml"
                      Write(Url.Action("FillListBoxes"));

#line default
#line hidden
                EndContext();
                BeginContext(3664, 1200, true);
                WriteLiteral(@"',
                    type: 'POST',
                    dataType: 'JSON',
                    data: { riskid: selectedRiskId },
                    success: function (data) {
                        $('#Assigned').empty();   // clear before appending new list
                        $('#Available').empty();   // clear before appending new list

                        $.each(data.riskincidents, function (index, value) {
                            $('#Assigned').append($('<option></option>').val(value.value).html(value.text));
                        });

                        $.each(data.incidents, function (index, value) {
                            $('#Available').append($('<option></option>').val(value.id).html(value.name));
                        });
                    }
                });

            });

            $('#right').on('click', function () {
                var itemsSelected = [];
                var riskSelected = $('#RiskID').val();

                $('#Ava");
                WriteLiteral("ilable option:selected\').each(function () {\r\n                    itemsSelected.push($(this).val());\r\n                });\r\n\r\n                $.ajax({\r\n                    url: \'");
                EndContext();
                BeginContext(4866, 30, false);
#line 123 "C:\Dev\Isas\src\Isas\Views\Risks\RiskIncident.cshtml"
                      Write(Url.Action("AddRiskIncidents"));

#line default
#line hidden
                EndContext();
                BeginContext(4897, 1221, true);
                WriteLiteral(@"',
                    type: 'POST',
                    dataType: 'JSON',
                    data: { riskId: riskSelected, incidents: itemsSelected },
                    success: function (data) {
                        $('#Assigned').empty();   // clear before appending new list
                        $('#Available').empty();   // clear before appending new list

                        $.each(data.updatedriskincidents, function (index, value) {
                            $('#Assigned').append($('<option></option>').val(value.value).html(value.text));
                        });

                        $.each(data.updatedincidents, function (index, value) {
                            $('#Available').append($('<option></option>').val(value.id).html(value.name));
                        });
                    }
                });

            })

            $('#rightAll').on('click', function () {
                var itemsAll = [];
                var riskSelected = $('#RiskID'");
                WriteLiteral(").val();\r\n\r\n                $(\'#Available option\').each(function () {\r\n                    itemsAll.push($(this).val());\r\n                });\r\n\r\n                $.ajax({\r\n                    url: \'");
                EndContext();
                BeginContext(6120, 30, false);
#line 152 "C:\Dev\Isas\src\Isas\Views\Risks\RiskIncident.cshtml"
                      Write(Url.Action("AddRiskIncidents"));

#line default
#line hidden
                EndContext();
                BeginContext(6151, 1230, true);
                WriteLiteral(@"',
                    type: 'POST',
                    dataType: 'JSON',
                    data: { riskId: riskSelected, incidents: itemsAll },
                    success: function (data) {
                        $('#Assigned').empty();   // clear before appending new list
                        $('#Available').empty();   // clear before appending new list

                        $.each(data.updatedriskincidents, function (index, value) {
                            $('#Assigned').append($('<option></option>').val(value.value).html(value.text));
                        });

                        $.each(data.updatedincidents, function (index, value) {
                            $('#Available').append($('<option></option>').val(value.id).html(value.name));
                        });
                    }
                });

            })

            $('#left').on('click', function () {
                var itemsSelected = [];
                var riskSelected = $('#RiskID').va");
                WriteLiteral("l();\r\n\r\n                $(\'#Assigned option:selected\').each(function () {\r\n                    itemsSelected.push($(this).val());\r\n                });\r\n\r\n                $.ajax({\r\n                    url: \'");
                EndContext();
                BeginContext(7383, 33, false);
#line 181 "C:\Dev\Isas\src\Isas\Views\Risks\RiskIncident.cshtml"
                      Write(Url.Action("RemoveRiskIncidents"));

#line default
#line hidden
                EndContext();
                BeginContext(7417, 1219, true);
                WriteLiteral(@"',
                    type: 'POST',
                    dataType: 'JSON',
                    data: { riskId: riskSelected, incidents: itemsSelected },
                    success: function (data) {
                        $('#Assigned').empty();   // clear before appending new list
                        $('#Available').empty();   // clear before appending new list

                        $.each(data.updatedriskincidents, function (index, value) {
                            $('#Assigned').append($('<option></option>').val(value.value).html(value.text));
                        });

                        $.each(data.updatedincidents, function (index, value) {
                            $('#Available').append($('<option></option>').val(value.id).html(value.name));
                        });
                    }
                });

            })

            $('#leftAll').on('click', function () {
                var itemsAll = [];
                var riskSelected = $('#RiskID')");
                WriteLiteral(".val();\r\n\r\n                $(\'#Assigned option\').each(function () {\r\n                    itemsAll.push($(this).val());\r\n                });\r\n\r\n                $.ajax({\r\n                    url: \'");
                EndContext();
                BeginContext(8638, 33, false);
#line 210 "C:\Dev\Isas\src\Isas\Views\Risks\RiskIncident.cshtml"
                      Write(Url.Action("RemoveRiskIncidents"));

#line default
#line hidden
                EndContext();
                BeginContext(8672, 910, true);
                WriteLiteral(@"',
                    type: 'POST',
                    dataType: 'JSON',
                    data: { riskId: riskSelected, incidents: itemsAll },
                    success: function (data) {
                        $('#Assigned').empty();   // clear before appending new list
                        $('#Available').empty();   // clear before appending new list

                        $.each(data.updatedriskincidents, function (index, value) {
                            $('#Assigned').append($('<option></option>').val(value.value).html(value.text));
                        });

                        $.each(data.updatedincidents, function (index, value) {
                            $('#Available').append($('<option></option>').val(value.id).html(value.name));
                        });
                    }
                });

            });
        });
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Isas.Models.InsurerViewModels.RiskIncidentViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
