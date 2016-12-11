using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Purse
{
    /// Форма, в которой представлено управление классом Purse

    public partial class Form1 : Form
    {
        Purse purse = new Purse();

        public Form1()
        {
            InitializeComponent();
            this.Text = "Cash : " + purse.cash.GetCash().ToString() + "  UAH";
        }

        private void button_Fill_Click(object sender, EventArgs e)
        {
            try
            {
                if (purse.cash.GetCash() < Convert.ToDouble(textBox_fill.Text))
                {
                    MessageBox.Show("Not enough money");
                }
                else
                {
                    purse.cash.SetCash(purse.cash.GetCash() - Convert.ToDouble(textBox_fill.Text));
                    purse.goldCard.Fill(Convert.ToDouble(textBox_fill.Text));
                    label_goldBalance.Text = purse.goldCard.GetBalance().ToString();
                    this.Text = "Cash : " + purse.cash.GetCash().ToString() + "  UAH";
                }
            }
            catch
            {
                MessageBox.Show("Type digit amount");
            }
        }

        private void button_Withdraw_Click(object sender, EventArgs e)
        {
            try
            {
                double res = purse.goldCard.Withdraw(Convert.ToDouble(textBox_withdraw.Text));
                purse.cash.SetCash(purse.cash.GetCash() + res);
                label_goldBalance.Text = purse.goldCard.GetBalance().ToString();
                this.Text = "Cash : " + purse.cash.GetCash().ToString() + "  UAH";
            }
            catch
            {
                MessageBox.Show("Type digit amount");
            }
        }

        private void button_ConvertUsd_Click(object sender, EventArgs e)
        {
            purse.goldCard.ConvertToUSD();
            label_goldBalance.Text = purse.goldCard.GetBalance().ToString();
            label_valuta.Text = "USD";
        }

        private void button_ConvertUah_Click(object sender, EventArgs e)
        {
            purse.goldCard.ConvertToUAH();
            label_goldBalance.Text = purse.goldCard.GetBalance().ToString();
            label_valuta.Text = "UAH";
        }

        private void button_TakeCredit_Click(object sender, EventArgs e)
        {
            try
            {
                if (purse.cash.GetCash() < Convert.ToDouble(textBox_TakeCredit.Text))
                    MessageBox.Show("Not enough money");
                else if(purse.credCard.GetCredit() == 0)
                    MessageBox.Show("No need to pay");
                else
                {
                    purse.credCard.PayCredit(purse.cash);
                    label_creditBalance.Text = purse.credCard.GetBalance().ToString();
                }
            }
            catch
            {
                MessageBox.Show("Type digit amount");
            }
        }

        private void button_withdrawCredit_Click(object sender, EventArgs e)
        {
            double res = purse.credCard.Withdraw(purse.credCard.GetBalance());
            purse.cash.SetCash(purse.cash.GetCash() + res);
            label_creditBalance.Text = purse.credCard.GetBalance().ToString();
            this.Text = "Cash : " + purse.cash.GetCash().ToString() + "  UAH";
        }

        private void button_ReturnCredit_Click(object sender, EventArgs e)
        {
            if (purse.cash.GetCash() < Convert.ToDouble(textBox_TakeCredit.Text))
                MessageBox.Show("Not enough money");
            else if (purse.credCard.GetCredit() != 0)
                MessageBox.Show("You already have taken credit. Pay previous to take new one.");
            else
            {
                purse.cash.SetCash(purse.cash.GetCash() - Convert.ToDouble(textBox_fill.Text));
                purse.credCard.CalculateTheCredit(textBox_TakeCredit.Text);
                label_creditBalance.Text = purse.credCard.GetBalance().ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (purse.cash.GetCash() < Convert.ToDouble(textBox4.Text))
                    MessageBox.Show("Not enough money");

                else
                {
                    purse.cash.SetCash(purse.cash.GetCash() - Convert.ToDouble(textBox4.Text));
                    purse.busCard.Fill(Convert.ToDouble(textBox4.Text));
                    label_businessBalance.Text = purse.busCard.GetBalance().ToString();
                    this.Text = "Cash : " + purse.cash.GetCash().ToString() + "  UAH";

                }
            }
            catch
            {
                MessageBox.Show("Input error! Only digits.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (purse.cash.GetCash() < Convert.ToDouble(textBox4.Text))
                MessageBox.Show("Not enough money");

                else
                {
                    double res = purse.busCard.Withdraw(Convert.ToDouble(textBox3.Text));
                    purse.cash.SetCash(purse.cash.GetCash() + res);
                    label_businessBalance.Text = purse.busCard.GetBalance().ToString();
                    this.Text = "Cash : " + purse.cash.GetCash().ToString() + "  UAH";

                }
            }
            catch
            {
                MessageBox.Show("Input error! Only digits.");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (purse.cash.GetCash() < Convert.ToDouble(textBox4.Text))
                MessageBox.Show("Not enough money");

                else
                {
                    purse.cash.SetCash(purse.cash.GetCash() - Convert.ToDouble(textBox4.Text));
                    purse.busCard.MakeDeposite(Convert.ToDouble(label_businessBalance.Text));
                    label_DepositeBalance.Text = purse.busCard.GetBalance().ToString();
                    this.Text = "Cash : " + purse.cash.GetCash().ToString() + "  UAH";
                    if (Convert.ToDouble(label_businessBalance.Text) < 1000)
                        label_DepositePercent.Text = "15";
                    if (Convert.ToDouble(label_businessBalance.Text) >= 1000 && Convert.ToDouble(label_businessBalance.Text) < 3000)
                        label_DepositePercent.Text = "20";
                    if (Convert.ToDouble(label_businessBalance.Text) >= 3000)
                        label_DepositePercent.Text = "25";
                }
            }
            catch
            {
                MessageBox.Show("Input error! Only digits.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (purse.cash.GetCash() < Convert.ToDouble(label_DepositeBalance.Text))
                    MessageBox.Show("Not enough money");

                else
                {
                    double res = purse.busCard.WithdrawDeposite(Convert.ToDouble(textBox3.Text));
                    purse.cash.SetCash(purse.cash.GetCash() + res);
                    label_DepositeBalance.Text = purse.busCard.GetBalance().ToString();
                    this.Text = "Cash : " + purse.cash.GetCash().ToString() + "  UAH";

                }
            }
            catch
            {
                MessageBox.Show("Input error! Only digits.");
            }
        }
    }
}
