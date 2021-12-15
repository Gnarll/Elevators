using System;
using LiftModel;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TheLift
{
    public class Presenter : IPersonCreatable
    {
        public Lift OurLift;
        private FrmLift View;

        public Presenter(FrmLift frm)
        {
            View = frm;
            View.button1.Click += BtnCreateLift_Click;
        }
        private void BtnCreateLift_Click(object sender, EventArgs e)
        {
            FrmCreateLift fcr = new FrmCreateLift();
            DialogResult dr = fcr.ShowDialog();

        }
        public void PersonCreate()
        {

        }

    }
}
