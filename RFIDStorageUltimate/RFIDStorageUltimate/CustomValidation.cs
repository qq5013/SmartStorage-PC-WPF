using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace RFIDStorageUltimate
{
    public class NotNullValidationRule : ValidationRule, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
        private String username;
        public String Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UserName"));
            }
        }
        private String password;
        public String Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Password"));
            }
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty(value as string) || string.IsNullOrWhiteSpace(value as string))
            {
                return new ValidationResult(false, "请输入");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}