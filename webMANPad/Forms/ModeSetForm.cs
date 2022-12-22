using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webMANPad.Forms
{
    public partial class ModeSetForm : Form
    {
        private int mmi;
        private int kpi;
        private int mwi;
        public ModeSetForm(string[] AvailableMouseModeProfiles,
        string[] AvailableMouseJoystickProfiles,
        string[] AvailableKeyboardProfiles,
        ref int MouseModeIndex, ref int MouseWheelIndex, ref int KeyboardProfileIndex)
        {
            InitializeComponent();
            CbxAdd(AvailableMouseModeProfiles, CBX1);
            CbxAdd(AvailableMouseJoystickProfiles, CBX2);
            CbxAdd(AvailableKeyboardProfiles, CBX3);
            mmi = MouseModeIndex; kpi = KeyboardProfileIndex;
            mwi = MouseWheelIndex;

        }
        private void CbxAdd(string[] array, ComboBox Target)
        {
            foreach (string v in array) Target.Items.Add(v);
        }
        private void ButtonCancelClicked(object sender, EventArgs e)
        {
            this.Close();
            Debug.WriteLine("[!] Index settings canceled.");
            return;
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (CBX1.SelectedIndex != -1) { mmi = CBX1.SelectedIndex; }
            if (CBX2.SelectedIndex != -1) { kpi = CBX1.SelectedIndex; }
            if (CBX3.SelectedIndex != -1) { mwi = CBX1.SelectedIndex; }
            Close();

        }

    }
}
