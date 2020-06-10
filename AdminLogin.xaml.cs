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

namespace CODEHUB 
{
    /// <summary>
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        public AdminLogin()
        {
            InitializeComponent();
            try
            {
                ImgShowHide.Source = new BitmapImage(new Uri("pic/Show.png", UriKind.Relative));
                txtVisiblePasswordbox.Visibility = System.Windows.Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           if(textbox1.Text=="Admin"&& textbox2.Password == "Admin")
            {
                if (Combobox1.Text == "System Progress")
                {
                    ADMINFLATE AF = new ADMINFLATE();
                    AF.Owner = this;
                    this.Hide();
                    AF.ShowDialog();
                }
                if (Combobox1.Text == "Query")
                {
                    string a = "Admin";
                    string b = "Admin";
                    string c = "Admin";
                    
                    QueryForm qf = new QueryForm(a,b,c);
                    qf.Owner = this;
                    this.Hide();
                    qf.ShowDialog();
                 //   Close();
                    /// normal form of query
                }
            }
          
            else  if(textbox1.Text != "admin" && textbox2.Password != "admin")
            {
                if (textbox1.Text != "admin")
                {
                    MessageBox.Show("Invalid Email");
                }

                else
                {
                    MessageBox.Show("Invalid Password");
                }
            }
            else
            {
                MessageBox.Show("Invalid Email & Password");
            }
            

            

        }

        private void textbox1_MouseEnter(object sender, MouseEventArgs e)
        {
            if (textbox1.Text == "Enter your Email")
            {
                textbox1.Text = "";
                textbox1.Foreground = Brushes.Black;
            }
        }

        private void textbox1_MouseLeave(object sender, MouseEventArgs e)
        {
            if (textbox1.Text == "")
            {
             textbox1.Text = "Enter your Email";
                textbox1.Foreground = Brushes.Gray;
            }
        }

        private void textbox2_MouseEnter(object sender, MouseEventArgs e)
        {
            if (textbox2.Password == "Enter your Password")
            {
                textbox2.Password = "";
                textbox2.Foreground = Brushes.Black;
            }
        }

        private void textbox2_MouseLeave(object sender, MouseEventArgs e)
        {
            if (textbox2.Password == "")
            {
                textbox2.Password = "Enter your Password";
                textbox2.Foreground = Brushes.Gray;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Owner = this;
            this.Hide();
            welcome.ShowDialog();
        }

        private void textbox2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (textbox2.Password.Length > 0)
            {


                ImgShowHide.Visibility = System.Windows.Visibility.Visible;

            }
            else
            {


                ImgShowHide.Visibility = System.Windows.Visibility.Hidden;

            }
        }

        private void ImgShowHide_MouseLeave(object sender, MouseEventArgs e)
        {
            HidePassword();
        }

        private void ImgShowHide_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPassword();
        }
        private void ShowPassword()
        {
            ImgShowHide.Source = new BitmapImage(new Uri("pic/hide.png", UriKind.Relative));
            txtVisiblePasswordbox.Visibility = System.Windows.Visibility.Visible;
            textbox2.Visibility = System.Windows.Visibility.Hidden;
            txtVisiblePasswordbox.Text = textbox2.Password;
        }
        private void ImgShowHide_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            HidePassword();
        }
        private void HidePassword()
        {
            ImgShowHide.Source = new BitmapImage(new Uri("pic/Show.png", UriKind.Relative));
            txtVisiblePasswordbox.Visibility = System.Windows.Visibility.Hidden;
            textbox2.Visibility = System.Windows.Visibility.Visible;
            textbox2.Focus();
        }
    }
}
