#pragma checksum "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dac6d6274651a50764061dd03393b6aa083d6bbe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Course_Detail), @"mvc.1.0.view", @"/Views/Course/Detail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dac6d6274651a50764061dd03393b6aa083d6bbe", @"/Views/Course/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03e784a6113a90c557e96cd9818916d58a6d6365", @"/Views/_ViewImports.cshtml")]
    public class Views_Course_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CourseVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("courses-details"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("post"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "blog", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mr-10 mb-10"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
  
    ViewData["Title"] = "Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- Banner Area Start -->\r\n");
#nullable restore
#line 7 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
Write(await Html.PartialAsync("_BannerPartial", "course detail"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Banner Area End -->
<!-- Blog Start -->
<div class=""courses-details-area blog-area pt-150 pb-140"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-8"">
                <div class=""courses-details"">
                    <div class=""courses-details-img"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "dac6d6274651a50764061dd03393b6aa083d6bbe8586", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 500, "~/img/course/", 500, 13, true);
#nullable restore
#line 16 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
AddHtmlAttributeValue("", 513, Model.Course.Image, 513, 19, false);

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
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"course-details-content\">\r\n                        <h2>");
#nullable restore
#line 19 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                       Write(Model.Course.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                        <p>");
#nullable restore
#line 20 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                      Write(Model.Course.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <div class=\"course-details-left\">\r\n                            <div class=\"single-course-left\">\r\n                                <h3>about course</h3>\r\n                                <p>");
#nullable restore
#line 24 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                              Write(Model.Course.About);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"single-course-left\">\r\n                                <h3>how to apply</h3>\r\n                                <p>");
#nullable restore
#line 28 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                              Write(Model.Course.HowToApply);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"single-course-left\">\r\n                                <h3>certification</h3>\r\n                                <p class=\"margin\">");
#nullable restore
#line 32 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                                             Write(Model.Course.Certification);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            </div>
                        </div>
                        <div class=""course-details-right"">
                            <h3>COURSE FEATURES</h3>
                            <ul>
                                <li>starts <span>");
#nullable restore
#line 38 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                                            Write(Model.Course.Starts?.ToString("dd  MMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n                                <li>duration <span>");
#nullable restore
#line 39 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                                              Write(Model.Course.Duration);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n                                <li>class duration <span>");
#nullable restore
#line 40 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                                                    Write(Model.Course.ClassDuration);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n                                <li>skill level <span>");
#nullable restore
#line 41 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                                                 Write(Model.Course.SkillLevel);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n                                <li>language <span>");
#nullable restore
#line 42 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                                              Write(Model.Course.Language);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n                                <li>students <span>");
#nullable restore
#line 43 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                                              Write(Model.Course.StudentsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n                                <li>assesments <span>");
#nullable restore
#line 44 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                                                Write(Model.Course.Assesments);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n                            </ul>\r\n                            <h3 class=\"red\">course fee $");
#nullable restore
#line 46 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                                                   Write(Model.Course.Fee);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"reply-area\">\r\n                        <h3>LEAVE A REPLY</h3>\r\n                     ");
#nullable restore
#line 51 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                 Write(await Html.PartialAsync("_LeaveReplyPartial"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                </div>
            </div>
            <div class=""col-md-4"">
                 <div class=""blog-sidebar right"">
                    <div class=""single-blog-widget mb-47"">
                        <h3>search</h3>
                        <div class=""blog-search"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dac6d6274651a50764061dd03393b6aa083d6bbe16155", async() => {
                WriteLiteral(@"
                                <input id=""InputCourse"" type=""search"" placeholder=""Search..."" name=""search"" />
                                <button id=""ButtonCourse"" type=""submit"">
                                    <span><i class=""fa fa-search""></i></span>
                                </button>
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                               <ul id=""ListCourse"" style=""border: 1px solid; background-color:white; text-decoration:none; width: 100%; height: auto; position: absolute; z-index: 18;"">
                                </ul>
                        </div>
                    </div>
                    <div class=""single-blog-widget mb-47"">
                        <h3>categories</h3>
                        <ul>
");
#nullable restore
#line 73 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                             foreach (Category category in Model.Categories.Take(6))
                            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li><a href=\"#\">");
#nullable restore
#line 76 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                                       Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 76 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                                                       Write(category.Courses.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(")</a></li>\r\n");
#nullable restore
#line 77 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                         \r\n                        </ul>\r\n                    </div>\r\n                   \r\n                  ");
#nullable restore
#line 82 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
             Write(await Component.InvokeAsync("BlogBanner"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    <div class=\"single-blog-widget mb-47\">\r\n                        <h3>latest post</h3>\r\n                        <div class=\"single-post mb-30\">\r\n");
#nullable restore
#line 87 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                             foreach (Blog blog in Model.Blogs.Take(3))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"single-post-img\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dac6d6274651a50764061dd03393b6aa083d6bbe20439", async() => {
                WriteLiteral("\r\n                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "dac6d6274651a50764061dd03393b6aa083d6bbe20735", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 4710, "~/img/blog/", 4710, 11, true);
#nullable restore
#line 91 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
AddHtmlAttributeValue("", 4721, blog.Image, 4721, 11, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                        <div class=\"blog-hover\">\r\n                                            <i class=\"fa fa-link\"></i>\r\n                                        </div>\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 90 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                                                                                   WriteLiteral(blog.Id);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n                                </div>\r\n");
            WriteLiteral("                                <div class=\"single-post-content\">\r\n                                    <h4>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dac6d6274651a50764061dd03393b6aa083d6bbe25019", async() => {
                WriteLiteral("English Language Course for you");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 99 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                                                                                       WriteLiteral(blog.Id);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("</h4>\r\n                                    <p>By ");
#nullable restore
#line 100 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                                     Write(blog.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("  / ");
#nullable restore
#line 100 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                                                     Write(blog.Date.ToString("MMMM dd, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                </div>\r\n");
#nullable restore
#line 102 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n\r\n                        \r\n                    </div>\r\n                    <div class=\"single-blog-widget\">\r\n                        <h3>tags</h3>\r\n                        <div class=\"single-tag\">\r\n");
#nullable restore
#line 110 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                             foreach (Tag tag in Model.Tags)
                            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dac6d6274651a50764061dd03393b6aa083d6bbe28894", async() => {
#nullable restore
#line 113 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                                                                                                               Write(tag.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 113 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                                                                           WriteLiteral(tag.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 114 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Course\Detail.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                      \r\n                          \r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<!-- Blog End -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CourseVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
