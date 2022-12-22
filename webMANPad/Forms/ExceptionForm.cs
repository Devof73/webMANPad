using System;
using System.Data;
using System.Windows.Forms;

namespace webMANPad.Forms
{
    public partial class ExceptionForm : Form
    {
        int hresult = 0;
        public ExceptionForm(Exception e)
        {
            InitializeComponent();
            if (e != null)
            {
                this.LBLHR.Text = e.HResult.ToString();
                this.LBLMSG.Text = e.Message;
                this.LBLEX.Text = e.ToString();
                hresult = e.HResult;
            }
            else
            {
                throw new InvalidExpressionException("value cant be null");
            }
        }

        private void BTN1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTN2_Click(object sender, EventArgs e)
        {
            Environment.Exit(hresult);
        }
    }
}
