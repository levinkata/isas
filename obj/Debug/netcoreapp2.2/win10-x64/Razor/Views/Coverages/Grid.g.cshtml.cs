#pragma checksum "C:\Dev\Isas\src\Isas\Views\Coverages\Grid.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a715c94ce51bfe9e50d8966151acb0b8f18f50c6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Coverages_Grid), @"mvc.1.0.view", @"/Views/Coverages/Grid.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Coverages/Grid.cshtml", typeof(AspNetCore.Views_Coverages_Grid))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a715c94ce51bfe9e50d8966151acb0b8f18f50c6", @"/Views/Coverages/Grid.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56b47519d9ed286534c00acb6b40cc4cb2e3d062", @"/Views/_ViewImports.cshtml")]
    public class Views_Coverages_Grid : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("update-url", "/Coverages/CellEditUpdate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("insert-url", "/Coverages/CellEditInsert", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("remove-url", "/Coverages/CellEditDelete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("adaptor", "remoteSaveAdaptor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("field", "ID", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("field", "Name", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("header-text", "Name", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("FlatGrid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Syncfusion.JavaScript.Models.GridProperties __Syncfusion_JavaScript_Models_GridProperties;
        private global::Syncfusion.JavaScript.DataSource __Syncfusion_JavaScript_DataSource;
        private global::Syncfusion.JavaScript.Models.EditSettings __Syncfusion_JavaScript_Models_EditSettings;
        private global::Syncfusion.JavaScript.GridCollectionTag __Syncfusion_JavaScript_GridCollectionTag;
        private global::Syncfusion.JavaScript.Models.Column __Syncfusion_JavaScript_Models_Column;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Dev\Isas\src\Isas\Views\Coverages\Grid.cshtml"
  
    ViewData["Title"] = "Cover Types";

#line default
#line hidden
            BeginContext(47, 80, true);
            WriteLiteral("\r\n<h2>Cover Types</h2>\r\n\r\n<span style=\"color:royalblue\">Grid / Default</span> \r\n");
            EndContext();
            BeginContext(127, 612, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("ej-grid", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a715c94ce51bfe9e50d8966151acb0b8f18f50c66342", async() => {
                BeginContext(191, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(197, 283, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("e-datamanager", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a715c94ce51bfe9e50d8966151acb0b8f18f50c66731", async() => {
                }
                );
                __Syncfusion_JavaScript_DataSource = CreateTagHelper<global::Syncfusion.JavaScript.DataSource>();
                __tagHelperExecutionContext.Add(__Syncfusion_JavaScript_DataSource);
#line 9 "C:\Dev\Isas\src\Isas\Views\Coverages\Grid.cshtml"
__Syncfusion_JavaScript_DataSource.Json = (IEnumerable<object>)ViewBag.data;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("json", __Syncfusion_JavaScript_DataSource.Json, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Syncfusion_JavaScript_DataSource.UpdateURL = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Syncfusion_JavaScript_DataSource.InsertURL = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Syncfusion_JavaScript_DataSource.RemoveURL = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Syncfusion_JavaScript_DataSource.Adaptor = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(480, 7, true);
                WriteLiteral(" \r\n    ");
                EndContext();
                BeginContext(487, 60, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("e-edit-settings", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a715c94ce51bfe9e50d8966151acb0b8f18f50c68947", async() => {
                }
                );
                __Syncfusion_JavaScript_Models_EditSettings = CreateTagHelper<global::Syncfusion.JavaScript.Models.EditSettings>();
                __tagHelperExecutionContext.Add(__Syncfusion_JavaScript_Models_EditSettings);
#line 14 "C:\Dev\Isas\src\Isas\Views\Coverages\Grid.cshtml"
__Syncfusion_JavaScript_Models_EditSettings.AllowAdding = true;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("allow-adding", __Syncfusion_JavaScript_Models_EditSettings.AllowAdding, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 14 "C:\Dev\Isas\src\Isas\Views\Coverages\Grid.cshtml"
__Syncfusion_JavaScript_Models_EditSettings.AllowEditing = true;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("allow-editing", __Syncfusion_JavaScript_Models_EditSettings.AllowEditing, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(547, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(553, 174, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("e-columns", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a715c94ce51bfe9e50d8966151acb0b8f18f50c610815", async() => {
                    BeginContext(564, 10, true);
                    WriteLiteral("\r\n        ");
                    EndContext();
                    BeginContext(574, 71, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("e-column", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a715c94ce51bfe9e50d8966151acb0b8f18f50c611231", async() => {
                    }
                    );
                    __Syncfusion_JavaScript_Models_Column = CreateTagHelper<global::Syncfusion.JavaScript.Models.Column>();
                    __tagHelperExecutionContext.Add(__Syncfusion_JavaScript_Models_Column);
                    __Syncfusion_JavaScript_Models_Column.Field = (string)__tagHelperAttribute_4.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#line 16 "C:\Dev\Isas\src\Isas\Views\Coverages\Grid.cshtml"
__Syncfusion_JavaScript_Models_Column.IsPrimaryKey = true;

#line default
#line hidden
                    __tagHelperExecutionContext.AddTagHelperAttribute("is-primary-key", __Syncfusion_JavaScript_Models_Column.IsPrimaryKey, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 16 "C:\Dev\Isas\src\Isas\Views\Coverages\Grid.cshtml"
__Syncfusion_JavaScript_Models_Column.Visible = false;

#line default
#line hidden
                    __tagHelperExecutionContext.AddTagHelperAttribute("visible", __Syncfusion_JavaScript_Models_Column.Visible, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(645, 10, true);
                    WriteLiteral("\r\n        ");
                    EndContext();
                    BeginContext(655, 54, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("e-column", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a715c94ce51bfe9e50d8966151acb0b8f18f50c613327", async() => {
                    }
                    );
                    __Syncfusion_JavaScript_Models_Column = CreateTagHelper<global::Syncfusion.JavaScript.Models.Column>();
                    __tagHelperExecutionContext.Add(__Syncfusion_JavaScript_Models_Column);
                    __Syncfusion_JavaScript_Models_Column.Field = (string)__tagHelperAttribute_5.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                    __Syncfusion_JavaScript_Models_Column.HeaderText = (string)__tagHelperAttribute_6.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(709, 6, true);
                    WriteLiteral("\r\n    ");
                    EndContext();
                }
                );
                __Syncfusion_JavaScript_GridCollectionTag = CreateTagHelper<global::Syncfusion.JavaScript.GridCollectionTag>();
                __tagHelperExecutionContext.Add(__Syncfusion_JavaScript_GridCollectionTag);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(727, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Syncfusion_JavaScript_Models_GridProperties = CreateTagHelper<global::Syncfusion.JavaScript.Models.GridProperties>();
            __tagHelperExecutionContext.Add(__Syncfusion_JavaScript_Models_GridProperties);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
#line 8 "C:\Dev\Isas\src\Isas\Views\Coverages\Grid.cshtml"
__Syncfusion_JavaScript_Models_GridProperties.AllowSorting = true;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("allow-sorting", __Syncfusion_JavaScript_Models_GridProperties.AllowSorting, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 8 "C:\Dev\Isas\src\Isas\Views\Coverages\Grid.cshtml"
__Syncfusion_JavaScript_Models_GridProperties.AllowPaging = true;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("allow-paging", __Syncfusion_JavaScript_Models_GridProperties.AllowPaging, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
