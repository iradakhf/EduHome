#pragma checksum "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Teacher\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55bcfac0fd013b0ab16a40a288853efdd278d96f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teacher_Index), @"mvc.1.0.view", @"/Views/Teacher/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55bcfac0fd013b0ab16a40a288853efdd278d96f", @"/Views/Teacher/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03e784a6113a90c557e96cd9818916d58a6d6365", @"/Views/_ViewImports.cshtml")]
    public class Views_Teacher_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TeacherVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Teacher\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- Banner Area Start -->\r\n");
#nullable restore
#line 7 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Teacher\Index.cshtml"
Write(await Html.PartialAsync("_BannerPartial", "our teachers"));

#line default
#line hidden
#nullable disable
            WriteLiteral(")\r\n<!-- Banner Area End -->\r\n<!-- Teacher Start -->\r\n");
#nullable restore
#line 10 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Teacher\Index.cshtml"
Write(await Component.InvokeAsync("Teacher"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- Teacher End -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TeacherVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
