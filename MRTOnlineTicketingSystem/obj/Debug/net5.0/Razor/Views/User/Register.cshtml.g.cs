#pragma checksum "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b9970c53c0994b5918bb5033924f812d27a76969"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Register), @"mvc.1.0.view", @"/Views/User/Register.cshtml")]
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
#line 1 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\_ViewImports.cshtml"
using MRTOnlineTicketingSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\_ViewImports.cshtml"
using MRTOnlineTicketingSystem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b9970c53c0994b5918bb5033924f812d27a76969", @"/Views/User/Register.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bee216b29dde80e13934f13b04dfa63a762c1b45", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MRTOnlineTicketingSystem.Models.User>
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b9970c53c0994b5918bb5033924f812d27a769693339", async() => {
                WriteLiteral("\r\n    <title>Register</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b9970c53c0994b5918bb5033924f812d27a769694336", async() => {
                WriteLiteral("\r\n\r\n    <h1> Create Account</h1>\r\n\r\n");
#nullable restore
#line 9 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml"
     using (Html.BeginForm())
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml"
         if (ViewBag.UserExist==true)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"alert alert-danger\">\r\n                <p>User with this email already exist!</p>\r\n            </div>\r\n");
#nullable restore
#line 16 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("        <div class=\" row\">\r\n            <p class=\"col-md-6\">\r\n                <label> ");
#nullable restore
#line 19 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml"
                   Write(Html.DisplayNameFor(x => x.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                ");
#nullable restore
#line 20 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml"
           Write(Html.TextBoxFor(x => x.Name, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 21 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml"
           Write(Html.ValidationMessageFor(x => x.Name, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </p>\r\n        </div>\r\n");
                WriteLiteral("        <div class=\" row\">\r\n            <p class=\"col-md-6\">\r\n                <label> ");
#nullable restore
#line 27 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml"
                   Write(Html.DisplayNameFor(x => x.ICNumber));

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                ");
#nullable restore
#line 28 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml"
           Write(Html.TextBoxFor(x => x.ICNumber, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 29 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml"
           Write(Html.ValidationMessageFor(x => x.ICNumber, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </p>\r\n        </div>\r\n");
                WriteLiteral("        <div class=\" row\">\r\n            <p class=\"col-md-6\">\r\n                <label> ");
#nullable restore
#line 35 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml"
                   Write(Html.DisplayNameFor(x => x.DateOfBirth));

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                ");
#nullable restore
#line 36 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml"
           Write(Html.TextBoxFor(x => x.DateOfBirth, new { @class = "datepicker  form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 37 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml"
           Write(Html.ValidationMessageFor(x => x.DateOfBirth, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </p>\r\n        </div>\r\n");
                WriteLiteral("        <div class=\" row\">\r\n            <p class=\"col-md-6\">\r\n                <label> ");
#nullable restore
#line 43 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml"
                   Write(Html.DisplayNameFor(x => x.Email));

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                ");
#nullable restore
#line 44 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml"
           Write(Html.TextBoxFor(x => x.Email, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 45 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml"
           Write(Html.ValidationMessageFor(x => x.Email, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </p>\r\n        </div>\r\n");
                WriteLiteral("        <div class=\" row\">\r\n            <p class=\"col-md-6\">\r\n                <label> ");
#nullable restore
#line 51 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml"
                   Write(Html.DisplayNameFor(x => x.Password));

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                ");
#nullable restore
#line 52 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml"
           Write(Html.PasswordFor(x => x.Password, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 53 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml"
           Write(Html.ValidationMessageFor(x => x.Password, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </p>\r\n        </div>\r\n");
                WriteLiteral("        <div class=\" row\">\r\n            <p class=\"col-md-6\">\r\n                <label> ");
#nullable restore
#line 59 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml"
                   Write(Html.DisplayNameFor(x => x.RePassword));

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                ");
#nullable restore
#line 60 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml"
           Write(Html.PasswordFor(x => x.RePassword, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 61 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml"
           Write(Html.ValidationMessageFor(x => x.RePassword, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </p>\r\n        </div>\r\n");
                WriteLiteral("        <p> <input type=\"submit\" value=\"Register\" class=\"btn-success btn-md\" /></p>\r\n");
#nullable restore
#line 66 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\Register.cshtml"
    }

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <link rel=""stylesheet"" href=""//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"" />
 
    <script src=""https://code.jquery.com/jquery-1.12.4.js""></script>
    <script src=""https://code.jquery.com/ui/1.12.1/jquery-ui.js""></script>

    <script type=""text/javascript"">

        $("".datepicker"").datepicker({
            dateFormat: ""dd-mm-yy"",
        });
    </script>

");
            }
            );
            WriteLiteral(" ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MRTOnlineTicketingSystem.Models.User> Html { get; private set; }
    }
}
#pragma warning restore 1591
