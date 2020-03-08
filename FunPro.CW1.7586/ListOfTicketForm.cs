using FunPro.CW1._7586;
using FunPro.CW1._7586.DAL;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FunPro.CW1._7586
{
    public partial class ListOfTicketForm : Form
    {
        public ListOfTicketForm()
        {
            InitializeComponent();
        }



        private void ListOfTicketForm_Load(object sender, EventArgs e)
        {
            MdiParent = AllForms.GetForm<MainParentForm>();
            LoadData();
        }



        private void ListOfTicketFormorm_Load(object sender, EventArgs e)
        {
            MdiParent = AllForms.GetForm<MainParentForm>();
            LoadData();
        }



        public void LoadData()
        {
            dgv.DataMember = "";
            dgv.DataSource = null;
            dgv.DataSource = new TicketList().GetAllTickets();
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            new EditTicketForm().CreateNewTicket();
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
                MessageBox.Show("There are no tickets left.");
            else
            {
                var t = (Ticket)dgv.SelectedRows[0].DataBoundItem;
                new TicketManager().Delete(t.Id);
                LoadData();
            }
        }



        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
                MessageBox.Show("Please select a ticket.");
            else
            {
                var t = (Ticket)dgv.SelectedRows[0].DataBoundItem;
                new EditTicketForm().UpdateTicket(t);
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (cbxSort.SelectedIndex < 0)
                MessageBox.Show("Please select an attribute to sort by.");
            else
            {
                ByAttribute selectedAttribute;
                if (cbxSort.SelectedIndex == 0)
                    selectedAttribute = ByAttribute.Priority;
                else selectedAttribute = ByAttribute.Status;

                dgv.DataMember = "";
                dgv.DataSource = null;
                dgv.DataSource = new TicketList().SortLinq(selectedAttribute);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbxSearch.SelectedIndex < 0)
                MessageBox.Show("Select an attribute to search by.");
            else if (string.IsNullOrWhiteSpace(tbxSearch.Text))
                MessageBox.Show("Please enter an id to search.");
            else
            {
                var selectedAttribute = cbxSearch.SelectedIndex == 0 ? ByAttribute.Id : ByAttribute.Id;

                dgv.DataMember = "";
                dgv.DataSource = null;
                dgv.DataSource = new TicketList().Search(tbxSearch.Text, selectedAttribute);
            }
        }
    }
}
