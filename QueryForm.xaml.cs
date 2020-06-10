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
using System.Data.SqlClient;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
namespace CODEHUB
{
    
    /// <summary>
    /// Interaction logic for QueryForm.xaml
    /// </summary>
    public partial class QueryForm : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        public IWebDriver driver;
        public QueryForm(string Name,string Email,string password)
        {
            InitializeComponent();
           textbox1_name.Text = Name;
            textbox1_Email.Text = Email;
            textbox1_Password.Password = password;
          
        }

        private void Radioprogramiz_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
          
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
            con.Open();
             SqlCommand cd = con.CreateCommand();
             cd.CommandType = System.Data.CommandType.Text;
             cd.CommandText = "DELETE FROM Current_User_Data";
             try
             {
                 cd.ExecuteNonQuery();

             }
             catch (Exception ex)
             {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            con.Close();
            string name = textbox1_name.Text;
            string languge = combobox1.Text;
            string query = tburl.Text;
            string password = textbox1_Password.Password;
            string time = DateTime.Now.ToLongTimeString();
            string date = DateTime.Now.ToLongDateString();
            string search = "Keyword&Semantics";
            string Email = textbox1_Email.Text;
             int remark = 0;
            if (Radiogit.IsChecked==true)
            {
                string source = "Github";

                try
                {
                    // SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlCommand cmdi = con.CreateCommand();
                  cmdi.CommandType = System.Data.CommandType.Text;

                    // MessageBox.Show("YOU SELECTED THIS BEFORE", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //cmd.CommandText = "insert into Codehub (URL) values('" + note.Text+"')";
                    cmd.CommandText = "insert into Report(Name,Language,Query,Source,Time,Date,Search,password,Email,Remarks) values('" + name + "','" + languge + "','" + query + "','" + source + "','" + time + "','" + date + "','" + search + "','" + password + "','" + Email + "','"+remark+"')";
                    cmd.ExecuteNonQuery();
                   cmdi.CommandText = "insert into Current_User_Data(Name,Language,Query,Source,Time,Date,Search,password,Email) values('" + name + "','" + languge + "','" + query + "','" + source + "','" + time + "','" + date + "','" + search + "','" + password + "','" + Email + "')";
                   cmdi.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                con.Close();
            }
            if (Radiogeeks.IsChecked==true)
            {
                string source = "Geeks for Geeks";

                try
                {
                    //  SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                  SqlCommand cmdi = con.CreateCommand();
                    cmdi.CommandType = System.Data.CommandType.Text;


                    // MessageBox.Show("YOU SELECTED THIS BEFORE", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //cmd.CommandText = "insert into Codehub (URL) values('" + note.Text+"')";
                    cmd.CommandText = "insert into Report(Name,Language,Query,Source,Time,Date,Search,password,Email,Remarks) values('" + name + "','" + languge + "','" + query + "','" + source + "','" + time + "','" + date + "','" + search + "','" + password + "','" + Email + "','" + remark + "')";
                    cmd.ExecuteNonQuery();
                    cmdi.CommandText = "insert into Current_User_Data(Name,Language,Query,Source,Time,Date,Search,password,Email) values('" + name + "','" + languge + "','" + query + "','" + source + "','" + time + "','" + date + "','" + search + "','" + password + "','" + Email + "')";
                   cmdi.ExecuteNonQuery();

                    //con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                con.Close();
            }
            if (Radioprogramiz.IsChecked==true)
            {
                string source = "Programiz";

                try
                {
                    //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlCommand cmdi = con.CreateCommand();
                   cmdi.CommandType = System.Data.CommandType.Text;


                    // MessageBox.Show("YOU SELECTED THIS BEFORE", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //cmd.CommandText = "insert into Codehub (URL) values('" + note.Text+"')";
                    cmd.CommandText = "insert into Report(Name,Language,Query,Source,Time,Date,Search,password,Email,Remarks) values('" + name + "','" + languge + "','" + query + "','" + source + "','" + time + "','" + date + "','" + search + "','" + password + "','" + Email + "','" + remark + "')";
                    cmd.ExecuteNonQuery();
                   cmdi.CommandText = "insert into Current_User_Data(Name,Language,Query,Source,Time,Date,Search,password,Email) values('" + name + "','" + languge + "','" + query + "','" + source + "','" + time + "','" + date + "','" + search + "','" + password + "','" + Email + "')";
                   cmdi.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                con.Close();
            }

            if (combobox1.Text == "" || tburl.Text == "")
            {
              //  MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                MessageBox.Show("Mendatory Fields Must Be Filled!", "NullExceptions", MessageBoxButton.OK, MessageBoxImage.Warning);
               /// MessageBox.Show("Mendatory Fields Must Be Filled!", "NullExceptions",
    // MessageBoxButtons.OK,
    // MessageBoxIcon.Warning // for Warning  
                            //MessageBoxIcon.Error // for Error 
                            //MessageBoxIcon.Information  // for Information
                            //MessageBoxIcon.Question // for Question
   // );


                //  MessageBox.Show("Mendatory Fields Must Be Filled!");

            }

            else
            {
              
                MessageBox.Show("Successfully!");
                

                   
                }
            }

        public void Open_Browser()


           
        {


            string search = tburl.Text;

            string language = combobox1.Text;

            if (Radiogit.IsChecked == true)

            {
               // panel2.Visible = false;
               // panel1.Visible = true;

               // this.BackgroundImage = Properties.Resources.black_polygonal_background_1055_564;


                //pictureBox1.Image = null;
              //  pictureBox1.BackgroundImage = Properties.Resources._39_394908_github_octocat;
                try
                {

                    switch (language)
                    {
                        case "C++":

                            language = "C%2B%2B";
                            opengit();
                            break;
                        case "C#":
                            language = "C%23";
                            opengit();
                            break;
                        default:
                            opengit();
                            break;
                    }

                }


                catch
                {
                    throw;
                }

                void opengit()
                {

                    var searchString = search;
                    searchString = searchString.Replace(" ", "+");
                    /* HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                       // document.Load(@"C:\Users\Windows 10\Documents\git.txt");
                       var Webget = new HtmlWeb();
                       document = Webget.Load("https://github.com/search?utf8=%E2%9C%93&q=" + searchString + "&type=");
                       HtmlNode[] aNodes2 = document.DocumentNode.SelectNodes("//ul[@class='repo-list']").ToArray();
                       string htmlString = aNodes2.FirstOrDefault().InnerHtml.Trim();
                       htmlString = htmlString.Replace("href=\"", "href=\"https://github.com");*/


                    var driverService = ChromeDriverService.CreateDefaultService();
                    driverService.HideCommandPromptWindow = true;
                    //  var options = new ChromeOptions();
                    //  options.AddArgument("headless");
                    driver = new ChromeDriver(driverService);
                    driver.Navigate().GoToUrl("https://github.com/search?l=" + language + "&q=" + searchString + "&type=" + "Repositories");

                    //webBrowser1.Navigate("https://github.com/search?l=" + language + "&q=" + searchString + "&type=" + "Repositories");

                }

            }
            else if (Radiogeeks.IsChecked == true)
            {
               // panel2.Visible = true;

                // panel1.Visible = false;
                try
                {

                    switch (language)
                    {
                        case "C++":

                            language = "C%2B%2B";
                            opengeeks();
                            break;


                        case "C#":

                            language = "C%23";
                            opengeeks();
                            break;
                        default:
                            opengeeks();
                            break;
                    }



                }


                catch
                {
                    throw;
                }
                void opengeeks()
                {

                    var driverService = ChromeDriverService.CreateDefaultService();
                    driverService.HideCommandPromptWindow = true;
                    var options = new ChromeOptions();
                    options.AddArgument("headless");
                    driver = new ChromeDriver(driverService, options);
                    driver.Navigate().GoToUrl("https://www.geeksforgeeks.org/?s=" + search + "+in+" + language);
                    //  webBrowser1.Navigate("https://www.geeksforgeeks.org/?s=" + search + "in" + language);

                }
            }
            else if (Radioprogramiz.IsChecked == true)
            {

               // panel2.Visible = true;
                // panel1.Visible = false;
                try
                {

                    switch (language)
                    {
                        case "C++":

                            language = "C%2B%2B";
                            openprogramiz();
                            break;


                        case "C#":
                            language = "C%23";
                            openprogramiz();

                            break;
                        default:
                            openprogramiz();
                            break;
                    }



                }


                catch
                {
                    throw;
                }
                void openprogramiz()
                {


                    var driverService = ChromeDriverService.CreateDefaultService();
                    driverService.HideCommandPromptWindow = true;
                    var options = new ChromeOptions();
                    options.AddArgument("headless");
                    driver = new ChromeDriver(driverService, options);
                    driver.Navigate().GoToUrl("https://www.programiz.com/search/" + search + " " + "in" + " " + language);
                    //webBrowser1.Navigate("https://www.programiz.com/search/" + search + " " + "in" + " " + language);
                }

            }
        }

        private void Scrape_Click(object sender, RoutedEventArgs e)
        {
           /* SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
            con.Open();
            SqlCommand cd = con.CreateCommand();
            cd.CommandType = System.Data.CommandType.Text;
            cd.CommandText = "DELETE FROM Ushine";
            SqlCommand cdi = con.CreateCommand();
            cdi.CommandType = System.Data.CommandType.Text;
            cdi.CommandText = "DELETE FROM Ugeeks";
            SqlCommand cdo = con.CreateCommand();
            cdo.CommandType = System.Data.CommandType.Text;
            cdo.CommandText = "DELETE FROM Uprogramiz";
            try
            {
                cd.ExecuteNonQuery();
                cdi.ExecuteNonQuery();
                cdo.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            con.Close();*/
            if (Radiogit.IsChecked == true)
            {
                string q = tburl.Text;
                string l = combobox1.Text;
                string s = "Github";
                MainFlate mf = new MainFlate(q,l,s);
                mf.Owner = this;
                this.Hide();
                mf.ShowDialog();
            }
            if (Radiogeeks.IsChecked == true)
            {
                string q = tburl.Text;
                string l = combobox1.Text;
                string s = "Geeks_For_Geeks";
                MainFlate mf = new MainFlate(q, l, s);
                mf.Owner = this;
                this.Hide();
                mf.ShowDialog();
            }
            if (Radioprogramiz.IsChecked == true)
            {
                string q = tburl.Text;
                string l = combobox1.Text;
                string s = "Programiz";
                MainFlate mf = new MainFlate(q, l, s);
                mf.Owner = this;
                this.Hide();
                mf.ShowDialog();
            }
           
        }


        private void Radiogit_Checked(object sender, RoutedEventArgs e)
        {
            Radiogit.Foreground = Brushes.Blue;
        }

        private void Radiogeeks_Checked(object sender, RoutedEventArgs e)
        {
            Radiogeeks.Foreground = Brushes.Blue;
        }

        private void Radioprogramiz_Checked(object sender, RoutedEventArgs e)
        {
            Radioprogramiz.Foreground = Brushes.Blue;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Owner = this;
            this.Hide();
            welcome.ShowDialog();
        }
    }

    }

