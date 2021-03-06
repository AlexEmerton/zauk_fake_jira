﻿using System;
using System.Windows.Forms;

namespace FunPro.CW1._7586
{
    public partial class ListOfSprintsForm : Form
    {
        public ListOfSprintsForm()
        {
            InitializeComponent();
        }



        private void SprintList_Load(object sender, EventArgs e)
        {
            MdiParent = AllForms.GetForm<MainParentForm>();
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            dgv.DataMember = "";
            dgv.DataSource = null;
            dgv.DataSource = new ListOfSprintsForm().GetAllSprints();
        }

        private object GetAllSprints()
        {
            throw new NotImplementedException();
        }
    }
}
