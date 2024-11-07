﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_App
{
    public partial class DebitForm : Form
    {
        public DebitForm()
        {
            InitializeComponent();
            loaddate();
            loadmode();
        }

        private void loadmode()
        {
            comboBox1.Items.Add("Cash");
            comboBox1.Items.Add("Cheque");
        }

        private void loaddate()
        {
            datelbl.Text = DateTime.Now.ToString("MM/dd/yyy");
        }

        private void DebitForm_Load(object sender, EventArgs e)
        {

        }

        private void Detailsbutton_Click(object sender, EventArgs e)
        {
            banking_dbEntities1 context = new banking_dbEntities1();
            newAccount acc = new newAccount();
            Deposit dp = new Deposit();
            dp.Date = datelbl.Text;
            dp.AccountNo = Convert.ToDecimal(acctxt.Text);
            dp.Name = nametxt.Text;
            dp.OldBalance = Convert.ToDecimal(oldbaltxt.Text);
            dp.Mode = comboBox1.SelectedItem.ToString();
            dp.DipAmount = Convert.ToDecimal(amounttxt.Text);
            context.Deposits.Add(dp);
            context.SaveChanges();
            decimal b = Convert.ToDecimal(acctxt.Text);
            var item = (from u in context.userAccounts where u.Account_No == b select u).FirstOrDefault();
            decimal x = Convert.ToDecimal(amounttxt.Text);
            if(x>item.balance)
            {
                MessageBox.Show("Insufficient balance");
            }
            else
            {
            item.balance = item.balance - x;
            context.SaveChanges();
            MessageBox.Show("Money Withdrawn Successfully");
            }
            
        }

        private void Dipbutton_Click(object sender, EventArgs e)
        {
            banking_dbEntities1 context = new banking_dbEntities1();
            decimal b = Convert.ToDecimal(acctxt.Text);
            var item = (from u in context.userAccounts where u.Account_No == b select u).FirstOrDefault();
            nametxt.Text = item.Name;
            oldbaltxt.Text = Convert.ToString(item.balance);
        }
    }
}