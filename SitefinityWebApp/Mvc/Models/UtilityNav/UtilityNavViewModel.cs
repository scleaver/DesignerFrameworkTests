using System.Collections.Generic;

namespace SitefinityWebApp.Mvc.Models.UtilityNav
{
    public class UtilityNavViewModel
    {
        public string CssClass { get; set; }

        public List<UtilityNavItemViewModel> NavItems { get; set; }
    }

    public class UtilityNavItemViewModel
    {
        /// <summary>
        /// Gets or sets the nav item text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gest or sets the nav item type.
        /// </summary>
        public NavItemType ItemType { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        public string LinkTarget { get; set; }

        /// <summary>
        /// Gets or sets the link url.
        /// </summary>
        public string LinkUrl { get; set; }

        /// <summary>
        /// Gets or sets the id attribute of the item.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gest or sets the class modifier of the item.
        /// </summary>
        public string CssClassId { get; set; }

        /// <summary>
        /// Gets or sets the image icon url of the nav item.
        /// </summary>
        public string IconUrl { get; set; }

        /// <summary>
        /// Gets or sets the image icon alt text.
        /// </summary>
        public string IconAltText { get; set; }

        public IList<PanelMenuItemsViewModel> PanelMenuItems { get; set; }
    }

    public class PanelMenuItemsViewModel
    {
        /// <summary>
        /// Gets or sets the menu item text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the menu item text.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        public string LinkTarget { get; set; }

        /// <summary>
        /// Gets or sets the link url.
        /// </summary>
        public string LinkUrl { get; set; }
    }
}
