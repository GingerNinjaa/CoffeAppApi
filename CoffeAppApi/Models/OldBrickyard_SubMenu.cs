using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeAppApi.Models
{
    public class OldBrickyard_SubMenu
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(400)]
        public string Description { get; set; }
        [MaxLength(25)]
        public int Price { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [MaxLength(25)]
        public string Type { get; set; }
    }
}
