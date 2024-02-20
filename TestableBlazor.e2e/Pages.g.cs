//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestableBlazor_e2e
{
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.ObjectModel;
    using ArtOfTest.WebAii.TestAttributes;
    using ArtOfTest.WebAii.TestTemplates;
    using ArtOfTest.WebAii.Controls.HtmlControls;
    
    public class Pages
    {
        private Manager _manager;
        public Pages(Manager manager)
        {
            _manager = manager;
        }
        /// <summary>
        /// Page : https://localhost:7002/ 
        /// </summary>
        public HttpsLocalhost7002Page HttpsLocalhost7002
        {
            get
            {
                return new HttpsLocalhost7002Page("https://localhost:7002/", _manager.ActiveBrowser.Find);
            }
        }
        public class HttpsLocalhost7002Page : HtmlPage
        {
            public HttpsLocalhost7002Page(string url, Find find) : 
                    base(url, find)
            {
            }
            /// <summary>
            /// Find expressions for this page
            /// </summary>
            public ExpressionDefinitions Expressions
            {
                get
                {
                    return new ExpressionDefinitions();
                }
            }
            /// <summary>
            /// Find logic 
            /// (Html): [class 'Contains' telerik-blazor] AND [class 'RegEx' (?:k-dateinput|k-datepicker|k-datetimepicker|k-timepicker)] AND [tagname 'Exact' span][class 'Contains' k-input-inner]
            ///
            /// </summary>
            public Telerik.TestingFramework.Controls.TelerikUI.Blazor.DateInput.TelerikBlazorDateInput BirthDateFieldText
            {
                get
                {
                    return Get<Telerik.TestingFramework.Controls.TelerikUI.Blazor.DateInput.TelerikBlazorDateInput>("tagname=span", "class=~telerik-blazor", "class=#(?:k-dateinput|k-datepicker|k-datetimepicker|k-timepicker)", "|", "class=~k-input-inner");
                }
            }
            /// <summary>
            /// Find logic 
            /// (Html): [class 'Contains' k-textbox] AND [class 'Contains' telerik-blazor]
            ///
            /// </summary>
            public Telerik.TestingFramework.Controls.TelerikUI.Blazor.TextBox.TelerikBlazorTextBox Span
            {
                get
                {
                    return Get<Telerik.TestingFramework.Controls.TelerikUI.Blazor.TextBox.TelerikBlazorTextBox>("class=~k-textbox", "class=~telerik-blazor");
                }
            }
            /// <summary>
            /// Find logic 
            /// (Html): [class 'Contains' k-textbox] AND [class 'Contains' telerik-blazor] AND [GroupIndex 'Exact' 1]
            ///
            /// </summary>
            public Telerik.TestingFramework.Controls.TelerikUI.Blazor.TextBox.TelerikBlazorTextBox Span0
            {
                get
                {
                    return Get<Telerik.TestingFramework.Controls.TelerikUI.Blazor.TextBox.TelerikBlazorTextBox>("class=~k-textbox", "class=~telerik-blazor", "GroupIndex=1");
                }
            }
            /// <summary>
            /// Find logic 
            /// (Html): [class 'Contains' k-dropdown] AND [class 'Contains' telerik-blazor]
            ///
            /// </summary>
            public Telerik.TestingFramework.Controls.TelerikUI.Blazor.DropdownList.TelerikBlazorDropdownList RegionSelectSpan
            {
                get
                {
                    return Get<Telerik.TestingFramework.Controls.TelerikUI.Blazor.DropdownList.TelerikBlazorDropdownList>("class=~k-dropdown", "class=~telerik-blazor");
                }
            }
            /// <summary>
            /// Find logic 
            /// (Html): [class 'Contains' k-dropdown] AND [class 'Contains' telerik-blazor] AND [GroupIndex 'Exact' 1]
            ///
            /// </summary>
            public Telerik.TestingFramework.Controls.TelerikUI.Blazor.DropdownList.TelerikBlazorDropdownList TeamSelectSpan
            {
                get
                {
                    return Get<Telerik.TestingFramework.Controls.TelerikUI.Blazor.DropdownList.TelerikBlazorDropdownList>("class=~k-dropdown", "class=~telerik-blazor", "GroupIndex=1");
                }
            }
            /// <summary>
            /// Find logic 
            /// (Html): [class 'Contains' k-button] AND [class 'Contains' telerik-blazor] AND [GroupIndex 'Exact' 3] AND [tagname 'Exact' button]
            ///
            /// </summary>
            public Telerik.TestingFramework.Controls.TelerikUI.Blazor.Button.TelerikBlazorButton FormSubmitButtonTag
            {
                get
                {
                    return Get<Telerik.TestingFramework.Controls.TelerikUI.Blazor.Button.TelerikBlazorButton>("tagname=button", "class=~k-button", "class=~telerik-blazor", "GroupIndex=3");
                }
            }
            /// <summary>
            /// Find logic 
            /// (Html): [class 'Contains' k-window] AND [class 'Contains' telerik-blazor]
            ///
            /// </summary>
            public Telerik.TestingFramework.Controls.TelerikUI.Blazor.Window.TelerikBlazorWindow Div
            {
                get
                {
                    return Get<Telerik.TestingFramework.Controls.TelerikUI.Blazor.Window.TelerikBlazorWindow>("class=~k-window", "class=~telerik-blazor");
                }
            }
            public class ExpressionDefinitions
            {
                public ArtOfTest.WebAii.Core.HtmlFindExpression BirthDateFieldText = new ArtOfTest.WebAii.Core.HtmlFindExpression("tagname=span", "class=~telerik-blazor", "class=#(?:k-dateinput|k-datepicker|k-datetimepicker|k-timepicker)", "|", "class=~k-input-inner");
                public ArtOfTest.WebAii.Core.HtmlFindExpression Span = new ArtOfTest.WebAii.Core.HtmlFindExpression("class=~k-textbox", "class=~telerik-blazor");
                public ArtOfTest.WebAii.Core.HtmlFindExpression Span0 = new ArtOfTest.WebAii.Core.HtmlFindExpression("class=~k-textbox", "class=~telerik-blazor", "GroupIndex=1");
                public ArtOfTest.WebAii.Core.HtmlFindExpression RegionSelectSpan = new ArtOfTest.WebAii.Core.HtmlFindExpression("class=~k-dropdown", "class=~telerik-blazor");
                public ArtOfTest.WebAii.Core.HtmlFindExpression TeamSelectSpan = new ArtOfTest.WebAii.Core.HtmlFindExpression("class=~k-dropdown", "class=~telerik-blazor", "GroupIndex=1");
                public ArtOfTest.WebAii.Core.HtmlFindExpression FormSubmitButtonTag = new ArtOfTest.WebAii.Core.HtmlFindExpression("tagname=button", "class=~k-button", "class=~telerik-blazor", "GroupIndex=3");
                public ArtOfTest.WebAii.Core.HtmlFindExpression Div = new ArtOfTest.WebAii.Core.HtmlFindExpression("class=~k-window", "class=~telerik-blazor");
            }
        }
    }
    public class Applications
    {
        private Manager _manager;
        public Applications(Manager manager)
        {
            _manager = manager;
        }
    }
    public class DesktopApplications
    {
        private Manager _manager;
        public DesktopApplications(Manager manager)
        {
            _manager = manager;
        }
    }
}
