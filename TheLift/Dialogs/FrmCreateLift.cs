using System;
using LiftModel;
using System.Windows.Forms;

namespace TheLift
{
    public partial class FrmCreateLift : Form
    {
        public Lift NewLift;
        public ILiftCreatable creatable;
        public FrmCreateLift()
        {
            InitializeComponent();
            creatable = new CreateLiftPresenter(this);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCreateLift_Load(object sender, EventArgs e)
        {

        }
    }
}
