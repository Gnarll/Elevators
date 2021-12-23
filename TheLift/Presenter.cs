using System;
using LiftModel;
using System.Threading;
using System.Windows.Forms;

namespace TheLift
{
    public class Presenter : IPersonCreatable
    {
        public Lift OurLift;
        private FrmLift View;
        Thread TimerThread;

        public Presenter(FrmLift frm)
        {
            TimerThread = new Thread(new ThreadStart(RefreshTimer));
            TimerThread.Start();
            TimerThread.Suspend();
            View = frm;
            View.button1.Click += BtnCreateLift_Click;
            View.btnControl.Click += BtnControl_Click;
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
        private void BtnControl_Click(object sender, EventArgs e)
        {
            if (OurLift != null)
            {
                View.IsActive = !View.IsActive;
                if (View.IsActive)
                {
                    TimerThread.Resume();
                    View.btnControl.Text = "Остановить систему";
                    View.splitContainer2.Enabled = true;
                    View.button1.Visible = false;
                }
                else
                {
                    TimerThread.Suspend();
                    View.btnControl.Text = "Запустить систему";
                    View.splitContainer2.Enabled = false;
                    View.button1.Visible = true;
                }
            }
            else { MessageBox.Show("Необходимо создать лифт.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
        public void RefreshTimer()
        {
            while (View.IsActive)
            {
                OurLift.TimerUpdate();
                View.timerLabel.Text = "Время работы: " + OurLift.CurrentMin.ToString() + " мин " + OurLift.CurrentSec.ToString() + " сек";
                Thread.Sleep(1000);
            }
        }

        public void PersonCreate()
        {

        }
    }
}