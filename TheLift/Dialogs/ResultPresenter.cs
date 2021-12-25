using System;


namespace TheLift.Dialogs
{
    public class ResultPresenter : IResultable
    {
        private FrmStat View;
        private LiftModel.Statistics stat;

        public ResultPresenter(FrmStat frm, LiftModel.Lift lift)
        {
            View = frm;
            stat = new LiftModel.Statistics(lift);

            View.btnOK.Click += BtnOK_Click;
            View.btnToWord.Click += BtnToWord_Click;
            View.btnToExcel.Click += BtnToExcel_Click;
            Result();
        }

        private void BtnToWord_Click(object sender, EventArgs e)
        {
            stat.ToWord();
        }

        private void BtnToExcel_Click(object sender, EventArgs e)
        {
            stat.ToExcel();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            View.Close();
        }

        public void Result()
        {
            View.txtPeople.Text = stat.People();
            View.txtTrips.Text = stat.AllTrips();
            View.txtEmptyTrips.Text = stat.AllEmptyTrips();
        }
    }
}
