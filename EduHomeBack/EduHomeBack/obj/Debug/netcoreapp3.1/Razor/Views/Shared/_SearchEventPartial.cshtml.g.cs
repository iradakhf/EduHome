#pragma checksum "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Shared\_SearchEventPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38414697ccd8b572896bad7e0d5cd9e234571e25"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__SearchEventPartial), @"mvc.1.0.view", @"/Views/Shared/_SearchEventPartial.cshtml")]
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
#line 2 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\_ViewImports.cshtml"
using EduHomeBack.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\_ViewImports.cshtml"
using EduHomeBack.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\_ViewImports.cshtml"
using EduHomeBack.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\_ViewImports.cshtml"
using EduHomeBack.ViewModels.CourseV;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\_ViewImports.cshtml"
using EduHomeBack.ViewModels.TeacherV;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\_ViewImports.cshtml"
using EduHomeBack.ViewModels.BlogV;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\_ViewImports.cshtml"
using EduHomeBack.ViewComponentModel.NoticeArea;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\_ViewImports.cshtml"
using EduHomeBack.ViewModels.EventV;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\_ViewImports.cshtml"
using EduHomeBack.ViewModels.AccountV;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38414697ccd8b572896bad7e0d5cd9e234571e25", @"/Views/Shared/_SearchEventPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"503ce10e2f742d5be5bdf71befc44bc56dc583ec", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__SearchEventPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EventVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Alternate Text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Shared\_SearchEventPartial.cshtml"
 foreach (EventVM eventVM in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li width=\"50\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "38414697ccd8b572896bad7e0d5cd9e234571e255536", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 120, "~/img/event/", 120, 12, true);
#nullable restore
#line 5 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Shared\_SearchEventPartial.cshtml"
AddHtmlAttributeValue("", 132, eventVM.Image, 132, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <a href=\"#\">");
#nullable restore
#line 6 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Shared\_SearchEventPartial.cshtml"
               Write(eventVM.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n    </li>\r\n");
#nullable restore
#line 8 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Shared\_SearchEventPartial.cshtml"

}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EventVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
