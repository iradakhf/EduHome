#pragma checksum "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Shared\Components\Slider\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab10193aa8c2dcaa4831d4f62afae376092e9fcf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Slider_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Slider/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab10193aa8c2dcaa4831d4f62afae376092e9fcf", @"/Views/Shared/Components/Slider/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03e784a6113a90c557e96cd9818916d58a6d6365", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Slider_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Slider>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Shared\Components\Slider\Default.cshtml"
 foreach (Slider item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <!-- Start Slingle Slide -->\r\n    <div class=\"single-slide item\"");
            BeginWriteAttribute("style", " style=\"", 134, "\"", 187, 4);
            WriteAttributeValue("", 142, "background-image:", 142, 17, true);
            WriteAttributeValue(" ", 159, "url(img/slider/", 160, 16, true);
#nullable restore
#line 6 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Shared\Components\Slider\Default.cshtml"
WriteAttributeValue("", 175, item.Image, 175, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 186, ")", 186, 1, true);
            EndWriteAttribute();
            WriteLiteral(@">
        <!-- Start Slider Content -->
        <div class=""slider-content-area"">
            <div class=""container"">
                <div class=""row"">
                    <div class=""col-md-10 col-md-offset-1"">
                        <div class=""slide-content-wrapper"">
                            <div class=""slide-content text-center"">
                                <h2>");
#nullable restore
#line 14 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Shared\Components\Slider\Default.cshtml"
                               Write(Html.Raw(item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h2>\r\n                                <p>");
#nullable restore
#line 15 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Shared\Components\Slider\Default.cshtml"
                              Write(Html.Raw(item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <a class=\"default-btn\" ");
#nullable restore
#line 16 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Shared\Components\Slider\Default.cshtml"
                                                  Write(item.Link);

#line default
#line hidden
#nullable disable
            WriteLiteral(@">Learn more</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Start Slider Content -->
    </div>
    <!-- End Slingle Slide -->
");
#nullable restore
#line 26 "C:\Users\irade\Desktop\EduHome\EduHomeBack\EduHomeBack\Views\Shared\Components\Slider\Default.cshtml"

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Slider>> Html { get; private set; }
    }
}
#pragma warning restore 1591
