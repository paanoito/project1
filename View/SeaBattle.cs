using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace Final_Project
{
    public partial class Form1 : Form
    {
        List<Button> playerPositionButtons;
        List<Button> enemyPositionButtons;

        Random rand = new Random();

        int totalShips = 3;
        int round = 15;
        int playerScore;
        int enemyScore;

        bool mysteryBoxUsed = false;
        Button playerBombTile = null;   
        Button enemyBombTile = null;   
        bool bombActivated = false;

        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void EnemyPlayTimerEvent(object sender, EventArgs e)
        {
            if (playerPositionButtons.Count > 0 && round > 0)
            {
                round -= 1;
                txtRounds.Text = "Round: " + round;

                int index = rand.Next(playerPositionButtons.Count);

                if ((string)playerPositionButtons[index].Tag == "playerShip")
                {
                    playerPositionButtons[index].BackgroundImage = Properties.Resources.fireIcon;
                    enemyMove.Text = playerPositionButtons[index].Text;
                    playerPositionButtons[index].Enabled = false;
                    playerPositionButtons[index].BackColor = Color.DarkBlue;
                    playerPositionButtons.RemoveAt(index);
                    enemyScore += 1;
                    txtEnemy.Text = enemyScore.ToString();
                    EnemyPlayTimer.Stop();
                }
                else
                {
                    playerPositionButtons[index].BackgroundImage = Properties.Resources.missIcon;
                    enemyMove.Text = playerPositionButtons[index].Text;
                    playerPositionButtons[index].Enabled = false;
                    playerPositionButtons[index].BackColor = Color.DarkBlue;
                    playerPositionButtons.RemoveAt(index);
                    EnemyPlayTimer.Stop();
                }
            }

            if (round < 1 || enemyScore > 2 || playerScore > 2)
            {
                EnemyPlayTimer.Stop();

                if (playerScore > enemyScore)
                {
                    MessageBox.Show("You Win!!", "Winning");
                    RestartGame();
                }
                else if (enemyScore > playerScore)
                {
                    MessageBox.Show("I sunk your battle ship", "Lost");
                    RestartGame();
                }
                else
                {
                    MessageBox.Show("No one wins this game", "Draw");
                    RestartGame();
                }
            }
        }

        private void PlayerPositionButtonsEvent(object sender, EventArgs e)
        {
            if (totalShips > 0)
            {
                var button = (Button)sender;

             
                button.Enabled = false;
                button.Tag = "playerShip";
                button.BackColor = Color.Orange;

 
                button.BackgroundImage = Properties.Resources.boatImage; 
                button.BackgroundImageLayout = ImageLayout.Stretch;  
                totalShips -= 1;

        
                if (totalShips == 0)
                {
                    txtHelp.Text = "2) Now click enemy tiles to attack!";
                    MessageBox.Show("You can now start attacking!", "Ready to Attack!");
                }
            }
        }


        private void RestartGame()
        {
            playerPositionButtons = new List<Button> { w1, w2, w3, w4, x1, x2, x3, x4, y1, y2, y3, y4, z1, z2, z3, z4 };
            enemyPositionButtons = new List<Button> { a1, a2, a3, a4, b1, b2, b3, b4, c1, c2, c3, c4, d1, d2, d3, d4 };

            foreach (var btn in enemyPositionButtons)
            {
                btn.Enabled = true;
                btn.Tag = null;
                btn.BackColor = Color.White;
                btn.BackgroundImage = null;
                btn.Click -= EnemyTile_Click;
                btn.Click += EnemyTile_Click;
            }

            foreach (var btn in playerPositionButtons)
            {
                btn.Enabled = true;
                btn.Tag = null;
                btn.BackColor = Color.White;
                btn.BackgroundImage = null;
            }

            playerScore = 0;
            enemyScore = 0;
            round = 15;
            totalShips = 3;

            txtPlayer.Text = playerScore.ToString();
            txtEnemy.Text = enemyScore.ToString();
            enemyMove.Text = "A1";

            mysteryBoxUsed = false;  
            bombActivated = false;  

       
            btnMysteryBox.Enabled = true;  

            
            playerBombTile = null;
            enemyBombTile = null;

            enemyLocationPicker();
            playerLocationPicker();
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

        private void EnemyTile_Click(object sender, EventArgs e)
        {
            if (round <= 0 || totalShips > 0)
                return;

            Button btn = (Button)sender;

            if (!btn.Enabled)
                return;

            round -= 1;
            txtRounds.Text = "Round: " + round;

            if (btn == playerBombTile)
            {
                MessageBox.Show("Game Over.", "Bomb Activated");
                playerScore = 0;
                txtPlayer.Text = playerScore.ToString();
                EnemyPlayTimer.Stop();
                MessageBox.Show("You lose!", "Game Over");
                RestartGame();
                return;
            }

            if ((string)btn.Tag == "enemyBomb")
            {
                btn.Enabled = false;
                btn.BackgroundImage = Properties.Resources.explosionIcon; // <- Explosion image
                btn.BackColor = Color.Red; // optional: red background
                MessageBox.Show("You hit the enemy's bomb! You lose!", "Bomb Activated");
                enemyScore = 0;
                txtEnemy.Text = enemyScore.ToString();
                EnemyPlayTimer.Stop();
                MessageBox.Show("You lose! The enemy's bomb exploded!", "Game Over");
                RestartGame();
                return;
            }

            if ((string)btn.Tag == "enemyShip")
            {
                btn.Enabled = false;
                btn.BackgroundImage = Properties.Resources.fireIcon;
                btn.BackColor = Color.DarkBlue;
                playerScore += 1;
                txtPlayer.Text = playerScore.ToString();
                EnemyPlayTimer.Start();
            }
            else
            {
                btn.Enabled = false;
                btn.BackgroundImage = Properties.Resources.missIcon;
                btn.BackColor = Color.DarkBlue;
                EnemyPlayTimer.Start();
            }
        }

        private void btnBomb_Click_1(object sender, EventArgs e)
        {
            if (round <= 0 || totalShips > 0)
                return;

            MessageBox.Show("Bomb activated! Game Over!", "Bomb Activated");
            
            if (bombActivated)
            {
                MessageBox.Show("You win! The enemy clicked on their bomb!", "Game Over");
            }
            else
            {
                MessageBox.Show("You lost! You clicked your own bomb.", "Game Over");
            }

    
            RestartGame();
        }

        private void btnMysteryBox_Click_1(object sender, EventArgs e)
        {
            if (mysteryBoxUsed)
            {
                MessageBox.Show("You have already used the Mystery Box this round!", "Mystery Box");
                return;
            }

            mysteryBoxUsed = true;

            Random rand = new Random();
            int reward = rand.Next(3); 

            if (reward == 0)
            {
                MessageBox.Show("Mystery Box: Bonus 1 Point!");
                playerScore += 1;
                txtPlayer.Text = playerScore.ToString();
            }
            else if (reward == 1)
            {
                MessageBox.Show("Mystery Box: Enemy Tile Revealed!");
                RevealRandomEnemyTile();
            }
            else if (reward == 2)
            {
                MessageBox.Show("Mystery Box: Ouch! Lose 1 Round!");
                round -= 1;
                txtRounds.Text = "Round: " + round;
            }

            btnMysteryBox.Enabled = false; 
        }

        private void RevealRandomEnemyTile()
        {
            var hiddenTiles = enemyPositionButtons.Where(btn => btn.Enabled).ToList();
            int index = rand.Next(hiddenTiles.Count);
            Button revealedButton = hiddenTiles[index];
            revealedButton.BackColor = Color.Gray;
            revealedButton.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
