using System;
using LiftModel;

namespace TheLift
{
    public class CreateLiftPresenter : ILiftCreatable
    {
        private FrmCreateLift View;
        public CreateLiftPresenter(FrmCreateLift frm)
        {
            View = frm;
            View.btnOK.Click += BtnOK_Click;
            View.numericUpDown1.Maximum = 20;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            LiftCreate();
            View.Close();
        }

        public void LiftCreate()
        {
            View.NewLift = new Lift(Convert.ToInt32(View.numericUpDown1.Value));
        }
    }
}
