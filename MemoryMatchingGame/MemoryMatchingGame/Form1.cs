﻿using System;
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

        // Assigning a variable to a turned card and assigning a variable to a 2nd turned card and then comparing them to each other
        PictureBox PendingImage1; // Store 1st flipped card into this variable
        PictureBox PendingImage2; // Store 2nd flipped card into this variable
        
        public GameWindow()
        {
            InitializeComponent();
        }


        private void GameWindow_Load(object sender, EventArgs e)
        {
            // This will disable the user from clicking on / selecting a card during the 5 second preview
            foreach (PictureBox picture in CardsHolder.Controls)
            {
                picture.Enabled = false;
            }
            
            // timer1 will set 5 seconds to the preview of the cards shown face up
            timer1.Start();

            // timer2 will start a 5 second countdown to 0 at the start to preview cards before they are put face down
            timer2.Start();
            
            // Hardcoding every PictureBox picture value
            // So that we can have all the image on display face up for a 5 second preview before they face down
            Card01.Image = Properties.Resources.Card01;
            DupCard01.Image = Properties.Resources.Card01;

            Card02.Image = Properties.Resources.Card02;
            DupCard02.Image = Properties.Resources.Card02;

            Card03.Image = Properties.Resources.Card03;
            DupCard03.Image = Properties.Resources.Card03;

            Card04.Image = Properties.Resources.Card04;
            DupCard04.Image = Properties.Resources.Card04;

            Card05.Image = Properties.Resources.Card05;
            DupCard05.Image = Properties.Resources.Card05;

            Card06.Image = Properties.Resources.Card06;
            DupCard06.Image = Properties.Resources.Card06;

            Card07.Image = Properties.Resources.Card07;
            DupCard07.Image = Properties.Resources.Card07;

            Card08.Image = Properties.Resources.Card08;
            DupCard08.Image = Properties.Resources.Card08;

            Card09.Image = Properties.Resources.Card09;
            DupCard09.Image = Properties.Resources.Card09;

            Card10.Image = Properties.Resources.Card10;
            DupCard10.Image = Properties.Resources.Card10;

            Card11.Image = Properties.Resources.Card11;
            DupCard11.Image = Properties.Resources.Card11;

            Card12.Image = Properties.Resources.Card12;
            DupCard12.Image = Properties.Resources.Card12;         
        }


        // Timer1 and Timer2: Score Timer and Countdown Timer (Timer3 below Region Cards)
        #region Timers
        // This enables the display of the cards face up (for 5 seconds according to timer1)
        private void timer1_Tick(object sender, EventArgs e)
        {
            // This will tell timer1 to stop otherwise it will keep going
            timer1.Stop();

            foreach (PictureBox picture in CardsHolder.Controls)
            {
                // This will enable to user to click on / select a card after the 5 second preview
                picture.Enabled = true;
                
                // After the 5 second preview the cursor arrow will change into a cursor hand
                picture.Cursor = Cursors.Hand;

                // This places an image as backcover to each card
                picture.Image = Properties.Resources.CardBackCover;
            }
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            // This will convert the 5 of CountdownCounter from a string to a number (int)
            int timer = Convert.ToInt32(CountdownCounter.Text);

            // This will subtract 1 second from the CountdownCounter and put the 4 back into timer2 and so forth
            timer = timer-1;

            // Because labels only take string values, we have to convert the counting down int result back to a string
            // CountdownCounter is a label
            CountdownCounter.Text = Convert.ToString(timer);

            // We have make a condition to stop timer2 when it gets to zero otherwise it keeps counting down infinitely
            if (timer == 0)
            {
                timer2.Stop();
            }
        }
        #endregion

        // Change Card Value
        #region Cards
        // When we click on a card we want it to flip over to show its face value (the image)
        private void Card01_Click(object sender, EventArgs e)
        {
            Card01.Image = Properties.Resources.Card01;

            // If PendingImage variables are emtpy (no value in it) then no card is selected / turned (or are already matched)
            // PendingImages are not matched and can hold a maximum of two cards (to be compared)

            // If PendingImage1 is has no value (null) then assign Card01 to PendingImage1
            if (PendingImage1 == null)
            {
                PendingImage1 = Card01;
            }

            // If PendingImage1 already has a value assigned to it, then check if PendingImage2 is empty
            // If PendingImage2 has no value assigned to it, then we need to store Card01 in PendingImage2
            // != means: is not equal to | && means: and at the same time
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card01;
            }

            // If both PendingImages have values assigned to it, then we can compare them to each other right now
            // In actuality we are checking if the tags we assigned to the cards earlier are of equal value
            // == means: is equal to
            if (PendingImage1 != null && PendingImage2 != null)
            {
                // If the tags are similar to each other, we are just going to leave them face up
                if (PendingImage1.Tag == PendingImage2.Tag)
                {

                }

                // If they are not similar to each other, then we'll flip both cards face down again
                // See timer3 below all the cards
                else
                {
                    timer3.Start();
                }
            }
        }


        private void DupCard01_Click(object sender, EventArgs e)
        {
            DupCard01.Image = Properties.Resources.Card01;

            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard01;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard01;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {

                }
                else
                {
                    timer3.Start();
                }
            }
        }


        private void Card02_Click(object sender, EventArgs e)
        {
            Card02.Image = Properties.Resources.Card02;

            if (PendingImage1 == null)
            {
                PendingImage1 = Card02;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card02;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {

                }
                else
                {
                    timer3.Start();
                }
            }
        }


        private void DupCard02_Click(object sender, EventArgs e)
        {
            DupCard02.Image = Properties.Resources.Card02;

            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard02;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard02;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {

                }
                else
                {
                    timer3.Start();
                }
            }
        }


        private void Card03_Click(object sender, EventArgs e)
        {
            Card03.Image = Properties.Resources.Card03;
        }

        private void DupCard03_Click(object sender, EventArgs e)
        {
            DupCard03.Image = Properties.Resources.Card03;
        }

        private void Card04_Click(object sender, EventArgs e)
        {
            Card04.Image = Properties.Resources.Card04;
        }

        private void DupCard04_Click(object sender, EventArgs e)
        {
            DupCard04.Image = Properties.Resources.Card04;
        }

        private void Card05_Click(object sender, EventArgs e)
        {
            Card05.Image = Properties.Resources.Card05;
        }

        private void DupCard05_Click(object sender, EventArgs e)
        {
            DupCard05.Image = Properties.Resources.Card05;
        }

        private void Card06_Click(object sender, EventArgs e)
        {
            Card06.Image = Properties.Resources.Card06;
        }

        private void DupCard06_Click(object sender, EventArgs e)
        {
            DupCard06.Image = Properties.Resources.Card06;
        }

        private void Card07_Click(object sender, EventArgs e)
        {
            Card07.Image = Properties.Resources.Card07;
        }

        private void DupCard07_Click(object sender, EventArgs e)
        {
            DupCard07.Image = Properties.Resources.Card07;
        }

        private void Card08_Click(object sender, EventArgs e)
        {
            Card08.Image = Properties.Resources.Card08;
        }

        private void DupCard08_Click(object sender, EventArgs e)
        {
            DupCard08.Image = Properties.Resources.Card08;
        }

        private void Card09_Click(object sender, EventArgs e)
        {
            Card09.Image = Properties.Resources.Card09;
        }

        private void DupCard09_Click(object sender, EventArgs e)
        {
            DupCard09.Image = Properties.Resources.Card09;
        }

        private void Card10_Click(object sender, EventArgs e)
        {
            Card10.Image = Properties.Resources.Card10;
        }

        private void DupCard10_Click(object sender, EventArgs e)
        {
            DupCard10.Image = Properties.Resources.Card10;
        }

        private void Card11_Click(object sender, EventArgs e)
        {
            Card11.Image = Properties.Resources.Card11;
        }

        private void DupCard11_Click(object sender, EventArgs e)
        {
            DupCard11.Image = Properties.Resources.Card11;
        }

        private void Card12_Click(object sender, EventArgs e)
        {
            Card12.Image = Properties.Resources.Card12;
        }

        private void DupCard12_Click(object sender, EventArgs e)
        {
            DupCard12.Image = Properties.Resources.Card12;
        }
        #endregion


        // Timer3: Time the cards remain face up after being selected and they are not the same
        private void timer3_Tick(object sender, EventArgs e)
        {
            // If they are not similar, they will flip face down again after 7 seconds
            timer3.Stop();
            PendingImage1.Image = Properties.Resources.CardBackCover;
            PendingImage2.Image = Properties.Resources.CardBackCover;

            // After being compared, they have to be set to null again
            PendingImage1 = null;
            PendingImage2 = null;
        }
    }
}
