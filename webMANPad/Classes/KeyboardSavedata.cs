using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using webMANPad.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace webMANPad.Classes
{
    public class KeyboardSavedata
    {
        private static Dictionary<Keys, PadController.Key> _CurrentAssignment = new Dictionary<Keys, PadController.Key>();
        public static Dictionary<Keys, PadController.Key> CurrentAssignment
        {
            get { return _CurrentAssignment; }
        }
        public static void AddKey(Keys Key, PadController.Key NewValue)
        {
            var keynames = _CurrentAssignment.Keys.Cast<Keys>().ToList();
            if (keynames.Contains(Key))
            {
                if (_CurrentAssignment.ContainsKey(Key)) Debug.WriteLine("[!] Asignamiento guardado ya tenía la clave " + Key);
                _CurrentAssignment.Remove(Key);
                _CurrentAssignment.Add(Key, NewValue);
            }
            else
            {
                _CurrentAssignment.Add(Key, NewValue);
            }
        }
        public static string SaveToFile()
        {
            StreamWriter _File = File.CreateText(System.Windows.Forms.Application.StartupPath + "\\webmanKeyboardAssignment_" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss"));
            foreach (var value in _CurrentAssignment.Keys)
            {
                PadController.Key key = PadController.Key.none;
                _CurrentAssignment.TryGetValue(value, out key);
                if (key != PadController.Key.none)
                {
                    _File.WriteLine(value + ":" + key);
                }
            }
            _File.FlushAsync();
            _File.Close();
            return System.Windows.Forms.Application.StartupPath + "\\webmanKeyboardAssignment_" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");
        }
        public static void LoadFromFile(string filename, out bool result)
        {
            var ps3keys = Enum.GetNames(typeof(PadController.Key));
            var kkeys = Enum.GetNames(typeof(Keys));
            var oldDic = _CurrentAssignment;
            try
            {
                var lines = File.ReadAllLines(filename);
                foreach (string line in lines)
                {
                    if (line.Contains(':'))
                    {
                        var values = line.Split(':');
                        if (kkeys.Contains(values[0]) & ps3keys.Contains(values[1]))
                        {
                            Debug.WriteLine("Adding values " + values[0] + " : " + values[1]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                new ExceptionForm(e).Show(); _CurrentAssignment = oldDic;
                Debug.WriteLine("[!!] Error while trying to write values. Older data are restored. ");
            }

        }

    }
}
