using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CODEHUB
{
    /// <summary>
    /// Interaction logic for Performance.xaml
    /// </summary>
    public partial class Performance : UserControl
    {
       

        public Performance()
        {
            InitializeComponent();
            //suggestion.Visibility = System.Windows.Visibility.Hidden;
            DataTable dt = new DataTable();
            int n = 5;
            MyWinformChart.Series[0].Points.AddY( n);
            
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True"))
            {
                con.Open();
                try
                {

                    
                    SqlCommand cmd = new SqlCommand("SELECT AVG (Remarks) FROM Report", con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Series sr = new Series();
                    while (reader.Read())
                    {
                        int max = reader.GetInt32(0);
                       
                        if (max > n)
                        {
                           
                            n += 10;
                            MyWinformChart.Series[0].Points.AddY(n);
                            //int avg = (n / max) * 100;
                            int avg = (reader.GetInt32(0) * 10);
                            Label.AppendText(avg.ToString() + "%");

                        }
                        else {
                            n += 10;
                            int avg = (reader.GetInt32(0) * 10);
                            Label.Text=(avg.ToString()+"%");
                            // int n = Conv.reader["Remarks"].ToString();   
                            MyWinformChart.Series[0].Points.AddY(reader.GetInt32(0));
                        MyWinformChart.Series[0].ChartType = SeriesChartType.Pie;
                        MyWinformChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                        MyWinformChart.Legends[0].Enabled = true;
                  }
                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                }

            }

        
            
       

        private void Label_Loaded(object sender, RoutedEventArgs e)

        { 
        
        }

        private void suggestion_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    }
    

