using LiftModel;
using System.Windows.Forms;

namespace TheLift.Dialogs
{
    public partial class FrmStat : Form
    {
        public IResultable resultable;
        public FrmStat(Lift lift)
        {
            InitializeComponent();
            resultable = new ResultPresenter(this, lift);
        }

        private void label6_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
