using System;
using LiftModel;
using System.Windows.Forms;

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
            if (dr == DialogResult.Yes)
            {
                this.OurLift = fcr.NewLift;
                RefreshButtons();
            }
        }

        public void RefreshButtons()
        {
            View.TableButtons.Items.Clear();
            foreach (LiftButton btn in OurLift.Buttons)
            {
                View.TableButtons.Items.Add(btn.Number.ToString(), btn.IsActive);

            }
        }

        public void PersonCreate()
        {

        }
    }
}