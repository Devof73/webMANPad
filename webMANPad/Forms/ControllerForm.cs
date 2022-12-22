using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using webMAN;
using WEBMAN.Data;
using webMANPad.Classes;
using webMANPad.Forms;

namespace webMANPad
{
    public partial class ControllerForm : Form
    {
        private bool IsLocked { get => CheckLock(); }
        private bool _locked = false;
        private readonly string _Address = "";
        private readonly bool _ConAvailable = false;
        private int _MousePosX = 0;
        private int _MousePosY = 0;
        private readonly bool _ServerOnXmb = false;
        private MouseMoveDirection _MouseDirectionX;
        private MouseMoveDirection _MouseDirectionY;
        private string _JoystickDirection = string.Empty;
        private readonly IKeyboardMouseEvents _InputHook = Hook.GlobalEvents();
        private readonly PadController _padControl = new PadController();
        private readonly System.Windows.Forms.Timer _keeper = new System.Windows.Forms.Timer();
        private string _ServerInfo = string.Empty;

        private enum MouseMoveDirection
        {
            left, right,
            up, down
        , no
        }
        Dictionary<System.Windows.Forms.Keys, PadController.Key> _UserKeyboardAssignments = KeyboardSavedata.CurrentAssignment;

        internal bool KeyIsSet(Keys key)
        {
            PadController.Key already = PadController.Key.none;
            _UserKeyboardAssignments.TryGetValue(key, out already);
            return already != PadController.Key.none & _UserKeyboardAssignments.ContainsKey(key);
        }
        private bool CheckLock() => Capture == true & Cursor.Clip == Bounds;
        public ControllerForm(string address, bool locked)
        {
            InitializeComponent();
            _InputHook.MouseMove += Hook_MouseMove;
            _InputHook.MouseClick += Hook_MouseClick;
            MOUSE_HANDLER.Add(PANEL_CONTROLLER);
            _Address = address;
            _locked = locked;
            _keeper.Tick += (object sender, EventArgs e) => KeeperTick();
            _keeper.Interval = 3000;
            if (_locked)
            {
                _keeper.Start();
            }

            ToogleLock(_locked);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) => new ExceptionForm((Exception)e.ExceptionObject);
        private void KeeperTick()
        {
            if (ServerReachable(_Address))
            {
                Cursor.Position = new Point(
                    Screen.PrimaryScreen.Bounds.X + this.Location.X + (this.Size.Width / 2)
                    , Screen.PrimaryScreen.Bounds.Y + this.Location.Y + (this.Size.Height / 2));
                //RefreshServerInfo();
                LABEL_INFO.Text = _ServerInfo;
                ToogleLock(this.Focused);
            }
            else
            {
                ToogleLock(_locked);
            }
        }
        private void RefreshServerInfo()
        {
            var t1 = new Thread(() =>
            {
                _ServerInfo = InfoRefresh();
            });
            t1.Start();
        }
        public string InfoRefresh()
        {

            var HTML = new WebClient().DownloadString("http://" + _Address + "/cpursx.ps3");
            Console.WriteLine(HTML);
            var cli = new Client(this);
            var client = new WebMAN();
            var att = cli.ServerApi.IsAttached;
            var con = cli.ServerApi.IsConnected;
            var firmstr = cli.ServerApi.PS3.GetFirmwareVersion_Str();
            var firmtype = cli.ServerApi.PS3.GetFirmwareType();
            var webmver = client.GetWMVersion(HTML);
            Thread.Sleep(100);
            var fanspeed = client.GetCurrentFanSpeed(HTML); Thread.Sleep(100);
            var hdd = client.GetHDD(HTML);
            var usdir = client.CurrUserDirectory(HTML);
            var gmn = client.GetInGameName(HTML); Thread.Sleep(100);
            var memory = client.GetCurrentMemory(HTML);
            var stime = client.GetStartupElapsedTime(HTML); Thread.Sleep(100);
            var tmp = client.GetCPU_RSX_TMP(HTML);
            string format =
            "IsConnected: {0}\n" +
            "IsAttached: {1}\n" +
            "FirmwareVersion: {2}" +
            "\nFirmwareType: {3}\n" +
            "System Temperature: {4}\n" +
            "webMAN version: {5}\n" +
            "Current Fan Speed: {6}\n" +
            "Hdd Rest: {7}\n" +
            "User Directory: {8}\n"
            + "Current Game: {9}\n" +
            "Memory rest: {10}\n" +
            "Startup Elapsed Time: {11}";
            string result =
                string.Format(format, con, att, firmstr, firmtype, tmp, webmver, fanspeed, hdd, usdir, gmn, memory, stime);
            webMAN.WebMAN.PopupPs3(_Address, result);
            return result;

        }
        private void Hook_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void Hook_MouseMove(object sender, MouseEventArgs e)
        {

            Thread t1 = new Thread(() =>
            {

                GetMouseMoveDirection(e, out _MouseDirectionX, out _MouseDirectionY);
                {
                    _JoystickDirection = string.Format(" Mouse Direction: {0} | {1} ", _MouseDirectionX, _MouseDirectionY);
                }
            });

            LABEL_MOUSEDIR.Text = _JoystickDirection;
            t1.Name = "MOUSE_HANDLER";
            t1.Start();

        }
        private MouseMoveDirection GetMouseMoveDirection(MouseEventArgs e)
        {
            MouseMoveDirection y, x;
            {
                double deltaDirection = _MousePosX - e.X;
                int dir = deltaDirection > 0 ? 1 : -1;
                bool r = dir == 1;
                _MousePosX = e.Location.X;
                x = r ? MouseMoveDirection.left : MouseMoveDirection.right;
            }
            {
                double deltaDirection = _MousePosY - e.Y;
                int dir = deltaDirection > 0 ? 1 : -1;
                bool u = dir == 1;
                _MousePosY = e.Location.Y;
                y = u ? MouseMoveDirection.down : MouseMoveDirection.up;

            }
            return x | y;

        }
        private void GetMouseMoveDirection(MouseEventArgs e, out MouseMoveDirection x, out MouseMoveDirection y)
        {
            MouseMoveDirection yy, xx;
            {
                double deltaDirection = _MousePosX - e.X;
                int dir = deltaDirection > 0 ? 1 : -1;
                bool r = dir == 1;
                _MousePosX = e.Location.X;
                xx = r ? MouseMoveDirection.left : MouseMoveDirection.right;
                x = xx;
            }
            {
                double deltaDirection = _MousePosY - e.Y;
                int dir = deltaDirection > 0 ? 1 : -1;
                bool u = dir == 1;
                _MousePosY = e.Location.Y;
                yy = u ? MouseMoveDirection.up : MouseMoveDirection.down;
                y = yy;
            }


        }
        private void ToogleLock(bool locked)
        {
            _locked = locked;
            _keeper.Enabled = locked;
            switch (locked)
            {
                case true:
                    {
                        Capture = true;
                        System.Windows.Forms.Cursor.Clip = Bounds;
                        return;
                    }
                case false:
                    {
                        Capture = false;
                        System.Windows.Forms.Cursor.Clip = Screen.PrimaryScreen.Bounds;
                        return;
                    }
            }


        }
        protected void HtmlIpCommand(string ipdomain, string value)
        {
            string url = string.Format("http://{0}/{1}", ipdomain, value.Replace("/", ""));
            _ = HtmlGet(url);
        }
        protected string HtmlGet(string url)
        {
            url = HttpUtility.HtmlEncode(url);
            try
            {
                string rt;

                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                rt = reader.ReadToEnd();
                reader.Close();
                response.Close();
                return rt;
            }

            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape & e.Shift)
            {
                ToogleLock(false);
                _keeper.Stop();
            }
            else if (_ConAvailable & _Address != "")
            {

            }
        }
        protected void Ps3Pad(PadController.Key key, PadController.KeyAction action) { }
        private string GetAnalogRdirectionForMouse(MouseMoveDirection mouseMoveDirection)
        {
            switch (mouseMoveDirection)
            {
                case MouseMoveDirection.left: return "analogR_left";
                case MouseMoveDirection.right: return "analogR_right";
                case MouseMoveDirection.up: return "analogR_up";
                case MouseMoveDirection.down: return "analogR_down";
                default: return "";
            }
        }
        protected bool ServerReachable(string hostname)
        {
            try
            {
                Console.WriteLine(Dns.Resolve(hostname).AddressList[0]);
                return true;
            }
            catch { return false; }

        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void PANEL_CONTROLLER_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PANEL_CONTROLLER_MouseMove(object sender, MouseEventArgs e) => Console.WriteLine("[***] Mouse Moving");
        private void PANEL_CONTROLLER_Enter(object sender, EventArgs e) => ToogleLock(true);
        private void ControllerForm_Activated(object sender, EventArgs e) => ToogleLock(true);
        private void ControllerForm_Resize(object sender, EventArgs e) => ToogleLock(true);
        private void ControllerForm_Leave(object sender, EventArgs e) => ToogleLock(false);
        private void ControllerForm_Move(object sender, EventArgs e) => ToogleLock(true);

        private void PANEL_CONTROLLER_Click(object sender, EventArgs e) => ToogleLock(true);
        private void ControllerForm_Deactivate(object sender, EventArgs e) => ToogleLock(false);
        private void ControllerForm_Load(object sender, EventArgs e)
        {
            _ = PadController.ParseMouseWheelAssignments(Application.StartupPath + "\\Config\\MouseWheelGameControls.txt");
        }

        private void MOUSE_HANDLER_IdleState(object sender, EventArgs e) => Console.WriteLine("[***] Mouse Idle.");
        private void ButtonModesReset_Click(object sender, EventArgs e)
        {

            //     new ModeSetForm(ref _MouseShootingMode, ref _MouseJoystickMode, );
        }

        private void LBLKEYBOARDAS_Click(object sender, EventArgs e) => new KeyboardAssignmentForm().ShowDialog();

    }
}


