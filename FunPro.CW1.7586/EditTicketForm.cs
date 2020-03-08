using FunPro.CW1._7586.DAL;
using System;
using System.Windows.Forms;

namespace FunPro.CW1._7586
{
    public partial class EditTicketForm : Form
    {
        public EditTicketForm()
        {
            InitializeComponent();
        }



        private void EditTicketForm_Load(object sender, EventArgs e)
        {
            MdiParent = AllForms.GetForm<ParentForm>();
        }



        public Ticket Ticket { get; set; }

        public FormMode Mode { get; set; }



        public void CreateNewTicket()
        {
            Mode = FormMode.CreateNew;
            Ticket = new Ticket();
            InitializeControls();
            MdiParent = AllForms.GetForm<ParentForm>();
            Show();
        }



        public void UpdateTicket(Ticket ticket)
        {
            Mode = FormMode.Update;
            Ticket = ticket;
            InitializeControls();
            ShowTicketInControls();
            MdiParent = AllForms.GetForm<ParentForm>();
            Show();
        }



        private void InitializeControls()
        {
            cbxSprint.DataSource = new SprintManager().GetAll();
        }



        private void ShowTicketInControls()
        {
            _ = Convert.ToInt32(cbxSprint.SelectedValue);
            tbxSummary.Text = Ticket.Summary;
            tbxDescription.Text = Ticket.Description;
            nudEstimation.Value = Ticket.Estimation;
            cbxPriority.SelectedValue = Ticket.Priority;
            cbxStatus.SelectedValue = Ticket.Status;
            _ = Ticket.Sprint.ID;
        }



        private void GrabUserInput()
        {
            Ticket.Summary = tbxSummary.Text;
            Ticket.Description = tbxDescription.Text;
            Ticket.Estimation = Convert.ToInt32(nudEstimation.Value);
            Ticket.Priority = cbxPriority.SelectedItem.ToString();
            Ticket.Status = cbxStatus.SelectedItem.ToString();
            Ticket.Sprint = (Sprint)cbxSprint.SelectedItem;

        }



        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                GrabUserInput();
                var manager = new TicketManager();
                if (Mode == FormMode.CreateNew)
                    manager.Create(Ticket);
                else
                    manager.Update(Ticket);

                AllForms.GetForm<ListOfTicketForm>().LoadData();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
