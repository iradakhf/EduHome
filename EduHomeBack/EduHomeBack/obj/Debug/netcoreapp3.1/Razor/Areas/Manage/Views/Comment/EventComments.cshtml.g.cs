#pragma checksum "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Comment\EventComments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "643f6842d69b80485d569d7f2d722f98e59fa91c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Comment_EventComments), @"mvc.1.0.view", @"/Areas/Manage/Views/Comment/EventComments.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"643f6842d69b80485d569d7f2d722f98e59fa91c", @"/Areas/Manage/Views/Comment/EventComments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50c1b1bcfa56fe33a8615c663fd131f39f306a41", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Comment_EventComments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Comment>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Comment\EventComments.cshtml"
  
    ViewData["Title"] = "BlogComments";
    int counter = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row justify-content-between"">
    <div class=""col-lg-2"">
        <h1 class=""h3 mb-4 text-gray-800"">Blog Comments</h1>
    </div>

</div>
<div class=""row"">
    <div class=""col-lg-12"">
        <table class=""table table-bordered table-striped"">
            <thead>
                <tr>
                    <th>
                        N:
                    </th>
                    <th>
                        Name
                    </th>
                    <th>
                        Email
                    </th>
                    <th>
                        Subject
                    </th>
                    <th>
                        Message
                    </th>
                    <th>
                        Created at
                    </th>

                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 40 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Comment\EventComments.cshtml"
                 foreach (Comment comment in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 44 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Comment\EventComments.cshtml"
                       Write(counter);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n                            ");
#nullable restore
#line 48 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Comment\EventComments.cshtml"
                       Write(comment.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 51 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Comment\EventComments.cshtml"
                       Write(comment.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 54 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Comment\EventComments.cshtml"
                       Write(comment.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 57 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Comment\EventComments.cshtml"
                       Write(comment.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 60 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Comment\EventComments.cshtml"
                       Write(comment.CreatedAt?.ToString("dd/mm/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 63 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Areas\Manage\Views\Comment\EventComments.cshtml"
                    counter++;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Comment>> Html { get; private set; }
    }
}
#pragma warning restore 1591
