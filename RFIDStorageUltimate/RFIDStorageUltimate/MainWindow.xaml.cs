using MahApps.Metro;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RFIDStorageUltimate
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        #region 全局变量定义
        private Theme currentTheme = Theme.Light;
        private Accent currentAccent = ThemeManager.DefaultAccents.First(x => x.Name == "Blue");
        private Boolean themeFlag = true;
        private Boolean closeFlag = true;
        private Random random;
        private String password;
        private String maskword;
        private String loginMode;
        private String[] accentAll;
        private Storyboard loginAnimate;
        private Storyboard cancelAnimate;
        private Storyboard closeAnimate;
        private struct Parameter
        {
            public String Name;
            public String Password;
        }
        private Thread CheckThread;
        private delegate void ChangeUI();
        #endregion

        

        public MainWindow()
        {
            InitializeComponent();
            Application.Current.Properties["currentTheme"] = Theme.Light;
            Application.Current.Properties["currentAccent"] = "Blue";
            random = new Random();
            accentAll = new String[] {"Amber","Blue","Brown","Cobalt","Crimson","Cyan","Emerald","Green","Indigo","Lime","Magenta","Mauve","Olive","Orange","Pink","Purple","Red","Sienna","Steel","Teal","Violet","Yellow"};
            loginAnimate = (Storyboard)this.Resources["LoginStoryBoard"];
            cancelAnimate = (Storyboard)this.Resources["CancelStoryBoard"];
            closeAnimate = (Storyboard)this.Resources["CloseStoryBoard"];
            this.DataContext = new NotNullValidationRule();
        }

        private void SkinButton_Click(object sender, RoutedEventArgs e)
        {
            Int32 i = random.Next(0,21);
            currentAccent = ThemeManager.DefaultAccents.First(x => x.Name == accentAll[i]);
            ThemeManager.ChangeTheme(Application.Current, currentAccent, currentTheme);
            Application.Current.Properties["currentAccent"] = accentAll[i];
        }

        private void ThemeButton_Click(object sender, RoutedEventArgs e)
        {
            if (themeFlag)
            {
                currentTheme = Theme.Dark;
                ThemeManager.ChangeTheme(Application.Current, currentAccent, currentTheme);
                BitmapImage image = new BitmapImage(new Uri("Images/Light.png", UriKind.Relative));
                ThemeImage.Source = image;
                themeFlag = false;
                Application.Current.Properties["currentTheme"] = Theme.Dark;
            }
            else
            {
                currentTheme = Theme.Light;
                ThemeManager.ChangeTheme(Application.Current, currentAccent, currentTheme);
                BitmapImage image = new BitmapImage(new Uri("Images/Dark.png", UriKind.Relative));
                ThemeImage.Source = image;
                themeFlag = true;
                Application.Current.Properties["currentTheme"] = Theme.Light;
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (!loginBar.IsIndeterminate)
            {
                if (UsernameValidationRule.Validate((object)UsernameTextBox.Text, null).IsValid && PasswordValidationRule.Validate((object)PasswordTextBox.Text, null).IsValid)
                {
                    //StatusTextBlock.Foreground = new SolidColorBrush(Colors.White);
                    //StatusTextBlock.Text = "Copyright@RFID智能仓储小组";

                    loginBar.IsIndeterminate = true;
                    LoginButton.Content = "取  消";
                    loginAnimate.Begin();

                    Parameter parameter = new Parameter();
                    parameter.Name = UsernameTextBox.Text.Trim();
                    parameter.Password = password.Trim();
                    CheckThread = new Thread(CheckFunction);
                    CheckThread.IsBackground = true;
                    CheckThread.Start((object)parameter);
                }
                else
                {
                    
                    if (UsernameTextBox.Text == "")
                    {
                        UsernameTextBox.Text = "";
                    }
                    if (PasswordTextBox.Text == "")
                    {
                        PasswordTextBox.Text = "";
                    }
                }
            }
            else
            {
                loginBar.IsIndeterminate = false;
                LoginButton.Content = "进  入";
                cancelAnimate.Begin();
                CheckThread.Abort();
                CheckThread.Join();
            }
        }

        private void PasswordTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((Key.Z >= e.Key && e.Key >= Key.A) || (Key.NumPad9 >= e.Key && e.Key >= Key.NumPad0))
            {
                if (PasswordTextBox.Text == "")
                {
                    password = "";
                }
                String s = e.Key.ToString();
                password += s.Substring(s.Length - 1, 1);
                maskword = "";
                for (int i = 0; i < PasswordTextBox.Text.Length; i++)
                {
                    maskword += "*";
                }
                PasswordTextBox.Text = maskword;
                PasswordTextBox.SelectionStart = maskword.Length;
            }
            else
            {
                switch (e.Key)
                {
                    case Key.Back:
                        if (password.Length != 0)
                        {
                            password = password.Remove(password.Length - 1);
                        }
                        break;
                    case Key.Enter:
                        break;
                    case Key.Tab:
                        break;
                    default:
                        e.Handled = true;
                        break;
                }
            }
        }

        private void CheckFunction(object Para)
        {
            Parameter parameter = (Parameter)Para;
            String username = parameter.Name;
            String password = parameter.Password;
            loginMode = App.StorageDB.LoginCheck(username, password);
            Thread.Sleep(1000);
            Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.SystemIdle, new ChangeUI(SelectFunction));
        }

        private void SelectFunction()
        {
            switch (loginMode)
            {
                case "ERROR":
                    LoginButton_Click(null, null);
                    this.ShowMessageAsync("错误", "数据库连接错误！请检查！", MahApps.Metro.Controls.MessageDialogStyle.Affirmative);
                    break;
                case "MANAGER":
                    Application.Current.Properties["UserName"] = UsernameTextBox.Text.Trim();
                    new AdminWindow().Show();
                    this.Close();
                    break;
                case "USER":
                    Application.Current.Properties["UserName"] = UsernameTextBox.Text.Trim();
                    new OperateWindow().Show();
                    this.Close();
                    break;
                case "NO":
                    LoginButton_Click(null, null);
                    break;
            }
        }

        private void MetroMainWindow_Closing(object sender, CancelEventArgs e)
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
