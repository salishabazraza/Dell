#pragma checksum "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Keywords\Partial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7c8cb4017a634385780f5e0ba2e0158ba2452bac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Keywords_Partial), @"mvc.1.0.view", @"/Views/Keywords/Partial.cshtml")]
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
#line 1 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\_ViewImports.cshtml"
using WebFront.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\_ViewImports.cshtml"
using WebFront.Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Keywords\Partial.cshtml"
using System.Collections.ObjectModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Keywords\Partial.cshtml"
using WebFront.Core.Helper;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c8cb4017a634385780f5e0ba2e0158ba2452bac", @"/Views/Keywords/Partial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1aab79b6528eb1298876d5349c71099ff028eb99", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Keywords_Partial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Keywords\Partial.cshtml"
  
	Layout = null;
	var result = (APISystemReturnModel<KeywordsAPIModel>)ViewBag.result;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Modal: Support start -->


<div class=""modal-header"">
	<button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
		<span aria-hidden=""true"">×</span>
	</button>
	<h4 class=""modal-title"" id=""myModalLabel2"">Keyword View Detail</h4>
</div>
<div class=""modal-body modal-text"">

	<div class=""row"">
		<div class=""col-md-12 col-sm-12 col-xs-12 text-center"">
			<br>

			<table class=""table table-bordered table-striped table-hover dt-responsive datatable-expand1 datatable-1"" cellspacing=""0"" width=""100%"">
				<thead>
					<tr>
						<th class=""col-md-2"">Keyword Name</th>
						<th class=""col-md-5"">Documents</th>
					</tr>
				</thead>
				<tbody>
					<tr>
						<td>");
#nullable restore
#line 32 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Keywords\Partial.cshtml"
                       Write(result.data.keyword.title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 33 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Keywords\Partial.cshtml"
                          
							List<string> li = new List<string>();
							string AllDocuments = "";
							foreach (var i in result.data.documents)
							{
								li.Add(i.title);
							}
							AllDocuments = string.Join(",", li);
						

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<td>");
#nullable restore
#line 42 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Keywords\Partial.cshtml"
                       Write(AllDocuments);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t</tr>\r\n\t\t\t\t</tbody>\r\n\t\t\t</table>\r\n\r\n\t\t\t<br>\r\n\t\t</div>\r\n\t</div>\r\n\r\n</div>\r\n\r\n<!-- Modal: Support end -->");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
