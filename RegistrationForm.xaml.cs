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
using System.IO;

using System.Data.SqlClient;
namespace CODEHUB
{
    /// <summary>
    /// Interaction logic for RegistrationForm.xaml
    /// </summary>
    public partial class RegistrationForm : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        public RegistrationForm()
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
            ///  new BitmapImage(new Uri(base.BaseUri, @"/Assets/favorited.png"));

            // new BitmapImage(new Uri("/MyProject;component/Images/down.png", UriKind.Relative));
        }

        private void Rigiter_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
             string Name=textbox0.Text;
            string Email = textbox1.Text;
            string Password = textbox2.Password;
           // con.Close();
              con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Register where Password='" + textbox2.Password + "'";
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                   if(dr.HasRows)
                    {

                    MessageBox.Show("This Password is Taken", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                    con.Close();
                    }
                else
                {
                    con.Close();
                    try
                    {
                        con.Open();
                        SqlCommand cnd = con.CreateCommand();
                        cnd.CommandType = System.Data.CommandType.Text;

                        if (textbox0.Text == "" && textbox1.Text == "" && textbox2.Password == "")
                        {
                            MessageBox.Show("Mandotory Fields Must Fill first", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

                        }
                        else { 


                        cnd.CommandText = "insert into Register(Name,Email,Password) values('" + Name + "','" + Email + "','" + Password + "')"; //'" + source + "','" + time + "','" + date + "','" + search + "','" + password + "','" + Email + "')";
                        cnd.ExecuteNonQuery();
                        textbox0.Text = "";
                        textbox1.Text = "";
                        textbox2.Password = "";

                    }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    con.Close();
                    string a = textbox0.Text;
                    string b = textbox1.Text;
                    string c = textbox2.Password;
                    CustomerLogin cl = new CustomerLogin(a, b, c);
                    cl.Owner = this;
                    this.Hide();
                    cl.ShowDialog();
                    Close();

                }
            }

                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            //MessageBox.Show("Do you Want To Login","Confirmation!",MessageBoxButton.YesNo,)
            
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Owner = this;
            this.Hide();
            welcome.ShowDialog();
        }

        private void textbox2_Unchecked(object sender, RoutedEventArgs e)
        {

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

        private void ImgShowHide_MouseLeave(object sender, MouseEventArgs e)
        {
            HidePassword();
        }

        private void txtPasswordbox_PasswordChanged(object sender, RoutedEventArgs e)
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

        /*  private void textbox0_MouseEnter(object sender, MouseEventArgs e)
          {
              if (textbox1.Text == "Enter your Name")
              {
                  textbox1.Text = "";
                  textbox1.Foreground = Brushes.Black;
              }
          }

          private void textbox0_MouseLeave(object sender, MouseEventArgs e)
          {
              if (textbox2.Text == "")
              {
                  textbox2.Text = "Enter your Name";
                  textbox2.Foreground = Brushes.Gray;
              }
          }


          private void textbox2_MouseEnter(object sender, MouseEventArgs e)
          {
              if (textbox2.Text == "Enter your Password")
              {
                  textbox2.Text = "";
                  textbox2.Foreground = Brushes.Black;
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

          private void textbox2_MouseLeave(object sender, MouseEventArgs e)
          {
              if (textbox2.Text == "")
              {
                  textbox2.Text = "Enter your Password";
                  textbox2.Foreground = Brushes.Gray;
              }
          }

          private void textbox1_MouseLeave(object sender, MouseEventArgs e)
          {
              if (textbox1.Text == "")
              {
                  textbox1.Text = "Enter your Email";
                  textbox1.Foreground = Brushes.Gray;
              }
          }*/

        /*  private void login_Click(object sender, RoutedEventArgs e)
          {
              if (textbox0.Text == "" && textbox1.Text == "" && textbox2.Password == "")
              {
                  MessageBox.Show("Register First", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

              }
              else
              {

              }
          }*/
    }
}
