#pragma checksum "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Documents\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b3c67ae693ef6c1b98a3ec01aa1f78ce743a82bf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Documents_Index), @"mvc.1.0.view", @"/Views/Documents/Index.cshtml")]
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
#line 1 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Documents\Index.cshtml"
using System.Collections.ObjectModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Documents\Index.cshtml"
using WebFront.Core.Helper;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b3c67ae693ef6c1b98a3ec01aa1f78ce743a82bf", @"/Views/Documents/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1aab79b6528eb1298876d5349c71099ff028eb99", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Documents_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Documents\Index.cshtml"
  
	/**/

	ViewBag.Title = "Documents";
	Layout = "~/Views/Shared/dashboardLayout.cshtml";
	var Keywords = (APISystemReturnModel<ObservableCollection<KeywordsAPIModel>>)ViewBag.Keywords;
	var result= (APISystemReturnModel<ObservableCollection<DocumentAPIModel>>)ViewBag.result;
	var keywordIdSearch = (int[])ViewBag.keywordIdSearch;

#line default
#line hidden
#nullable disable
            DefineSection("CustomHeader", async() => {
                WriteLiteral("\r\n\t<link href=\"https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css\" rel=\"stylesheet\" />\r\n");
            }
            );
            WriteLiteral("<!-- page content -->\r\n<div class=\"right_col\" role=\"main\">\r\n\t\r\n     ");
#nullable restore
#line 18 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Documents\Index.cshtml"
Write(Html.Raw(@ViewBag.Alert));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" 

	<div class=""row"">
		<div class=""col-md-12 col-sm-12 col-xs-12"">
			<div class=""x_panel"">
				<div class=""x_title"">
					<h3>Documents List</h3>
					<ul class=""nav navbar-right panel_toolbox"">
						<li>
							<a class=""collapse-link""><i class=""fa fa-chevron-up""></i></a>
						</li>
					</ul>


					<div class=""clearfix""></div>

				</div>
				<div class=""x_content"">

");
#nullable restore
#line 37 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Documents\Index.cshtml"
                     using (Html.BeginForm("index", "documents", FormMethod.Get, null))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""mb-20"">
                                <div class=""row"">
                                
                                    <div class=""col-lg-3 col-md-4 col-sm-6 col-xs-12 mb-10"">
                                        <div class=""form-group"">
                                            <label class=""control-label col-lg-12 col-md-12 col-sm-12 col-xs-12 "">Document Name</label>
                                            <div class=""clearfix""></div>
                                            <div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12 "">
                                            
												<select class=""js-example-basic-multiple form-control"" name=""keywordId"" multiple=""multiple"">
");
#nullable restore
#line 49 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Documents\Index.cshtml"
                                                              
																List<int> ids = new List<int>();
																foreach (var i in keywordIdSearch)
																{
																	ids.Add(i);
																}

																foreach (var i in Keywords.data)
																{
																	if (ids.Contains(i.keyword.keywordId))
																	{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b3c67ae693ef6c1b98a3ec01aa1f78ce743a82bf6583", async() => {
#nullable restore
#line 60 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Documents\Index.cshtml"
                                                                                                                     Write(i.keyword.title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 60 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Documents\Index.cshtml"
                                                                                        WriteLiteral(i.keyword.keywordId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 61 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Documents\Index.cshtml"
																	}else
																	{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b3c67ae693ef6c1b98a3ec01aa1f78ce743a82bf9085", async() => {
#nullable restore
#line 63 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Documents\Index.cshtml"
                                                                                                            Write(i.keyword.title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 63 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Documents\Index.cshtml"
                                                                               WriteLiteral(i.keyword.keywordId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 64 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Documents\Index.cshtml"
																	}
																	
																}
															

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
														</select>
											
											</div>
                                        </div>
                                    </div>
                                    <div class=""clearfix""></div>

                                    
                                </div>

                                <div class=""row text-right"">
                                    <div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12"">
                                        <div class=""form-group"">
                                            <div class=""col-md-12 col-sm-12 col-xs-12 mt-10"">
                                                <button type=""submit"" class=""btn btn-primary"">Search</button>
");
            WriteLiteral("                                            </div>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 90 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Documents\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""ln_solid""></div>

					<div>
						<table class=""table table-bordered table-striped table-hover dt-responsive datatable-expand1 datatable-1"" cellspacing=""0"" width=""100%"">
							<thead>
								<tr>
									<th class=""col-md-2"">Document Name</th>
									<th class=""col-md-5"">Url</th>
									<th class=""col-md-2 text-right"">Actions</th>

								</tr>
							</thead>
							<tbody>
");
#nullable restore
#line 104 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Documents\Index.cshtml"
                                  
									foreach (var i in result.data)
									{
										
									

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t<tr>\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t<td>");
#nullable restore
#line 111 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Documents\Index.cshtml"
                                           Write(i.document.title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n\t\t\t\t\t\t\t\t\t\t\t<td><a");
            BeginWriteAttribute("href", " href=\"", 4260, "\"", 4285, 1);
#nullable restore
#line 112 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Documents\Index.cshtml"
WriteAttributeValue("", 4267, i.document.docURL, 4267, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_self\">");
#nullable restore
#line 112 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Documents\Index.cshtml"
                                                                                       Write(i.document.docURL);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t<td class=\"text-right\">\r\n\t\t\t\t\t\t\t\t\t\t\t<input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 4400, "\"", 4430, 1);
#nullable restore
#line 115 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Documents\Index.cshtml"
WriteAttributeValue("", 4408, i.document.documentId, 4408, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"documentId\" class=\"documentId\" />\r\n\t\t\t\t\t\t\t\t\t\t\t<a href=\"javascript: void();\" class=\"btntest\" data-toggle=\"modal\" data-target=\".supported-modal\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<i class=\"fas fa-question-circle\"></i>\r\n\t\t\t\t\t\t\t\t\t\t\t\t</a>\r\n\t\t\t\t\t\t\t\t\t\t\t\t<a");
            BeginWriteAttribute("href", " href=\"", 4668, "\"", 4775, 1);
#nullable restore
#line 119 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Documents\Index.cshtml"
WriteAttributeValue("", 4675, Url.Action("Edit","Documents",new {documentId=i.document.documentId,documentName=i.document.title}), 4675, 100, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info btn-xs\"><i class=\"fas fa-edit\"></i></a>\r\n\t\t\t\t\t\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t\t\t\t\t</tr>\r\n");
#nullable restore
#line 122 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Documents\Index.cshtml"
									}
								

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
							</tbody>
						</table>
						<div class=""ln_solid""></div>
						<div class=""form-group"">
							<div class=""text-right"">
							</div>
						</div>

					</div>

				</div>
			</div>
		</div>
	</div>



</div>
<!-- /page content -->

<!-- Modal: Support start -->
<div class=""modal fade supported-modal"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
	<div class=""modal-dialog modal-xs"">
		<div class=""modal-content"">


			<div class=""RequestorNameDiv""></div>

		</div>
	</div>
</div>
<!-- Modal: Support end -->
");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
	<script>

		$(document).ready(function() {
			var table = $('.datatable-1').DataTable({
				'responsive': true,
				'paging': true,
				'info': false,
				'searching': false,

				//""order"": [[1, ""desc""]],
				""columnDefs"": [
					{ ""orderable"": false, ""targets"": 0 }
				]
			});

			$('.btntest').on('click', function() {
				var val = $(this).closest(""td"").find(""input[name='documentId']"").val();
				debugger;
				$.ajax({
					url: '");
#nullable restore
#line 177 "D:\Demo Dell\WebFront.Core\WebFront.Core\Views\Documents\Index.cshtml"
                     Write(Url.Action("Partial"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
					type: 'GET',
					cache: false,
					  data: { documentId: val }
				}).done(function(result) {
					$('.RequestorNameDiv').html(result);
				});

			});

		});

		window.addEventListener(""pageshow"", function(event) {
			var historyTraversal = event.persisted ||
				(typeof window.performance != ""undefined"" &&
					window.performance.navigation.type === 2);
			if (historyTraversal) {
				// Handle page restore.
				window.location.reload();
			}
		});

	</script>

	<script src=""https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.min.js""></script>
	<script>
		$(document).ready(function() {
			$('.js-example-basic-multiple').select2();
		});

	

	</script>

");
            }
            );
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