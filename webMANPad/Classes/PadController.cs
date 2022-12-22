

using System.Runtime.InteropServices;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace webMANPad
{
    public class PadController
    {

        public enum MouseMethod { Click, Wheel }
        public enum KeyAction
        {
            hold,
            release,
            press,
            none,
        }

        public static Key GetKeyFromInput(KeyEventArgs input)
        {
            switch (input.KeyData)
            {
                case Keys.None: return Key.none;
                case Keys.W: return Key.analogL_up;
                case Keys.A: return Key.analogL_left;
                case Keys.S: return Key.analogL_down;
                case Keys.D: return Key.analogL_right;
                case Keys.R: return Key.square;
                case Keys.E: return Key.triangle;
                case Keys.F: return Key.circle;
                case Keys.Escape: return Key.circle;
                case Keys.F1: return Key.select;
                case Keys.F2: return Key.start;
                case Keys.F3: return Key.psbtn;
                case Keys.Up: return Key.up;
                case Keys.Down: return Key.down;
                case Keys.Left: return Key.left;
                case Keys.Right: return Key.right;
                case Keys.LShiftKey: return Key.l3;
                case Keys.ControlKey: return Key.r3;
                case Keys.Space: return Key.cross;
                case Keys.Enter: return Key.cross;
                case Keys.Tab: return Key.psbtn;
                case Keys.Back: return Key.circle;
                default: return Key.none;


            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns>[0]: ASSIGNMENT NAME | [1]: BUTTON(S) | [2]: ASSIGNMENT INDEX </returns>
        /// Application.StartupPath + "\\Config\\MouseWheelGameControls.txt";
        public static string[] ParseMouseWheelAssignments(string thisFile)
        {
            var path = thisFile;

            if (File.Exists(path))
            {
                var Out = new List<string>();
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    if (line.Length > 2)
                    {
                        if (char.IsNumber(line[0]) & line[1] == ':')
                        {
                            Out.Add(line);
                            Console.WriteLine("CONFIG => " + line);
                        }

                    }

                }
                return Out.ToArray();
            }
            else return null;
        }

        //
        public static string[] ParseMouseWheelConfigAssignments(string[] parsedConfig, int gameIndex)
        {
            var output = new List<string>();
            var validKeys = Enum.GetNames(typeof(Keys)).ToList<string>();
            var line = parsedConfig[gameIndex].Remove(0, 3);
            Debug.WriteLine("CONFIG => " + line);
            var values = line.Replace("\"", "").Split('=');
            Debug.WriteLine(line.Replace("\"", ""));
            if (values[1].Contains("|"))
            {
                var wheel = values[1].Split('|');
                var wheelup = wheel[0];
                var wheeldown = wheel[1];
                if (validKeys.Contains(wheelup)) { output.Add(wheelup); }
                else output.Add("none"); Debug.WriteLine("[*] Wheel config parsing result in unrecognized key for PS3: " + wheelup);
                if (validKeys.Contains(wheeldown))
                { output.Add(wheeldown); }
                else output.Add("none"); Debug.WriteLine("[*] Wheel config parsing result in unrecognized key for PS3: " + wheeldown);

            }
            else if (!values[1].Contains("|"))
            {
                Debug.WriteLine(values[1] + " doesn't contains '|'. ");
                if (validKeys.Contains(values[1]))
                {
                    Debug.WriteLine($"validkeys contains -> {values[1]}");
                    output.Add(values[1]);
                    Debug.WriteLine("Key Added.");
                }

            }
            return output.ToArray();
        }
        public enum Key
        {
            up,
            down,
            left,
            right,
            cross,
            circle,
            square,
            triangle,
            r1,
            r2,
            l1,
            l2,
            l3,
            r3,
            psbtn,
            select,
            start,
            analogL_up,
            analogL_down,
            analogL_left,
            analogL_right,
            analogR_up,
            analogR_down,
            analogR_left,
            analogR_right,
            none,
        }
        public static void ClickSomePoint(Point Location)
        {

            Cursor.Position = Location;

            DoClickMouse(0x2);
            DoClickMouse(0x4);
        }
        static void DoClickMouse(int mouseButton)
        {
            var input = new INPUT()
            {
                dwType = 0, // Mouse input
                mi = new MOUSEINPUT() { dwFlags = mouseButton }
            };

            if (SendInput(1, input, Marshal.SizeOf(input)) == 0)
            {
                throw new Exception();
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            int dx;
            int dy;
            int mouseData;
            public int dwFlags;
            int time;
            IntPtr dwExtraInfo;
        }
        struct INPUT
        {
            public uint dwType;
            public MOUSEINPUT mi;
        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint cInputs, INPUT input, int size);
    }
}
