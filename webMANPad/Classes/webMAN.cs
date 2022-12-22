/*
    PS3 webMAN current User Game Playing Get From HTML and a RichTextBox 70% Accuracy
    by D.s.j. 
    Discord = d.s.j.#0598
    YouTube = destru0036
    Version 1.5
*/
using System;
using System.Drawing;
using System.Net;
using HtmlAgilityPack;
using System.Collections;
using System.Collections.Generic;

using System.Threading;



namespace webMAN
{

    public class WebMAN
    {
        internal static string ExtractText(string html, int method = 0)
        {
            int valuei = 0;
            if (method is 0)
            {
                if (string.IsNullOrEmpty(html))
                {
                    throw new ArgumentNullException("html");
                }

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var chunks = new List<string>();
                var dn = doc.DocumentNode.DescendantNodesAndSelf();
                foreach (var item in dn)
                {
                    if (item.NodeType == HtmlNodeType.Text)
                    {
                        if (item.InnerText.Trim() != "")
                        {
                            chunks.Add(item.InnerText.Trim());
                        }
                    }
                }
                return String.Join(" ", chunks);
            }
            else
            {
                if (html == null)
                {
                    throw new ArgumentNullException("html");
                }

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var chunks = new List<string>();
                var dn = doc.DocumentNode.DescendantNodesAndSelf();
                foreach (var item in dn)
                {

                    if (item.NodeType == HtmlNodeType.Text)
                    {
                        if (item.InnerText.Trim() != "")
                        {
                            chunks.Add(valuei + " - " + item.InnerText.Trim());
                        }
                    }
                    valuei++;
                }
                if (method is 2)
                {
                    return String.Join("\r", chunks);
                }

            }
            return "";
        }
        public string[] ExtractTextToArray(string html)
        {
            if (html == null)
            {
                throw new ArgumentNullException("html");
            }

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            var chunks = new List<string>();
            var dn = doc.DocumentNode.DescendantNodesAndSelf();
            foreach (var item in dn)
            {
                if (item.NodeType == HtmlNodeType.Text)
                {
                    if (item.InnerText.Trim() != "")
                    {
                        chunks.Add(item.InnerText.Trim());
                    }
                }
            }

            return chunks.ToArray();
        }
        internal string PS3GetValue(string consoleIp, int valueIndex)
        {
            List<string> chunks = new List<string>();
            ExtractText(InternalRefreshHTML(consoleIp), 2);
            var val = chunks[valueIndex];

            return val;
        }
        public string InternalRefreshHTML(string consoleIP)
        {
            WebClient web = new WebClient();
            string ip = consoleIP;
            string userUrl = $"http://{ip}/cpursx.ps3";
            System.IO.Stream stream = web.OpenRead(userUrl);
            using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
            {
                String text = reader.ReadToEnd();
                web.Dispose();
                return text;
            }


        }
        public string wVersion(string consoleIp)
        {
            return PS3GetValue(consoleIp, 17);
        }

        internal string GetPs3CpuRsxValues(string ps3Ip)
        {
            List<string> emp = new List<string>();
            return ExtractText($"http://{ps3Ip}/cpursx.ps3", 1);
        }
        public string GetCurrentGameString(int method = 0, string OptionalHTML = "oldhtml")
        {
            ///
            /// GCGS Methods
            /// 
            /// 0 = Homemade method, need IP, a bit slowly, but accuraccy 70%
            /// 1 = Substring method, fast, but 50% accuraccy 
            /// 2 = same as 1 but returns only game region
            /// 3 = substrings mode, 90% accuraccy
            /// 4 = substrings mode, but region only
            ///
            string result = "";
            try
            {

                if (method == 1 || method == 2)
                {
                    string gameregion = "";
                    string key = OptionalHTML.Replace(OptionalHTML.Substring(0, 1388), "");
                    key = key.Replace(key.Substring(0, 43), "");
                    gameregion = key.Substring(0, 9);
                    string v1 = $"/{gameregion}-ver.xml\" target=\"_blank\">{gameregion}</a> <a";
                    key = key.Replace(v1, "");
                    key = key.Replace(key.Substring(73, 33), "{SEPARATOR_SIGN!}");

                    int GN_Index = key.IndexOf("{SEPARATOR_SIGN!}");
                    key = key.Replace("href=\"http://google.com/search?q=", " - ");
                    key = key.Replace(key.Substring(GN_Index, key.Length - GN_Index), "");
                    key = key.Replace("\">{SEPARATOR_SIGN!} &nbsp; <a hr", "");
                    if (method == 2)
                    {
                        key = key.Substring(0, 9);
                    }

                    result = key;
                }
                if (method == 3 || method == 4)
                {
                    string data = OptionalHTML;
                    int keyIndex = OptionalHTML.IndexOf("https://a0.ww.np.dl.playstation.net/tpl/np/");
                    int gameKeyIndex = data.IndexOf("<a href=\"http://google.com/search?q=");
                    var separator = "\">";
                    var length = data.IndexOf(separator);
                    string GameName = data.Substring(gameKeyIndex + 36, length);


                    string gregion = data.Substring(keyIndex + 43, 9);
                    result = GameName;

                    if (method == 4)
                    { result = gregion; }

                }
            }
            catch
            {
                result = "Error";
            }



            return result;
        }
        public string GetInGameName(string wm_html_cpursx)
        {
            string result = "";
            try
            {
                string html = wm_html_cpursx;
                string codetext = html.Replace("&nbsp;", "[DSJ_INDEX_DETECTOR]");
                int fkeyIndex = codetext.IndexOf("[DSJ_INDEX_DETECTOR]") - 5;
                string trashvalue = "http://google.com/search?q=";
                int trashCountIndex = codetext.IndexOf(trashvalue) + 27;
                codetext = codetext.Remove(0, trashCountIndex);
                codetext = codetext.Remove(fkeyIndex);
                string trashvalue2 = "</a> [DSJ_INDEX_DETECTOR]";
                int tsv2_Index = codetext.IndexOf(trashvalue2);
                codetext = codetext.Remove(tsv2_Index);
                string lastseparator = "\">";
                codetext = codetext.Remove(codetext.IndexOf(lastseparator));
                codetext = codetext.Replace("Â", "");
                result = codetext;
                //MessageBox.Show(codetext);

            }
            catch
            {
                result = "XMB (VSH)";
            }

            return result;
        }
        public string GetWMVersion(string wm_ps3_html)
        {
            string Result;
            try
            {
                string trashtext = wm_ps3_html.Substring(0, 3165);
                string newhtml = wm_ps3_html.Replace(trashtext, "");
                Result = newhtml.Substring(0, 19);
                ///Result.Replace()
            }
            catch
            {
                Result = "unknown";
            }

            return Result;
        }


        public string GetCPU_RSX_TMP(string wm_ps3_html)
        {
            string result = "";
            string HTML = wm_ps3_html;
            try
            {
                int keyIndex_1 = HTML.IndexOf("CPU:");
                int keyIndex_2 = HTML.IndexOf("RSX:");

                string i_cpu = HTML.Substring(keyIndex_1, 10);
                string i_rsx = HTML.Substring(keyIndex_2, 10);
                string str = i_cpu + " " + i_rsx;
                str = str.Replace("Â", "");
                result = str;
                return result;
            }
            catch
            {
                result = "Unhandled Error while converting strings. (055348673)";
                return result;
            }


        }
        public string GetCurrGameImageURL(string wm_ps3_html)
        {
            int keyIndex = wm_ps3_html.IndexOf("<img src=\"/dev_hdd0/game/");
            string keyString = wm_ps3_html.Substring(keyIndex, 44);
            keyString = keyString.Replace("<img src=\"", "");
            return keyString;
        }
        public string GetCurrentMemory(string wm_ps3_html_cpursx)
        {
            var HTML = wm_ps3_html_cpursx;
            int keyIndex = HTML.IndexOf("class=\"s\" href=\"/games.ps3\">");
            string value = HTML.Substring(keyIndex + 28, 13);
            /// MessageBox.Show(value);
            if (value == "=\"http://www.")
            {
                return "0";
            }
            return value;

        }
        public string GetHDD(string wm_ps3_html_cpursx)
        {
            var HTML = wm_ps3_html_cpursx;
            string key = "/a><br><a href=\"/dev_hdd0\">";
            int keyIndex = HTML.IndexOf(key);
            string value = HTML.Substring(keyIndex + 27, 12);

            return value;
        }
        public string CurrUserID(string wm_ps3_html_cpursx)
        {
            var HTML = wm_ps3_html_cpursx;
            try
            {

                string key = "br><a href=\"/dev_hdd0/home/";
                int FIndex = HTML.IndexOf(key);
                string FValue = HTML.Substring(FIndex + 27, 8);
                return FValue;

            }
            catch
            {
                return "000000000";
            }

        }
        public string CurrUserDirectory(string wm_ps3_html_cpursx)
        {
            string result = "";
            try
            {
                var HTML = wm_ps3_html_cpursx;
                string key = "br><a href=\"/dev_hdd0/home/";
                int FIndex = HTML.IndexOf(key);
                string FValue = HTML.Substring(FIndex + 12, 23);
                result = FValue;
                if (result == "html><html xmlns=\"http:")
                {
                    result = "/dev_hdd0/home/00000000";
                }
                return result;
                //
            }

            catch
            {
                result = "Error while processing strings.";
                return result;
            }


        }
        public string GetCurrentFanSpeed(string wm_ps3_html_cpursx)
        {
            try
            {
                var HTML = wm_ps3_html_cpursx;
                string keyToSearch = "href=\"/cpursx.ps3?mode\"";
                int FPhraseIndex = HTML.IndexOf(keyToSearch);
                string Fvalue = HTML.Substring(FPhraseIndex + 24, 21);
                return Fvalue.Replace("VEL. FAN: ", "");
            }
            catch
            {
                return "Error";
            }


        }
        public Bitmap GetCurrentGamePic(string wm_ps3_html, string consoleIp, bool letcheck = false)
        {
            try
            {
                string uriprefix = $"http://{consoleIp}";
                string link = uriprefix + GetCurrGameImageURL(wm_ps3_html);
                System.Net.WebRequest request =
                System.Net.WebRequest.Create(link);

                System.Net.WebResponse response = request.GetResponse();
                System.IO.Stream responseStream = response.GetResponseStream();

                Bitmap bmp = (Bitmap)Bitmap.FromStream(responseStream);
                response.Close();
                response.Close();

                return bmp;
            }
            catch
            {
                return null;
            }

        }
        public string GetFirmware(string wm_ps3_html_cpursx)
        {
            try
            {
                string HTML = wm_ps3_html_cpursx;
                int keyIndex = HTML.IndexOf("<a class=\"s\" href=\"/setup.ps3\">");
                string valueFormat = HTML.Substring(keyIndex + 31, 19);
                return valueFormat;

            }
            catch
            {
                return "";
            }

        }
        public string GetStartupElapsedTime(string wm_ps3_html_cpursx)
        {
            try
            {
                string HTML = wm_ps3_html_cpursx;
                int keyIndex = HTML.IndexOf("style='position:relative;top:8px;'></label>");
                string strValue = HTML.Substring(keyIndex + 45, 12);
                int dsIndex = strValue.IndexOf("d");
                string days = strValue.Substring(1, dsIndex);
                string hs = strValue.Substring(2, 2);
                string min = strValue.Substring(5, 2);
                string s = strValue.Substring(8, 2);
                string Result = days + "d" + ":" + hs + ":" + min + ":" + s;

                return Result;
            }
            catch
            {
                return "-d:-:-:-:-";
            }


        }
        public int FindDifference(int nr1, int nr2)
        {
            return Math.Abs(nr1 - nr2);
        }
        public static void WExeCommand(string ip, string command)
        {
            try
            {
                WebClient web = new WebClient();
                web.OpenRead(string.Format("http://" + ip + "/{0}", command.Replace("/", ""))).Close();
                new WebClient().DownloadData("http://" + ip + "/popup.ps3*~B" + command);
                Thread.Sleep(700);
                web.Dispose();
            }
            catch (WebException e) { if (e.Message == "The remote server returned an error: (501) OK") return; }

        }
        public static void PopupPs3(string ip, string message)
        {
            try
            {
                new WebClient().DownloadData("http://" + ip + "/popup.ps3*~B" + message.Replace("\n", " "));
                Thread.Sleep(200);
            }
            catch (WebException e) { if (e.Message == "The remote server returned an error: (501) OK") return; }
        }
        public static byte[] WBytes(string ip, string command)
        {
            try
            {
                WebClient web = new WebClient();
                var s = web.DownloadData(("http://" + ip + "/" + command));
                new WebClient().DownloadData("http://" + ip + "/popup.ps3*~B" + command);
                Thread.Sleep(500);
                web.Dispose();
                return s;
            }
            catch (WebException e) { if (e.Message == "The remote server returned an error: (501) OK") return null; }
            return null;
        }
        public void SWExeCommand(string ip, string command) => WExeCommand(ip, command);
    }

}



