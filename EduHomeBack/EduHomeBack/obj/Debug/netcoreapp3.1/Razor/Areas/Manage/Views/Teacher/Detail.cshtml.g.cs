#pragma checksum "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aaf0475f9dfeadeba4f78764243ad711858407b4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Teacher_Detail), @"mvc.1.0.view", @"/Areas/Manage/Views/Teacher/Detail.cshtml")]
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
#line 2 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\_ViewImports.cshtml"
using EduHomeBack.Areas.Manage.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\_ViewImports.cshtml"
using EduHomeBack.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\_ViewImports.cshtml"
using EduHomeBack.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\_ViewImports.cshtml"
using EduHomeBack.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\_ViewImports.cshtml"
using EduHomeBack.ViewModels.CourseV;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\_ViewImports.cshtml"
using EduHomeBack.ViewModels.TeacherV;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\_ViewImports.cshtml"
using EduHomeBack.Areas.Manage.ViewModels.Account;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aaf0475f9dfeadeba4f78764243ad711858407b4", @"/Areas/Manage/Views/Teacher/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50c1b1bcfa56fe33a8615c663fd131f39f306a41", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Teacher_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Teacher>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
  
    ViewData["Title"] = "Detail";
    int counter = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1 class=""h3 mb-4 text-gray-800""> Teacher Detail</h1>
<div class=""row"">
    <div class=""col-lg-12"">
        <table class=""table table-bordered table-striped"">
            <thead>
                <tr>
                    <th>
                        Image
                    </th>

                    <th>
                        FullName
                    </th>

                    <th>
                        About
                    </th>
                    <th>Info</th>
                    <th>
                        Position
                    </th>
                    <th>
                        Skills
                    </th>
                    <th>
                        Tags
                    </th>
                </tr>
            </thead>
            <tbody>

                <tr>
                    <td>
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "aaf0475f9dfeadeba4f78764243ad711858407b45785", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1000, "~/img/teacher/", 1000, 14, true);
#nullable restore
#line 40 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
AddHtmlAttributeValue("", 1014, Model.Image, 1014, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 44 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
                   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span>  </span>  ");
#nullable restore
#line 44 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
                                                Write(Model.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                      ");
#nullable restore
#line 47 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
                 Write(Model.About);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        \r\n                        Degree:  ");
#nullable restore
#line 51 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
                            Write(Model.Degree);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <br>\r\n                        Faculty: ");
#nullable restore
#line 53 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
                            Write(Model.Faculty);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <br>\r\n                        Experience :  ");
#nullable restore
#line 55 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
                                 Write(Model.Experience);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <br>\r\n                        Hobbies: ");
#nullable restore
#line 57 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
                            Write(Model.Hobbies);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <br>\r\n                        Email : ");
#nullable restore
#line 59 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
                           Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <br>\r\n                        Phone : ");
#nullable restore
#line 61 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
                           Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <br>\r\n                        Skype :  ");
#nullable restore
#line 63 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
                            Write(Model.Skype);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <br>\r\n                        Facebook : ");
#nullable restore
#line 65 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
                              Write(Model.FacebookUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <br>\r\n                        Twitter :  ");
#nullable restore
#line 67 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
                              Write(Model.TwitterUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <br>\r\n                        V :  ");
#nullable restore
#line 69 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
                        Write(Model.VUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 72 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
                   Write(Model.Position.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 75 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
                         foreach (TeacherSkill TeacherSkill in Model.TeacherSkills)
                        {

                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 78 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
                       Write(TeacherSkill.Skill.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <br>\r\n");
#nullable restore
#line 80 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 84 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
                         foreach (Course course in Model.Courses)
                        {

                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 87 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
                       Write(course.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <br>\r\n");
#nullable restore
#line 89 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n\r\n                </tr>\r\n\r\n            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n</div>\r\n");
            DefineSection("script", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 101 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Teacher\Detail.cshtml"
Write(await Html.PartialAsync("_ValidationPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Teacher> Html { get; private set; }
    }
}
#pragma warning restore 1591
