using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class Form1 : Form
    {
        //true- X , false-O
        bool playerTurn = true;
        int turnCount = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_MouseClick(object sender, MouseEventArgs e)
        {

            Button btn = (Button)sender;

            if (playerTurn)
            {
                btn.Text = "X";
                btn.Enabled = false;
            }
            else
            {
                btn.Text = "O";
                btn.Enabled = false;
            }

            //for the draws, the maxium play is 9
            turnCount++;
            playerTurn = !playerTurn;
            checkWinner();



        }

        public void checkWinner()
        {

            bool checkWinner = false;

            if ((btn1.Text == btn2.Text) && (btn2.Text == btn3.Text) && (!btn2.Enabled))
                checkWinner = true;
            else if ((btn4.Text == btn5.Text) && (btn5.Text == btn6.Text) && (!btn5.Enabled))
                checkWinner = true;
            else if ((btn7.Text == btn8.Text) && (btn8.Text == btn9.Text) && (!btn8.Enabled))
                checkWinner = true;

            // |||
            else if ((btn1.Text == btn4.Text) && (btn4.Text == btn7.Text) && (!btn4.Enabled))
                checkWinner = true;
            else if ((btn2.Text == btn5.Text) && (btn5.Text == btn8.Text) && (!btn5.Enabled))
                checkWinner = true;
            else if ((btn3.Text == btn6.Text) && (btn6.Text == btn9.Text) && (!btn6.Enabled))
                checkWinner = true;

            //X
            else if ((btn1.Text == btn5.Text) && (btn5.Text == btn9.Text) && (!btn5.Enabled))
                checkWinner = true;
            else if ((btn3.Text == btn5.Text) && (btn5.Text == btn7.Text) && (!btn5.Enabled))
                checkWinner = true;


            if (checkWinner)
            {
                String winnerIs = "";

                if (playerTurn)
                    winnerIs = "O";
                else
                    winnerIs = "X";

                MessageBox.Show($"The winner is: {winnerIs} congratilations.");
                newGame();
            }
            else
            {
                if (turnCount == 9)
                {
                    MessageBox.Show("Game is Draw,Play again!");
                    newGame();
                }

            }
        }

        public void newGame()
        {
            playerTurn = true;
            turnCount = 0;

            try
            {

                foreach (Control c in Controls)
                {
                    if (c is Button)
                    {
                        (c as Button).Enabled = true;
                        (c as Button).Text = "";
                    }
                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
    }
}
