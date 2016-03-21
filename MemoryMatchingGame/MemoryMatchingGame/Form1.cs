using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryMatchingGame
{
    public partial class GameWindow : Form
    {
        // Variables 
        // Usually it's not good to assign variable at the top. When program loads it's gonna take up some memory.
        // But this game is very small so it's fine.

        int score = 0;   // Ours Scores
        Random Location = new Random();  // Selects a randome value from X and Y list and assigns a new location to each card
        List<int> X = new List<int>();   // X Values of each PictureBox
        List<int> Y = new List<int>();   // Y Values of each PictureBox
        bool again = false;   // Play game again or not 

        
        public GameWindow()
        {
            InitializeComponent();
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            foreach(PictureBox picture in CardsHolder.Controls)
            {
                picture.Image = Properties.Resources.CardBackCover;
            }
        }
    }
}
