using System.ComponentModel;

namespace SitefinityWebApp.Mvc.Models.UtilityNav
{
    public enum NavItemType
    {
        [Description("Link")]
        link,
        [Description("Button")]
        button,
        [Description("Dropdown panel")]
        panel
    }
}
