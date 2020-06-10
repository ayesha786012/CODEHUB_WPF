using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
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
using Xunit;

namespace CODEHUB
{
    /// <summary>
    /// Interaction logic for CustomerLogin.xaml
    /// </summary>
    public partial class CustomerLogin : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        public CustomerLogin(string name, string email, string password)
        {
            InitializeComponent();
            textbox1_name.Text = name;
            textbox1_Email.Text = email;
            textbox1_Password.Password = password;
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
            //Register Form
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (textbox1.Text.Length == 0)
            {
                MessageBox.Show("Enter Email", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Warning);
                textbox1.Focus();
            }
            else if (textbox2.Password.Length == 0)
            {
                MessageBox.Show("Enter Password", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Warning);
                textbox2.Focus();
            }
            else
            {
                string email = textbox1.Text;
                string password = textbox2.Password;
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Register where Email='" + email + "'  and password='" + password + "'", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                { 
                    textbox1_name.Text = dataSet.Tables[0].Rows[0]["Name"].ToString();

                 string a = textbox1_name.Text;
                    textbox1_Email.Text= dataSet.Tables[0].Rows[0]["Email"].ToString();
                    string b = textbox1_Email.Text;
                    textbox1_Password.Password= dataSet.Tables[0].Rows[0]["Password"].ToString();
                    string c = textbox1_Password.Password;
                    QueryForm qf = new QueryForm(a,b ,c );
                    qf.Owner = this;
                    this.Hide();
                    qf.ShowDialog();
                    //string username = dataSet.Tables[0].Rows[0]["FirstName"].ToString() + " " + dataSet.Tables[0].Rows[0]["LastName"].ToString();
                    // welcome.TextBlockName.Text = username;//Sending value from one form to another form.  
                    // welcome.Show();
                   // Close();
                }
                else
                {
                    MessageBox.Show("Sorry! Please enter existing emailid/password.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);

                  //  errormessage.Text = "";
                }
                con.Close();
            }

            
        }


        private void Rigiter_Click(object sender, RoutedEventArgs e)
        {
            RegistrationForm rf = new RegistrationForm();
            rf.Owner = this;
            this.Hide();
            rf.ShowDialog();
           // Close();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Owner = this;
            this.Hide();
            welcome.ShowDialog();
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

        private void ImgShowHide_MouseLeave(object sender, MouseEventArgs e)
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

        /*  private void textbox1_MouseEnter(object sender, MouseEventArgs e)
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

        /*  private void textbox2_MouseEnter(object sender, MouseEventArgs e)
          {
              if (textbox2.Text == "Enter your Password")
              {
                  textbox2.Text = "";
                  textbox2.Foreground = Brushes.Black;
              }
          }

          private void textbox2_MouseLeave(object sender, MouseEventArgs e)
          {
              if (textbox2.Text == "")
              {
                  textbox2.Text = "Enter your Password";
                  textbox2.Foreground = Brushes.Gray;
              }
          }*/
    }
}
