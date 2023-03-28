using System.Collections.Generic;
using System.Linq;

namespace Boilerplate.Core.Models.DataModels
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsCurrentPage { get; set; }
        public bool IsCurrentPageActive { get; set; }
        public List<MenuItem> Children { get; set; } = new List<MenuItem>();
        public bool HasChildren => Children.Any();
        public bool IsExternal { get; set; }
        public int NavLevel { get; set; }
    }
}
