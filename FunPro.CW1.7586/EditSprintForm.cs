using FunPro.CW1._7586;
using FunPro.CW1._7586.DAL;
using System;
using System.Windows.Forms;


namespace FunPro.CW1._7568

{
    public partial class EditSprintForm : Form
    {
        public EditSprintForm()
        {
            InitializeComponent();
        }

        public Sprint Sprint { get; set; }

        public FormMode Mode { get; set; }

        public void CreateNewSprint()
        {
            Mode = FormMode.CreateNew;
            Sprint = new Sprint();
            InitializeControls();
            MdiParent = AllForms.GetForm<MainParentForm>();
            Show();
        }

        public void UpdateSprint(Sprint sprint)
        {
            Mode = FormMode.Update;
            Sprint = sprint;
            InitializeControls();
            ShowSprintInControls();
            MdiParent = AllForms.GetForm<MainParentForm>();
            Show();
        }

        private void InitializeControls()
        {
        }

        private void ShowSprintInControls()
        {
            tbxName.Text = Sprint.Name;
            dtpDate.Value = Sprint.Date;
            nudNoD.Value = Sprint.NumberOfDevelopers;
            tbxStatus.Text = Sprint.Status;
        }

        private void GrabUserInput()
        {
            Sprint.Name = tbxName.Text;
            Sprint.Date = dtpDate.Value;
            Sprint.NumberOfDevelopers = Convert.ToInt32(nudNoD.Value);
            Sprint.Status = tbxStatus.Text;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                GrabUserInput();
                var manager = new SprintManager();
                if (Mode == FormMode.CreateNew)
                    manager.Create(Sprint);
                else
                    manager.Update(Sprint);

                AllForms.GetForm<ListOfSprintsForm>().LoadData();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditSprintForm_Load(object sender, EventArgs e)
        {
            MdiParent = AllForms.GetForm<MainParentForm>();
            LoadData();
        }


        public void LoadData()
        {
            dgv.DataMember = "";
            dgv.DataSource = null;
            dgv.DataSource = new TicketList().GetBacklogTickets();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }
    }
}
