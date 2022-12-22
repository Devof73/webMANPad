using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace webMANPad.Classes
{
    public class AllKeys
    {
        public static readonly string[] Ps3KeysNames = Enum.GetNames(typeof(PadController.Key));
        public static readonly string[] CommonKeyboardNames = Enum.GetNames(typeof(Keys));
        static void FillStringList(in List<string> target, string[] values)
        { foreach (string s in values) { target.Add(s); } }
    }
}
