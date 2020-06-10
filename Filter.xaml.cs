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
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

using System.Data.SqlClient;


namespace CODEHUB
{
    /// <summary>
    /// Interaction logic for Filter.xaml1
    /// </summary>
    public partial class Filter : UserControl
    {
        public IWebDriver driver;
        public Filter(string q, string l, string s)
        {
            InitializeComponent();

            //  InitializeComponent();

            //MessageBox.Show("Before Move to Rank the Repositories Example You must Firstly to Filter The Examples", "Notify",MessageBoxButton.OK,MessageBoxImage.Information);

            Query.Text = q;
            Language.Text = l;
            Source.Text = s;
            SqlConnection conp = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

            conp.Open();
            SqlCommand cndp = conp.CreateCommand();
            cndp.CommandType = System.Data.CommandType.Text;
            //   cnd.CommandText = "select * from Codehub";
            if (Source.Text == "Github")
            {
                cndp.CommandText = "SELECT link FROM system WHERE query='" + q + "'AND Source='" + s + "'AND Language='" + l + "'";
                try
                {
                SqlDataReader dr = cndp.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                          
                        listbox1.Items.Add(dr["link"].ToString());
                            
                    }
                    else
                    {
                            MessageBox.Show("Crawl First");




                        }
                        // TreeNode n = new TreeNode(dr["link"].ToString());


                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
            if (Source.Text == "Geeks_For_Geeks")
            {
                cndp.CommandText = "SELECT link FROM system WHERE query='" + q + "'AND Source='" + s + "'AND Language='" + l + "'";
                try
                {
                    SqlDataReader dr = cndp.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr.HasRows)
                        {
                            //     driver.Close();

                            listbox1.Items.Add(dr["link"].ToString());

                        }
                        else
                        {
                            MessageBox.Show("Crawl First");

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            if (Source.Text == "Programiz")
            {

                Extension.Text ="Pro";
                Extension.IsReadOnly = true;
                cndp.CommandText = "SELECT link FROM system WHERE query='" + q + "'AND Source='" + s + "'AND Language='" + l + "'";
                try
                {
                    SqlDataReader dr = cndp.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr.HasRows)
                        {
                            //     driver.Close();

                            listbox1.Items.Add(dr["link"].ToString());

                        }
                        else
                        {
                            MessageBox.Show("First Crawl!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            // List<string> listcolllection = new List<string>();
            foreach (string str in listbox1.Items)
            {
                listcolllection.Add(str);
                Extension.CharacterCasing = CharacterCasing.Lower;
            }
        }
        List<string> listcolllection = new List<string>();
        private void link_Click(object sender, RoutedEventArgs e)
        {


            if (Extension.Text == "")
            {
                MessageBox.Show("Write Language Extension First");
            }

            else if (Extension.Text != "")
            {

                if (Extension.Text == "Pro")
                {
                    if (listbox1.Items.Count > 0)
                    {
                        ayesha();
                    }
                    else
                    {
                        MessageBox.Show("First Crawl!");
                    }
                }
                else { 
                switch (Language.Text)
                {
                    case "C++":

                        if (Extension.Text != ".cpp" && Extension.Text != "cpp")
                        {

                            MessageBox.Show("Write Correct Extension Of C++ Language Check By click On Extension Button");


                        }
                        else
                        {
                            ayesha();
                        }
                        break;


                    case "C#":
                        if (Extension.Text != ".cs" && Extension.Text != "cs")
                        {


                            if (Extension.Text == "Pro")
                            {
                                Extension.IsReadOnly = true;
                            }
                            else
                            {
                                MessageBox.Show("Write Correct Extension Of C++ Language Check By click On Extension Button");


                            }
                        }
                        else
                        {
                            ayesha();
                        }
                        break;
                    case "JAVA":
                        if (Extension.Text != ".java" && Extension.Text != "java")
                        {

                            if (Extension.Text == "Pro")
                            {
                                Extension.IsReadOnly = true;
                            }
                            else
                            {
                                MessageBox.Show("Write Correct Extension Of C++ Language Check By click On Extension Button");


                            }
                        }
                        else
                        {
                            ayesha();
                        }
                        break;
                    case "C":
                        if (Extension.Text != ".c" && Extension.Text != "c" )
                        {

                            if (Extension.Text == "Pro")
                            {
                                Extension.IsReadOnly = true;
                            }
                            else
                            {
                                MessageBox.Show("Write Correct Extension Of C++ Language Check By click On Extension Button");


                            }
                        }
                        else
                        {
                            ayesha();
                        }
                        break;
                    case "PYTHON":
                        if (Extension.Text != ".py" && Extension.Text != "py" )
                        {

                           
                                MessageBox.Show("Write Correct Extension Of C++ Language Check By click On Extension Button");


                            
                        }
                        else
                        {
                            ayesha();
                        }
                        break;
                    default:
                        //openprogramiz();
                        break;
                }
            }
                }
            


        }

        private void ayesha()
        {


            if (Source.Text == "Github")
            {

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
                con.Open();
                SqlCommand cd = con.CreateCommand();
                cd.CommandType = System.Data.CommandType.Text;
                cd.CommandText = "DELETE FROM Ushine";
                try
                {
                    cd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                     MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                con.Close();
                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                var options = new ChromeOptions();
              //  options.AddArgument("headless");
                options.AddArgument("no-sandbox");
                driver = new ChromeDriver(driverService,options);

                List<string> listcolllection = new List<string>();
                foreach (string str in listbox1.Items)
                {
                    listcolllection.Add(str);
                    Extension.CharacterCasing = CharacterCasing.Lower;
                    checkgithub(str);
                    try
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = System.Data.CommandType.Text;


                        // MessageBox.Show("YOU SELECTED THIS BEFORE", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //cmd.CommandText = "insert into Codehub (URL) values('" + note.Text+"')";
                        cmd.CommandText = "insert into Ushine(link,star,watches,code,Query,Source,Language) values(@link,@star,@watches,@code,@Query,@Source,@Language)";// + watches1.Text + "','" + richtextbox1.Text + "','" + Query.Text + "','" + Source.Text + "','" + Language.Text + "')";
                        cmd.Parameters.AddWithValue("@link", str);
                        cmd.Parameters.AddWithValue("@star", star.Text);
                        cmd.Parameters.AddWithValue("@watches", watches1.Text);
                        cmd.Parameters.AddWithValue("@code", richtextbox1.Text);
                        cmd.Parameters.AddWithValue("@Query", Query.Text);
                        cmd.Parameters.AddWithValue("@Source", Source.Text);
                        cmd.Parameters.AddWithValue("@Language", Language.Text);
                        cmd.ExecuteNonQuery();
                       // cmd.Dispose();
                       // con.Dispose();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    con.Close();
                    richtextbox1.Text = "";
                    star.Text = "";
                    watches1.Text = "";
                }
                //}
                // TreeNode n = new TreeNode(dr["link"].ToString());
            }


            /*  catch (Exception ex)
              {
                  MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
              }*/




            if (Source.Text == "Geeks_For_Geeks")
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

               // SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

                con.Open();
                SqlCommand cd = con.CreateCommand();
                cd.CommandType = System.Data.CommandType.Text;
                cd.CommandText = "DELETE FROM Ugeeks";
                try
                {
                    cd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                con.Close();
                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                var options = new ChromeOptions();
                options.AddArgument("headless");
                driver = new ChromeDriver(driverService, options);

                List<string> listcolllection = new List<string>();
                foreach (string str in listbox1.Items)
                {
                    listcolllection.Add(str);
                    Extension.CharacterCasing = CharacterCasing.Lower;
                    checkgeeks(str);
                    try
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = System.Data.CommandType.Text;


                        // MessageBox.Show("YOU SELECTED THIS BEFORE", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //cmd.CommandText = "insert into Codehub (URL) values('" + note.Text+"')";
                        cmd.CommandText = "insert into Ugeeks(link,star,watches,code,Query,Source,Language) values(@link,@star,@watches,@code,@Query,@Source,@Language)";// + watches1.Text + "','" + richtextbox1.Text + "','" + Query.Text + "','" + Source.Text + "','" + Language.Text + "')";
                        cmd.Parameters.AddWithValue("@link", str);
                        cmd.Parameters.AddWithValue("@star", star.Text);
                        cmd.Parameters.AddWithValue("@watches", watches1.Text);
                        cmd.Parameters.AddWithValue("@code", richtextbox1.Text);
                        cmd.Parameters.AddWithValue("@Query", Query.Text);
                        cmd.Parameters.AddWithValue("@Source", Source.Text);
                        cmd.Parameters.AddWithValue("@Language", Language.Text);
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    con.Close();
                    richtextbox1.Text = "";
                    star.Text = "";
                    watches1.Text = "";
                }
            }
            //}
            // TreeNode n = new TreeNode(dr["link"].ToString());
            /* }
             catch (Exception ex)
             {
                 MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
             }
         }*/




            if (Source.Text == "Programiz")

            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
                //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

                con.Open();
                SqlCommand cd = con.CreateCommand();
                cd.CommandType = System.Data.CommandType.Text;
                cd.CommandText = "DELETE FROM Uprogramiz";
                try
                {
                    cd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                con.Close();

                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                var options = new ChromeOptions();
                options.AddArgument("headless");
                driver = new ChromeDriver(driverService);

                List<string> listcolllection = new List<string>();
                foreach (string str in listbox1.Items)
                {
                    listcolllection.Add(str);
                    Extension.CharacterCasing = CharacterCasing.Lower;
                    checkprogramiz(str);
                    try
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = System.Data.CommandType.Text;


                        // MessageBox.Show("YOU SELECTED THIS BEFORE", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //cmd.CommandText = "insert into Codehub (URL) values('" + note.Text+"')";
                        cmd.CommandText = "insert into Uprogramiz(link,star,watches,code,Query,Source,Language) values(@link,@star,@watches,@code,@Query,@Source,@Language)";// + watches1.Text + "','" + richtextbox1.Text + "','" + Query.Text + "','" + Source.Text + "','" + Language.Text + "')";
                        cmd.Parameters.AddWithValue("@link", str);
                        cmd.Parameters.AddWithValue("@star", star.Text);
                        cmd.Parameters.AddWithValue("@watches", watches1.Text);
                        cmd.Parameters.AddWithValue("@code", richtextbox1.Text);
                        cmd.Parameters.AddWithValue("@Query", Query.Text);
                        cmd.Parameters.AddWithValue("@Source", Source.Text);
                        cmd.Parameters.AddWithValue("@Language", Language.Text);
                        cmd.ExecuteNonQuery();
                        SqlConnection coni = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

                        coni.Open();
                        SqlCommand cdp = coni.CreateCommand();
                        cdp.CommandType = System.Data.CommandType.Text;
                        cdp.CommandText = "DELETE FROM Uprogramiz WHERE Code=''";
                        try
                        {
                            cdp.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        coni.Close();
                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    con.Close();
                    richtextbox1.Text = "";
                    star.Text = "";
                    watches1.Text = "";
                }
                con.Close();
                listbox1.Items.Clear();
                SqlConnection conpo = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

                conpo.Open();
                SqlCommand cndpo = conpo.CreateCommand();
                cndpo.CommandType = System.Data.CommandType.Text;
                //   cnd.CommandText = "select * from Codehub";

                cndpo.CommandText = "SELECT link FROM Uprogramiz WHERE query='" + Query.Text + "'AND Source='" + Source.Text + "'AND Language='" + Language.Text + "'";
                try
                {
                    SqlDataReader dro = cndpo.ExecuteReader();
                    while (dro.Read())
                    {
                        if (dro.HasRows)
                        {

                            listbox1.Items.Add(dro["link"].ToString());

                        }
                        else
                        {




                        }
                        // TreeNode n = new TreeNode(dr["link"].ToString());


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }




            }
            // TreeNode n = new TreeNode(dr["link"].ToString());


            /*  }
          }
          catch (Exception ex)
          {
              MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
          }*/



        }
                
            
        
            private void checkprogramiz(string str)
        
        {
            string selected = str;

            driver.Navigate().GoToUrl("https://www.programiz.com" + selected);
            // webBrowser1.Navigate(selected);

            IList<IWebElement> searchElements = driver.FindElements(By.XPath(".//div[@class='content']"));

            foreach (IWebElement i in searchElements)
            {
                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                var text = i.GetAttribute("innerHTML");
                htmlDocument.LoadHtml(text);
                var inputs = htmlDocument.DocumentNode.Descendants("pre").ToList();
                foreach (var items in inputs)
                {
                    HtmlAgilityPack.HtmlDocument htmlDocument1 = new HtmlAgilityPack.HtmlDocument();
                    htmlDocument1.LoadHtml(items.InnerHtml);

                    var tds = htmlDocument1.DocumentNode.Descendants("code").ToList();
                    var links = htmlDocument1.DocumentNode.Descendants("a");


                    if (tds.Count != 0)
                        foreach (var node in tds)
                        {
                            // richTextBox1.AppendText("\t\n");

                            richtextbox1.AppendText(node.InnerText.Trim() ?? " ");
                            // this.richTextBox1.Text = this.richTextBox1.Text.Trim();
                            //richTextBox1.Text = Regex.Replace(richTextBox1.Text, "", "");
                            //richTextBox1.Font = new Font("Georgia", 8);

                        }

                }
            }
        }

        private void checkgeeks(string str)
        {
            string selected = str;
            driver.Navigate().GoToUrl(selected);

            // webBrowser1.Navigate(selected);

            IList<IWebElement> searchElements = driver.FindElements(By.TagName("table"));

            foreach (IWebElement i in searchElements)
            {
                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                var text = i.GetAttribute("innerHTML");
                htmlDocument.LoadHtml(text);
                var inputs = htmlDocument.DocumentNode.Descendants("tbody").ToList();
                foreach (var items in inputs)
                {
                    HtmlAgilityPack.HtmlDocument htmlDocument1 = new HtmlAgilityPack.HtmlDocument();
                    htmlDocument1.LoadHtml(items.InnerHtml);

                    var tds = htmlDocument1.DocumentNode.Descendants("div").ToList();
                    var links = htmlDocument1.DocumentNode.Descendants("a");


                    if (tds.Count != 0)
                        foreach (var node in tds)
                        {
                            richtextbox1.AppendText("\t\n");

                            richtextbox1.AppendText(node.InnerText.Trim() ?? " ");
                            // this.richTextBox1.Text = this.richTextBox1.Text.Trim();
                            //  richTextBox1.Text = Regex.Replace(richTextBox1.Text, "", "");
                            //  richTextBox1.Font = new Font("Georgia", 8);

                        }
                }
            }
        }

        private void checkgithub(string str)
        {
            string selected = str;



            driver.Navigate().GoToUrl("https://github.com" + selected);
            //webBrowser1.Navigate("https://github.com" + selected);

            IList<IWebElement> SER = driver.FindElements(By.TagName("main"));
            foreach (IWebElement i in SER)
            {
                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                var text = i.GetAttribute("innerHTML");
                htmlDocument.LoadHtml(text);

                var inputs = htmlDocument.DocumentNode.Descendants("tbody").ToList();
                foreach (var items in inputs)
                {

                    IList<IWebElement> searchElements = driver.FindElements(By.XPath(".//ul[@class='pagehead-actions flex-shrink-0 ']"));
                    foreach (IWebElement iM in searchElements)
                    {
                        HtmlAgilityPack.HtmlDocument htmlDocumentM = new HtmlAgilityPack.HtmlDocument();
                        var textM = i.GetAttribute("innerHTML");
                        htmlDocumentM.LoadHtml(text);
                        //var tds = htmlDocument.DocumentNode.Descendants("li").ToList();
                        var watches = htmlDocumentM.DocumentNode.SelectSingleNode(".//a[@class='social-count js-social-count']");
                        // var star = htmlDocument.DocumentNode.SelectSingleNode(".// foam[@class='starred js-social-form']  a[@class='social-count js-social-count']");
                        var folk = htmlDocumentM.DocumentNode.SelectSingleNode(".//a[@class='social-count']");

                        HtmlAgilityPack.HtmlDocument htmlDocument1 = new HtmlAgilityPack.HtmlDocument();
                        htmlDocument1.LoadHtml(items.InnerHtml);


                        var tds = htmlDocument1.DocumentNode.Descendants("tr").ToList();

                        if (tds.Count != 0)
                            foreach (var node in tds)
                            {
                                //

                                richtextbox1.AppendText(node.InnerText + "\t\r");


                            }
                       star.AppendText(watches.InnerText);
                        watches1.AppendText(folk.InnerText);

                    }
                }
            }
        }
    

        private void Extension_button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Here Are the Language Extensions\n\n\n " +
               "C#-->.cs/cs\n\n" +
               "C++-->.cpp/cpp\n\n" +
               "C--->.c/c\n\n" +
               "PYTHON-->.py/py\n\n" +

               "JAVA-->.java/java\n\n") ;
               
        }

        private void Extension_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(Extension.Text) == false)
            {
              listbox1.Items.Clear();
                foreach (string s in listcolllection)
                {
                    if (s.Contains(Extension.Text))
                    // SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=CODEHUB;Integrated Security=True");
                    {
                        listbox1.Items.Add(s);

                    }


                }

            }
            else if (Extension.Text == "")
            {
                listbox1.Items.Clear();
                foreach (string str in listcolllection)
                {
                    listbox1.Items.Add(str);
                }
            }
        }

        private void listbox1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           
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

        private void listbox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void richtextbox1_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void listbox1_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)

            {

                string Selected = listbox1.SelectedItem.ToString();
                richtextbox1.Text = "";
                star.Text = "";
                watches1.Text = "";

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

                con.Open();
                SqlCommand cnd = con.CreateCommand();
                cnd.CommandType = System.Data.CommandType.Text;
                //   cnd.CommandText = "select * from Codehub";
                if (Source.Text == "Github")
                {
                    cnd.CommandText = "SELECT * FROM Ushine WHERE link='" + Selected + "'";
                    try
                    {
                        SqlDataReader dr = cnd.ExecuteReader();
                        while (dr.Read())
                        {


                            star.AppendText(dr["star"].ToString());
                            watches1.AppendText(dr["watches"].ToString());
                            richtextbox1.AppendText(dr["Code"].ToString());

                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                if (Source.Text == "Geeks_For_Geeks")
                {
                    cnd.CommandText = "SELECT * FROM Ugeeks WHERE link='" + Selected + "'";
                    try
                    {
                        SqlDataReader dr = cnd.ExecuteReader();
                        while (dr.Read())
                        {


                            // textBox2.AppendText(dr["star"].ToString());
                            //textBox3.AppendText(dr["watches"].ToString());
                            // star. = false;
                            star.Visibility = System.Windows.Visibility.Hidden;
                            watches1.Visibility = System.Windows.Visibility.Hidden;

                            star_label.Visibility = System.Windows.Visibility.Hidden;
                            watches_label.Visibility = System.Windows.Visibility.Hidden;
                            richtextbox1.AppendText(dr["Code"].ToString());
                            richtextbox1.Text.Replace(" × × &nbsp; × ×	Sort by:RelevanceRelevanceDate Sort by:RelevanceRelevanceDate Relevance Relevance RelevanceDate Relevance Relevance Date Date ×	× &nbsp; × ×  Sort by:RelevanceRelevanceDate Sort by:RelevanceRelevanceDate Relevance Relevance RelevanceDate Relevance Relevance Date Date","");
                            richtextbox1.Text.Replace("&nbsp;", " ");

                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                if (Source.Text == "Programiz")
                {
                   
                    cnd.CommandText = "SELECT * FROM Uprogramiz WHERE link='" + Selected + "'";
                    try
                    {
                        SqlDataReader dr = cnd.ExecuteReader();
                        while (dr.Read())
                        {


                            // textBox2.AppendText(dr["star"].ToString());
                            //textBox3.AppendText(dr["watches"].ToString());
                            star.Visibility = System.Windows.Visibility.Hidden;
                            watches1.Visibility = System.Windows.Visibility.Hidden;

                            star_label.Visibility = System.Windows.Visibility.Hidden;
                            watches_label.Visibility = System.Windows.Visibility.Hidden;
                            richtextbox1.AppendText(dr["Code"].ToString());

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
}
