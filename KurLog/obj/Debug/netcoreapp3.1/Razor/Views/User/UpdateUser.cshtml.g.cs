#pragma checksum "C:\Users\Casper\Desktop\KurLog\KurLog\KurLog\Views\User\UpdateUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9df9c3a99609fb5729cd8be0db75023e492e2426"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_UpdateUser), @"mvc.1.0.view", @"/Views/User/UpdateUser.cshtml")]
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
#line 1 "C:\Users\Casper\Desktop\KurLog\KurLog\KurLog\Views\_ViewImports.cshtml"
using KurLog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Casper\Desktop\KurLog\KurLog\KurLog\Views\_ViewImports.cshtml"
using KurLog.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9df9c3a99609fb5729cd8be0db75023e492e2426", @"/Views/User/UpdateUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dcd39e8b717afd021908a62673a1f5c6adae51e3", @"/Views/_ViewImports.cshtml")]
    public class Views_User_UpdateUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<KurLog.Models.UserModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Casper\Desktop\KurLog\KurLog\KurLog\Views\User\UpdateUser.cshtml"
  
    ViewData["Title"] = "UpdateUser";

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9df9c3a99609fb5729cd8be0db75023e492e24263643", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 6 "C:\Users\Casper\Desktop\KurLog\KurLog\KurLog\Views\User\UpdateUser.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.All;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Casper\Desktop\KurLog\KurLog\KurLog\Views\User\UpdateUser.cshtml"
 using (Html.BeginRouteForm("UpdateUser", "userModel", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Casper\Desktop\KurLog\KurLog\KurLog\Views\User\UpdateUser.cshtml"
Write(Html.HiddenFor(x => x.Id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Casper\Desktop\KurLog\KurLog\KurLog\Views\User\UpdateUser.cshtml"
Write(Html.LabelFor(x => x.FirstName));

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Casper\Desktop\KurLog\KurLog\KurLog\Views\User\UpdateUser.cshtml"
Write(Html.TextBoxFor(x => x.FirstName, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Casper\Desktop\KurLog\KurLog\KurLog\Views\User\UpdateUser.cshtml"
Write(Html.LabelFor(x => x.LastName));

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Casper\Desktop\KurLog\KurLog\KurLog\Views\User\UpdateUser.cshtml"
Write(Html.TextBoxFor(x => x.LastName, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Casper\Desktop\KurLog\KurLog\KurLog\Views\User\UpdateUser.cshtml"
Write(Html.LabelFor(x => x.UserName));

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\Casper\Desktop\KurLog\KurLog\KurLog\Views\User\UpdateUser.cshtml"
Write(Html.TextBoxFor(x => x.UserName, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\Casper\Desktop\KurLog\KurLog\KurLog\Views\User\UpdateUser.cshtml"
Write(Html.LabelFor(x => x.Password));

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\Casper\Desktop\KurLog\KurLog\KurLog\Views\User\UpdateUser.cshtml"
Write(Html.TextBoxFor(x => x.Password, new { @class = "form-control", @type = "password" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\Casper\Desktop\KurLog\KurLog\KurLog\Views\User\UpdateUser.cshtml"
Write(Html.LabelFor(x => x.Authority));

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\Casper\Desktop\KurLog\KurLog\KurLog\Views\User\UpdateUser.cshtml"
Write(Html.TextBoxFor(x => x.Authority, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <button class=\"btn btn-info\">Update</button>\r\n");
#nullable restore
#line 22 "C:\Users\Casper\Desktop\KurLog\KurLog\KurLog\Views\User\UpdateUser.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KurLog.Models.UserModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
