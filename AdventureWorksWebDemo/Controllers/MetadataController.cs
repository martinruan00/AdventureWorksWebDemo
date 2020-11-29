using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorksWebDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorksWebDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetadataController : ControllerBase
    {
        [HttpGet("menu")]
        public async Task<ActionResult<IEnumerable<MenuModel>>> GetMenu()
        {
            var menu = new[]
            {
                new MenuModel
                {
                    Header = "Human resources", 
                    SubMenu = new List<MenuModel>
                    {
                        new MenuModel { Header = "Departments", Route = "humanresources/department" },
                        new MenuModel { Header = "Employees", Route = "humanresources/employee" },
                        new MenuModel { Header = "Shifts", Route = "humanresources/shift" }
                    }
                },
                new MenuModel
                {
                    Header = "Production",
                    SubMenu = new List<MenuModel>
                    {
                        new MenuModel { Header = "Products", Route = "production/products" },
                    }
                }
            };
            return menu;
        }
    }
}
