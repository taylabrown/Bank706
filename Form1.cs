using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Part_C
{
    public partial class Form1 : Form
    {
        private List<Account> myA = new List<Account>();
        public Form1()
        {
            InitializeComponent();
            MakeAccounts();
            DisplayAccounts();
        }

        private void MakeAccounts()
        {
            myA.Add(new Everyday());
            myA.Add(new Investment(5, 10));
            myA.Add(new Omni(5, 10, -100));

            // Setting balance
            myA[0].Balance = 50;
            myA[1].Balance = 500;
            myA[2].Balance = 5000;
        }


        // Withdraws
        public void Withdraw()
        {
            Account account = (Account)listBox1.SelectedItem;

            account.Withdraw(decimal.Parse(textBoxWithdraw.Text));
            textBoxtransactions.Text = account.GetLastTransaction();
        }

        private void buttonWithdraw_Click_1(object sender, EventArgs e)
        {
            Withdraw();
        }



        // Deposits
        private void Deposit()
        {
            Account account = (Account)listBox1.SelectedItem;

            account.Deposit(decimal.Parse(textBoxDeposit.Text));
            textBoxtransactions.Text = account.GetLastTransaction();
        }
       
        private void buttonDeposit_Click_1(object sender, EventArgs e)
        {
            Deposit();
        }

        // Displays Account
        private void DisplayAccounts()
        {
            listBox1.Items.Clear();
            foreach (Account a in myA)
            {
                listBox1.Items.Add(a);
            }
            listBox1.SelectedIndex = 0;
        }


       

        // Displays accounts details
        private void DisplayDetails()
        {
            textBoxtransactions.Clear();
            Account account = (Account)listBox1.SelectedItem;
            textBoxtransactions.Text = account.Details();
        }

        // Displays Details
        private void button1_Click(object sender, EventArgs e)
        {
            DisplayDetails();

        }

        // Displays Transaction
        private void buttonTransaction_Click(object sender, EventArgs e)
        {
            Account account = (Account)listBox1.SelectedItem;
            textBoxtransactions.Text = account.GetLastTransaction();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxtransactions.Clear();
            textBoxDeposit.Clear();
            textBoxWithdraw.Clear();
        }

     
    }

}
