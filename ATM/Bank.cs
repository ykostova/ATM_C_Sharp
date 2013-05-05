using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ATM
{
    public partial class Bank : Form
    {
        Account[] accountArray = { new Account(300, 1111, 111111), new Account(30, 2222, 222222), new Account(250, 3333, 333333) };
        Thread thread1;
        Thread thread2;

        public Bank()
        {
            InitializeComponent();
            
        }


        //On load the Bank Form Shall trigger the two atms running using threading
        private void Bank_Load(object sender, EventArgs e)
        {
            thread1 = new Thread(new ThreadStart(() => new ATM(accountArray).ShowDialog()));
            thread2 = new Thread(new ThreadStart(() => new ATM(accountArray).ShowDialog()));
            thread1.Start();
            thread2.Start();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Button to be responsible for updating the bank data for the account
        private void button1_Click(object sender, EventArgs e)
        {/*
                bank_display.Text = "Account Number:";
                bank_display.AppendText(Environment.NewLine);
                bank_display.AppendText(Environment.NewLine);
                bank_display.AppendText(e.actAccount.getAccountNum().ToString());
                bank_display.AppendText(Environment.NewLine);
                bank_display.AppendText(Environment.NewLine);
                bank_display.Text = "Account Balance:";
                bank_display.AppendText(Environment.NewLine);
                bank_display.AppendText(Environment.NewLine);
                bank_display.AppendText(e.actAccount.getBalance().ToString());
                bank_display.AppendText(Environment.NewLine);
          */
        }
    }
}
