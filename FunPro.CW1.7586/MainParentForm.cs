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


        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CreateNewTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditTicketForm().CreateNewTicket();
        }
        private void ListAllTicketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllForms.GetForm<EditTicketForm>().Show();
        }
        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditSprintForm().CreateNewSprint();
        }

        private void ListAllSprintsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllForms.GetForm<EditSprintForm>().Show();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var x = new AboutForm();
            x.ShowDialog();

        }


    }
}
