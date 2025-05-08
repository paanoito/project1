using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.Model;

namespace Final_Project.Model
{
    public class Tile
    {
        public string ID { get; set; }
        public string Type { get; set; } = ""; // "playerShip", "enemyShip", "enemyBomb"
        public bool IsEnabled { get; set; } = true;
    }
}
