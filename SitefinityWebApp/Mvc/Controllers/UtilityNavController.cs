using Progress.Sitefinity.Renderer.Designers.Attributes;
using SitefinityWebApp.Mvc.Models.UtilityNav;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using Telerik.Sitefinity.Modules.Pages.Configuration;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Personalization;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Web.UI;

namespace SitefinityWebApp.Mvc.Controllers
{
    /// <summary>
    /// This class represents the controller of the Utility Nav widget.
    /// </summary>
    [ControllerToolboxItem(Name = "UtilityNav_MVC", Title = "Utility Nav", SectionName = ToolboxesConfig.ContentToolboxSectionName, CssClass = WidgetIconCssClass)]
    public class UtilityNavController : Controller, IPersonalizable, ICustomWidgetVisualizationExtended
    {
        #region Properties

        /// <summary>
        /// TEST 3: Complex object as per documentation here: https://www.progress.com/documentation/sitefinity-cms/autogenerated-field-types-dp-dp#-complex-objects-
        /// RESULT: Unusable
        /// ISSUES:
        /// 1. Data does not persist when used this way. According to https://community.progress.com/s/article/autogenerated-field-types-how-to-create-complex-object-property
        /// You need to use a TypeConverter but this is not mentioned in documentation - why can't documentation be updated with info from KB article?
        /// </summary>
        [DisplayName("Menu item 1")]
        public UtilityNavItemModel NavItem1 { get; set; }

        /// <summary>
        /// TEST 4: Same complex object but as per KB article here: https://community.progress.com/s/article/autogenerated-field-types-how-to-create-complex-object-property
        /// RESULT: It works but not if you want to use HTML field.
        /// ISSUES:
        /// 1. HTML datatype does not work in a complex object but this is not documented. It just renders as a Textarea with no edior.
        /// Not sure if any other other data types don't work https://www.progress.com/documentation/sitefinity-cms/customize-autogenerated-fields-dp-dp#datatype
        /// </summary>
        [DisplayName("Menu item 2")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public UtilityNavItemModel NavItem2
        {
            get
            {
                if (navItem2 == null)
                    navItem2 = new UtilityNavItemModel();

                return navItem2;
            }
            set
            {
                navItem2 = value;
            }
        }

        /// <summary>
        /// TEST 1: This was orginally what I was trying to do. so that the content manager can add as many menu items as they like.
        /// List of complex object as per documentation here: https://www.progress.com/documentation/sitefinity-cms/autogenerated-field-types-dp-dp#-complex-objects-
        /// RESULT: Unsuable
        /// ISSUES: 
        /// 1. Data does no persist. This is mentioned in the following KB article but not in documentation:
        /// https://community.progress.com/s/article/autogenerated-field-types-list-of-complex-objects-is-not-persisted
        /// 2. UI is squashed - works for only perhaps 2 fields. No way to force the item into single column view.
        /// 3. Can't reorder the items.
        /// 4. ConditionalVisibility only fire once not if you change a value the second time.
        /// 5. not all ConditionalVisibility rules work for some reason.
        /// 6. Value cannot be null. Parameter name: collection error on save
        /// </summary>
        [DisplayName("Menu item 3")]
        public IList<UtilityNavItemModel> NavItems { get; set; }

        /// <summary>
        /// Test 2: Stops the widget designer from working all together
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public IList<UtilityNavItemModel> NavItems2
        {
            get
            {
                if (navItems2 == null)
                    navItems2 = new List<UtilityNavItemModel>();

                return navItems2;
            }
            set
            {
                navItems2 = value;
            }
        }


        [ContentSection("Settings")]
        [DisplayName("CSS class")]
        public string CssClass { get; set; }

        /// <summary>
        /// Gets or sets the name of the template that widget will be displayed.
        /// </summary>
        /// <value></value>
        [ContentSection("Settings")]
        public string TemplateName
        {
            get
            {
                return _templateName;
            }

            set
            {
                _templateName = value;
            }
        }

        /// <inheritdoc />
        [Category("Advanced")]
        public string WidgetCssClass
        {
            get
            {
                return WidgetIconCssClass;
            }
        }

        /// <summary>
        /// Gets the is design mode.
        /// </summary>
        /// <value>The is design mode.</value>
        protected virtual bool IsDesignMode
        {
            get
            {
                return SystemManager.IsDesignMode;
            }
        }

        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                return NavItem1 == null || NavItem1.Text.IsNullOrEmpty();
            }
        }

        [Browsable(false)]
        public string EmptyLinkText
        {
            get
            {
                return "Set nav items and settings";
            }
        }

        #endregion

        #region Actions

        public ActionResult Index()
        {
            if (IsEmpty)
            {
                return new EmptyResult();
            }

            var viewModel = new UtilityNavViewModel
            {
                CssClass = CssClass,
                NavItems = CreateNavItems()
            };

            return View(_templateName, viewModel);
        }

        private List<UtilityNavItemViewModel> CreateNavItems()
        {
            var list = new List<UtilityNavItemModel>();
            list.Add(NavItem1);
            //list.Add(NavItem2);

            var viewList = new List<UtilityNavItemViewModel>();

            foreach (var item in list)
            {

            }

            return viewList;
        }

        /// <inheritDoc/>
        protected override void HandleUnknownAction(string actionName)
        {
            ActionInvoker.InvokeAction(ControllerContext, "Index");
        }

        #endregion

        #region Private methods        

        #endregion

        #region Private fields and constants

        internal const string WidgetIconCssClass = "sfUtilityNavIcn sfMvcIcn";

        private string _templateName = "Default";
        private UtilityNavItemModel navItem2;
        private IList<UtilityNavItemModel> navItems2;

        #endregion
    }
}
