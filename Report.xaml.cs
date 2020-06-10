using Microsoft.Win32;
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
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : UserControl
    {
        public Report()
        {
            InitializeComponent();
            if (Recommended.Items.Count == 0)
            {
                MessageBox.Show("If You Want To View the Complete Report Then you neeed to go Recommended Tab to Save your Recommended Results", "Notify", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                MessageBox.Show("Check your Recommended First And Saved!");
            }
             
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

            con.Open();
            SqlCommand cnd = con.CreateCommand();
            cnd.CommandType = System.Data.CommandType.Text;
            //   cnd.CommandText = "select * from Codehub";
            cnd.CommandText = "SELECT * FROM Current_User_Data ";
            try
            {
                SqlDataReader dr = cnd.ExecuteReader();
                while (dr.Read())
                {



                    Name.AppendText(dr["Name"].ToString());
                    query.AppendText(dr["Query"].ToString());
                    Language.AppendText(dr["Language"].ToString());
                    source.AppendText(dr["Source"].ToString());
                    Password.AppendText(dr["Password"].ToString());
                    search.AppendText(dr["Search"].ToString());
                    Date.AppendText(dr["Date"].ToString());
                    Time.AppendText(dr["Time"].ToString());
                    Email.AppendText(dr["Email"].ToString());

                    Recommended.Items.Add(dr["Recommended"].ToString());
                    ///listview on click
                    /////buttons 
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        
        }
    }
}
