using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeAppApi.Data
{
    public class API_DbContext
    {
        public API_DbContext(DbContextOptions<API_DbContext> options) : base(options)
        {

        }
        //Old Brickyard
        public DbSet<OldBrickyard_MainMenu> oldBrickyardMainMenus { get; set; }
        public DbSet<OldBrickyard_Menu> oldBrickyardMenus { get; set; }
        public DbSet<OldBrickyard_Reservation> oldBrickyardReservations { get; set; }
    }
}
