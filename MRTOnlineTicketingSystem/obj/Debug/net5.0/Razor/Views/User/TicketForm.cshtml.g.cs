#pragma checksum "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\TicketForm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6838499eecb33286ce685ff474fa447b592dd207"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_TicketForm), @"mvc.1.0.view", @"/Views/User/TicketForm.cshtml")]
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
#nullable restore
#line 3 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\TicketForm.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6838499eecb33286ce685ff474fa447b592dd207", @"/Views/User/TicketForm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bee216b29dde80e13934f13b04dfa63a762c1b45", @"/Views/_ViewImports.cshtml")]
    public class Views_User_TicketForm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MRTOnlineTicketingSystem.Models.MRTTicket>
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6838499eecb33286ce685ff474fa447b592dd2073617", async() => {
                WriteLiteral("\r\n    <title>Ticket</title>\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6838499eecb33286ce685ff474fa447b592dd2074612", async() => {
                WriteLiteral("\r\n\r\n    <h1>Book ticket for your journey now</h1>\r\n\r\n");
#nullable restore
#line 11 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\TicketForm.cshtml"
     using (Html.BeginForm())
    {


#line default
#line hidden
#nullable disable
                WriteLiteral("        <p class=\"col-md-4\">\r\n            <label>");
#nullable restore
#line 15 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\TicketForm.cshtml"
              Write(Html.DisplayNameFor(x => x.currentLocationIndex));

#line default
#line hidden
#nullable disable
                WriteLiteral(" </label>\r\n            ");
#nullable restore
#line 16 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\TicketForm.cshtml"
       Write(Html.DropDownListFor(x => x.currentLocationIndex, new SelectList(Model.DictStation, "Key", "Value"), "Select Station", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 17 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\TicketForm.cshtml"
       Write(Html.ValidationMessageFor(x => x.currentLocationIndex, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        </p>\r\n        <p class=\"col-md-4\">\r\n            <label>");
#nullable restore
#line 21 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\TicketForm.cshtml"
              Write(Html.DisplayNameFor(x => x.destinationLocationIndex));

#line default
#line hidden
#nullable disable
                WriteLiteral(" </label>\r\n            ");
#nullable restore
#line 22 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\TicketForm.cshtml"
       Write(Html.DropDownListFor(x => x.destinationLocationIndex, new SelectList(Model.DictStation, "Key", "Value"), "Select Station", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 23 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\TicketForm.cshtml"
       Write(Html.ValidationMessageFor(x => x.destinationLocationIndex, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        </p>\r\n");
                WriteLiteral("        <p class=\"col-md-4\">\r\n            <label>");
#nullable restore
#line 28 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\TicketForm.cshtml"
              Write(Html.DisplayNameFor(x => x.TicketIndex));

#line default
#line hidden
#nullable disable
                WriteLiteral(" </label>\r\n            ");
#nullable restore
#line 29 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\TicketForm.cshtml"
       Write(Html.DropDownListFor(x => x.TicketIndex, new SelectList(Model.DictTicketType, "Key", "Value"), "Select Ticket Type", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 30 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\TicketForm.cshtml"
       Write(Html.ValidationMessageFor(x => x.TicketIndex, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        </p>\r\n        <p class=\"col-md-4\">\r\n            <label>");
#nullable restore
#line 34 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\TicketForm.cshtml"
              Write(Html.DisplayNameFor(x => x.Adult));

#line default
#line hidden
#nullable disable
                WriteLiteral(" </label>\r\n            ");
#nullable restore
#line 35 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\TicketForm.cshtml"
       Write(Html.TextBoxFor(x => x.Adult, new { @type = "number", @class = "form-control", @min = "0", @step = "1" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        </p>\r\n        <p class=\"col-md-4\">\r\n            <label>");
#nullable restore
#line 39 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\TicketForm.cshtml"
              Write(Html.DisplayNameFor(x => x.Student));

#line default
#line hidden
#nullable disable
                WriteLiteral(" </label>\r\n            ");
#nullable restore
#line 40 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\TicketForm.cshtml"
       Write(Html.TextBoxFor(x => x.Student, new { @type = "number", @class = "form-control", @min = "0", @step = "1" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        </p>\r\n        <p class=\"col-md-4\">\r\n            <label>");
#nullable restore
#line 44 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\TicketForm.cshtml"
              Write(Html.DisplayNameFor(x => x.SeniorCitizen));

#line default
#line hidden
#nullable disable
                WriteLiteral(" </label>\r\n            ");
#nullable restore
#line 45 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\TicketForm.cshtml"
       Write(Html.TextBoxFor(x => x.SeniorCitizen, new { @type = "number", @class = "form-control", @min = "0", @step = "1" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        </p>\r\n        <p class=\"col-md-4\">\r\n            <label>");
#nullable restore
#line 49 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\TicketForm.cshtml"
              Write(Html.DisplayNameFor(x => x.Disable));

#line default
#line hidden
#nullable disable
                WriteLiteral(" </label>\r\n            ");
#nullable restore
#line 50 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\TicketForm.cshtml"
       Write(Html.TextBoxFor(x => x.Disable, new { @type = "number", @class = "form-control", @min = "0", @step = "1" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        </p>\r\n");
                WriteLiteral("        <p> <input type=\"submit\" value=\"Buy\" class=\"btn-success btn-md\" /></p>\r\n");
#nullable restore
#line 56 "C:\Users\Arthuria\Documents\GitHub\MRTOnlineTicketingSystem\MRTOnlineTicketingSystem\Views\User\TicketForm.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MRTOnlineTicketingSystem.Models.MRTTicket> Html { get; private set; }
    }
}
#pragma warning restore 1591
