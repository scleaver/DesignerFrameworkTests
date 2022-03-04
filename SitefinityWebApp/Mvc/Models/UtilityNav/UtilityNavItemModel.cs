using Progress.Sitefinity.Renderer.Designers;
using Progress.Sitefinity.Renderer.Designers.Attributes;
using Progress.Sitefinity.Renderer.Entities.Content;
using Progress.Sitefinity.Renderer.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SitefinityWebApp.Mvc.Models.UtilityNav
{
    public class UtilityNavItemModel
    {
        [DisplayName("Menu item type")]
        [DefaultValue(NavItemType.link)]
        public NavItemType ItemType { get; set; }

        [DisplayName("Menu item text")]
        [DescriptionExtended("This is the extended description", InlineDescription = "Inline description", InstructionalNotes = "Instructional notes")]
        public string Text { get; set; }

        [DisplayName("Unique identifier")]
        public string Id { get; set; }

        [ConditionalVisibility("{\"conditions\":[{\"fieldName\":\"ItemType\",\"operator\":\"Equals\",\"value\":\"link\"}]}")]
        public LinkModel Link { get; set; }

        /// <summary>
        /// This is just here to test it works... don't actually want to use it.
        /// </summary>
        //[DisplayName("Extended text")]
        //[ConditionalVisibility("{\"conditions\":[{\"fieldName\":\"ItemType\",\"operator\":\"Equals\",\"value\":\"button\"}]}")]
        //[DataType(customDataType: KnownFieldTypes.Html)]
        //public string ExtendedText { get; set; }

        [DisplayName("Link target")]
        [DefaultValue(LinkTarget.self)]
        [ConditionalVisibility("{\"conditions\":[{\"fieldName\":\"ItemType\",\"operator\":\"Equals\",\"value\":\"link\"}]}")]
        public LinkTarget Target { get; set; }

        [Content(Type = KnownContentTypes.Images, OpenMultipleItemsSelection = false)]
        public MixedContentContext Icon { get; set; }

        [DisplayName("Panel menu items")]
        [ConditionalVisibility("{\"conditions\":[{\"fieldName\":\"ItemType\",\"operator\":\"Equals\",\"value\":\"panel\"}]}")]
        [Content(Type = "Telerik.Sitefinity.DynamicTypes.Model.Navigation.MenuItem", OpenMultipleItemsSelection = true)]
        public MixedContentContext PanelMenuItems { get; set; }
    }
}
