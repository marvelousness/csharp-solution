using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using NativeWifi;
using static NativeWifi.Wlan;
using static NativeWifi.WlanClient;


namespace WifiConnector
{
    public partial class FormMain : Form
    {

        private List<WlanAvailableNetwork> NetWorkList = new List<WlanAvailableNetwork>();
        private WlanInterface WlanIface;

        public FormMain()
        {
            WlanClient client = new WlanClient();
            WlanIface = client.Interfaces[0];
            WlanIface.WlanConnectionNotification += WlanIface_WlanConnectionNotification;
            WlanIface.WlanReasonNotification += WlanIface_WlanReasonNotification;
            InitializeComponent();

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadNetWork();
        }

        private void LoadNetWork()
        {
            WlanAvailableNetwork[] networks = WlanIface.GetAvailableNetworkList(0);
            foreach (WlanAvailableNetwork network in networks)
            {
                string SSID = WlanHelper.GetStringForSSID(network.dot11Ssid);
                if (network.flags.HasFlag(WlanAvailableNetworkFlags.Connected))
                {
                    this.tsslInfo.Text = "当前已连接WIFI：" + SSID;
                }

                //如果有配置文件的SSID会重复出现。过滤掉
                if (!this.lbox.Items.Contains(SSID))
                {
                    this.lbox.Items.Add(SSID);
                    NetWorkList.Add(network);
                }
            }

            // 按信号强度排序
            NetWorkList.Sort((a, b) => b.wlanSignalQuality.CompareTo(a.wlanSignalQuality));

            this.lbox.Items.Clear();
            foreach (WlanAvailableNetwork network in NetWorkList)
            {
                this.lbox.Items.Add(WlanHelper.GetStringForSSID(network.dot11Ssid));
            }
        }

        void WlanIface_WlanReasonNotification(WlanNotificationData notifyData, WlanReasonCode reasonCode)
        {
            MessageBox.Show(reasonCode.ToString());
        }

        void WlanIface_WlanConnectionNotification(WlanNotificationData notifyData, WlanConnectionNotificationData connNotifyData)
        {
            string wifiName = connNotifyData.profileName;
            if (notifyData.notificationSource == WlanNotificationSource.MSM)
            {
                WlanNotificationCodeMsm msm = (WlanNotificationCodeMsm)notifyData.NotificationCode;
                switch (msm)
                {
                    case WlanNotificationCodeMsm.Associating:
                        break;
                    case WlanNotificationCodeMsm.Associated:
                        break;
                    case WlanNotificationCodeMsm.Authenticating:
                        Invoke(new Action(() => this.tsslInfo.Text = "正在验证：" + wifiName));
                        break;
                    case WlanNotificationCodeMsm.Connected:
                        Invoke(new Action(() => this.tsslInfo.Text = "已经连接：" + wifiName));
                        break;
                    case WlanNotificationCodeMsm.RoamingStart:
                        break;
                    case WlanNotificationCodeMsm.RoamingEnd:
                        break;
                    case WlanNotificationCodeMsm.RadioStateChange:
                        break;
                    case WlanNotificationCodeMsm.SignalQualityChange:
                        break;
                    case WlanNotificationCodeMsm.Disassociating:
                        break;
                    case WlanNotificationCodeMsm.Disconnected:
                        Invoke(new Action(() => this.tsslInfo.Text = "已经断开连接：" + wifiName));
                        break;
                    case WlanNotificationCodeMsm.PeerJoin:
                        break;
                    case WlanNotificationCodeMsm.PeerLeave:
                        break;
                    case WlanNotificationCodeMsm.AdapterRemoval:
                        break;
                    case WlanNotificationCodeMsm.AdapterOperationModeChange:
                        break;
                    default:
                        break;
                }
            }
            else if (notifyData.notificationSource == WlanNotificationSource.ACM)
            {
                WlanNotificationCodeAcm acm = (WlanNotificationCodeAcm) notifyData.NotificationCode;
                switch (acm)
                {
                    case WlanNotificationCodeAcm.AutoconfEnabled:
                        Invoke(new Action(() => this.tsslInfo.Text = "自动配置已启用"));
                        break;
                    case WlanNotificationCodeAcm.AutoconfDisabled:
                        Invoke(new Action(() => this.tsslInfo.Text = "自动配置已禁用"));
                        break;
                    case WlanNotificationCodeAcm.BackgroundScanEnabled:
                        Invoke(new Action(() => this.tsslInfo.Text = "后台扫描已启用"));
                        break;
                    case WlanNotificationCodeAcm.BackgroundScanDisabled:
                        Invoke(new Action(() => this.tsslInfo.Text = "后台扫描已禁用"));
                        break;
                    case WlanNotificationCodeAcm.BssTypeChange:
                        break;
                    case WlanNotificationCodeAcm.PowerSettingChange:
                        break;
                    case WlanNotificationCodeAcm.ScanComplete:
                        Invoke(new Action(() => this.tsslInfo.Text = "扫描完成"));
                        break;
                    case WlanNotificationCodeAcm.ScanFail:
                        Invoke(new Action(() => this.tsslInfo.Text = "扫描失败"));
                        break;
                    case WlanNotificationCodeAcm.ConnectionStart:
                        Invoke(new Action(() => this.tsslInfo.Text = "正在连接：" + wifiName));
                        break;
                    case WlanNotificationCodeAcm.ConnectionComplete:
                        Invoke(new Action(() => this.tsslInfo.Text = "连接已完成：" + wifiName));
                        break;
                    case WlanNotificationCodeAcm.ConnectionAttemptFail:
                        //连接失败
                        {
                            Invoke(new Action(() => this.tsslInfo.Text = "连接失败：" + wifiName));
                            WlanIface.DeleteProfile(wifiName);
                        }
                        break;
                    case WlanNotificationCodeAcm.FilterListChange:
                        break;
                    case WlanNotificationCodeAcm.InterfaceArrival:
                        break;
                    case WlanNotificationCodeAcm.InterfaceRemoval:
                        break;
                    case WlanNotificationCodeAcm.ProfileChange:
                        break;
                    case WlanNotificationCodeAcm.ProfileNameChange:
                        break;
                    case WlanNotificationCodeAcm.ProfilesExhausted:
                        break;
                    case WlanNotificationCodeAcm.NetworkNotAvailable:
                        break;
                    case WlanNotificationCodeAcm.NetworkAvailable:
                        break;
                    case WlanNotificationCodeAcm.Disconnecting:
                        Invoke(new Action(() => this.tsslInfo.Text = "正在断开连接：" + wifiName));
                        break;
                    case WlanNotificationCodeAcm.Disconnected:
                        Invoke(new Action(() => this.tsslInfo.Text = "已经断开连接：" + wifiName));
                        break;
                    case WlanNotificationCodeAcm.AdhocNetworkStateChange:
                        break;
                    default:
                        break;
                }
            }

        }

        /// <summary>
        /// 鼠标双击直接连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.cmenuItemConnector_Click(null, null);
        }
        /// <summary>
        /// 选中项发生变化的时候显示WIFI的气泡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.lbox.SelectedIndex;
            if (index > -1 && index < NetWorkList.Count)
            {
                WlanAvailableNetwork wn = NetWorkList[this.lbox.SelectedIndex];
                this.tip.SetToolTip(this.lbox, WlanHelper.GetWifiToolTip(wn));
            }
        }
        /// <summary>
        /// 右键刷新列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmenuItemRefresh_Click(object sender, EventArgs e)
        {
            NetWorkList.Clear();
            this.lbox.Items.Clear();
            LoadNetWork();
        }
        /// <summary>
        /// 连接WiFi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmenuItemConnector_Click(object sender, EventArgs e)
        {
            WlanAvailableNetwork wn = NetWorkList[this.lbox.SelectedIndex];
            if (wn.securityEnabled && !WlanHelper.HasProfile(WlanIface, WlanHelper.GetStringForSSID(wn.dot11Ssid)))
            {
                FormPasswordInput fp = new FormPasswordInput();
                while (DialogResult.OK == new FormPasswordInput().ShowDialog())
                {
                    try
                    {
                        WlanHelper.ConnetWifi(WlanIface, wn, fp.Password);
                        break;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("手动连接失败!");
                    }
                }
                fp.Dispose();
            }
            else
            {
                WlanHelper.ConnetWifi(WlanIface, wn);
            }
        }
        /// <summary>
        /// 破解WiFi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmenuItemDecipher_Click(object sender, EventArgs e)
        {
            WlanAvailableNetwork wn = NetWorkList[this.lbox.SelectedIndex];
            if (wn.securityEnabled && !WlanHelper.HasProfile(WlanIface, WlanHelper.GetStringForSSID(wn.dot11Ssid)))
            {
                // 1. 先尝试使用简单密码破解
                string[] pwds = SimpleEnumerator.PASSWORDS;
                foreach (string pwd in pwds)
                {
                    try
                    {
                        Console.WriteLine("尝试使用密码：" + pwd);
                        WlanHelper.ConnetWifi(WlanIface, wn, pwd);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                // 2. 再尝试盲猜密码
                // 盲猜的范围是：
                // 密码位数在 [8, 16] 位范围内
                // 密码组成有 [32, 128) 字符内
                for (int length = 8; length < 17; length++)
                {

                }
            }
            else
            {
                WlanHelper.ConnetWifi(WlanIface, wn);
            }
        }
    }
}
