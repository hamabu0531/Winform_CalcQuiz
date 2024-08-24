using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcQuiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();
        int addend1, addend2, minuend, substrahend, multiplicand, multiplier, divisor, dividend;
        int timeLeft;
        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                startButton.Enabled = true;
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                timeLabel.BackColor = Color.White;
            }
            else if (timeLeft > 6)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
            }
            else if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
                timeLabel.BackColor = Color.Red;
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You did't finish in time", "Sorry!");
                timeLabel.BackColor = Color.White;
                sum.Value = addend1 + addend2;
                difference.Value = minuend - substrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }
        public void StartTheQuiz()
        {
            SumQuiz();
            MinusQuiz();
            MultiplicandQuiz();
            DivisionQuiz();
            // Start the timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) && (minuend - substrahend == difference.Value)
                && (multiplicand * multiplier == product.Value) && (dividend / divisor == quotient.Value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SumQuiz()
        {
            // Fill in the addition problem.
            // Generate two random numbers to add.
            // Store the values in the variables 'addend1' and 'addend2'.
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Convert the two randomly generated numbers
            // into strings so that they can be displayed
            // in the label controls.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // 'sum' is the name of the NumericUpDown control.
            // This step makes sure its value is zero before
            // adding any values to it.
            sum.Value = 0;
        }
        public void MinusQuiz()
        {
            minuend = randomizer.Next(1, 101);
            substrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = substrahend.ToString();
            difference.Value = 0;
        }
        public void MultiplicandQuiz()
        {
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;
        }
        public void DivisionQuiz()
        {
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;
        }
    }
}
