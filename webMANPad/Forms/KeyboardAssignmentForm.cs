using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using webMANPad.Classes;

namespace webMANPad.Forms
{
    public partial class KeyboardAssignmentForm : Form
    {
        PadController.Key _SelectedPkey;
        Keys _SelectedKkey;

        public KeyboardAssignmentForm()
        {
            InitializeComponent();
            new Thread(() => AddAllFromSavedata()).Start();
            new Thread(() => FillAsignmentList()).Start();
        }
        void AddAllFromSavedata()
        {
            var dic = KeyboardSavedata.CurrentAssignment;
            foreach (var value in dic.Keys)
            {
                KeyboardSavedata.CurrentAssignment.TryGetValue(value, out PadController.Key key);
                if (key != PadController.Key.none)
                {
                    AddValue(value.ToString(), key.ToString());
                }
            }
        }
        void AddValue(string kkey, string pkey)
        {
            ListBoxAssignments.Items.Clear();
            ListBoxAssignments.Items.Add(kkey + " : " + pkey);
        }
        void FillAsignmentList()
        {
            var left = AllKeys.CommonKeyboardNames;
            var right = AllKeys.Ps3KeysNames;
            for (int i = 0; i < left.Length; i++)
            {
                CBX_KEY.Items.Add(left[i]);
            }
            for (int i = 0; i < right.Length; i++)
            {
                CBX_PS3KEY.Items.Add(right[i]);
            }
        }
        private void KeyboardAssignmentForm_Load(object sender, EventArgs e)
        {

        }

        private void ButtonSaveClick(object sender, EventArgs e)
        {

        }

        private void ButtonDeleteClicked(object sender, EventArgs e)
        {

        }

        private void LBXUSER_SelectedIndexChanged(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                if (ListBoxAssignments.SelectedIndex != -1)
                {
                    var valuens = (string)ListBoxAssignments.SelectedItem;
                    var values = valuens.Split(':');
                    var value1 = values[0];
                    var value2 = values[1];
                    if (AllKeys.CommonKeyboardNames.Contains(value1) & AllKeys.CommonKeyboardNames.Contains(value2))
                    {
                        _SelectedKkey = (Keys)Enum.Parse(typeof(Keys), value1);
                        _SelectedPkey = (PadController.Key)Enum.Parse(typeof(PadController.Key), value2);

                    }

                }
            })
            { IsBackground = true, Name = "LBXUSER_SELECTEDINDEXWORKER" }.Start();
        }

        private void ButtonAddNew_Click(object sender, EventArgs e)
        {
            if (!KeyboardSavedata.CurrentAssignment.ContainsKey(_SelectedKkey))
            {
                KeyboardSavedata.AddKey(_SelectedKkey, _SelectedPkey);
                AddValue(_SelectedKkey.ToString(), _SelectedPkey.ToString());
            }
            else MessageBox.Show("Already assigned " + _SelectedKkey.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ButtonLoadByFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { AddExtension = true, Filter = "Text Plain|*.txt", Title = "Select" };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                KeyboardSavedata.LoadFromFile(ofd.FileName);
            }
            ofd.Dispose();
        }
    }
}
