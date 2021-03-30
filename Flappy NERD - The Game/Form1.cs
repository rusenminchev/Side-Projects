using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBirdTheGame
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottoom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score " + score;

            if (pipeBottoom.Left < -70)
            {
                pipeBottoom.Left = 650;
                score++;
            }
            if (pipeTop.Left < -100)
            {
                pipeTop.Left = 800;
                score++;
            }


            if (flappyBird.Bounds.IntersectsWith(pipeBottoom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
                    flappyBird.Top < -25)
            {
                EndGame();
            }

            if (score > 5)
            {
                pipeSpeed = 15;
            }
        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }

        private void gameKeyIsUp(object sender, KeyPressEventArgs e)
        {

        }

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }

        private void EndGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over!";

        }

    }
}
