#pragma checksum "C:\Users\irade\source\repos\EduHome\EduHome\Views\Contact\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e81c2a76fa28e7d4b1a7a820e09cf39c66bba2a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contact_Index), @"mvc.1.0.view", @"/Views/Contact/Index.cshtml")]
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
#line 2 "C:\Users\irade\source\repos\EduHome\EduHome\Views\_ViewImports.cshtml"
using EduHome.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\irade\source\repos\EduHome\EduHome\Views\_ViewImports.cshtml"
using EduHome.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\irade\source\repos\EduHome\EduHome\Views\_ViewImports.cshtml"
using EduHome.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\irade\source\repos\EduHome\EduHome\Views\_ViewImports.cshtml"
using EduHome.ViewModels.CourseV;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\irade\source\repos\EduHome\EduHome\Views\_ViewImports.cshtml"
using EduHome.ViewModels.TeacherV;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e81c2a76fa28e7d4b1a7a820e09cf39c66bba2a8", @"/Views/Contact/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ced9a56986c14ae55d1ea705227f90140542bac", @"/Views/_ViewImports.cshtml")]
    public class Views_Contact_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Settings>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/contact/contact1.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("contact"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/contact/contact2.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/contact/contact3.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\irade\source\repos\EduHome\EduHome\Views\Contact\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- Banner Area Start -->\r\n");
#nullable restore
#line 7 "C:\Users\irade\source\repos\EduHome\EduHome\Views\Contact\Index.cshtml"
Write(await Html.PartialAsync("_BannerPartial", "contact"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@")
<!-- Banner Area End -->
<!-- Contact Start -->
<div class=""map-area"">
    <!-- google-map-area start -->
    <div class=""google-map-area"">
        <!--  Map Section -->
        <div id=""contacts"" class=""map-area"">
            <div id=""googleMap"" style=""width:100%;height:440px;""></div>
        </div>
    </div>
</div>
<div class=""contact-area pt-150 pb-140"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-5 col-sm-5 col-xs-12"">
                <div class=""contact-contents text-center"">
                    <div class=""single-contact mb-65"">
                        <div class=""contact-icon"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e81c2a76fa28e7d4b1a7a820e09cf39c66bba2a86247", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"contact-add\">\r\n                            <h3>address</h3>\r\n                            <p>");
#nullable restore
#line 30 "C:\Users\irade\source\repos\EduHome\EduHome\Views\Contact\Index.cshtml"
                          Write(Html.Raw(Model.FirstOrDefault(s => s.Key == "Address").Value));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"single-contact mb-65\">\r\n                        <div class=\"contact-icon\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e81c2a76fa28e7d4b1a7a820e09cf39c66bba2a88025", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"contact-add\">\r\n                            <h3>Phone</h3>\r\n                            <p>");
#nullable restore
#line 39 "C:\Users\irade\source\repos\EduHome\EduHome\Views\Contact\Index.cshtml"
                          Write(Model.FirstOrDefault(s => s.Key == "CallCenter").Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"single-contact\">\r\n                        <div class=\"contact-icon\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e81c2a76fa28e7d4b1a7a820e09cf39c66bba2a89788", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"contact-add\">\r\n                            <h3>address</h3>\r\n                            <p>");
#nullable restore
#line 48 "C:\Users\irade\source\repos\EduHome\EduHome\Views\Contact\Index.cshtml"
                          Write(Model.FirstOrDefault(s => s.Key == "Email").Value);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>

                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-md-7 col-sm-7 col-xs-12"">
                <div class=""reply-area"">
                    <h3>LEAVE A message</h3>
                    ");
#nullable restore
#line 57 "C:\Users\irade\source\repos\EduHome\EduHome\Views\Contact\Index.cshtml"
                Write(await Html.PartialAsync("_LeaveReplyPartial"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<!-- Contact End -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Settings>> Html { get; private set; }
    }
}
#pragma warning restore 1591
