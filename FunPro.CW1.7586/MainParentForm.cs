using System;
using System.Windows.Forms;

namespace FunPro.CW1._7586
{
    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutForm();
            form.ShowDialog();
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {

        }

        private void AllTicketsToolStripMenuItem_Click(object sender, EventArgs e) => AllForms.GetForm<ListOfTicketsForm>().Show();

        private void allSprintsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllForms.GetForm<ListOfSprintsForm>().Show();
        }


    }
}
