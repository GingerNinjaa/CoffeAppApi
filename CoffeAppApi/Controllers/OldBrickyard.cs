using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeAppApi.Data;
using CoffeAppApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OldBrickyard : Controller
    {
        // Db conection
        API_DbContext _api_DbContent;

        public OldBrickyard(API_DbContext apiDbContent)
        {
            _api_DbContent = apiDbContent;
        }

        //Display all
        //api/OldBrickyard/all
        [HttpGet("all")]
        [ResponseCache(Duration = 360, Location = ResponseCacheLocation.Any)]
        public IActionResult GetAll()
        {
            var all = _api_DbContent.oldBrickyardMainMenus
                .Include(x => x.Menus)
                .ThenInclude(c => c.SubMenus);

            return Ok(all);
        }

        //Display only MainMenu items
        //api/OldBrickyard/MainMenuOnly
        [HttpGet("MainMenuOnly")]
        [ResponseCache(Duration = 360, Location = ResponseCacheLocation.Any)]
        public IActionResult GetMainMenuOnly()
        {
            var mainMenus = _api_DbContent.oldBrickyardMainMenus;

            return Ok(mainMenus);
        }

        //Display MainMenu items with releted items
        //api/OldBrickyard/MainMenu
        [HttpGet("MainMenu")]
        [ResponseCache(Duration = 360, Location = ResponseCacheLocation.Any)]
        public IActionResult GetMainMenu()
        {
            var mainMenusWithCategor = _api_DbContent.oldBrickyardMainMenus.Include("Menus");

            return Ok(mainMenusWithCategor);
        }

        //Display MainMenu items with releted item by ID
        //api/OldBrickyard/GetMenu/1
        [HttpGet("GetMenu/{id}")]
        public IActionResult GetMenu(int id = 1)
        {
            var menu = _api_DbContent.oldBrickyardMainMenus.Include("Menus").FirstOrDefault(x => x.Id == id);

            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }

        //Display Menu items with submenu items that are releted to menu item
        //api/OldBrickyard/SubMenu/1
        [HttpGet]
        [Route("SubMenu/{id}")]
        public IActionResult GetSubMenu(int id = 1)
        {
            var menu = _api_DbContent.oldBrickyardMenus.Include("SubMenus").FirstOrDefault(x => x.Id == id);

            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }

        //add reservation
        //api/Eurodom/post
        //[Authorize]
        [HttpPost("post")]
        public IActionResult Post(OldBrickyard_Reservation reservation)
        {
            _api_DbContent.oldBrickyardReservations.Add(reservation);

            _api_DbContent.SaveChanges();


            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
