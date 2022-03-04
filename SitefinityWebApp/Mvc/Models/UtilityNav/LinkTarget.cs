using System.ComponentModel;

namespace SitefinityWebApp.Mvc.Models.UtilityNav
{
    public enum LinkTarget
    {
        [Description("Default eg. _self")]
        self,
        [Description("New window or tab eg. _blank")]
        blank,
        [Description("Parent frame eg. _parent")]
        parent,
        [Description("Full body of the window eg. _top")]
        top
    }
}
