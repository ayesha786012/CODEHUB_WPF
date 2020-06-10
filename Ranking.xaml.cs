using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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

namespace CODEHUB
{
    /// <summary>
    /// Interaction logic for Ranking.xaml
    /// </summary>
    public partial class Ranking : UserControl
    {
        public Ranking(string q, string l, string s)
        {
            InitializeComponent();
            query.Text = q;
            language.Text=l;
            source.Text = s;
           
            if (s == "Github")
            {
                // textBox3.Text = source;
                stackpanel.Visibility = System.Windows.Visibility.Visible;
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

                con.Open();
                SqlCommand cnd = con.CreateCommand();
                cnd.CommandType = System.Data.CommandType.Text;
                //   cnd.CommandText = "select * from Codehub";

                cnd.CommandText = "SELECT link FROM Ushine WHERE query='" + query.Text + "'AND Source='" + source.Text + "'AND Language='" + language.Text + "'";
                try
                {
                        SqlDataReader dr = cnd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr.HasRows)
                            {
                                listbox1.Items.Add(dr["link"].ToString());
                            }
                            // l

                            // textBox2.AppendText(dr["star"].ToString());
                            // textBox3.AppendText(dr["watches"].ToString());
                            // richTextBox2.AppendText(dr["Code"].ToString());
                            else
                            {
                                MessageBox.Show("If you Crawl then Filter first Before Rank examples", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                
               
                    // panel2.Visible = true;
                    // panel3.Visible = false;
                }

            else if (s == "Geeks_For_Geeks")
            {
                //panel2.Visible = false;
                stackpanel.Visibility = System.Windows.Visibility.Hidden;
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

                con.Open();
                SqlCommand cnd = con.CreateCommand();
                cnd.CommandType = System.Data.CommandType.Text;
                //   cnd.CommandText = "select * from Codehub";

                cnd.CommandText = "SELECT link FROM Ugeeks WHERE query='" + query.Text + "'AND Source='" + source.Text + "'AND Language='" + language.Text + "'";
                try
                {
                        SqlDataReader dr = cnd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr.HasRows)
                            {
                                //listbox1.Items.Add(dr["link"].ToString());
                            }
                        // l

                        // textBox2.AppendText(dr["star"].ToString());
                        // textBox3.AppendText(dr["watches"].ToString());
                        // richTextBox2.AppendText(dr["Code"].ToString());
                        else
                        {
                            MessageBox.Show("If you Crawl then Filter first Before Rank examples", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                
                
                //  panel3.Visible = true;
            }
            else if (s == "Programiz")
            {
                stackpanel.Visibility = System.Windows.Visibility.Hidden;
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

                con.Open();
                SqlCommand cnd = con.CreateCommand();
                cnd.CommandType = System.Data.CommandType.Text;
                //   cnd.CommandText = "select * from Codehub";

                cnd.CommandText = "SELECT link FROM Uprogramiz WHERE query='" + query.Text + "'AND Source='" + source.Text + "'AND Language='" + language.Text + "'";
                try
                {
                    SqlDataReader dr = cnd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr.HasRows)
                        {
                           // listbox1.Items.Add(dr["link"].ToString());
                        }
                        // l

                        // textBox2.AppendText(dr["star"].ToString());
                        // textBox3.AppendText(dr["watches"].ToString());
                        // richTextBox2.AppendText(dr["Code"].ToString());
                        else
                        {
                            MessageBox.Show("If you Crawl then Filter first Before Rank examples", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            //  option1Selected = Option1Selected;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Rank_Click(object sender, RoutedEventArgs e)
        {
            if (comborank1.Text == "")
            {
                MessageBox.Show(" Select Any Category");
            }
            else
            {
                
                 listbox1.Items.Clear();
                    if (comborank1.Text == "Context Based Ranking")
                    {
                        richtextbox1.Text = "";

                        textbox1_star.Text = "";
                        textbox1_watches.Text = "";
                        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=CODEHUB;Integrated Security=True");
                        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

                        con.Open();
                        SqlCommand cnd = con.CreateCommand();
                        cnd.CommandType = System.Data.CommandType.Text;
                        //   cnd.CommandText = "select * from Codehub";
                        if (source.Text == "Github")
                        {
                            cnd.CommandText = "SELECT link FROM Ushine";
                            try
                            {
                                SqlDataReader dr = cnd.ExecuteReader();
                                while (dr.Read())
                                {
                                    if (dr.HasRows)
                                    {


                                        listbox1.Items.Add(dr["link"].ToString());
                                    }
                                    else
                                    {
                                        MessageBox.Show("If you Crawl then Filter first Before Rank examples", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);

                                    }
                                    // textBox2.AppendText(dr["star"].ToString());
                                    // textBox3.AppendText(dr["watches"].ToString());
                                    // richTextBox2.AppendText(dr["Code"].ToString());

                                }
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                        }
                        if (source.Text == "Geeks_For_Geeks")
                        {
                            cnd.CommandText = "SELECT link FROM Ugeeks";
                            try
                            {
                                SqlDataReader dr = cnd.ExecuteReader();
                                while (dr.Read())
                                {


                                    // textBox2.AppendText(dr["star"].ToString());
                                    //textBox3.AppendText(dr["watches"].ToString());

                                    listbox1.Items.Add(dr["link"].ToString());

                                }
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                        }
                        if (source.Text == "Programiz")
                        {
                            cnd.CommandText = "SELECT link FROM Uprogramiz";
                            try
                            {
                                SqlDataReader dr = cnd.ExecuteReader();
                                while (dr.Read())
                                {


                                    // textBox2.AppendText(dr["star"].ToString());
                                    //textBox3.AppendText(dr["watches"].ToString());

                                    listbox1.Items.Add(dr["link"].ToString());

                                }
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                        }

                    }
                    if (comborank1.Text == "Popularity Based Ranking")
                    {
                        richtextbox1.Text = "";
                        listbox1.Items.Clear();
                        textbox1_watches.Text = "";
                        textbox1_star.Text = "";
                        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=CODEHUB;Integrated Security=True");
                        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

                        con.Open();
                        SqlCommand cnd = con.CreateCommand();
                        cnd.CommandType = System.Data.CommandType.Text;
                        //   cnd.CommandText = "select * from Codehub";
                        //   cnd.CommandText = "SELECT link FROM system ORDER BY star,watches DESC ";
                        if (source.Text == "Github")
                        {
                            cnd.CommandText = "SELECT link FROM Ushine ORDER BY star,watches DESC";
                            try
                            {
                                SqlDataReader dr = cnd.ExecuteReader();
                                while (dr.Read())
                                {

                                    listbox1.Items.Add(dr["link"].ToString());
                                    //textBox2.AppendText(dr["star"].ToString());
                                    // textBox3.AppendText(dr["watches"].ToString());
                                    // richTextBox2.AppendText(dr["Code"].ToString());

                                }
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                        }
                        if (source.Text == "Geeks_For_Geeks")
                        {
                            listbox1.Items.Clear();
                            cnd.CommandText = "SELECT link FROM Ugeeks ";
                            try
                            {
                                SqlDataReader dr = cnd.ExecuteReader();
                                while (dr.Read())
                                {

                                    listbox1.Items.Add(dr["link"].ToString());
                                    // textBox2.AppendText(dr["star"].ToString());
                                    //textBox3.AppendText(dr["watches"].ToString());

                                    // richTextBox2.AppendText(dr["Code"].ToString());

                                }
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                        }
                        if (source.Text == "Programiz")
                        {
                            listbox1.Items.Clear();
                            cnd.CommandText = "SELECT link FROM Uprogramiz ";
                            try
                            {
                                SqlDataReader dr = cnd.ExecuteReader();
                                while (dr.Read())
                                {
                                    listbox1.Items.Add(dr["link"].ToString());

                                    // textBox2.AppendText(dr["star"].ToString());
                                    //textBox3.AppendText(dr["watches"].ToString());

                                    //richTextBox2.AppendText(dr["Code"].ToString());

                                }
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                        }


                    }
                
            }
        }

        private void listbox1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
         

        {
            richtextbox1.Text = "";
            textbox1_star.Text = "";
            textbox1_watches.Text = "";
            string Selected = listbox1.SelectedItem.ToString();

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

            con.Open();
            SqlCommand cnd = con.CreateCommand();
            cnd.CommandType = System.Data.CommandType.Text;
            //   cnd.CommandText = "select * from Codehub";
            if (source.Text == "Github")
            {
                cnd.CommandText = "SELECT * FROM Ushine WHERE link='" + Selected + "'";
                try
                {
                    SqlDataReader dr = cnd.ExecuteReader();
                    while (dr.Read())
                    {


                        textbox1_star.AppendText(dr["star"].ToString());
                        textbox1_watches.AppendText(dr["watches"].ToString());
                        richtextbox1.AppendText(dr["Code"].ToString());

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            if (source.Text == "Geeks_For_Geeks")
            {
                cnd.CommandText = "SELECT * FROM Ugeeks WHERE link='" + Selected + "'";
                try
                {
                    SqlDataReader dr = cnd.ExecuteReader();
                    while (dr.Read())
                    {


                        // textBox2.AppendText(dr["star"].ToString());
                        //textBox3.AppendText(dr["watches"].ToString());

                        richtextbox1.AppendText(dr["Code"].ToString());

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            if (source.Text == "Programiz")
            {
                cnd.CommandText = "SELECT * FROM Uprogramiz WHERE link='" + Selected + "'";
                try
                {
                    SqlDataReader dr = cnd.ExecuteReader();
                    while (dr.Read())
                    {


                        // textBox2.AppendText(dr["star"].ToString());
                        //textBox3.AppendText(dr["watches"].ToString());

                        richtextbox1.AppendText(dr["Code"].ToString());

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {
            writefile();
        }
        private async void writefile()
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            /*  using (SaveFileDialog sdf = new SaveFileDialog()
              {
                  Filter = "Text Document|*.txt",
                  ValidateNames = true,

              })*/

            if (dlg.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(dlg.FileName))

                    await sw.WriteLineAsync(richtextbox1.Text);
                MessageBox.Show("Successfully Saved !", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

    }
}
