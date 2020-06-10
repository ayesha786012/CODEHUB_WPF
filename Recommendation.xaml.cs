using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Recommendation.xaml
    /// </summary>
    public partial class Recommendation : UserControl
    {
        public Recommendation(string q, string l,string s)
        {
            InitializeComponent();
            query.Text = q;
            language.Text = l;
            source.Text = s;
            InitializeComponent();
            if (s == "Github")
            {
                // textBox3.Text = source;
                //stackpanel.Visibility = System.Windows.Visibility.Visible;
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


                // panel2.Visible = true;
                // panel3.Visible = false;
            }

            else if (s == "Geeks_For_Geeks")
            {
                //panel2.Visible = false;
              //  stackpanel.Visibility = System.Windows.Visibility.Hidden;
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


                //  panel3.Visible = true;
            }
            else if (s == "Programiz")
            {
              //  stackpanel.Visibility = System.Windows.Visibility.Hidden;
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

        private void Recommend_Click(object sender, RoutedEventArgs e)
        
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

            con.Open();
            SqlCommand cnd = con.CreateCommand();
            cnd.CommandType = System.Data.CommandType.Text;
            //   cnd.CommandText = "select * from Codehub";
            if (source.Text == "Github")
            {
                cnd.CommandText = "SELECT link FROM Ushine WHERE query='" + query.Text + "'AND Source='" + source.Text + "'AND Language='" + language.Text + "' ORDER BY star,watches DESC";

              //  cnd.CommandText = "SELECT link FROM Ushine";
                try
                {
                    SqlDataReader dr = cnd.ExecuteReader();
                    if (dr.HasRows)
                    {

                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        listbox1.Items.Add(dt.Rows[0]["link"].ToString());
                        listbox1.Items.Add(dt.Rows[1]["link"].ToString());
                        // textBox4.Text = "\t";
                        //  textBox5.Text = dt.Rows[1]["link"].ToString();
                        //  textBox6.Text = dt.Rows[2]["link"].ToString();


                        // listBox1.Items.Add(dr["link"]);
                        //   textBox4.AppendText(dr();



                    }
                    else
                    {
                        MessageBox.Show("If you Crawl then Filter first Before Rank examples", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    //MessageBox.Show("If you Crawl then Filter first Before Rank examples", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);

                }

                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            if (source.Text == "Geeks_For_Geeks")
            {
                cnd.CommandText = "SELECT link FROM Ugeeks WHERE query='" + query.Text + "'AND Source='" + source.Text + "'AND Language='" + language.Text + "'";
                try
                {
                    SqlDataReader dr = cnd.ExecuteReader();
                    if (dr.HasRows)
                    {

                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        listbox1.Items.Add(dt.Rows[0]["link"].ToString());
                        listbox1.Items.Add(dt.Rows[1]["link"].ToString());
                        // textBox4.Text = "\t";
                        //  textBox5.Text = dt.Rows[1]["link"].ToString();
                        //  textBox6.Text = dt.Rows[2]["link"].ToString();


                        // listBox1.Items.Add(dr["link"]);
                        //   textBox4.AppendText(dr();



                    }
                    else
                    {
                        MessageBox.Show("If you Crawl then Filter first Before Rank examples", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            if (source.Text == "Programiz")
            {
                cnd.CommandText = "SELECT link FROM Uprogramiz WHERE query='" + query.Text + "'AND Source='" + source.Text + "'AND Language='" + language.Text + "'";
                try
                {
                    SqlDataReader dr = cnd.ExecuteReader();
                    if (dr.HasRows)
                    {

                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        listbox1.Items.Add(dt.Rows[0]["link"].ToString());
                        try
                        {
                            listbox1.Items.Add(dt.Rows[1]["link"].ToString());

                        }
                        // textBox4.Text = "\t";
                        //  textBox5.Text = dt.Rows[1]["link"].ToString();
                        //  textBox6.Text = dt.Rows[2]["link"].ToString();


                        // listBox1.Items.Add(dr["link"]);
                        //   textBox4.AppendText(dr();

                        catch
                        {

                        }

                    }
                    else
                    {
                        MessageBox.Show("If you Crawl then Filter first Before Rank examples", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

                catch (Exception ex)
                {
                   // MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            con.Close();

        }

        private void listbox1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
       

        {
            richtextbox1.Text = "";
            string Selected = listbox1.SelectedItem.ToString();

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

            con.Open();
            SqlCommand cnd = con.CreateCommand();
            cnd.CommandType = System.Data.CommandType.Text;
            //   cnd.CommandText = "select * from Codehub";
            if (source.Text == "Github")
            {
                cnd.CommandText = "SELECT * FROM Ushine WHERE link='" + Selected + "' ORDER BY star,watches DESC";
                try
                {
                    SqlDataReader dr = cnd.ExecuteReader();
                    while (dr.Read())
                    {


                        // textBox2.AppendText(dr["star"].ToString());
                        // textBox1.AppendText(dr["watches"].ToString());
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
        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (listbox1.Items.Count == 0)
            {
                MessageBox.Show("Filter First!");
            }
            else { 
            SqlConnection coni = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
            coni.Open();
            SqlCommand cndi = coni.CreateCommand();
            // SqlCommand cndii = coni.CreateCommand();
            cndi.CommandType = System.Data.CommandType.Text;
                // cndii.CommandType = System.Data.CommandType.Text;
                // cnd.CommandText = "SELECT URL FROM Codehub WHERE id = 1";
                try
                {
                    if (listbox1.Items.Count < 2)
                    {
                        string collection1 = listbox1.Items[0].ToString();
                        cndi.CommandText = "select * from Current_User_Data where Query='" + query.Text + "' update Current_User_Data set Recommended ='" + collection1 + "' where Query='" + query.Text + "'";
                        cndi.ExecuteNonQuery();

                    }
                    else
                    {
                        // string collection= ;
                        string collection1 = listbox1.Items[0].ToString();
                    string collection2 = listbox1.Items[1].ToString();
                    string collectionfinal = collection1 + collection2;
                    cndi.CommandText = "select * from Report where Query='" + query.Text + "' update Report set Recommended ='" + collectionfinal + "' where Query='" + query.Text + "'";
                    cndi.ExecuteNonQuery();
                    // cndii.CommandText = "select * from Current_User_Data where Query='" + query.Text + "' update Current_User_Data set Recommended ='" + listbox1.Items.ToString() + "' where Query='" + query.Text + "'";
                    // cndii.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //throw ;
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            coni.Close();
            SqlConnection conio = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
            conio.Open();
            //  SqlCommand cndi = coni.CreateCommand();
            SqlCommand cndii = conio.CreateCommand();
            // cndi.CommandType = System.Data.CommandType.Text;
            cndii.CommandType = System.Data.CommandType.Text;
            // cnd.CommandText = "SELECT URL FROM Codehub WHERE id = 1";
            try
            {
                    if (listbox1.Items.Count < 2)
                    {
                        string collection1 = listbox1.Items[0].ToString();
                        cndii.CommandText = "select * from Current_User_Data where Query='" + query.Text + "' update Current_User_Data set Recommended ='" + collection1 + "' where Query='" + query.Text + "'";
                        cndii.ExecuteNonQuery();

                    }
                    else
                    {
                        string collection1 = listbox1.Items[0].ToString();
                        string collection2 = listbox1.Items[1].ToString();
                        string collectionfinal = collection1 + collection2;
                        //cndi.CommandText = "select * from Report where Query='" + query.Text + "' update Report set Recommended ='" + collection + "' where Query='" + query.Text + "'";
                        // cndi.ExecuteNonQuery();
                        cndii.CommandText = "select * from Current_User_Data where Query='" + query.Text + "' update Current_User_Data set Recommended ='" + collectionfinal + "' where Query='" + query.Text + "'";
                        cndii.ExecuteNonQuery();
                    }
            }
            catch (Exception ex)
            {
                //throw ;
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            coni.Close();
            MessageBox.Show("Successfully Saved!");
        }
        }
    }
}
