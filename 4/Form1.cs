using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4
{
    public partial class Form1 : Form
    {
        String user;
        String id;

        public Form1()
        {
            InitializeComponent();
        }
        public void clear()
        {
            txtLastname.Text = "" ;
            txtFirstname.Text = "" ;
            txtMiddlename.Text = "" ;
        }
        #region Buttons
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtLastname.Text == "" || txtFirstname.Text == "" || txtMiddlename.Text == "")
            {
                MessageBox.Show("Please Fill-Out all needed Student Information", "FILL-OUT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                user = txtLastname.Text + ", " + txtFirstname.Text + " " + txtMiddlename.Text;

                if (lists.Items.Contains(user))
                {
                    MessageBox.Show("Student is already in the list", "Student Record Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    lists.Items.Add(user);
                    int count = lists.Items.Count;
                    lblNum.Text = "Total Number of Student: " + count.ToString();
                    clear();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtLastname.Text == "" || txtFirstname.Text == "" || txtMiddlename.Text == "")
            {
                MessageBox.Show("Please Fill-Out all needed Personal Information", "FILL-OUT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                user = txtLastname.Text + ", " + txtFirstname.Text + " " + txtMiddlename.Text;
                id = lists.SelectedIndex.ToString();
                if (id == "-1")
                {
                    MessageBox.Show("Please select data to edit", "EDIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int selectedData = lists.SelectedIndex;
                    lists.Items.RemoveAt(selectedData);
                    lists.Items.Insert(selectedData, user);
                    clear();
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            id = lists.SelectedIndex.ToString();
            if (id == "-1")
            {
                MessageBox.Show("Please select data to delete", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete the data?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    lists.Items.RemoveAt(lists.SelectedIndex);
                    int count = lists.Items.Count;
                    lblNum.Text = "Total Number of Student: " + count.ToString();
                    clear();
                }
                else
                {
                    MessageBox.Show("Cancelled", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion
    }
}
