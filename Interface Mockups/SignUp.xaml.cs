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
using System.Windows.Shapes;

namespace Interface_Mockups
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(SignUpNameBox.Text != "" && SignUpLastNameBox.Text != "" && SignUpEmailBox.Text != "" && SignUpPasswordBox.Text != "")
            {
                if(SignUpPasswordBox.Text == PasswordConfirmBox.Text)
                {
                    UserAccount userAccount = new UserAccount(SignUpNameBox.Text, SignUpLastNameBox.Text, SignUpEmailBox.Text, SignUpPasswordBox.Text);
                    userAccount.SaveAccount();
                    Window MainWindow = new MainWindow();
                    MainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Passwords do not match!");
                }
            }
            else
            {
                MessageBox.Show("All fields are required!");
            }
        }
    }
}
