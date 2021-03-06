﻿using MahApps.Metro;
using MahApps.Metro.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RFIDStorageUltimate
{
    /// <summary>
    /// AdminWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AdminWindow : MetroWindow
    {
        private IntPtr hCom = IntPtr.Zero;
        private Boolean UHF_IsOpen = false;
        private Boolean UHF_IsPersist = false;
        private Boolean closeFlag = true;
        private Boolean scanFlag = true;
        private Storyboard ScaningAnimate;
        private Storyboard RegisterAnimate;
        private Storyboard closeAnimate;
        private ArrayList UHF_TagUIIs;
        private Thread UHF_threadRCV;
        private Thread UHF_threadWRT;
        private SoundPlayer player = new SoundPlayer();
        private struct Parameter
        {
            public Byte[] UID;
            public String Message;
        }

        private Theme currentTheme;
        private Accent currentAccent;

        #region FunctionDeclare
        //M900OpenAndConnect
        [DllImport("M900_API.dll", CharSet = CharSet.Auto, EntryPoint = "M900OpenAndConnect")]
        public static extern Int32 M900OpenAndConnect(ref IntPtr hCom, Byte[] cPort, Int32 BaudRate, Byte flagCrc);
        //Public Declare Function M900OpenAndConnect Lib "M900_API.dll" (ByRef hCom As Int32, ByVal cPort As Byte(), ByVal flagCrc As Byte) As Int32
        //'int WINAPI M900OpenAndConnect (HANDLE &hCom, char* cPort,int BaudRate,  UCHAR flagCrc); 
        //'4.1 M900OpenAndConnect ()
        //'4.1.1  功能简介 
        //'该函数打开串口并与 M900 建立链接。 
        //'4.1.2  函数原型 
        //'4.1.3  返回值 
        //'1：打开 M900 功放和打开端口成功。 
        //'其他：打开 M900 功放或打开端口失败。
        //'4.1.4  输入参数
        //'HANDLE &hCom：通信端口句柄，初始化为 NULL。
        //'char* cPort：串口，例如 COM1、COM2 等。
        //'UCHAR  flagCrc：是否使用 CRC16 验证功能。1：使用 CRC 功能；0：不使用 CRC 功能。

        //M900CloseAndDisconnect
        [DllImport("M900_API.dll", CharSet = CharSet.Auto, EntryPoint = "M900CloseAndDisconnect")]
        public static extern Int32 M900CloseAndDisconnect(ref IntPtr hCom, Byte flagCrc);
        //Public Declare Function M900CloseAndDisconnect Lib "M900_API.dll" (ByRef hCom As Int32, ByVal flagCrc As Byte) As Int32
        //'4.2 M900CloseAndDisconnect ()
        //'4.2.1  功能简介
        //'该函数关闭 M900 的功放并关闭通信端口。 
        //'4.2.2  函数原型
        //'int WINAPI M900CloseAndDisconnect (HANDLE &hCom, UCHAR flagCrc);
        //'4.2.3  返回值
        //'1：关闭 M900 功放和关闭端口成功。
        //'其他：关闭 M900 功放或关闭端口失败。
        //'4.2.4  输入参数
        //'HANDLE &hCom：通信端口句柄。
        //'UCHAR  flagCrc：是否使用 CRC16 验证功能。1：使用 CRC 功能；0：不使用 CRC 功能。

        //M900Inventory
        [DllImport("M900_API.dll", CharSet = CharSet.Auto, EntryPoint = "M900Inventory")]
        public static extern Int32 M900Inventory(IntPtr hCom, Byte flagAnti, Byte initQ, Byte flagCrc);
        //Public Declare Function M900Inventory Lib "M900_API.dll" (ByVal hCom As Int32, ByVal flagAnti As Byte, ByVal initQ As Byte, ByVal flagCrc As Byte) As Int32
        //'4.10 M900Inventory ()
        //'4.10.1  功能简介
        //'该函数启动 M900 的识别循环。
        //'4.10.2  函数原型
        //'	int  WINAPI  M900Inventory  (HANDLE  hCom,  UCHAR  flagAnti,  UCHAR initQ,  UCHAR flagCrc);
        //'4.10.3  返回值
        //'1：成功启动 M900 的识别循环。
        //'其他：启动 M900 的识别循环失败。
        //'4.10.4  输入参数
        //'HANDLE hCom：通信端口句柄。
        //'UCHAR flagAnti：是否使用防碰撞识别功能。1：防碰撞识别；0：单标签识别。
        //'UCHAR initQ：防碰撞识别过程的初始 Q 值，flagAnti 为 1 时有效。
        //'UCHAR  flagCrc：是否使用 CRC16 验证功能。1：使用 CRC 功能；0：不使用 CRC 功能。

        //M900GetReceived
        [DllImport("M900_API.dll", CharSet = CharSet.Auto, EntryPoint = "M900GetReceived")]
        public static extern Int32 M900GetReceived(IntPtr hCom, Byte[] uLenUii, Byte[] uData);
        //Public Declare Function M900GetReceived Lib "M900_API.dll" (ByVal hCom As Int32, ByVal uLenUii As Byte(), ByVal uData As Byte()) As Int32
        //'4.11 M900GetReceived ()
        //'4.11.1  功能简介
        //'该函数读取 M900 返回的标签 UII。
        //'4.11.2  函数原型
        //'int WINAPI M900GetReceived (HANDLE hCom, UCHAR* uLenUii, UCHAR* uUii);
        //'4.11.3  返回值
        //'1：成功读取标签的 UII。
        //'其他：读取标签的 UII 失败。
        //'4.11.4  输入参数
        //'HANDLE hCom：通信端口句柄。
        //'UCHAR* uLenUii：标签 UII 的长度，1 个字节。
        //'UCHAR* uData：标签 UII，至少 66 个字节。

        //M900StopGet
        [DllImport("M900_API.dll", CharSet = CharSet.Auto, EntryPoint = "M900StopGet")]
        public static extern Int32 M900StopGet(IntPtr hCom, Byte flagCrc);
        //Public Declare Function M900StopGet Lib "M900_API.dll" (ByVal hCom As Int32, ByVal flagCrc As Byte) As Int32
        //'4.12 M900StopGet ()
        //'4.12.1  功能简介
        //'该函数停止 M900 的识别循环。
        //'4.12.2  函数原型
        //'int WINAPI M900StopGet (HANDLE hCom, UCHAR flagCrc);
        //'4.12.3  返回值
        //'1：成功停止识别。
        //'其他：停止识别失败。
        //'4.12.4  输入参数
        //'HANDLE hCom：通信端口句柄。
        //'UCHAR  flagCrc：是否使用 CRC16 验证功能。1：使用 CRC 功能；0：不使用 CRC 功能。
        //Public Function VarPtr(ByVal MyObject As Object) As IntPtr
        //    Dim MyGCHandle = System.Runtime.InteropServices.GCHandle.Alloc(MyObject, System.Runtime.InteropServices.GCHandleType.Pinned)
        //    Dim ptr = MyGCHandle.AddrOfPinnedObject()
        //    MyGCHandle.Free()
        //    Return ptr
        //End Function
        [DllImport("M900_API.dll", CharSet = CharSet.Auto, EntryPoint = "M900ReadData")]
        public static extern Int32 M900ReadData(IntPtr hCom, Byte[] uAccessPwd, Byte uBank, Byte[] uPtr, Byte uCnt, Byte[] uUii, Byte[] uReadData, Byte[] uErrorCode, Byte flagCrc);
        //4.13 M900ReadData ()
        //4.13.1  功能简介
        //该函数读取标签数据。
        //4.13.2  函数原型
        //int  WINAPI  M900ReadData  (HANDLE  hCom,  UCHAR*  uAccessPwd,  UCHAR  uBank, UCHAR*  uPtr,  UCHAR  uCnt,  UCHAR*  uUii,  UCHAR*  uReadData,  UCHAR*  uErrorCode, UCHAR flagCrc);
        //4.13.3  返回值
        //1：成功读取标签数据。
        //其他：读取标签数据失败。
        //4.13.4  输入参数
        //HANDLE hCom：通信端口句柄。
        //UCHAR* uAccessPwd：标签的 ACCESS PASSWORD。
        //UCHAR uBank：标签的数据段类型。
        //UCHAR* uPtr：起始地址的偏移量。
        //UCHAR uCnt：读取数据的长度（两个字节为单位）。
        //UCHAR* uUii：标签的 UII。
        //UCHAR* uReadData：读取的标签数据，至少为 uCnt * 2 个字节。
        //UCHAR* uErrorCode：标签返回的 Error Code。只在函数返回失败，且 uErrorCode 不等于 0xFF 时有效。
        //UCHAR  flagCrc：是否使用 CRC16 验证功能。1：使用 CRC 功能；0：不使用 CRC 功能。
        [DllImport("M900_API.dll", CharSet = CharSet.Auto, EntryPoint = "M900WriteData")]
        public static extern Int32 M900WriteData(IntPtr hCom, Byte[] uAccessPwd, Byte uBank, Byte[] uPtr, Byte uCnt, Byte[] uUii, Byte[] uWriteData, Byte[] uErrorCode, Byte flagCrc);
        //4.14 M900WriteData ()
        //4.14.1  功能简介
        //该函数写入标签数据。
        //4.14.2  函数原型
        //int  WINAPI  M900WriteData  (HANDLE  hCom,  UCHAR*  uAccessPwd,  UCHAR  uBank, UCHAR*  uPtr,  UCHAR  uCnt,  UCHAR*  uUii,  UCHAR*  uWriteData,  UCHAR*  uErrorCode, UCHAR flagCrc);
        //4.14.3  返回值
        //1：成功写入标签数据。
        //其他：写入标签数据失败。
        //4.14.4  输入参数
        //HANDLE hCom：通信端口句柄。
        //UCHAR* uAccessPwd：标签的 ACCESS PASSWORD。
        //UCHAR uBank：标签的数据段类型。
        //UCHAR* uPtr：起始地址的偏移量。
        //UCHAR uCnt：写入数据的长度（两个字节为单位）。
        //UCHAR* uUii：标签的 UII。
        //UCHAR* uWriteData：需要写入的数据。
        //UCHAR* uErrorCode：标签返回的 Error Code。只在函数返回失败，且 uErrorCode 不等于 0xFF 时有效。
        //UCHAR  flagCrc：是否使用 CRC16 验证功能。1：使用 CRC 功能；0：不使用 CRC 功能。
        [DllImport("M900_API.dll", CharSet = CharSet.Auto, EntryPoint = "M900GetPower")]
        public static extern Int32 M900GetPower(IntPtr hCom, Byte[] uPower, Byte flagCrc);
        //4.4 M900GetPower ()
        //4.4.1  功能简介
        //该函数读取 M900 的功率设置。
        //4.4.2  函数原型
        //int WINAPI M900GetPower (HANDLE hCom, UCHAR* uPower, UCHAR flagCrc);
        //4.4.3  返回值
        //1：成功读取 M900 的功率设置。
        //其他：读取 M900 的功率设置失败。
        //4.4.4  输入参数
        //HANDLE hCom：通信端口句柄。
        //UCHAR* uPower：M900 返回的 POWER 字节。
        //UCHAR  flagCrc：是否使用 CRC16 验证功能。1：使用 CRC 功能；0：不使用 CRC 功能。
        [DllImport("M900_API.dll", CharSet = CharSet.Auto, EntryPoint = "M900SetPower")]
        public static extern Int32 M900SetPower(IntPtr hCom, Byte uOption, Byte uPower, Byte flagCrc);
        //4.5 M900SetPower ()
        //4.5.1  功能简介
        //该函数设置 M900 的功率。
        //4.5.2  函数原型
        //int WINAPI M900SetPower (HANDLE hCom, UCHAR uOption, UCHAR uPower, UCHAR flagCrc);
        //4.4.3  返回值
        //1：成功设置 M900 的功率设置。
        //其他：设置 M900 的功率失败。
        //4.5.4  输入参数
        //HANDLE hCom：通信端口句柄。
        //UCHAR uOption：设置功率命令的 OPTION 字节。
        //UCHAR uPower：设置功率命令的 POWER 字节。
        //UCHAR  flagCrc：是否使用 CRC16 验证功能。1：使用 CRC 功能；0：不使用 CRC 功能。
        [DllImport("M900_API.dll", CharSet = CharSet.Auto, EntryPoint = "M900GetPaStatus")]
        public static extern Int32 M900GetPaStatus(IntPtr hCom, Byte[] uStatus, Byte flagCrc);
        //4.3 M900GetPaStatus ()
        //4.3.1  功能简介
        //该函数读取 M900 功放状态。
        //4.3.2  函数原型
        //int WINAPI M900GetPaStatus (HANDLE hCom, UCHAR* uStatus, UCHAR flagCrc);
        //4.3.3  返回值
        //1：成功读取 M900 功放状态。
        //其他：读取 M900 功放状态失败。
        //4.3.4  输入参数
        //HANDLE hCom：通信端口句柄。
        //UCHAR* uStatus：M900 的功放状态。1：功放状态为开启；0：功放状态为关闭。
        //UCHAR  flagCrc：是否使用 CRC16 验证功能。1：使用 CRC 功能；0：不使用 CRC 功能。
        [DllImport("M900_API.dll", CharSet = CharSet.Auto, EntryPoint = "M900OpenPower")]
        public static extern Int32 M900OpenPower(IntPtr hCom, Byte flagCrc);
        //4.6 M900OpenPower ()
        //4.6.1  功能简介
        //该函数打开 M900 的功放。
        //4.6.2  函数原型
        //int WINAPI M900OpenPower (HANDLE hCom, UCHAR flagCrc);
        //4.6.3  返回值
        //1：开启 M900 的功放成功。
        //其他：开启 M900 的功放失败。
        //4.6.4  输入参数
        //HANDLE hCom：通信端口句柄。
        //UCHAR  flagCrc：是否使用 CRC16 验证功能。1：使用 CRC 功能；0：不使用 CRC 功能。
        [DllImport("M900_API.dll", CharSet = CharSet.Auto, EntryPoint = "M900ClosePower")]
        public static extern Int32 M900ClosePower(IntPtr hCom, Byte flagCrc);
        //4.7 M900ClosePower ()
        //4.7.1  功能简介
        //该函数关闭 M900 的功放。
        //4.7.2  函数原型
        //int WINAPI M900ClosePower (HANDLE hCom, UCHAR flagCrc);
        //4.7.3  返回值
        //1：关闭 M900 的功放成功。
        //其他：关闭 M900 的功放失败。
        //4.7.4  输入参数
        //HANDLE hCom：通信端口句柄。
        //UCHAR  flagCrc：是否使用 CRC16 验证功能。1：使用 CRC 功能；0：不使用 CRC 功能。
        [DllImport("M900_API.dll", CharSet = CharSet.Auto, EntryPoint = "M900EraseData")]
        public static extern Int32 M900EraseData(IntPtr hCom, Byte[] uAccessPwd, Byte uBank, Byte[] uPtr, Byte uCnt, Byte[] uUii, Byte[] uErrorCode, Byte flagCrc);
        //4.15 M900EraseData ()
        //4.15.1  功能简介
        //该函数擦除标签数据。
        //4.15.2  函数原型
        //int  WINAPI  M900EraseData  (HANDLE  hCom,  UCHAR*  uAccessPwd,  UCHAR  uBank, UCHAR* uPtr, UCHAR uCnt, UCHAR* uUii, UCHAR* uErrorCode, UCHAR flagCrc);
        //4.15.3  返回值
        //1：成功擦除标签数据。
        //其他：擦除标签数据失败。
        //4.15.4  输入参数
        //HANDLE hCom：通信端口句柄。
        //UCHAR* uAccessPwd：标签的 ACCESS PASSWORD。
        //UCHAR uBank：标签的存储空间类型。
        //UCHAR* uPtr：起始地址的偏移量。
        //UCHAR uCnt：需要擦除的数据长度（两个字节为单位）。
        //UCHAR* uUii：标签的 UII。
        //UCHAR* uErrorCode：标签返回的 Error Code。只在函数返回失败，且 uErrorCode 不等于 0xFF 时有效。
        //UCHAR  flagCrc：是否使用 CRC16 验证功能。1：使用 CRC 功能；0：不使用 CRC 功能。
        [DllImport("M900_API.dll", CharSet = CharSet.Auto, EntryPoint = "M900LockMem")]
        public static extern Int32 M900LockMem(IntPtr hCom, Byte[] uAccessPwd, Byte[] uLockData, Byte[] uUii, Byte[] uErrorCode, Byte flagCrc);
        //4.16 M900LockMem ()
        //4.16.1  功能简介
        //该函数锁定标签的指定数据段。
        //4.16.2  函数原型
        //int   WINAPI   M900LockMem   (HANDLE   hCom,   UCHAR*   uAccessPwd,   UCHAR* uLockData, UCHAR* uUii, UCHAR* uErrorCode, UCHAR flagCrc);
        //4.16.3  返回值
        //1：成功锁定标签的指定数据段。
        //其他：锁定标签的指定数据段失败。
        //4.16.4  输入参数
        //HANDLE hCom：通信端口句柄。
        //UCHAR* uAccessPwd：标签的 ACCESS PASSWORD。
        //UCHAR* uLockData：命令的 LOCKDATA 数据段（3 字节）。
        //UCHAR* uUii：标签的 UII。
        //UCHAR* uErrorCode：标签返回的 Error Code。只在函数返回失败，且 uErrorCode 不等于 0xFF 时有效。
        //UCHAR  flagCrc：是否使用 CRC16 验证功能。1：使用 CRC 功能；0：不使用 CRC 功能。
        [DllImport("M900_API.dll", CharSet = CharSet.Auto, EntryPoint = "M900KillTag")]
        public static extern Int32 M900KillTag(IntPtr hCom, Byte[] uKillPwd, Byte[] uUii, Byte[] uErrorCode, Byte flagCrc);
        //4.17 M900KillTag ()
        //4.17.1  功能简介
        //该函数销毁指定标签。
        //4.17.2  函数原型
        //int WINAPI M900KillTag (HANDLE hCom, UCHAR* uKillPwd, UCHAR* uUii, UCHAR* uErrorCode, UCHAR flagCrc);
        //4.17.3  返回值
        //1：成功销毁指定标签。
        //其他：销毁指定标签失败。
        //4.17.4  输入参数
        //HANDLE hCom：通信端口句柄。
        //UCHAR* uKillPwd：标签的 Kill Password（32 位）。
        //UCHAR* uUii：标签的 UII。
        //UCHAR* uErrorCode：标签返回的 Error Code。只在函数返回失败，且 uErrorCode 不等于 0xFF 时有效。
        //UCHAR  flagCrc：是否使用 CRC16 验证功能。1：使用 CRC 功能；0：不使用 CRC 功能。
        #endregion

        public AdminWindow()
        {
            InitializeComponent();
            if (Application.Current.Properties["currentTheme"] == null && Application.Current.Properties["currentAccent"] == null)
            {
                currentTheme = Theme.Light;
                currentAccent = ThemeManager.DefaultAccents.First(x => x.Name == "Blue");
            }
            else
            {
                currentTheme = (Theme)Application.Current.Properties["currentTheme"];
                currentAccent = ThemeManager.DefaultAccents.First(x => x.Name == Application.Current.Properties["currentAccent"].ToString());
            }
            ThemeManager.ChangeTheme(Application.Current, currentAccent, currentTheme);
            this.DataContext = App.StorageDB;
            ScaningAnimate = (Storyboard)this.Resources["ScaningStoryBoard"];
            RegisterAnimate = (Storyboard)this.Resources["RegisterStoryBoard"];
            closeAnimate = (Storyboard)this.Resources["CloseStoryBoard"];
            player.Stream = Properties.Resources.VideoRecord;
            UHF_TagUIIs = new ArrayList();
            for (int i = 0; i <= 15; i++)
            {
                IntQComboBox.Items.Add(i);
            }
            IntQComboBox.SelectedIndex = 3;
            for (int i = 10; i <= 27; i++)
            {
                PowerComboBox.Items.Add(i);
            }
            PowerComboBox.SelectedIndex = 10;
            List<String> ComList;
            if (GetComList(out ComList) > 0)
            {
                foreach (String com in ComList)
                {
                    SerialComboBox.Items.Add(com);
                }
                SerialComboBox.SelectedIndex = 1;
            }
            GoodsNameComboBox.SelectedIndex = 0;
            ExtraPanel.Children.Clear();
        }

        private void BrowseInfoButton_Click(object sender, RoutedEventArgs e)
        {
            OperateControl.Content = null;
            OperateControl.Content = BrowsePanel;
        }

        private void RegisterLabelButton_Click(object sender, RoutedEventArgs e)
        {
            OperateControl.Content = null;
            OperateControl.Content = RegisterPanel;
        }

        private void GoodsManageButton_Click(object sender, RoutedEventArgs e)
        {
            OperateControl.Content = null;
            OperateControl.Content = GoodsManagePanel;
        }

        private void UserManageButton_Click(object sender, RoutedEventArgs e)
        {
            OperateControl.Content = null;
            OperateControl.Content = UserManagePanel;
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                NavigationCommands.Search.Execute(null, SearchTextBox);
                //this.CommandBindings[0].Command.Execute(null);
            }
        }

        private void TextBoxButtonCmd(object sender, ExecutedRoutedEventArgs e)
        {
            App.StorageDB.Search(SearchTextBox.Text);
            OperateControl.Content = null;
            OperateControl.Content = SearchPanel;
        }

        private void ScanBegin()
        {
            StatusRing.IsActive = true;
            IndicateStatusBar.Background = new SolidColorBrush(Colors.OrangeRed);
            MetroAdminWindow.GlowBrush = new SolidColorBrush(Colors.OrangeRed);
            BitmapImage image = new BitmapImage(new Uri("Images/Loading.png", UriKind.Relative));
            ScanningImage.Source = image;
            ScaningAnimate.Begin();
            scanFlag = false;
            RegisterScanningButton.Count = "关闭扫描";
            StatusTextBlock.Text = "扫描中......";
        }

        private void ScanEnd()
        {
            StatusRing.IsActive = false;
            
            ScaningAnimate.Stop();
            BitmapImage image = new BitmapImage(new Uri("Images/Scanning.png", UriKind.Relative));
            ScanningImage.Source = image;
            scanFlag = true;
            RegisterScanningButton.Count = "打开扫描";
            StatusTextBlock.Text = "扫描完成";
        }

        private void RegisterScanningButton_Click(object sender, RoutedEventArgs e)
        {
            if (scanFlag)
            {
                if (!UHF_IsPersist)
                {
                    if (GoodsNameComboBox.SelectedIndex == -1)
                    {
                        this.ShowMessageAsync("错误", "未选择注册商品", MahApps.Metro.Controls.MessageDialogStyle.Affirmative);
                        return;
                    }

                    if (!UHF_IsOpen)
                    {
                        if (SerialComboBox.SelectedIndex == -1)
                        {
                            this.ShowMessageAsync("错误", "未选择串口", MahApps.Metro.Controls.MessageDialogStyle.Affirmative);
                            return;
                        }
                        Byte[] PortName = Encoding.ASCII.GetBytes(SerialComboBox.SelectedItem.ToString());
                        Int32 BaudRate = Int32.Parse("57600");
                        Int32 value = M900OpenAndConnect(ref hCom, PortName, BaudRate, 0);
                        if (value == 1)
                        {
                            UHF_IsOpen = true;
                        }
                        else
                        {
                            this.ShowMessageAsync("错误", "模块打开错误", MahApps.Metro.Controls.MessageDialogStyle.Affirmative);
                            return;
                        }
                    }

                    String strPower = PowerComboBox.SelectedItem.ToString();
                    Byte uPower;
                    try
                    {
                        uPower = Byte.Parse(strPower);
                    }
                    catch
                    {
                        this.ShowMessageAsync("错误", "设置功率错误", MahApps.Metro.Controls.MessageDialogStyle.Affirmative);
                        return;
                    }
                    Int32 value2 = M900SetPower(hCom, 0x03, uPower, 0);
                    if (value2 == 1)
                    {
                        StatusTextBlock.Text = "设置功率命令执行成功！";
                    }
                    else
                    {
                        this.ShowMessageAsync("错误", "设置功率错误", MahApps.Metro.Controls.MessageDialogStyle.Affirmative);
                        Int32 value = M900CloseAndDisconnect(ref hCom, 0);
                        if (value == 1)
                        {
                            UHF_IsOpen = false;
                            StatusTextBlock.Text = "串口关闭，清理完成";
                            return;
                        }
                        else
                        {
                            this.ShowMessageAsync("错误", "关闭失败！", MahApps.Metro.Controls.MessageDialogStyle.Affirmative);
                            return;
                        }
                    }

                    Byte FlagAnti = (Byte)(0x01);
                    if (IntQComboBox.SelectedIndex == -1)
                    {
                        this.ShowMessageAsync("错误", "未选择IntQ", MahApps.Metro.Controls.MessageDialogStyle.Affirmative);
                        return;
                    }
                    Byte InitQ = (Byte)IntQComboBox.SelectedIndex;
                    Int32 value1 = M900Inventory(hCom, FlagAnti, InitQ, 0);
                    if (value1 == 1)
                    {
                        ScanBegin();
                        UHF_IsPersist = true;
                        UHF_threadRCV = new Thread(new ThreadStart(this.ReceiveThread));
                        UHF_threadRCV.IsBackground = true;
                        UHF_threadRCV.Start();
                    }
                    else
                    {
                        this.ShowMessageAsync("错误", "寻卡命令执行失败", MahApps.Metro.Controls.MessageDialogStyle.Affirmative);
                    }
                }
                else
                {
                    StatusTextBlock.Text = "现在不能操作，请等待";
                    return;
                }
            }
            else
            {
                ScanEnd();
                UHF_IsPersist = false;
                M900StopGet(hCom, 0);
                UHF_threadRCV.Abort();
                UHF_threadRCV.Join();
                UHF_threadRCV = null;
            }
        }

        private void ReceiveThread()
        {
            Byte[] uLenUii = new Byte[1];
            Byte[] uUii = new Byte[255];
            String strUii;
            while (UHF_IsPersist)
            {
                Int32 value = M900GetReceived(hCom, uLenUii, uUii);
                if (value == 1)
                {
                    strUii = "";
                    Int32 length = uLenUii[0];
                    for (Int32 i = 0; i < length; i++)
                    {
                        strUii += String.Format("{0:X2}", uUii[i]);
                    }
                    if (UHF_TagUIIs.IndexOf((object)strUii) < 0)
                    {
                        player.Play();
                        UHF_TagUIIs.Add(strUii);
                        Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.SystemIdle, (ThreadStart)delegate() { LabelList.Items.Add(strUii); });
                    }
                }
                Thread.Sleep(20);
            }
        }

        private void RegisterCleanButton_Click(object sender, RoutedEventArgs e)
        {
            if (UHF_IsOpen)
            {
                if (!UHF_IsPersist)
                {
                    UHF_TagUIIs.Clear();
                    LabelList.Items.Clear();
                    ReadInfo.Text = "";
                    Int32 value = M900CloseAndDisconnect(ref hCom, 0);
                    if (value == 1)
                    {
                        UHF_IsOpen = false;
                        IndicateStatusBar.Background = (Brush)this.FindResource("AccentColorBrush");
                        MetroAdminWindow.GlowBrush = (SolidColorBrush)this.FindResource("AccentColorBrush");
                        StatusTextBlock.Text = "串口关闭，清理完成";
                        return;
                    }
                    else
                    {
                        this.ShowMessageAsync("错误", "关闭失败！", MahApps.Metro.Controls.MessageDialogStyle.Affirmative);
                        return;
                    }
                }
                else
                {
                    StatusTextBlock.Text = "现在不能操作，请等待";
                    return;
                }
            }
            else
            {
                StatusTextBlock.Text = "串口未打开";
                return;
            }
        }

        private void RegisterReadButton_Click(object sender, RoutedEventArgs e)
        {
            if (UHF_IsOpen)
            {
                if (!UHF_IsPersist)
                {
                    if (LabelList.SelectedIndex < 0)
                    {
                        StatusTextBlock.Text = "请选择你要操作的UID！";
                        LabelList.Focus();
                        return;
                    }
                    
                    Byte uBank = (Byte)3;
                    Byte[] uAccessPwd = new Byte[]{0x00,0x00,0x00,0x00};
                    Byte[] uPtr = new Byte[1];
                    uPtr[0] = Convert.ToByte(1);
                    Byte uCnt = Convert.ToByte(31);
                    Byte[] uReadData = new Byte[uCnt * 2];
                    Byte[] uErrorCode = new Byte[1];
                    String struii = LabelList.SelectedItem.ToString().Trim();
                    Byte[] uUii = new Byte[struii.Length / 2];
                    for (Int32 i = 0; i < uUii.Length; i++)
                    {
                        uUii[i] = Convert.ToByte(struii.Substring(i * 2, 2), 16);
                    }
                    if (M900ReadData(hCom, uAccessPwd, uBank, uPtr, uCnt, uUii, uReadData, uErrorCode, 0) == 1)
                    {
                        String strdata = "";
                        for (Int32 i = 0; i < uReadData.Length; i++)
                        {
                            strdata += String.Format("{0:X2}", uReadData[i]);
                        }
                        string number = Encoding.ASCII.GetString(uReadData,0,14).Trim();
                        string str = Encoding.Unicode.GetString(uReadData,14,48).Trim();
                        ReadInfo.Text = "商品编号：" + '\n' + '\n' + number + '\n' + '\n' + '\n' + '\n' + '\n' +"商品名称：" + '\n' + '\n' + str;
                        StatusTextBlock.Text = "数据读取完成";
                    }
                    else
                    {
                        StatusTextBlock.Text = String.Format("读取数据命令失败，错误代码为0x{0}！", uErrorCode[0]);
                        return;
                    }
                }
                else
                {
                    StatusTextBlock.Text = "现在不能操作，请等待";
                    return;
                }
            }
            else
            {
                StatusTextBlock.Text = "串口未打开";
                return;
            }
        }

        private void RegisterWriteButton_Click(object sender, RoutedEventArgs e)
        {
            if (UHF_IsOpen)
            {
                if (!UHF_IsPersist)
                {
                    if (LabelList.SelectedIndex < 0)
                    {
                        StatusTextBlock.Text = "请选择你要操作的UID！";
                        LabelList.Focus();
                        return;
                    }
                    String message;
                    if ((Boolean)ClearSwitch.IsChecked)
                    {
                        message = "";
                        if(!App.StorageDB.DeleteLabel(LabelList.SelectedItem.ToString().Trim()))
                        {
                            this.ShowMessageAsync("错误", "注册删除失败", MahApps.Metro.Controls.MessageDialogStyle.Affirmative);
                            return;
                        }
                    }
                    else
                    {
                        message = ((DataRowView)(GoodsNameComboBox.SelectedItem))[0].ToString() + " " + ((DataRowView)(GoodsNameComboBox.SelectedItem))[1].ToString();
                        if (!App.StorageDB.RegisterLabel(LabelList.SelectedItem.ToString().Trim(), ((DataRowView)(GoodsNameComboBox.SelectedItem))[0].ToString()))
                        {
                            this.ShowMessageAsync("错误", "注册标签失败", MahApps.Metro.Controls.MessageDialogStyle.Affirmative);
                            return;
                        }
                    } 
                    String struii = LabelList.SelectedItem.ToString().Trim();
                    Byte[] uUii = new Byte[struii.Length / 2];
                    for (Int32 i = 0; i < uUii.Length; i++)
                    {
                        uUii[i] = Convert.ToByte(struii.Substring(i * 2, 2), 16);
                    }
                    
                    int m = 38 - message.Length;
                    for (int i = 0; i < m; i++)
                    {
                        message += " ";
                    }

                    Parameter parameter = new Parameter();
                    parameter.UID = uUii;
                    parameter.Message = message;
                    
                    UHF_IsPersist = true;
                    UHF_threadWRT = new Thread(WriteThread);
                    UHF_threadWRT.IsBackground = true;
                    UHF_threadWRT.Start((object)parameter);
                }
                else
                {
                    StatusTextBlock.Text = "现在不能操作，请等待";
                    return;
                }
            }
            else
            {
                StatusTextBlock.Text = "串口未打开";
                return;
            }
        }

        private void WriteThread(object Para)
        {
            Parameter parameter = (Parameter)Para;
            Byte[] uUii = parameter.UID;
            String message = parameter.Message;
  
            Byte[] uAccessPwd = new Byte[] { 0x00, 0x00, 0x00, 0x00 };
            Byte uBank = (Byte)3;
            int count = 1;
            
            Byte[] uErrorCode = new Byte[1];
            Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.SystemIdle, (ThreadStart)delegate() { RegisterAnimate.Begin(); StatusTextBlock.Text = "正在写入"; });

            Byte[] uPtr = new Byte[1];
            Byte uCnt = Convert.ToByte(1);
            Byte[] uWriteData = new Byte[uCnt * 2];

            for (int j = 0; j < 7; j++)
            {
                uPtr[0] = Convert.ToByte(count);
                uWriteData = Encoding.ASCII.GetBytes(message.Substring(j*2,2));
                for (int i = 0; i < 10; i++)
                {
                    if (M900WriteData(hCom, uAccessPwd, uBank, uPtr, uCnt, uUii, uWriteData, uErrorCode, 0) == 1)
                    {
                        count++;
                        break;
                    }
                    if (i == 9)
                    {
                        UHF_IsPersist = false;
                        Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.SystemIdle, (ThreadStart)delegate() { RegisterAnimate.Stop(); StatusTextBlock.Text = String.Format("写入失败，错误代码为0x{0}！", uErrorCode[0]); });
                        Thread.CurrentThread.Abort();
                        Thread.CurrentThread.Join();
                    }
                    Thread.Sleep(20);
                }
                
            }

            message = message.Substring(14);

            foreach (char c in message)
            {
                uPtr[0] = Convert.ToByte(count);
                uWriteData = Encoding.Unicode.GetBytes(c.ToString());
                for (int i = 0; i < 10; i++)
                {
                    if (M900WriteData(hCom, uAccessPwd, uBank, uPtr, uCnt, uUii, uWriteData, uErrorCode, 0) == 1)
                    {
                        count++;
                        break;
                    }
                    if (i == 9)
                    {
                        UHF_IsPersist = false;
                        Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.SystemIdle, (ThreadStart)delegate() { RegisterAnimate.Stop(); StatusTextBlock.Text = String.Format("写入失败，错误代码为0x{0}！", uErrorCode[0]) ; });
                        Thread.CurrentThread.Abort();
                        Thread.CurrentThread.Join();   
                    }
                    Thread.Sleep(20);
                }
            }
            UHF_IsPersist = false;
            Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.SystemIdle, (ThreadStart)delegate() { RegisterAnimate.Stop(); StatusTextBlock.Text = "写入完成"; });
            Thread.CurrentThread.Abort();
            Thread.CurrentThread.Join();  
        }

        private void SetButton_Click(object sender, RoutedEventArgs e)
        {
            var flyout = this.Flyouts.Items[0] as Flyout;
            if (flyout == null)
            {
                return;
            }
            if (!UHF_IsOpen)
            {
                if (!flyout.IsOpen)
                {
                    List<String> ComList;
                    SerialComboBox.Items.Clear();
                    if (GetComList(out ComList) > 0)
                    {
                        foreach (String com in ComList)
                        {
                            SerialComboBox.Items.Add(com);
                        }
                        SerialComboBox.SelectedIndex = 1;
                    }
                }
                flyout.IsOpen = !flyout.IsOpen;
            }
            else
            {
                StatusTextBlock.Text = "串口已经打开，不能操作！";
            }
        }

        public Int32 GetComList(out List<String> ComList)
        {
            Microsoft.Win32.RegistryKey keyCom = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
            if (keyCom != null)
            {
                string[] sSubKeys = keyCom.GetValueNames();
                ComList = new List<string>();
                foreach (string sName in sSubKeys)
                {
                    ComList.Add((string)keyCom.GetValue(sName));
                }
                return ComList.Count;
            }
            else
            {
                ComList = null;
                return 0;
            }
        }

        private void GoodsManageAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!App.StorageDB.AddGoods())
            {
                this.ShowMessageAsync("错误", "添加商品错误！", MahApps.Metro.Controls.MessageDialogStyle.Affirmative);
            }
            else
            {
                StatusTextBlock.Text = "商品添加成功！";
                GoodsListDataGrid.SelectedIndex = GoodsListDataGrid.Items.Count - 1;
                GoodsListDataGrid.ScrollIntoView(GoodsListDataGrid.SelectedItem);
            }
        }

        private void GoodsManageDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (GoodsListDataGrid.SelectedItem != null)
            {
                if (!App.StorageDB.DeleteGoods(((DataRowView)GoodsListDataGrid.SelectedItem)[0].ToString()))
                {
                    this.ShowMessageAsync("错误", "删除商品错误！", MahApps.Metro.Controls.MessageDialogStyle.Affirmative);
                }
                else
                {
                    StatusTextBlock.Text = "商品删除成功！";
                }
            }
            else
            {
                StatusTextBlock.Text = "请选择先！";
            }
        }

        private void GoodsManageUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            FocusManager.SetFocusedElement(this, (Button)sender);
            if (!App.StorageDB.UpdateGoods())
            {
                this.ShowMessageAsync("错误", "更新商品错误！", MahApps.Metro.Controls.MessageDialogStyle.Affirmative);
            }
            else
            {
                StatusTextBlock.Text = "商品更新成功！";
            }
        }

        private void UserManageAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!App.StorageDB.AddUser())
            {
                this.ShowMessageAsync("错误", "添加人员错误！", MahApps.Metro.Controls.MessageDialogStyle.Affirmative);
            }
            else
            {
                StatusTextBlock.Text = "人员添加成功！";
                UserList.SelectedIndex = UserList.Items.Count - 1;
                UserList.ScrollIntoView(UserList.SelectedItem);
            }
        }

        private void UserManageDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserList.SelectedItem != null)
            {
                if (!App.StorageDB.DeleteUser(((DataRowView)UserList.SelectedItem)[0].ToString()))
                {
                    this.ShowMessageAsync("错误", "删除人员错误！", MahApps.Metro.Controls.MessageDialogStyle.Affirmative);
                }
                else
                {
                    StatusTextBlock.Text = "删除人员成功！";
                }
            }
            else
            {
                StatusTextBlock.Text = "请选择先！";
            }
        }

        private void UserManageUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            FocusManager.SetFocusedElement(this, (Button)sender);
            if (!App.StorageDB.UpdateUser())
            {
                this.ShowMessageAsync("错误", "更新人员错误！", MahApps.Metro.Controls.MessageDialogStyle.Affirmative);
            }
            else
            {
                StatusTextBlock.Text = "人员更新成功！";
            }
        }

        private void MetroAdminWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (closeFlag)
            {
                closeAnimate.Completed += (a, b) =>
                {
                    closeFlag = false;
                    this.Close();
                };
                closeAnimate.Begin();
                MainControl.Content = null;
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}
