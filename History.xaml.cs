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
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : UserControl
    {
        public History()
        {
            InitializeComponent();
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

            con.Open();
            SqlCommand cnd = con.CreateCommand();
            cnd.CommandType = System.Data.CommandType.Text;
            //   cnd.CommandText = "select * from Codehub";
           
            cnd.CommandText = "SELECT * FROM Report  WHERE Password='" + password.Text + "' ORDER BY Time,Date ASC";
            try
            {
                SqlDataReader dr = cnd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["Recommended"].ToString() == "")
                    {
                        MessageBox.Show("Check your Recommended First And Saved!");
                    }
                    else { 
                    foreach (var item in dr)
                    {
                        TreeViewItem ParentItem = new TreeViewItem();
                        ParentItem.Header = dr["Date"].ToString();
                        treeview1.Items.Add(ParentItem);
                        //  
                        TreeViewItem Child1Item = new TreeViewItem();
                        Child1Item.Header = dr["Time"].ToString();
                        ParentItem.Items.Add(Child1Item);
                        TreeViewItem Child1Item2 = new TreeViewItem();
                        Child1Item2.Header = dr["Source"].ToString();
                        Child1Item.Items.Add(Child1Item2);
                        TreeViewItem Child1Item3 = new TreeViewItem();
                        Child1Item3.Header = dr["Query"].ToString();
                        Child1Item2.Items.Add(Child1Item3);
                        TreeViewItem Child1Item4 = new TreeViewItem();
                        Child1Item4.Header = "Recommended_Results";
                        Child1Item3.Items.Add(Child1Item4);
                        TreeViewItem Child1Item5 = new TreeViewItem();
                        Child1Item5.Header = dr["Recommended"].ToString();
                        Child1Item4.Items.Add(Child1Item5);

                    }
                }
                  /*  textBox1.AppendText(dr["Name"].ToString());
                    textBox2.AppendText(dr["Query"].ToString());
                    textBox3.AppendText(dr["Language"].ToString());
                    textBox4.AppendText(dr["Source"].ToString());
                    //textBox5.AppendText(dr["Query"].ToString());
                    textBox5.AppendText(dr["Search"].ToString());
                    textBox6.AppendText(dr["Date"].ToString());
                    textBox7.AppendText(dr["Time"].ToString());
                    textBox10.AppendText(dr["Email"].ToString());
                    listBox1.Items.Add(dr["Recommended"].ToString());*/
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
