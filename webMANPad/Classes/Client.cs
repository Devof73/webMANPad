using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Web.UI;
using System.Windows.Forms;

namespace WEBMAN.Data
{
    internal class Client
    {
        private readonly PS3MAPI _Ps3API = null;
        private Form _sender = null;
        private uint[] _AttPs = { };
        public uint[] AvailableAttachmentPoints { get { return _AttPs; } }
        public PS3MAPI ServerApi { get { return _Ps3API; } }
        public Client(Form instance)
        {
            if (instance != null)
            {
                _sender = instance;
                _Ps3API = new PS3MAPI();
            }
        }
        internal void DisplayMessage(string message, string title = "Message") => MessageBox.Show(message, title, MessageBoxButtons.OK, icon: MessageBoxIcon.Question);
        internal Exception TryCatch(Action @do, Action @catch, Action @finally, out bool result)
        {
            try
            {
                @do();
                result = true;
            }
            catch (Exception e)
            {
                @catch?.Invoke();
                result = false;
                return e;
            }
            finally
            {
                @finally?.Invoke();
                result = true;
            }
            return null;
        }
        internal Exception TryCatch(Action @do, Action @catch, Action @finally)
        {
            try
            {
                @do();
            }
            catch (Exception e)
            {
                @catch();
                return e;
            }
            finally
            {
                @finally?.Invoke();
            }
            return null;
        }
        /// <summary>
        /// Tries to connect to server.
        /// </summary>
        /// <param name="sip"> Server ip to connection.</param>
        /// <param name="port"> Server port. Default "7887"</param>
        /// <param name="notifyMessage"> Welcome message (optional)</param>
        internal void ConnectToPs3(string sip, int port = 7887, string notifyMessage = "")
        {
            var connected = false;
            TryCatch(() => _Ps3API.ConnectTarget(sip, port), null, null
                , out connected);
            DisplayMessage("Connection Status: " + connected.ToString(), "Alert");
            if (notifyMessage != "" && _Ps3API.IsConnected)
            {
                _Ps3API.PS3.Notify(notifyMessage);
            }

        }
        internal bool DisconnectFromPs3(string byeMessage = "")
        {

            if (_Ps3API.IsConnected)
            {
                if (byeMessage != "")
                {
                    _Ps3API.PS3.Notify(byeMessage);
                }
                _Ps3API.DisconnectTarget();
            }
            Debug.WriteLine("! papi connection state => " + _Ps3API.IsConnected);
            return !_Ps3API.IsConnected;
        }
        /// <summary>
        /// Notifies to system a message.
        /// </summary>
        /// <param name="notify">The message to notify.</param>
        internal void PMessage(string notify)
        {
            var r = false;
            if (notify == "") return;
            if (string.IsNullOrEmpty(notify)) return;
            if (string.IsNullOrWhiteSpace(notify)) return;
            TryCatch(() => _Ps3API.PS3.Notify(notify), null, null);
        }
        /// <summary>
        /// Gets system temp and return it into a String.
        /// </summary>
        /// <returns>A string containing RSX and CPU temperatures.</returns>
        public string GetTemperatureCelsius()
        {
            if (_Ps3API.IsConnected)
            {
                uint cpu, rsx;
                _Ps3API.PS3.GetTemperature(out cpu, out rsx);
                if (cpu == 0 & rsx == 0)
                {
                    Debug.WriteLine("! no cpu rsx temp fetched.");
                }
                return string.Format("CPU: {0} RSX: {1}", cpu, rsx);
            }
            else
            {
                return "ERROR_NOTCON";
            }
        }
        public override string ToString()
        {
            return "PS3 " + _Ps3API.IsConnected + " " + _Ps3API.IsAttached + " " + _Ps3API.PS3.GetFirmwareVersion_Str();
        }
        public List<string> GetAttachmentPoints()
        {
            bool flag = _Ps3API.IsConnected;
            if (flag)
            {
                var e1 = _Ps3API.Process.GetPidProcesses();
                var outp = new List<string>();
                _AttPs = new uint[10];
                int i = 0;
                foreach (uint uin in e1)
                {
                    var name = _Ps3API.Process.GetName(uin);
                    if (uin != 0 & name.Length >= 5)
                    {
                        outp.Add(name + string.Format("({0})", uin));
                        _AttPs[i] = uin;
                        i++;
                    }
                }
                if (e1.Length == 0)
                {
                    Debug.WriteLine("! Not att points fetched.");
                }
                return outp;
            }
            else
            {
                Debug.WriteLine("! Cannot perform operation. ");
                return null;
            }
        }
    }
}
