using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Final_Project.View
{
    public interface IGameView
    {
        event EventHandler PlayerTileClicked;
        event EventHandler EnemyTileClicked;
        event EventHandler BombButtonClicked;
        event EventHandler MysteryBoxClicked;

        void SetRoundText(string roundText);
        void SetPlayerScore(string playerScore);
        void SetEnemyScore(string enemyScore);
        void ShowMessage(string message, string title);
        void EnableBombButton(bool enabled);
        void EnableMysteryBox(bool enabled);
        void SetTileBackgroundImage(Button button, Image image);
        void SetTileEnabled(Button button, bool enabled);
        void SetTileBackColor(Button button, Color color);
        void SetTileTag(Button button, object tag);
        void SetTileTag(System.Windows.Forms.Button btn, object value);
        void SetTileBackColor(System.Windows.Forms.Button btn, Color white);
        void SetTileBackgroundImage(System.Windows.Forms.Button btn, object value);
        void SetTileEnabled(System.Windows.Forms.Button btn, bool v);
    }

}
