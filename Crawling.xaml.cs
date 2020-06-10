using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CODEHUB
{
    /// <summary>
    /// Interaction logic for Crawling.xaml
    /// </summary>
    public partial class Crawling : UserControl
    {
        public IWebDriver driver;
        public Crawling(string query, string lan, string sour)
        {
            InitializeComponent();
            Query.Text = query;
            Language.Text = lan;
            Source.Text = sour;

           
            
                SqlConnection conp = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

                conp.Open();
                SqlCommand cndp = conp.CreateCommand();
                cndp.CommandType = System.Data.CommandType.Text;
            //   cnd.CommandText = "select * from Codehub";
          //  query = "select * from customer where country = '" + country + "' AND idcurrency = '" + idcurrency + "'";
            cndp.CommandText = "SELECT * FROM system WHERE query='"+ query + "'AND Source='"+ sour + "'AND Language='"+lan+"'";
                try
                {
                    SqlDataReader dr = cndp.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {

                        treeview1.Items.Add(dr["link"].ToString());
                    }
                   
                    // read data for each record here
                }

                // TreeNode n = new TreeNode(dr["link"].ToString());

                if (treeview1.Items.Count > 0)
                {
                    //
                }
                else
                {
                    

                        Open_Browser();
                        Find_Data();

                    
                }
                }
                catch (Exception ex)
                {
                throw ;
                  // MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            
            
        }
        private void Find_Data()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
            /*con.Open();
            SqlCommand cd = con.CreateCommand();
            cd.CommandType = System.Data.CommandType.Text;
            cd.CommandText = "DELETE FROM system";
            try
            {
                cd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            */
            if (Source.Text=="Github")
            {
                IList<IWebElement> searchElements = driver.FindElements(By.XPath(".//ul[@class='repo-list']"));
                foreach (IWebElement i in searchElements)
                {
                    HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                    var text = i.GetAttribute("innerHTML");
                    htmlDocument.LoadHtml(text);
                    var tds = htmlDocument.DocumentNode.Descendants("li").ToList();

                    var links = htmlDocument.DocumentNode.SelectNodes(".//a[@class='v-align-middle']").ToList();

                    if (tds.Count != 0)

                        foreach (var node in tds)
                        {
                            //node= Regex.Replace(node.InnerText, @"( |\t|\r?\n)\1+", "$1"); 

                            /* richTextBox1.AppendText("-----------------------------\n\n\n");


                             //  string data = node.InnerText;

                             richTextBox1.AppendText(node.InnerText.Trim() ?? " ");
                             this.richTextBox1.Text = this.richTextBox1.Text.Trim();
                             richTextBox1.Text = Regex.Replace(richTextBox1.Text, "", "");*/

                            //string nodes = node;




                         //   listbox1.View = View.List;
                         //   listView1.Columns.Add("", 150);
                         //   listView1.BackColor = System.Drawing.Color.LightPink;
                           // listView1.ForeColor = System.Drawing.Color.Black;
                           // listView1.Font = new Font("Georgia", 8);
                          //  listbox1.Items.Add(node.InnerText.Trim() ?? " ");


                           



                        }
                    foreach (var link in links)
                    {
                        //  var linko= link.SelectSingleNode(".//a[@class='v-align-middle']");
                        // var linko = de
                        var href = link.GetAttributeValue("href", string.Empty);
                        // array(href);
                     //   TreeNode node = new TreeNode(href);
                        TreeViewItem node=new TreeViewItem();
                      node.Header = href;
                        treeview1.Items.Add(node);
                        treeview1.Foreground = Brushes.DarkBlue;
                        // Rank n = new Rank(node);
                        Collection(node);

                        //listView2.Items.Add("\n\n\n");
                        //  listView1.Items.Add("______________________________");

                        // TreeNode node = new TreeNode(textBox1.Text);
                        // treeView1.Nodes.Add(node);

                    }


                }
            }

            if (Source.Text=="Geeks_For_Geeks")

            {
                IList<IWebElement> searchElements = driver.FindElements(By.Id("content"));


                foreach (IWebElement i in searchElements)
                {
                    HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                    var text = i.GetAttribute("innerHTML");
                    htmlDocument.LoadHtml(text);
                    var inputs = htmlDocument.DocumentNode.Descendants("article").ToList();
                    foreach (var items in inputs)
                    {
                        HtmlAgilityPack.HtmlDocument htmlDocument1 = new HtmlAgilityPack.HtmlDocument();
                        htmlDocument1.LoadHtml(items.InnerHtml);
                        var tds = htmlDocument1.DocumentNode.Descendants("div").ToList();
                        var links = htmlDocument1.DocumentNode.Descendants("a");

                        if (tds.Count != 0)
                            foreach (var node in tds)
                            {


                                //   listbox1.View = View.List;
                                //   listView1.Columns.Add("", 150);
                                //   listView1.BackColor = System.Drawing.Color.LightPink;
                                // listView1.ForeColor = System.Drawing.Color.Black;
                                // listView1.Font = new Font("Georgia", 8);
                              //  listbox1.Items.Add(node.InnerText.Trim() ?? " ");

                            }

                        foreach (var link in links)
                        {
                            var href = link.GetAttributeValue("href", string.Empty);
                            /* listView2.View = View.List;
                            listView2.Columns.Add("", 150);
                            listView2.BackColor = System.Drawing.Color.Green;
                            listView2.ForeColor = System.Drawing.Color.Black;
                            listView2.Font = new Font("Georgia", 8);
                            listView2.Items.Add(href);*/
                            TreeViewItem node = new TreeViewItem();
                            node.Header = href;
                            treeview1.Items.Add(node);
                            // Rank n = new Rank(node);
                            //   Collection(node);
                            con.Open();
                            SqlCommand cmd = con.CreateCommand();
                            cmd.CommandType = System.Data.CommandType.Text;


                            // MessageBox.Show("YOU SELECTED THIS BEFORE", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            // cmd.CommandText = "insert into Codehub values('" + href + "')";
                            cmd.CommandText = "insert into system(link,query,Source,Language) values('" + href + "','"+Query.Text+"','"+Source.Text+"','"+Language.Text+"')";
                            cmd.ExecuteNonQuery();
                            con.Close();
                            /*
                                                        this.listView2.Text = this.listView1.Text.Trim();
                                                        listView2.Text = Regex.Replace(listView1.Text, "", "");

                                                        listView2.Items.Add("__________________________________________________________________");*/

                        }




                    }
                }
            }
            if (Source.Text=="Programiz")
            {
                IList<IWebElement> searchElements = driver.FindElements(By.ClassName("col-sm-12"));
                foreach (IWebElement i in searchElements)
                {
                    HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                    var text = i.GetAttribute("innerHTML");
                    htmlDocument.LoadHtml(text);
                    var inputs = htmlDocument.DocumentNode.Descendants("div").ToList();
                    foreach (var items in inputs)
                    {
                        HtmlAgilityPack.HtmlDocument htmlDocument1 = new HtmlAgilityPack.HtmlDocument();
                        htmlDocument1.LoadHtml(items.InnerHtml);
                        var tds = htmlDocument1.DocumentNode.Descendants("p").ToList();
                        var links = htmlDocument1.DocumentNode.Descendants("a");

                        if (tds.Count != 0)
                            foreach (var node in tds)
                            {
                                //richTextBox1.AppendText("-----------------------------\n\n\n");


                                //   listbox1.View = View.List;
                                //   listView1.Columns.Add("", 150);
                                //   listView1.BackColor = System.Drawing.Color.LightPink;
                                // listView1.ForeColor = System.Drawing.Color.Black;
                                // listView1.Font = new Font("Georgia", 8);
                              //  listbox1.Items.Add(node.InnerText.Trim() ?? " ");


                            }

                        foreach (var link in links)
                        {
                            // var href = link.GetAttributeValue("href", string.Empty);
                            // richTextBox2.AppendText("-----------------------------\n\n\n");
                            var href = link.GetAttributeValue("href", string.Empty);
                            /* listView2.View = View.List;
                             listView2.Columns.Add("", 150);
                             listView2.BackColor = System.Drawing.Color.Green;
                             listView2.ForeColor = System.Drawing.Color.Black;
                             listView2.Font = new Font("Georgia", 8);
                             listView2.Items.Add(href);*/
                            TreeViewItem node = new TreeViewItem();
                            node.Header = href;
                            treeview1.Items.Add(node);
                            // Rank n = new Rank(node);
                         //   Collection(node);
                            con.Open();
                            SqlCommand cmd = con.CreateCommand();
                            cmd.CommandType = System.Data.CommandType.Text;


                            // MessageBox.Show("YOU SELECTED THIS BEFORE", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            // cmd.CommandText = "insert into Codehub values('" + href + "')";
                            cmd.CommandText = "insert into system(link,query,Source,Language) values('" + href + "','" + Query.Text + "','" + Source.Text + "','" + Language.Text + "')";
                            cmd.ExecuteNonQuery();
                            con.Close();
/*
                            this.listView2.Text = this.listView1.Text.Trim();
                            listView2.Text = Regex.Replace(listView1.Text, "", "");

                            listView2.Items.Add("__________________________________________________________________");*/

                        }


                    }

                }
            }
            /*TreeNode nodle = treeView1.SelectedNode;
            Recommend n = new Recommend( nodle
                );*/

        }
        void Collection(TreeViewItem node)
        {

         //  richtextbox1. = "";
            string selected = node.Header.ToString();
            driver.Navigate().GoToUrl("https://github.com" + selected);


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

                        try
                        {
                            var linkso = htmlDocument1.DocumentNode.SelectNodes(".//a[@class='js-navigation-open ']").ToList();

                            foreach (var link in linkso)
                            {

                                string href = link.GetAttributeValue("href", string.Empty);
                                // richTextBox2.AppendText("-----------------------------\n\n\n");
                                //array(href);
                             //   TreeNode note = new TreeNode(href);
                             //   treeView1.SelectedNode = node;
                              //  treeView1.SelectedNode.Nodes.Add(note);
                                TreeViewItem nodeo = new TreeViewItem();
                                nodeo.Header = href;
                                treeview1.Items.Add(nodeo);
                                try
                                {
                                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
                                    con.Open();
                                    SqlCommand cmd = con.CreateCommand();
                                    cmd.CommandType = System.Data.CommandType.Text;


                                    // MessageBox.Show("YOU SELECTED THIS BEFORE", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                    //cmd.CommandText = "insert into Codehub (URL) values('" + note.Text+"')";
                                    cmd.CommandText = "insert into system(link,star,watches,query,Source,Language) values('" + href + "','" + watches.InnerText + "','" + folk.InnerText + "','"+Query.Text+"','"+Source.Text+"','"+Language.Text+"')";
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);

                                }
                                //con.Close();


                              //  collection2(nodeo);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);

                        }
                    }

                }

              //  treeView1.Font = new Font("calibiri", 10);
              //  richTextBox1.Font = new Font("Georgia", 10);
                //listView2.BackColor = Color.Blue;
                //     string selectedo = treeView1.SelectedNode.Text;
                // MessageBox.Show(selectedo);
            }
           // richTextBox1.AppendText("\n\n\n");

        }

         /* private void collection2(TreeViewItem note)

          {

             // richTextBox1.Text = "";
              string selected = note.Header.ToString();
              driver.Navigate().GoToUrl("https://github.com" + selected);


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

                          try
                          {
                              var linkso = htmlDocument1.DocumentNode.SelectNodes(".//a[@class='js-navigation-open ']").ToList();

                              foreach (var link in linkso)
                              {

                                  string href = link.GetAttributeValue("href", string.Empty);
                                // richTextBox2.AppendText("-----------------------------\n\n\n");
                                //array(href);
                                TreeViewItem nodeoi = new TreeViewItem();
                                nodeoi.Header = href;
                                treeview1.Items.Add(nodeoi);

                                try
                                  {
                                      SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
                                      con.Open();
                                      SqlCommand cmd = con.CreateCommand();
                                      cmd.CommandType = System.Data.CommandType.Text;


                                    // MessageBox.Show("YOU SELECTED THIS BEFORE", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                    //cmd.CommandText = "insert into Codehub (URL) values('" + note.Text+"')";
                                    cmd.CommandText = "insert into system(link,star,watches,query,Source,Language) values('" + href + "','" + watches.InnerText + "','" + folk.InnerText + "','" + Query.Text + "','" + Source.Text + "','" + Language.Text + "')";
                                    cmd.ExecuteNonQuery();
                                      con.Close();
                                  }
                                  catch (Exception ex)
                                  {
                                   MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                                }
                                //con.Close();


                                //collection2(note);
                            }
                          }
                          catch (Exception ex)
                          {
                           // MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }

                  }

                //  treeView1.Font = new Font("calibiri", 10);
                //  richTextBox1.Font = new Font("Georgia", 10);
                  //listView2.BackColor = Color.Blue;
                  //     string selectedo = treeView1.SelectedNode.Text;
                  // MessageBox.Show(selectedo);
              }
           //   richTextBox1.AppendText("\n\n\n");

          }*/
        public void Open_Browser()



        {


            string search = Query.Text;

            string language = Language.Text;

            if (Source.Text=="Github")

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
                     var options = new ChromeOptions();
                    options.AddArgument("headless");
                    driver = new ChromeDriver(driverService);
                    driver.Navigate().GoToUrl("https://github.com/search?l=" + language + "&q=" + searchString + "&type=" + "Repositories");

                    //webBrowser1.Navigate("https://github.com/search?l=" + language + "&q=" + searchString + "&type=" + "Repositories");

                }

            }
            else if (Source.Text=="Geeks_For_Geeks")
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
                    var searchString = search;
                    searchString = searchString.Replace(" ", "+");
                    var driverService = ChromeDriverService.CreateDefaultService();
                    driverService.HideCommandPromptWindow = true;
                   var options = new ChromeOptions();
                    options.AddArgument("headless");
                    driver = new ChromeDriver(driverService,options);
                    driver.Navigate().GoToUrl("https://www.geeksforgeeks.org/?s=" + searchString + "+in+" + language);
                    //  webBrowser1.Navigate("https://www.geeksforgeeks.org/?s=" + search + "in" + language);

                }
            }
            else if (Source.Text == "Programiz")
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

                    var searchString = search;
                    searchString = searchString.Replace(" ", "+");
                    var driverService = ChromeDriverService.CreateDefaultService();
                    driverService.HideCommandPromptWindow = true;
                   //var options = new ChromeOptions();
                   // options.AddArgument("headless");
                    driver = new ChromeDriver(driverService);
                    driver.Navigate().GoToUrl("https://www.programiz.com/search/" + searchString + " " + "in" + " " + language);
                    //webBrowser1.Navigate("https://www.programiz.com/search/" + search + " " + "in" + " " + language);
                }

            }
            if (treeview1.Items.Count > 0)
            {
                driver.Close();
            }
        }
    }
}
