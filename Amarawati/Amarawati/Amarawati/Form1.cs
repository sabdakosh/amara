using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using MetroFramework.Controls;

namespace Amarawati
{
    public partial class Amarawati : MetroForm
    {
        public Amarawati()
        {
            InitializeComponent();
        }
        member aa = new member();//member object
        Class1 cla = new Class1(); //class that have get , edit ,delete function
        string old=null;
        
        private void FormMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'amarawati_databaseDataSet.Member_Table' table. You can move, or remove it, as needed.
            //this.member_TableTableAdapter.Fill(this.amarawati_databaseDataSet.Member_Table);
            // TODO: This line of code loads data into the 'amarawati_databaseDataSet.Member_Ledger' table. You can move, or remove it, as needed.
            //this.member_LedgerTableAdapter.Fill(this.amarawati_databaseDataSet.Member_Ledger);
            // TODO: This line of code loads data into the 'amarawati_databaseDataSet.Member_Table' table. You can move, or remove it, as needed.
            //this.member_TableTableAdapter.Fill(this.amarawati_databaseDataSet.Member_Table);
           
            load();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void member_btn_Click(object sender, EventArgs e)
        {
            member_btn.Width = 170;
            members_panel.BringToFront();
        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void metroTile1_Click_1(object sender, EventArgs e)
        {
            if (metroTile1.Text == "Add")
            {
                getdata();
                cla.add(aa);
                load();
            }
            else if(metroTile1.Text=="Update")
            {
                //MessageBox.Show("update");
                getdata();
                cla.edit(aa, old);
                load();
            }
        }

        void getdata()
        {
            aa.House_no = metroTextBox1.Text;
            aa.Name = metroTextBox4.Text;
            aa.Phone_no = metroTextBox3.Text;
            aa.Email = metroTextBox2.Text;
        }

        //load from database to gridview
        void load()
        {
            metroGrid1.Rows.Clear();
            List<object[]> test = new List<object[]>();
            test = cla.get();
            foreach (object[] test1 in test)
            {
                metroGrid1.Rows.Add(test1);
            }
        
        }

        
        private void metroGrid1_SelectionChanged(object sender, EventArgs e)
        {
            metroTile1.Text = "Update";
            DataGridViewRow aa = metroGrid1.CurrentRow;
            int i = 0;
            string[] temp = new string[5];
            foreach (DataGridViewCell cc in aa.Cells)
            {
                temp[i] = cc.Value.ToString();
                i++;
            }
            old = temp[0];
            metroTextBox1.Text = temp[0];
            metroTextBox4.Text = temp[1];
            metroTextBox3.Text = temp[2];
            metroTextBox2.Text = temp[3];
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            metroTextBox1.Clear();
            metroTextBox2.Clear();
            metroTextBox3.Clear();
            metroTextBox4.Clear();
            metroTile1.Text = "Add";
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            getdata();
            cla.delete(aa, old);
            load();
        }
       
    }
}
