#pragma checksum "D:\Repositorios\projeto financeiro\projeto financeiro\Views\Pessoa\Planilha.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "35c07161e8300569faef80170c2920bca7c18817"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pessoa_Planilha), @"mvc.1.0.view", @"/Views/Pessoa/Planilha.cshtml")]
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
#line 1 "D:\Repositorios\projeto financeiro\projeto financeiro\Views\_ViewImports.cshtml"
using projeto_financeiro;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Repositorios\projeto financeiro\projeto financeiro\Views\_ViewImports.cshtml"
using projeto_financeiro.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35c07161e8300569faef80170c2920bca7c18817", @"/Views/Pessoa/Planilha.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da2883c15518455f1cde3107fa271a53fb681f73", @"/Views/_ViewImports.cshtml")]
    public class Views_Pessoa_Planilha : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<projeto_financeiro.Models.Pessoa.Planilha>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<div asp-action=\"Copiar\" class=\"row justify-content-center\">\r\n   \r\n    <div class=\"row justify-content-center\">\r\n        <table class=\"table table-success table-striped table-hover col-md-6\">\r\n            <thead>\r\n                <tr>\r\n\r\n");
            WriteLiteral("                    <th scope=\"col\">\r\n                        Chave NFE\r\n                    </th>\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody >\r\n");
#nullable restore
#line 21 "D:\Repositorios\projeto financeiro\projeto financeiro\Views\Pessoa\Planilha.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n");
            WriteLiteral("                        <td>\r\n                            ");
#nullable restore
#line 29 "D:\Repositorios\projeto financeiro\projeto financeiro\Views\Pessoa\Planilha.cshtml"
                       Write(Html.DisplayFor(modelItem => item.idnfe));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 32 "D:\Repositorios\projeto financeiro\projeto financeiro\Views\Pessoa\Planilha.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n           \r\n        </table>\r\n       \r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<projeto_financeiro.Models.Pessoa.Planilha>> Html { get; private set; }
    }
}
#pragma warning restore 1591