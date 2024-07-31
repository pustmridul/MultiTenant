using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Navs.Models
{
    internal class NavModel
    {
    }
    public class NavDto
    {
        public int Id { get; set; }
        public string Name { get; set; }= string.Empty;
        public string? UrlLink { get; set; }
        public int? ParentId { get; set; }
        public ICollection<NavDto>? Children { get; set; }
    }
}
