using MiniServer.Server.Event;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MiniServer.Server
{
    namespace Event
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        enum EventType
        {
            /// <summary>
            /// 信息
            /// </summary>
            Info,
            /// <summary>
            /// 警告
            /// </summary>
            Warn,
            /// <summary>
            /// 错误
            /// </summary>
            Error
        }

        /// <summary>
        /// 消息事件参数
        /// </summary>
        class MessageEventArgs
        {
            /// <summary>
            /// 事件类型
            /// </summary>
            public EventType Type;
            /// <summary>
            /// 事件消息
            /// </summary>
            public string Info;
        }

        /// <summary>
        /// 请求事件参数
        /// </summary>
        class RequestEventArgs
        {
            public RequestEventArgs(string uri, string method, HttpListenerRequest request, HttpListenerResponse response)
            {
                RequestUri = uri;
                RequestMethod = method;
                Request = request;
                Response = response;
            }
            /// <summary>
            /// 请求地址
            /// </summary>
            public string RequestUri { get; }
            /// <summary>
            /// 请求方法
            /// </summary>
            public string RequestMethod { get; }
            /// <summary>
            /// 请求对象
            /// </summary>
            public HttpListenerRequest Request { get; }
            /// <summary>
            /// 响应对象
            /// </summary>
            public HttpListenerResponse Response { get; }
            /// <summary>
            /// 表示该事件已经处理
            /// </summary>
            public bool Handled { get; set; }
        }

    }

    /// <summary>
    /// 声明一个用于传递消息的事件委托
    /// </summary>
    /// <param name="sender">事件发送对象</param>
    /// <param name="e">消息事件对象</param>
    delegate void SimpleHttpMessage(object sender, MessageEventArgs e);

    /// <summary>
    /// 声明一个用于处理请求的事件委托
    /// </summary>
    /// <param name="sender">事件发送对象</param>
    /// <param name="e">请求事件对象</param>
    delegate void SimpleHttpRequest(object sender, RequestEventArgs e);

    /// <summary>
    /// 简单的 HTTP 服务
    /// </summary>
    class SimpleHttpServer
    {
        private int port;
        private bool enableCSRF;
        private string workspace;
        private readonly HttpListener listener = new HttpListener();
        private readonly Dictionary<string, string> HttpContentType = new Dictionary<string, string>();

        /// <summary>
        /// 消息事件
        /// </summary>
        public event SimpleHttpMessage OnMessage;
        /// <summary>
        /// 请求事件
        /// </summary>
        public event SimpleHttpRequest OnRequest;

        public SimpleHttpServer()
        {
            HttpContentType.Add(".tif", "image/tiff");
            HttpContentType.Add(".ai", "application/postscript");
            HttpContentType.Add(".aifc", "audio/aiff");
            HttpContentType.Add(".anv", "application/x-anv");
            HttpContentType.Add(".asf", "video/x-ms-asf");
            HttpContentType.Add(".asx", "video/x-ms-asf");
            HttpContentType.Add(".avi", "video/avi");
            HttpContentType.Add(".biz", "text/xml;charset=utf-8");
            HttpContentType.Add(".bot", "application/x-bot");
            HttpContentType.Add(".c90", "application/x-c90");
            HttpContentType.Add(".cat", "application/vnd.ms-pki.seccat");
            HttpContentType.Add(".cdr", "application/x-cdr");
            HttpContentType.Add(".cer", "application/x-x509-ca-cert");
            HttpContentType.Add(".cgm", "application/x-cgm");
            HttpContentType.Add(".class", "java/*");
            HttpContentType.Add(".cmp", "application/x-cmp");
            HttpContentType.Add(".cot", "application/x-cot");
            HttpContentType.Add(".crt", "application/x-x509-ca-cert");
            HttpContentType.Add(".css", "text/css;charset=utf-8");
            HttpContentType.Add(".dbf", "application/x-dbf");
            HttpContentType.Add(".dbx", "application/x-dbx");
            HttpContentType.Add(".dcx", "application/x-dcx");
            HttpContentType.Add(".dgn", "application/x-dgn");
            HttpContentType.Add(".dll", "application/x-msdownload");
            HttpContentType.Add(".dot", "application/msword");
            HttpContentType.Add(".dtd", "text/xml;charset=utf-8");
            HttpContentType.Add(".dwf", "application/x-dwf");
            HttpContentType.Add(".dxb", "application/x-dxb");
            HttpContentType.Add(".edn", "application/vnd.adobe.edn");
            HttpContentType.Add(".eml", "Info/rfc822");
            HttpContentType.Add(".epi", "application/x-epi");
            HttpContentType.Add(".eps", "application/postscript");
            HttpContentType.Add(".exe", "application/x-msdownload");
            HttpContentType.Add(".fdf", "application/vnd.fdf");
            HttpContentType.Add(".fo", "text/xml;charset=utf-8");
            HttpContentType.Add(".g4", "application/x-g4");
            HttpContentType.Add(".", "application/x-");
            HttpContentType.Add(".gl2", "application/x-gl2");
            HttpContentType.Add(".hgl", "application/x-hgl");
            HttpContentType.Add(".hpg", "application/x-hpgl");
            HttpContentType.Add(".hqx", "application/mac-binhex40");
            HttpContentType.Add(".hta", "application/hta");
            HttpContentType.Add(".htm", "text/html;charset=utf-8");
            HttpContentType.Add(".htt", "text/webviewhtml;charset=utf-8");
            HttpContentType.Add(".icb", "application/x-icb");
            HttpContentType.Add(".ico", "application/x-ico");
            HttpContentType.Add(".ig4", "application/x-g4");
            HttpContentType.Add(".iii", "application/x-iphone");
            HttpContentType.Add(".ins", "application/x-internet-signup");
            HttpContentType.Add(".IVF", "video/x-ivf");
            HttpContentType.Add(".jfif", "image/jpeg");
            HttpContentType.Add(".jpe", "application/x-jpe");
            HttpContentType.Add(".jpg", "image/jpeg");
            HttpContentType.Add(".js", "application/x-javascript;charset=utf-8");
            HttpContentType.Add(".json", "application/json;charset=utf-8");
            HttpContentType.Add(".la1", "audio/x-liquid-file");
            HttpContentType.Add(".latex", "application/x-latex");
            HttpContentType.Add(".lbm", "application/x-lbm");
            HttpContentType.Add(".ls", "application/x-javascript");
            HttpContentType.Add(".m1v", "video/x-mpeg");
            HttpContentType.Add(".m3u", "audio/mpegurl");
            HttpContentType.Add(".mac", "application/x-mac");
            HttpContentType.Add(".math", "text/xml;charset=utf-8");
            HttpContentType.Add(".md", "text/plain;charset=utf-8");
            HttpContentType.Add(".mdb", "application/x-mdb");
            HttpContentType.Add(".mht", "Info/rfc822");
            HttpContentType.Add(".mi", "application/x-mi");
            HttpContentType.Add(".midi", "audio/mid");
            HttpContentType.Add(".mml", "text/xml;charset=utf-8");
            HttpContentType.Add(".mns", "audio/x-musicnet-stream");
            HttpContentType.Add(".movie", "video/x-sgi-movie");
            HttpContentType.Add(".mp2", "audio/mp2");
            HttpContentType.Add(".mp3", "audio/mp3");
            HttpContentType.Add(".mpa", "video/x-mpg");
            HttpContentType.Add(".mpe", "video/x-mpeg");
            HttpContentType.Add(".mpg", "video/mpg");
            HttpContentType.Add(".mpp", "application/vnd.ms-project");
            HttpContentType.Add(".mpt", "application/vnd.ms-project");
            HttpContentType.Add(".mpv2", "video/mpeg");
            HttpContentType.Add(".mpx", "application/vnd.ms-project");
            HttpContentType.Add(".mxp", "application/x-mmxp");
            HttpContentType.Add(".nrf", "application/x-nrf");
            HttpContentType.Add(".odc", "text/x-ms-odc;charset=utf-8");
            HttpContentType.Add(".p10", "application/pkcs10");
            HttpContentType.Add(".p7b", "application/x-pkcs7-certificates");
            HttpContentType.Add(".p7m", "application/pkcs7-mime");
            HttpContentType.Add(".p7s", "application/pkcs7-signature");
            HttpContentType.Add(".pci", "application/x-pci");
            HttpContentType.Add(".pcx", "application/x-pcx");
            HttpContentType.Add(".pdf", "application/pdf");
            HttpContentType.Add(".pfx", "application/x-pkcs12");
            HttpContentType.Add(".pic", "application/x-pic");
            HttpContentType.Add(".pl", "application/x-perl");
            HttpContentType.Add(".pls", "audio/scpls");
            HttpContentType.Add(".png", "image/png");
            HttpContentType.Add(".pot", "application/vnd.ms-powerpoint");
            HttpContentType.Add(".ppm", "application/x-ppm");
            HttpContentType.Add(".ppt", "application/vnd.ms-powerpoint");
            HttpContentType.Add(".pr", "application/x-pr");
            HttpContentType.Add(".prn", "application/x-prn");
            HttpContentType.Add(".ps", "application/x-ps");
            HttpContentType.Add(".ptn", "application/x-ptn");
            HttpContentType.Add(".r3t", "text/vnd.rn-realtext3d;charset=utf-8");
            HttpContentType.Add(".ram", "audio/x-pn-realaudio");
            HttpContentType.Add(".rat", "application/rat-file");
            HttpContentType.Add(".rec", "application/vnd.rn-recording");
            HttpContentType.Add(".rgb", "application/x-rgb");
            HttpContentType.Add(".rjt", "application/vnd.rn-realsystem-rjt");
            HttpContentType.Add(".rle", "application/x-rle");
            HttpContentType.Add(".rmf", "application/vnd.adobe.rmf");
            HttpContentType.Add(".rmj", "application/vnd.rn-realsystem-rmj");
            HttpContentType.Add(".rmp", "application/vnd.rn-rn_music_package");
            HttpContentType.Add(".rmvb", "application/vnd.rn-realmedia-vbr");
            HttpContentType.Add(".rnx", "application/vnd.rn-realplayer");
            HttpContentType.Add(".rpm", "audio/x-pn-realaudio-plugin");
            HttpContentType.Add(".rt", "text/vnd.rn-realtext;charset=utf-8");
            HttpContentType.Add(".rtf", "application/x-rtf");
            HttpContentType.Add(".sam", "application/x-sam");
            HttpContentType.Add(".sdp", "application/sdp");
            HttpContentType.Add(".sit", "application/x-stuffit");
            HttpContentType.Add(".sld", "application/x-sld");
            HttpContentType.Add(".smi", "application/smil");
            HttpContentType.Add(".smk", "application/x-smk");
            HttpContentType.Add(".sol", "text/plain;charset=utf-8");
            HttpContentType.Add(".spc", "application/x-pkcs7-certificates");
            HttpContentType.Add(".spp", "text/xml;charset=utf-8");
            HttpContentType.Add(".sst", "application/vnd.ms-pki.certstore");
            HttpContentType.Add(".stm", "text/html");
            HttpContentType.Add(".svg", "text/xml;charset=utf-8");
            HttpContentType.Add(".tdf", "application/x-tdf");
            HttpContentType.Add(".tga", "application/x-tga");
            HttpContentType.Add(".tld", "text/xml;charset=utf-8");
            HttpContentType.Add(".torrent", "application/x-bittorrent");
            HttpContentType.Add(".txt", "text/plain");
            HttpContentType.Add(".uls", "text/iuls;charset=utf-8");
            HttpContentType.Add(".vda", "application/x-vda");
            HttpContentType.Add(".vml", "text/xml;charset=utf-8");
            HttpContentType.Add(".vsd", "application/vnd.visio");
            HttpContentType.Add(".vss", "application/vnd.visio");
            HttpContentType.Add(".vst", "application/x-vst");
            HttpContentType.Add(".vsx", "application/vnd.visio");
            HttpContentType.Add(".vxml", "text/xml;charset=utf-8");
            HttpContentType.Add(".wax", "audio/x-ms-wax");
            HttpContentType.Add(".wb2", "application/x-wb2");
            HttpContentType.Add(".wbmp", "image/vnd.wap.wbmp");
            HttpContentType.Add(".wk3", "application/x-wk3");
            HttpContentType.Add(".wkq", "application/x-wkq");
            HttpContentType.Add(".wm", "video/x-ms-wm");
            HttpContentType.Add(".wmd", "application/x-ms-wmd");
            HttpContentType.Add(".wml", "text/vnd.wap.wml;charset=utf-8");
            HttpContentType.Add(".wmx", "video/x-ms-wmx");
            HttpContentType.Add(".wp6", "application/x-wp6");
            HttpContentType.Add(".wpg", "application/x-wpg");
            HttpContentType.Add(".wq1", "application/x-wq1");
            HttpContentType.Add(".wri", "application/x-wri");
            HttpContentType.Add(".ws", "application/x-ws");
            HttpContentType.Add(".wsc", "text/scriptlet;charset=utf-8");
            HttpContentType.Add(".wvx", "video/x-ms-wvx");
            HttpContentType.Add(".xdr", "text/xml;charset=utf-8");
            HttpContentType.Add(".xfdf", "application/vnd.adobe.xfdf");
            HttpContentType.Add(".xls", "application/vnd.ms-excel");
            HttpContentType.Add(".xlw", "application/x-xlw");
            HttpContentType.Add(".xpl", "audio/scpls");
            HttpContentType.Add(".xql", "text/xml;charset=utf-8");
            HttpContentType.Add(".xsd", "text/xml;charset=utf-8");
            HttpContentType.Add(".xslt", "text/xml;charset=utf-8");
            HttpContentType.Add(".x_b", "application/x-x_b");
            HttpContentType.Add(".sisx", "application/vnd.symbian.install");
            HttpContentType.Add(".ipa", "application/vnd.iphone");
            HttpContentType.Add(".xap", "application/x-silverlight-app");
            HttpContentType.Add(".acp", "audio/x-mei-aac");
            HttpContentType.Add(".aif", "audio/aiff");
            HttpContentType.Add(".aiff", "audio/aiff");
            HttpContentType.Add(".asa", "text/asa;charset=utf-8");
            HttpContentType.Add(".asp", "text/asp;charset=utf-8");
            HttpContentType.Add(".au", "audio/basic");
            HttpContentType.Add(".awf", "application/vnd.adobe.workflow");
            HttpContentType.Add(".bmp", "application/x-bmp");
            HttpContentType.Add(".c4t", "application/x-c4t");
            HttpContentType.Add(".cal", "application/x-cals");
            HttpContentType.Add(".cdf", "application/x-netcdf");
            HttpContentType.Add(".cel", "application/x-cel");
            HttpContentType.Add(".cg4", "application/x-g4");
            HttpContentType.Add(".cit", "application/x-cit");
            HttpContentType.Add(".cml", "text/xml;charset=utf-8");
            HttpContentType.Add(".cmx", "application/x-cmx");
            HttpContentType.Add(".crl", "application/pkix-crl");
            HttpContentType.Add(".csi", "application/x-csi");
            HttpContentType.Add(".cut", "application/x-cut");
            HttpContentType.Add(".dbm", "application/x-dbm");
            HttpContentType.Add(".dcd", "text/xml;charset=utf-8");
            HttpContentType.Add(".der", "application/x-x509-ca-cert");
            HttpContentType.Add(".dib", "application/x-dib");
            HttpContentType.Add(".doc", "application/msword");
            HttpContentType.Add(".drw", "application/x-drw");
            HttpContentType.Add(".dwg", "application/x-dwg");
            HttpContentType.Add(".dxf", "application/x-dxf");
            HttpContentType.Add(".emf", "application/x-emf");
            HttpContentType.Add(".ent", "text/xml;charset=utf-8");
            HttpContentType.Add(".etd", "application/x-ebx");
            HttpContentType.Add(".fax", "image/fax");
            HttpContentType.Add(".fif", "application/fractals");
            HttpContentType.Add(".frm", "application/x-frm");
            HttpContentType.Add(".gbr", "application/x-gbr");
            HttpContentType.Add(".gif", "image/gif");
            HttpContentType.Add(".gp4", "application/x-gp4");
            HttpContentType.Add(".hmr", "application/x-hmr");
            HttpContentType.Add(".hpl", "application/x-hpl");
            HttpContentType.Add(".hrf", "application/x-hrf");
            HttpContentType.Add(".htc", "text/x-component;charset=utf-8");
            HttpContentType.Add(".html", "text/html;charset=utf-8");
            HttpContentType.Add(".htx", "text/html;charset=utf-8");
            HttpContentType.Add(".iff", "application/x-iff");
            HttpContentType.Add(".igs", "application/x-igs");
            HttpContentType.Add(".img", "application/x-img");
            HttpContentType.Add(".isp", "application/x-internet-signup");
            HttpContentType.Add(".java", "java/*");
            HttpContentType.Add(".jpeg", "image/jpeg");
            HttpContentType.Add(".jsp", "text/html;charset=utf-8");
            HttpContentType.Add(".lar", "application/x-laplayer-reg");
            HttpContentType.Add(".lavs", "audio/x-liquid-secure");
            HttpContentType.Add(".lmsff", "audio/x-la-lms");
            HttpContentType.Add(".ltr", "application/x-ltr");
            HttpContentType.Add(".m2v", "video/x-mpeg");
            HttpContentType.Add(".m4e", "video/mpeg4");
            HttpContentType.Add(".man", "application/x-troff-man");
            HttpContentType.Add(".mfp", "application/x-shockwave-flash");
            HttpContentType.Add(".mhtml", "Info/rfc822");
            HttpContentType.Add(".mid", "audio/mid");
            HttpContentType.Add(".mil", "application/x-mil");
            HttpContentType.Add(".mnd", "audio/x-musicnet-download");
            HttpContentType.Add(".mocha", "application/x-javascript");
            HttpContentType.Add(".mp1", "audio/mp1");
            HttpContentType.Add(".mp2v", "video/mpeg");
            HttpContentType.Add(".mp4", "video/mpeg4");
            HttpContentType.Add(".mpd", "application/vnd.ms-project");
            HttpContentType.Add(".mpeg", "video/mpg");
            HttpContentType.Add(".mpga", "audio/rn-mpeg");
            HttpContentType.Add(".mps", "video/x-mpeg");
            HttpContentType.Add(".mpv", "video/mpg");
            HttpContentType.Add(".mpw", "application/vnd.ms-project");
            HttpContentType.Add(".mtx", "text/xml;charset=utf-8");
            HttpContentType.Add(".net", "image/pnetvue");
            HttpContentType.Add(".nws", "Info/rfc822");
            HttpContentType.Add(".out", "application/x-out");
            HttpContentType.Add(".p12", "application/x-pkcs12");
            HttpContentType.Add(".p7c", "application/pkcs7-mime");
            HttpContentType.Add(".p7r", "application/x-pkcs7-certreqresp");
            HttpContentType.Add(".pc5", "application/x-pc5");
            HttpContentType.Add(".pcl", "application/x-pcl");
            HttpContentType.Add(".pdx", "application/vnd.adobe.pdx");
            HttpContentType.Add(".pgl", "application/x-pgl");
            HttpContentType.Add(".pko", "application/vnd.ms-pki.pko");
            HttpContentType.Add(".plg", "text/html;charset=utf-8");
            HttpContentType.Add(".plt", "application/x-plt");
            HttpContentType.Add(".ppa", "application/vnd.ms-powerpoint");
            HttpContentType.Add(".pps", "application/vnd.ms-powerpoint");
            HttpContentType.Add(".prf", "application/pics-rules");
            HttpContentType.Add(".prt", "application/x-prt");
            HttpContentType.Add(".pwz", "application/vnd.ms-powerpoint");
            HttpContentType.Add(".ra", "audio/vnd.rn-realaudio");
            HttpContentType.Add(".ras", "application/x-ras");
            HttpContentType.Add(".rdf", "text/xml;charset=utf-8");
            HttpContentType.Add(".red", "application/x-red");
            HttpContentType.Add(".rjs", "application/vnd.rn-realsystem-rjs");
            HttpContentType.Add(".rlc", "application/x-rlc");
            HttpContentType.Add(".rm", "application/vnd.rn-realmedia");
            HttpContentType.Add(".rmi", "audio/mid");
            HttpContentType.Add(".rmm", "audio/x-pn-realaudio");
            HttpContentType.Add(".rms", "application/vnd.rn-realmedia-secure");
            HttpContentType.Add(".rmx", "application/vnd.rn-realsystem-rmx");
            HttpContentType.Add(".rp", "image/vnd.rn-realpix");
            HttpContentType.Add(".rsml", "application/vnd.rn-rsml");
            HttpContentType.Add(".rv", "video/vnd.rn-realvideo");
            HttpContentType.Add(".sat", "application/x-sat");
            HttpContentType.Add(".sdw", "application/x-sdw");
            HttpContentType.Add(".slb", "application/x-slb");
            HttpContentType.Add(".slk", "drawing/x-slk");
            HttpContentType.Add(".smil", "application/smil");
            HttpContentType.Add(".snd", "audio/basic");
            HttpContentType.Add(".sor", "text/plain;charset=utf-8");
            HttpContentType.Add(".spl", "application/futuresplash");
            HttpContentType.Add(".ssm", "application/streamingmedia");
            HttpContentType.Add(".stl", "application/vnd.ms-pki.stl");
            HttpContentType.Add(".sty", "application/x-sty");
            HttpContentType.Add(".swf", "application/x-shockwave-flash");
            HttpContentType.Add(".tg4", "application/x-tg4");
            HttpContentType.Add(".tiff", "image/tiff");
            HttpContentType.Add(".top", "drawing/x-top");
            HttpContentType.Add(".tsd", "text/xml;charset=utf-8");
            HttpContentType.Add(".uin", "application/x-icq");
            HttpContentType.Add(".vcf", "text/x-vcard;charset=utf-8");
            HttpContentType.Add(".vdx", "application/vnd.visio");
            HttpContentType.Add(".vpg", "application/x-vpeg005");
            HttpContentType.Add(".vsw", "application/vnd.visio");
            HttpContentType.Add(".vtx", "application/vnd.visio");
            HttpContentType.Add(".wav", "audio/wav");
            HttpContentType.Add(".wb1", "application/x-wb1");
            HttpContentType.Add(".wb3", "application/x-wb3");
            HttpContentType.Add(".wiz", "application/msword");
            HttpContentType.Add(".wk4", "application/x-wk4");
            HttpContentType.Add(".wks", "application/x-wks");
            HttpContentType.Add(".wma", "audio/x-ms-wma");
            HttpContentType.Add(".wmf", "application/x-wmf");
            HttpContentType.Add(".wmv", "video/x-ms-wmv");
            HttpContentType.Add(".wmz", "application/x-ms-wmz");
            HttpContentType.Add(".wpd", "application/x-wpd");
            HttpContentType.Add(".wpl", "application/vnd.ms-wpl");
            HttpContentType.Add(".wr1", "application/x-wr1");
            HttpContentType.Add(".wrk", "application/x-wrk");
            HttpContentType.Add(".ws2", "application/x-ws");
            HttpContentType.Add(".wsdl", "text/xml;charset=utf-8");
            HttpContentType.Add(".xdp", "application/vnd.adobe.xdp");
            HttpContentType.Add(".xfd", "application/vnd.adobe.xfd");
            HttpContentType.Add(".xhtml", "text/html;charset=utf-8");
            HttpContentType.Add(".xml", "text/xml;charset=utf-8");
            HttpContentType.Add(".xq", "text/xml;charset=utf-8");
            HttpContentType.Add(".xquery", "text/xml;charset=utf-8");
            HttpContentType.Add(".xsl", "text/xml;charset=utf-8");
            HttpContentType.Add(".xwd", "application/x-xwd");
            HttpContentType.Add(".sis", "application/vnd.symbian.install");
            HttpContentType.Add(".x_t", "application/x-x_t");
            HttpContentType.Add(".apk", "application/vnd.android.package-archive");
        }

        /// <summary>
        /// 是否开启 CSRF
        /// </summary>
        public bool EnableCSRF { get => enableCSRF; set => enableCSRF = value; }
        /// <summary>
        /// 工作端口
        /// </summary>
        public int Port { get => port; set => port = value; }
        /// <summary>
        /// 服务网址的前缀
        /// </summary>
        public string Prefixes { get => string.Join("", this.listener.Prefixes.AsEnumerable()); }
        /// <summary>
        /// 工作目录
        /// </summary>
        public string Workspace
        {
            get
            {
                DirectoryInfo dir = new DirectoryInfo(string.IsNullOrEmpty(this.workspace) ? "." : this.workspace);
                return dir.FullName;
            }
            set
            {
                Print(EventType.Warn, "Switch workspace to : " + value);
                workspace = value;
            }
        }

        /// <summary>
        /// 获取默认的 DOM 文本
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="label">状态码标签文本</param>
        /// <param name="desc">其他描述</param>
        /// <returns></returns>
        private string getDefaultDomString(int code, string label, string desc = "")
        {
            string title = code + " " + label;
            string html = "";
            html += "<!DOCTYPE HTML>";
            html += "<html lang=\"zh-CN\">";
            html += "  <head>";
            html += "    <meta charset=\"UTF-8\">";
            html += "    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">";
            html += "    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">";
            html += "    <title>" + title + "</title>";
            html += "  </head>";
            html += "  <body style=\"text-align: center\">";
            html += "    <h1>" + title + "</h1>";
            html += "    <hr />";
            html += "    <p><a href=\"/\">Back to /</a></p>";
            html += "    <p>" + desc + "</p>";
            html += "  </body>";
            html += "</html>";
            return html;
        }
        /// <summary>
        /// 打印信息到事件中
        /// </summary>
        /// <param name="type">打印类型</param>
        /// <param name="vs">需要打印的信息的内容</param>
        private void Print(EventType type, params object[] vs)
        {
            IEnumerable<string> strs = vs.Select(v => v != null ? v.ToString() : "");
            string info = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + "] ";
            info += string.Join(" ", strs) + "\n";
            MessageEventArgs e = new MessageEventArgs();
            e.Type = type;
            e.Info = info;
            OnMessage(this, e);
        }
        /// <summary>
        /// 根据当前 URI 获取当前目录的路径
        /// </summary>
        /// <param name="uri">请求的 uri</param>
        /// <returns></returns>
        private string GetCurrentDirectoryPathByRawUri(string uri)
        {
            DirectoryInfo dir = new DirectoryInfo(this.Workspace);
            if (!dir.Exists)
            {
                dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            }
            List<string> uris = uri.ToString().Split('/').ToList();
            uris.Insert(0, dir.FullName);
            return Path.Combine(uris.ToArray());
        }
        /// <summary>
        /// 获取指定路径下的目录列表页面
        /// </summary>
        /// <param name="path">指定的路径</param>
        /// <returns></returns>
        private string GetDirectoryListDom(string path, string uri)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = null;
            DirectoryInfo[] dirs = null;
            try
            {
                files = directory.GetFiles();
                dirs = directory.GetDirectories();
            }
            catch (Exception)
            {
                files = new FileInfo[0];
                dirs = new DirectoryInfo[0];
            }

            List<string> lines = new List<string>
            {
                "<!DOCTYPE HTML>",
                "<html lang=\"zh-CN\">",
                "  <head>",
                "    <meta charset=\"UTF-8\">",
                "    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">",
                "    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">",
                "    <title>目录索引</title>",
                "  </head>",
                "  <body>",
                "    <h1>目录列表： " + uri + "</h1>",
                "    <hr>",
                "    <ul>"
            };
            if (!"/".Equals(uri))
            {
                lines.Add(string.Format("        <li><a href=\"../\">上级目录</a></li>"));
            }
            foreach (DirectoryInfo dir in dirs)
            {
                if (dir.Name.StartsWith("."))
                {
                    continue;
                }
                lines.Add(string.Format("        <li><a href=\"./{0}/\">{0}</a></li>", dir.Name));
            }
            foreach (FileInfo file in files)
            {
                if (file.Name.StartsWith("."))
                {
                    continue;
                }
                lines.Add(string.Format("        <li><a href=\"./{0}\">{0}</a></li>", file.Name));
            }
            lines.Add("    </ul>");
            lines.Add("  </body>");
            lines.Add("</html>");

            return string.Join("\r\n", lines.ToArray());
        }
        /// <summary>
        /// 处理请求
        /// </summary>
        private void HandleRequest()
        {
            while (listener.IsListening)
            {
                HttpListenerContext context = null;
                try
                {
                    context = listener.GetContext();
                }
                catch (Exception)
                {
                    break;
                }

                HttpListenerRequest request = context.Request;
                string method = request.HttpMethod;
                string uri = HttpUtility.UrlDecode(request.Url.AbsolutePath);
                string info = string.Format("[{0}] {1}", method, uri);
                Print(EventType.Info, info);

                string path = GetCurrentDirectoryPathByRawUri(uri);

                HttpListenerResponse response = context.Response;
                response.ContentEncoding = Encoding.UTF8;

                if (this.OnRequest != null)
                {
                    // 判断是否已经实现了处理请求的方法
                    bool isImplemented = true;
                    RequestEventArgs args = new RequestEventArgs(uri, method, request, response);
                    try
                    {
                        this.OnRequest(this, args);
                    }
                    catch (Exception e)
                    {
                        isImplemented = !(e is NotImplementedException);
                        if (isImplemented)
                        {
                            // 如果已经实现了该事件的处理，则出现错误后处理为 500
                            response.StatusCode = 500;
                            using (StreamWriter swriter = new StreamWriter(response.OutputStream))
                            {
                                // 处理为 500
                                swriter.WriteLine(getDefaultDomString(500, "Server Error", e.Message));
                            }
                            continue;
                        }
                    }
                    if (isImplemented && args.Handled)
                    {
                        // 如果外部已经实现，并且已经处理，则不执行后续的默认处理过程
                        continue;
                    }
                }

                // 如果是目录，则查找默认的首页页面
                if (Directory.Exists(path))
                {
                    string[] indexFiles = { "index.html", "index.htm", "default.html", "default.htm" };
                    foreach (string indexFile in indexFiles)
                    {
                        string indexFilePath = Path.Combine(path, indexFile);
                        if (File.Exists(indexFilePath))
                        {
                            path = indexFilePath;
                            break;
                        }
                    }
                }

                // 根据后缀名增加 ContentType 的响应头
                string suffix = Path.GetExtension(path);
                if (HttpContentType.ContainsKey(suffix))
                {
                    response.ContentType = HttpContentType[suffix];
                    // response.AddHeader("ContentType", HttpContentType[suffix]);
                }

                if (File.Exists(path))
                {
                    // 请求的路径是文件，则处理为下载
                    using (Stream writer = response.OutputStream)
                    {
                        //创建读取文件的流
                        string error = "";
                        try
                        {
                            using (FileStream reader = new FileStream(path, FileMode.Open, FileAccess.Read))
                            {
                                int length = 0;
                                //创建一个5M的缓冲区
                                byte[] buffers = new byte[1024 * 1024 * 5];
                                int i = 0;
                                //文件读取到缓冲区
                                while ((i = reader.Read(buffers, 0, buffers.Length)) > 0)
                                {
                                    //将缓冲区中内容写入fsWriter流
                                    writer.Write(buffers, 0, i);
                                    length += i;
                                    //显示进度
                                    double proc = (double)length / reader.Length;

                                    info = string.Format("[{0}] [↓ {1:F2}%] {2}", method, proc * 100, uri);
                                    Print(EventType.Info, info);
                                }
                            }
                        }
                        catch (IOException e)
                        {
                            error = e.Message;
                        }
                        if (!string.IsNullOrEmpty(error))
                        {
                            // 存在错误信息，极有可能是因为读取的时候出现异常，处理为服务器异常即可
                            response.StatusCode = 500;
                            using (StreamWriter swriter = new StreamWriter(writer))
                            {
                                swriter.WriteLine(getDefaultDomString(500, "Server Error", error));
                            }
                        }
                    }
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(response.OutputStream))
                    {
                        if (Directory.Exists(path))
                        {
                            // 请求路径是目录，则处理为目录列表展示
                            writer.WriteLine(GetDirectoryListDom(path, uri));
                        }
                        else
                        {
                            // 请求路径不是目录，则处理为找不到页面
                            response.StatusCode = 404;
                            writer.WriteLine(getDefaultDomString(404, "Not Found"));
                        }
                    }
                }


            }
        }
        /// <summary>
        /// 检测端口是否已经被占用
        /// </summary>
        /// <param name="port">端口号</param>
        /// <returns></returns>
        public static bool PortIsUsed(int port)
        {
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();

            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// 开启服务
        /// </summary>
        public void Start(int port = 9090)
        {
            if (listener.IsListening)
            {
                return;
            }

            if (PortIsUsed(port))
            {
                Print(EventType.Error, "Port " + port + " is already occupied!");
                return;
            }

            listener.Prefixes.Clear();
            listener.Prefixes.Add("http://localhost:" + port + "/");
            this.port = port;

            listener.Start();
            Print(EventType.Info, "Server is working at : " + this.Prefixes);
            Print(EventType.Info, "Server`workspace at : " + this.Workspace);
            Task task = Task.Factory.StartNew(this.HandleRequest);
            //task.Wait();
        }
        /// <summary>
        /// 停止服务
        /// </summary>
        public void Stop()
        {
            if (listener.IsListening)
            {
                listener.Stop();
                Print(EventType.Warn, "Server is stopped at : " + this.Port);
            }
        }
    }
}
