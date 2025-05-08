using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.Model;

namespace Final_Project.Model
{
    public class GameState
    {
        public int PlayerScore { get; set; }
        public int EnemyScore { get; set; }
        public int Round { get; set; } = 15;
        public int TotalShips { get; set; } = 3;
        public bool MysteryBoxUsed { get; set; } = false;
        public bool BombActivated { get; set; } = false;
    }

}
