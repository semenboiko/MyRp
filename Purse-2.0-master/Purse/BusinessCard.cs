using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Purse
{
    /*!
     Business card, included 5 methods, detailed at the next comments.
     */

    public class BusinessCard
    {
        IMoney money2 = new Money();
        double percent;

        /*!
         return card balance
         */
        public double GetBalance()
        {
            return money2.GetCash();
        }


        /*!
         recharge cards
         */
        public void Fill(double cash)
        {
            money2.SetCash(money2.GetCash() + cash);
        }


        /*!
          withdrawals from the card
         */
        public double Withdraw(double cash)
        {
            if ((money2.GetCash() - cash) < 0)
            {
                MessageBox.Show("Your withdraw is bigger than balance, please enter another sum.");
                return 0;
            }
            else
            {
                money2.SetCash(money2.GetCash() - cash);
                MessageBox.Show("Done");
                return (cash);
            }
        }


        /*!
          make a deposit
         */
        public void MakeDeposite(double cash)
        {
            if (money2.GetCash() < 1000)
            {
                money2.SetCash(money2.GetCash()*1.15);
                MessageBox.Show("Your deposit of 15% per year");
            }

            if (money2.GetCash() >= 1000 && money2.GetCash() < 3000)
            {
                money2.SetCash(money2.GetCash() * 1.20);
                MessageBox.Show("Your deposit of 20% per year");
            }

            if (money2.GetCash() >= 3000)
            {
                money2.SetCash(money2.GetCash() * 1.25);
                MessageBox.Show("Your deposit of 25% per year");
            }
        }

        /*!
          withdrawals costs from the deposit
        */
        public double WithdrawDeposite(double cash)
        {
            if ((money2.GetCash() - cash) < 0)
            {
                MessageBox.Show("Your withdraw is bigger than balance, please enter another sum.");
                return 0;
            }
            else
            {
                money2.SetCash(money2.GetCash() - cash);
                MessageBox.Show("Done");
                return (cash);
            }
        }
    }
}
