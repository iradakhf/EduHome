#pragma checksum "C:\Users\irade\source\repos\EduHome\EduHome\Views\Shared\_NoticePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d310c7d7353c3ca2ab612d9d5bc3fc613b66cd6f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__NoticePartial), @"mvc.1.0.view", @"/Views/Shared/_NoticePartial.cshtml")]
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
using EduHome.ViewModels.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\irade\source\repos\EduHome\EduHome\Views\_ViewImports.cshtml"
using EduHome.ViewModels.About;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d310c7d7353c3ca2ab612d9d5bc3fc613b66cd6f", @"/Views/Shared/_NoticePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0bf5770131ee9c292e31dc80bb3ec7dfa82de597", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__NoticePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<NoticeBoard>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<section class=""notice-area two three pt-140 pb-100"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-6 col-sm-6 col-xs-12"">
                <div class=""notice-right-wrapper mb-25 pb-25"">
                    <h3>TAKE A VIDEO TOUR</h3>
                    <div class=""notice-video"">
                        <div class=""video-icon video-hover"">
                            <a class=""video-popup""");
            BeginWriteAttribute("href", " href=\"", 471, "\"", 637, 1);
            WriteAttributeValue("", 478, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#nullable restore
#line 10 "C:\Users\irade\source\repos\EduHome\EduHome\Views\Shared\_NoticePartial.cshtml"
                                                          foreach (NoticeBoard notice1 in Model.Take(1))
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\irade\source\repos\EduHome\EduHome\Views\Shared\_NoticePartial.cshtml"
                           Write(notice1.VideoLink);

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\irade\source\repos\EduHome\EduHome\Views\Shared\_NoticePartial.cshtml"
                                                  
	                         }

#line default
#line hidden
#nullable disable
                PopWriter();
            }
            ), 478, 159, false);
            EndWriteAttribute();
            WriteLiteral(@">
                                <i class=""zmdi zmdi-play""></i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-md-6 col-sm-6 col-xs-12"">
                <div class=""notice-left-wrapper"">
                    <h3>notice board</h3>
                    <div class=""notice-left"">
");
#nullable restore
#line 24 "C:\Users\irade\source\repos\EduHome\EduHome\Views\Shared\_NoticePartial.cshtml"
                         foreach (NoticeBoard notice in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"single-notice-left mb-23 pb-20\">\r\n                                <h4>");
#nullable restore
#line 27 "C:\Users\irade\source\repos\EduHome\EduHome\Views\Shared\_NoticePartial.cshtml"
                               Write(notice.Date.ToString("dd, MMMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                <p>");
#nullable restore
#line 28 "C:\Users\irade\source\repos\EduHome\EduHome\Views\Shared\_NoticePartial.cshtml"
                              Write(notice.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n");
#nullable restore
#line 30 "C:\Users\irade\source\repos\EduHome\EduHome\Views\Shared\_NoticePartial.cshtml"

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<NoticeBoard>> Html { get; private set; }
    }
}
#pragma warning restore 1591
