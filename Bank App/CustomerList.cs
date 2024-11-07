using System;
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
    public partial class CustomerList : Form
    {
        public CustomerList()
        {
            InitializeComponent();
            bindgrid();
        }

        private void bindgrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            banking_dbEntities1 bs = new banking_dbEntities1();
            var item = bs.userAccounts.ToList();
            dataGridView1.DataSource = item;
        }

        private void CustomerList_Load(object sender, EventArgs e)
        {

        }
    }
}
