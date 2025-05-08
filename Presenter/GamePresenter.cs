using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final_Project.Model;
using Final_Project.View;

namespace Final_Project.Presenter
{
    public class GamePresenter
    {
        private readonly IGameView view;
        private List<Button> playerPositionButtons;
        private List<Button> enemyPositionButtons;

        private Random rand = new Random();
        private int totalShips = 3;
        private int round = 15;
        private int playerScore;
        private int enemyScore;
        private bool mysteryBoxUsed = false;
        private Button playerBombTile = null;
        private Button enemyBombTile = null;
        private bool bombActivated = false;

        public GamePresenter(IGameView view)
        {
            this.view = view;
            Initialize();
        }

        private void Initialize()
        {
            view.PlayerTileClicked += OnPlayerTileClicked;
            view.EnemyTileClicked += OnEnemyTileClicked;
            view.BombButtonClicked += OnBombButtonClicked;
            view.MysteryBoxClicked += OnMysteryBoxClicked;

            RestartGame();
        }

        private void RestartGame()
        {
            playerPositionButtons = new List<Button> { /* buttons here */ };
            enemyPositionButtons = new List<Button> { /* buttons here */ };

            foreach (var btn in enemyPositionButtons)
            {
                view.SetTileEnabled(btn, true);
                view.SetTileTag(btn, null);
                view.SetTileBackColor(btn, Color.White);
                view.SetTileBackgroundImage(btn, null);
            }

            foreach (var btn in playerPositionButtons)
            {
                view.SetTileEnabled(btn, true);
                view.SetTileTag(btn, null);
                view.SetTileBackColor(btn, Color.White);
                view.SetTileBackgroundImage(btn, null);
            }

            playerScore = 0;
            enemyScore = 0;
            round = 15;
            totalShips = 3;

            view.SetPlayerScore(playerScore.ToString());
            view.SetEnemyScore(enemyScore.ToString());
            view.SetRoundText("Round: " + round);

            mysteryBoxUsed = false;
            bombActivated = false;

            view.EnableBombButton(true);
            enemyLocationPicker();
            playerLocationPicker();
        }

        private void OnPlayerTileClicked(object sender, EventArgs e)
        {
            if (totalShips > 0)
            {
                var button = (Button)sender;
                button.Enabled = false;
                button.Tag = "playerShip";
                button.BackColor = Color.Orange;
                button.BackgroundImage = Properties.Resources.boatImage;
                totalShips -= 1;

                if (totalShips == 0)
                {
                    view.ShowMessage("You can now start attacking!", "Ready to Attack!");
                }
            }
        }

        private void OnEnemyTileClicked(object sender, EventArgs e)
        {
            if (round <= 0 || totalShips > 0)
                return;

            Button btn = (Button)sender;
            if (!btn.Enabled)
                return;

            round -= 1;
            view.SetRoundText("Round: " + round);

            if (btn == playerBombTile)
            {
                view.ShowMessage("Game Over.", "Bomb Activated");
                playerScore = 0;
                view.SetPlayerScore(playerScore.ToString());
                view.ShowMessage("You lose!", "Game Over");
                RestartGame();
                return;
            }

            if ((string)btn.Tag == "enemyBomb")
            {
                btn.Enabled = false;
                btn.BackgroundImage = Properties.Resources.explosionIcon;
                btn.BackColor = Color.Red;
                view.ShowMessage("You hit the enemy's bomb! You lose!", "Bomb Activated");
                enemyScore = 0;
                view.SetEnemyScore(enemyScore.ToString());
                view.ShowMessage("You lose! The enemy's bomb exploded!", "Game Over");
                RestartGame();
                return;
            }

            if ((string)btn.Tag == "enemyShip")
            {
                btn.Enabled = false;
                btn.BackgroundImage = Properties.Resources.fireIcon;
                btn.BackColor = Color.DarkBlue;
                playerScore += 1;
                view.SetPlayerScore(playerScore.ToString());
            }
            else
            {
                btn.Enabled = false;
                btn.BackgroundImage = Properties.Resources.missIcon;
                btn.BackColor = Color.DarkBlue;
            }
        }

        private void OnBombButtonClicked(object sender, EventArgs e)
        {
            view.ShowMessage("Bomb activated! Game Over!", "Bomb Activated");
            if (bombActivated)
            {
                view.ShowMessage("You win! The enemy clicked on their bomb!", "Game Over");
            }
            else
            {
                view.ShowMessage("You lost! You clicked your own bomb.", "Game Over");
            }
            RestartGame();
        }

        private void OnMysteryBoxClicked(object sender, EventArgs e)
        {
            if (mysteryBoxUsed)
            {
                view.ShowMessage("You have already used the Mystery Box this round!", "Mystery Box");
                return;
            }

            mysteryBoxUsed = true;

            int reward = rand.Next(3);

            if (reward == 0)
            {
                view.ShowMessage("Mystery Box: Bonus 1 Point!", "Mystery Box");
                playerScore += 1;
                view.SetPlayerScore(playerScore.ToString());
            }
            else if (reward == 1)
            {
                view.ShowMessage("Mystery Box: Enemy Tile Revealed!", "Mystery Box");
                RevealRandomEnemyTile();
            }
            else if (reward == 2)
            {
                view.ShowMessage("Mystery Box: Ouch! Lose 1 Round!", "Mystery Box");
                round -= 1;
                view.SetRoundText("Round: " + round);
            }

            view.EnableMysteryBox(false);
        }

        private void RevealRandomEnemyTile()
        {
            var hiddenTiles = enemyPositionButtons.Where(btn => btn.Enabled).ToList();
            int index = rand.Next(hiddenTiles.Count);
            Button revealedButton = hiddenTiles[index];
            revealedButton.BackColor = Color.Gray;
            revealedButton.Enabled = false;
        }

        private void enemyLocationPicker()
        {
            for (int i = 0; i < 3; i++)
            {
                int index = rand.Next(enemyPositionButtons.Count);
                if (enemyPositionButtons[index].Enabled && (string)enemyPositionButtons[index].Tag == null)
                {
                    enemyPositionButtons[index].Tag = "enemyShip";
                }
                else
                {
                    i--;
                }
            }

            int bombIndex = rand.Next(enemyPositionButtons.Count);
            enemyBombTile = enemyPositionButtons[bombIndex];
            enemyBombTile.Tag = "enemyBomb";
        }

        private void playerLocationPicker()
        {
            int bombIndex = rand.Next(playerPositionButtons.Count);
            playerBombTile = playerPositionButtons[bombIndex];
            playerBombTile.BackgroundImage = Properties.Resources.bombIcon;

            enemyPositionButtons.ForEach(btn =>
            {
                if (btn == playerBombTile)
                    btn.BackgroundImage = null;
            });
        }
    }

}