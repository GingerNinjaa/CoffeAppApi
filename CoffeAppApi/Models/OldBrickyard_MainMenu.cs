using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeAppApi.Models
{
    public class OldBrickyard_MainMenu
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        // one Menu
        // to many SubMenus
        public ICollection<OldBrickyard_Menu> Menus { get; set; }
    }
}

