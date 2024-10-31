using System.ComponentModel;

namespace RazorHtmxWebApp.Pages.HtmxTests
{
    public class Item
    {
        public Item()
        {
        }

        public Item(string aName, string aDescription, Guid newGuid)
        {
            this.Name = aName;
            this.Description = aDescription;
            this.UniqueIdentifier = newGuid.ToString();
        }

        public string? Name { get; set; }
        public string? Description { get; set; }
        [DisplayName("ID")] public string? UniqueIdentifier { get; set; }

    }
}

