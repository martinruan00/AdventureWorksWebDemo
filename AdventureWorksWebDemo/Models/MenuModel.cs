using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksWebDemo.Models
{
    public class MenuModel
    {
        public string Header { get; internal set; }
        public List<MenuModel> SubMenu { get; internal set; }
        public string Route { get; internal set; }
    }
}
