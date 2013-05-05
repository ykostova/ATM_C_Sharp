using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATM
{
    public partial class ATM : Form
    {
        //String to monitor the current user input as string
        string input = "";

        //A number that will take the the converted string input
        int inputNumber = 0;

        //boolean to indicate whether the input is a pin so that it hides the numbers
        bool pinEnter = false;

        /*An integer to indicate which level through the menus the program has reached
        //0 - input of account and pin
        //1 - loading main menu options
        //2 - loading withdraw cash options
         */
        int menu = 0;

        int stepCounter = 1;

        //local referance to the array of accounts
        public Account[] accounts;

        //referance to the account that is being used
        public Account activeAccount = null;

        // the atm constructor takes an array of account objects as a referance
        public ATM(Account[] acc)
        {
            InitializeComponent();
            //Sets the controls
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            display.ReadOnly = true;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            display.ScrollBars = ScrollBars.Vertical;
            display.AcceptsReturn = true;
            //Sets the local accounts array data
            this.accounts = acc;
            //Sets up the display according to current settings
            display.Text = "Hello from AC22005 ATM Machine";
            display.AppendText(Environment.NewLine);
            display.AppendText(Environment.NewLine);
            display.AppendText("Enter your account number:");
            display.AppendText(Environment.NewLine);
            display.AppendText(Environment.NewLine);
            this.ShowDialog();
        }

        private void ATM_Load(object sender, EventArgs e)
        {
            
        }

        //Method to display the menu options
        private void displayOptions()
        {
            menu = 1;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox4.Text = "Withdraw cash";
            textBox5.Text = "Check balance";
            textBox6.Text = "Exit";
            display.ScrollBars = ScrollBars.None;
            display.AcceptsReturn = false;
        }

        //Method to display the cash withdraw options
        private void displayWithdraw()
        {
            menu = 2;
            textBox4.Text = "£10.00";
            textBox5.Text = "£50.00";
            textBox6.Text = "£500.00";
        }

        //Method to display the balance
        private void displayBalance()
        {
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
                display.Text = "Your current balance is : £" + activeAccount.getBalance() + ".00";
                display.AppendText(Environment.NewLine);
                display.AppendText(Environment.NewLine);
                display.AppendText("press enter to continue...");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void display_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        //First Right Side Button event handler
        private void button4_Click(object sender, EventArgs e)
        {
            //if first stage do nothing
            if (menu == 0)
            {
            }
            //if main menu stage display withdraw options
            else if (menu == 1) displayWithdraw();
            //if other menu state decrement the balance on withdrowal by 10
            else 
            {
                if (activeAccount.decrementBalance(10))
                {
                    textBox4.Visible = false;
                    textBox5.Visible = false;
                    textBox6.Visible = false;
                    display.Text = "Withdrawn £10.00";
                    display.AppendText(Environment.NewLine);
                    display.AppendText("Your NEW balance is : £" + activeAccount.getBalance() + ".00");
                    display.AppendText(Environment.NewLine);
                    display.AppendText(Environment.NewLine);
                    display.AppendText("press enter to continue...");
                    menu = 1;
                }
                else
                {
                    textBox4.Visible = false;
                    textBox5.Visible = false;
                    textBox6.Visible = false;
                    display.Text = "Withdrawal £10.00 DENIED ";
                    display.AppendText(Environment.NewLine);
                    display.AppendText(Environment.NewLine);
                    display.AppendText("INSUFFICIENT FUNDS");
                    display.AppendText(Environment.NewLine);
                    display.AppendText(Environment.NewLine);
                    display.AppendText("press enter to continue...");
                    menu = 1;
                }
            }
        }

        //Second Right Side Button event handler
        private void button5_Click(object sender, EventArgs e)
        {
            //if first stage do nothing
            if (menu == 0){}
            //if main menu stage display withdraw options
            else if (menu == 1) displayBalance();
            //if other menu state decrement the balance on withdrowal by 50
            else 
            { 
                if (activeAccount.decrementBalance(50))
                {
                    textBox4.Visible = false;
                    textBox5.Visible = false;
                    textBox6.Visible = false;
                    display.Text = "Withdrawn £50.00";
                    display.AppendText(Environment.NewLine);
                    display.AppendText("Your NEW balance is : £" + activeAccount.getBalance() + ".00");
                    display.AppendText(Environment.NewLine);
                    display.AppendText(Environment.NewLine);
                    display.AppendText("press enter to continue...");
                    menu = 1;
                }
                else
                {
                    textBox4.Visible = false;
                    textBox5.Visible = false;
                    textBox6.Visible = false;
                    display.Text = "Withdrawal £50.00 DENIED ";
                    display.AppendText(Environment.NewLine);
                    display.AppendText(Environment.NewLine);
                    display.AppendText("INSUFFICIENT FUNDS");
                    display.AppendText(Environment.NewLine);
                    display.AppendText(Environment.NewLine);
                    display.AppendText("press enter to continue...");
                    menu = 1;
                }
            }
        }

        //Third Right Side Button event handler
        private void button6_Click(object sender, EventArgs e)
        {
            //if first stage do nothing
            if (menu == 0) 
            {
            }
            //if main menu stage display withdraw options
            else if (menu == 1) this.Close();
            //if other menu state decrement the balance on withdrowal by 500
            else
            { 
                if (activeAccount.decrementBalance(500))
                {
                    textBox4.Visible = false;
                    textBox5.Visible = false;
                    textBox6.Visible = false;
                    display.Text = "Withdrawn £500.00";
                    display.AppendText(Environment.NewLine);
                    display.AppendText("Your NEW balance is : £" + activeAccount.getBalance() + ".00");
                    display.AppendText(Environment.NewLine);
                    display.AppendText(Environment.NewLine);
                    display.AppendText("press enter to continue...");
                    menu = 1;
                }
                else
                {
                    textBox4.Visible = false;
                    textBox5.Visible = false;
                    textBox6.Visible = false;
                    display.Text = "Withdrawal £500.00 DENIED ";
                    display.AppendText(Environment.NewLine);
                    display.AppendText(Environment.NewLine);
                    display.AppendText("INSUFFICIENT FUNDS");
                    display.AppendText(Environment.NewLine);
                    display.AppendText(Environment.NewLine);
                    display.AppendText("press enter to continue...");
                    menu = 1;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

/***************** Event Handlers on digit buttons
              if it is pin add a * to the display other wise add the number 
               both to the display and to the input string****************************************/

        private void zero_btn_Click(object sender, EventArgs e)
        {
            if (pinEnter) display.Text += "*";
            else display.Text += "0";
            input += "0";
        }

        private void one_btn_Click(object sender, EventArgs e)
        {
            if (pinEnter) display.Text += "*";
            else display.Text += "1";
            input += "1";
        }

        private void two_btn_Click(object sender, EventArgs e)
        {
            if (pinEnter) display.Text += "*";
            else display.Text += "2";
            input += "2";
        }

        private void three_btn_Click(object sender, EventArgs e)
        {
            if (pinEnter) display.Text += "*";
            else display.Text += "3";
            input += "3";
        }

        private void four_btn_Click(object sender, EventArgs e)
        {
            if (pinEnter) display.Text += "*";
            else display.Text += "4";
            input += "4";
        }

        private void five_btn_Click(object sender, EventArgs e)
        {
            if (pinEnter) display.Text += "*";
            else display.Text += "5";
            input += "5";
        }

        private void six_btn_Click(object sender, EventArgs e)
        {
            if (pinEnter) display.Text += "*";
            else display.Text += "6";
            input += "6";
        }

        private void seven_btn_Click(object sender, EventArgs e)
        {
            if (pinEnter) display.Text += "*";
            else display.Text += "7";
            input += "7";
        }

        private void eight_btn_Click(object sender, EventArgs e)
        {
            if (pinEnter) display.Text += "*";
            else display.Text += "8";
            input += "8";
        }

        private void nine_btn_Click(object sender, EventArgs e)
        {
            if (pinEnter) display.Text += "*";
            else display.Text += "9";
            input += "9";
        }
        
        //Cancel Button takes the user to the menu if on the menu part
        //if in the beginning takes to the start up display
        private void cancel_btn_Click(object sender, EventArgs e)
        {
            if (stepCounter < 3)
            {
                display.Text = "Hello from AC22005 ATM Machine";
                display.AppendText(Environment.NewLine);
                display.AppendText(Environment.NewLine);
                display.AppendText("Enter your account number:");
                display.AppendText(Environment.NewLine);
                display.AppendText(Environment.NewLine);
                stepCounter = 1;
            }
            else
            {
                stepCounter=3;
                display.Text = "Choose an option:";
                displayOptions();
            }
        }

        //Clears the current input string and all of it from the display
        private void clear_btn_Click(object sender, EventArgs e)
        {
            int len = input.Length;
            display.Text = display.Text.Remove((display.Text.Length-len), len);
            input = "";
        }

        /*
         * Enter Button Event Handler Handles All the Steps the User is Taken Through
         * during the use of the ATM
         */
        private void enter_btn_Click(object sender, EventArgs e)
        {
            //If beginning do nothing
            if(menu!=0)
            {
               // this.Owner.ShowDialog();
            }
            //if its the last step thus in the middle of the menu add -1 to allow emulate do nothing on press enter
            //just go back to menu
            if (stepCounter == 3) input = "-1";

            //Validates if the input is empty
            if(input.Equals(""))
            {
                display.AppendText(Environment.NewLine);
                display.AppendText("INVALID INPUT");
                display.AppendText(Environment.NewLine);
            }
            //If the input is valid
            else
            {
                //Convert the input string to a number
                inputNumber = Convert.ToInt32(input);
                input = "";
                display.AppendText(Environment.NewLine);

                //Check which step at the program the user is
                switch (stepCounter)
                {
                    /*
                     * First step is gettin the account number
                     *  - if valid takes through to pin
                     *  - else repeat
                     */
                    case 1: int inputAcc = inputNumber;
                            inputNumber = 0;
                            for (int i = 0; i < this.accounts.Length; i++)
                            {
                                if (accounts[i].getAccountNum() == inputAcc)
                                {
                                    activeAccount =  accounts[i];
                                    stepCounter++;
                                    display.AppendText(Environment.NewLine);
                                    display.AppendText("Enter pin:");
                                    display.AppendText(Environment.NewLine);
                                    display.AppendText(Environment.NewLine);
                                    pinEnter = true;
                                }
                            }
                            if (activeAccount == null) 
                            {
                                display.Text = "No matching account found.";
                                display.AppendText(Environment.NewLine);
                                display.AppendText(Environment.NewLine);
                                display.AppendText("Enter your account number:");
                                display.AppendText(Environment.NewLine);
                                display.AppendText(Environment.NewLine);
                            }
                            break;

                    /*
                     * Second step is gettin the pin number
                     *  - if valid takes through to main menu
                     *  - else repeat
                     */
                    case 2: int inputPin = inputNumber;
                            inputNumber = 0;
                            if (activeAccount.checkPin(inputPin))
                            {
                                pinEnter = false;
                                stepCounter++;
                                display.Text = "Choose an option:";
                                displayOptions();
                            }
                            else
                            {
                                display.Text = "Wrong pin entered.";
                                display.AppendText(Environment.NewLine);
                                display.AppendText(Environment.NewLine);
                                display.AppendText("Enter your pin:");
                                display.AppendText(Environment.NewLine);
                                display.AppendText(Environment.NewLine);
                            }
                            break;

                    /*
                     * Third step is gettin the chosen option
                     */
                    case 3: inputNumber = 0;
                            display.Text = "Choose an option:";
                            displayOptions();
                            break;

                    default: break;
                }
            }
        }
    }
}
