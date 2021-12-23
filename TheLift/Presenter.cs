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
        Thread TimerThread, MovingLift;

        public Presenter(FrmLift frm)
        {
            TimerThread = new Thread(new ThreadStart(RefreshTimer));
            MovingLift = new Thread(new ThreadStart(Control));

            MovingLift.Start();
            MovingLift.Suspend();
            TimerThread.Start();
            TimerThread.Suspend();

            View = frm;
            View.button1.Click += BtnCreateLift_Click;
            View.btnControl.Click += BtnControl_Click;
            View.btnCreatePerson.Click += BtnCreatePerson_Click;
            View.button3.Click += TimePerFloor_Click;
        }

        private void TimePerFloor_Click(object sender, EventArgs e)
        {
            try
            {
                OurLift.SetTimeMoving(Int32.Parse(View.TimePerFloorTextBox.Text) * 1000);
            }
            catch (Exception)
            {
                MessageBox.Show("Введите целое число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Control()
        {
            OurLift.Move();
            Thread.Sleep(OurLift.GetTimeMoving());
            if (View.txtCurrentFloor.InvokeRequired)
            {
                View.txtCurrentFloor.Invoke(new MethodInvoker(delegate
                {
                    View.txtCurrentFloor.Text = OurLift.CurrentFloor.ToString();
                }));   
            }
                    
        }

        private void BtnCreateLift_Click(object sender, EventArgs e)
        {
            FrmCreateLift fcr = new FrmCreateLift();
            DialogResult dr = fcr.ShowDialog();
            if (dr == DialogResult.Yes)
            {
                this.OurLift = fcr.NewLift;
                View.txtCurrentFloor.Text = OurLift.CurrentFloor.ToString();
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
                    MovingLift.Resume();
                    TimerThread.Resume();
                    View.btnControl.Text = "Остановить систему";
                    View.splitContainer2.Enabled = true;
                    View.button1.Visible = false;
                }
                else
                {
                    MovingLift.Suspend();
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

        private void BtnCreatePerson_Click(object sender, EventArgs e)
        {
            PersonCreate();
            RefreshQueue();
        }

        public void PersonCreate()
        {
            int StartFloor = Convert.ToInt32(View.nudCurrentFloor.Value);
            int TargetFloor = Convert.ToInt32(View.nudTargetFloor.Value);
            Person person = new Person(StartFloor, TargetFloor);
            OurLift.AddToQueue(person);

        }

        public void RefreshQueue()// обновление элементов управления
        {

            View.lbQueue.Items.Clear(); 
            View.lbQueue.DisplayMember = "Info";
            foreach (Person pe in OurLift.Queue)
            {
                View.lbQueue.Items.Add(pe);
            }
        }

        public void RefreshPessengers()
        {
            View.lbPessengers.Items.Clear();
            View.lbPessengers.DisplayMember = "Info";
            foreach (Person pe in OurLift.Pessengers)
            {
                View.lbPessengers.Items.Add(pe);
            }
        }
    }
}