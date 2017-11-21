using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Interface_Mockups
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] info;
        List<UserAccount> users;

        public MainWindow()
        {
            users = new List<UserAccount>();
            InitializeComponent();
            string path = "Accounts/UserAccounts.txt";
            char newline = '\n';
            string fileread = File.ReadAllText(path);
            info = fileread.Split(newline);
            string[] userdata = new string[4];

            for (int i = 0; i < info.Length; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    userdata[j] = info[i];
                }
                users.Add(new UserAccount(userdata[0], userdata[1], userdata[2], userdata[3]));
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PasswordBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserAccount x = new UserAccount("first", "Last", "useynamo", "passerverd");
            if (UsernameBox.Text == x.Email && x.password_matches(PasswordBox.Text) == true)
            {
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Close();
              
            }
            else
            {
                MessageBox.Show("Username or password is incorrect!");
               
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SignUp signup = new SignUp();
            signup.Show();
            this.Close();
        }
    }
}
