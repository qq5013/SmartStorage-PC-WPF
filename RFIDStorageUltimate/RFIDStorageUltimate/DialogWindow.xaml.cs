using MahApps.Metro.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RFIDStorageUltimate
{
    /// <summary>
    /// DialogWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DialogWindow : Window
    {
        private Thread OperateThread;
        private struct Parameter
        {
            public Hashtable UIDToGoodsNumber;
            public String UserName;
            public String Mode;
        }
        public DialogWindow(Hashtable UIDToGoodsNumber, String Mode, String UserName)
        {
            InitializeComponent();
            Parameter parameter = new Parameter();
            parameter.UIDToGoodsNumber = UIDToGoodsNumber;
            parameter.UserName = UserName;
            parameter.Mode = Mode;
            OperateThread = new Thread(OperateThreadFunction);
            OperateThread.IsBackground = true;
            OperateThread.Start((object)parameter);
        }

        private void OperateThreadFunction(object Para)
        {
            Parameter parameter = (Parameter)Para;
            Hashtable UIDToGoodsNumber = parameter.UIDToGoodsNumber;
            String UserName = parameter.UserName;
            String Mode = parameter.Mode;
            switch (Mode)
            {
                case "入库":
                    if (App.StorageDB.InOperate(UIDToGoodsNumber, UserName))
                    {
                        Thread.Sleep(2000);
                        Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.SystemIdle, (ThreadStart)delegate() { this.DialogResult = true; });
                    }
                    else
                    {
                        Thread.Sleep(2000);
                        Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.SystemIdle, (ThreadStart)delegate() { this.DialogResult = false; });
                    }
                    break;
                case "出库":
                    if (App.StorageDB.OutOperate(UIDToGoodsNumber, UserName))
                    {
                        Thread.Sleep(2000);
                        Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.SystemIdle, (ThreadStart)delegate() { this.DialogResult = true; });
                    }
                    else
                    {
                        Thread.Sleep(2000);
                        Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.SystemIdle, (ThreadStart)delegate() { this.DialogResult = false; });
                    }
                    break;
                default:
                    Thread.Sleep(2000);
                    Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.SystemIdle, (ThreadStart)delegate() { this.DialogResult = false; });
                    break;
            }
        }
    }
}
