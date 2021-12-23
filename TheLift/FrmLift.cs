using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;


namespace TheLift
{
    public partial class FrmLift : Form
    {
        public IPersonCreatable personCreatable;
        public bool IsActive = false;

        public FrmLift()
        {
            InitializeComponent();
            personCreatable = new Presenter(this);

        }

        private void txtCurrentFloor_TextChanged(object sender, EventArgs e)
        {

        }
      

        private void FrmLift_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void splitContainer1_Panel1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void splitContainer1_Panel1_MouseMove_1(object sender, MouseEventArgs e)
        {

        }

        private void splitContainer1_Panel1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int m = 0;
            int s = 0;

            timer1.Start();

            s = s + 1;
            if (s == 61)
            {
                m = m + 1;
                s = 0;
            }

            this.timerLabel.Text = " Время работы: " + m + ":" + s;
        }

        private void timerLabel_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnControl_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnCreatePerson_Click(object sender, EventArgs e)
        {

        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void TableButtons_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TableButtons2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lbPessengers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbQueue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
