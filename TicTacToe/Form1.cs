using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool turn = true; //true = X; false = O;
        int turnCount = 0;
        int XScore = 0;
        int OScore = 0;
        int draw = 0;
        int roundCount = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Kenneth");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
                label5.Text = "O's Turn";
            }
            else { 
                b.Text = "O";
                label5.Text = "X's Turn";
            }
            turn = !turn;
            b.Enabled = false;
            turnCount++;

            checkForWinner();
        }

        private void checkForWinner()
        {

            bool thereIsAWinner = false;
            //Horizontal check
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                thereIsAWinner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                thereIsAWinner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                thereIsAWinner = true;

            //Vertical check
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                thereIsAWinner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                thereIsAWinner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                thereIsAWinner = true;

            //Diagonal check
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                thereIsAWinner = true;
            else if ((C1.Text == B2.Text) && (B2.Text == A3.Text) && (!C1.Enabled))
                thereIsAWinner = true;

            if (thereIsAWinner)
            {
                disableButtons();

                String winner = "";
                if (turn)
                {
                    winner = "O";
                    OScore++;
                    label5.Text = "O Won";
                }
                else
                {
                    winner = "X";
                    XScore++;
                    label5.Text = "X Won";
                }

                label1.Text = "X Score: " + XScore;
                label2.Text = "O Score: " + OScore;
                

                MessageBox.Show(winner + " wins!", "Yay!");
                nextRound.Enabled = true;
            }
            else
            {
                if(turnCount == 9 && (thereIsAWinner == false))
                {
                    draw++;

                    label3.Text = "Draw: " + draw;

                    MessageBox.Show("Draw!", "Close!");
                    nextRound.Enabled = true;

                }
            }
        }//end checkForWinner

        private void disableButtons()
        {
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turnCount = 0;
            XScore = 0;
            OScore = 0;
            draw = 0;
            roundCount = 1;
            label1.Text = "X Score: 0";
            label2.Text = "O Score: 0";
            label3.Text = "Draw: 0";
            label4.Text = "Round 1";
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            nextRound.Enabled = false;
            nextRound.Text = "Next Round";
        }

        private void nextRound_Click(object sender, EventArgs e)
        {
            roundCount++;
            turn = true;
            turnCount = 0;
            label4.Text = "Round " + roundCount;
            label5.Text = "X's Turn";
            foreach(Control c in Controls)
            {
                if(c.GetType() == typeof(Button))
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            nextRound.Enabled = false;
            nextRound.Text = "Next Round";
        }
    }
}
