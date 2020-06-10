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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace CODEHUB
{
    /// <summary>
    /// Interaction logic for StarRating.xaml
    /// </summary>
    public partial class StarRating : UserControl
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Rating", typeof(int), typeof(StarRating),
           new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(RatingChanged)));

        private int _max = 5;

        public int Value
        {
            get
            {
                return (int)GetValue(ValueProperty);
            }
            set
            {
                if (value < 0)
                {
                    SetValue(ValueProperty, 0);
                }
                else if (value > _max)
                {
                    SetValue(ValueProperty, _max);
                }
                else
                {
                    SetValue(ValueProperty, value);
                    
                }
            }
        }

        private static void RatingChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            StarRating item = sender as StarRating;
            int newval = (int)e.NewValue;
            UIElementCollection childs = ((Grid)(item.Content)).Children;

            ToggleButton button = null;

            for (int i = 0; i < newval; i++)
            {
                button = childs[i] as ToggleButton;
                if (button != null)
                    button.IsChecked = true;
            }

            for (int i = newval; i < childs.Count; i++)
            {
                button = childs[i] as ToggleButton;
                if (button != null)
                    button.IsChecked = false;
            }

        }

        private void ClickEventHandler(object sender, RoutedEventArgs args)
        {
            if (password.Text == "")
            {
                MessageBox.Show("Enter Password First","Notify!",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
            else
            {
                ToggleButton button = sender as ToggleButton;
                int newvalue = int.Parse(button.Tag.ToString());
                Value = newvalue;
            }
        }
        public StarRating()
        {
            InitializeComponent();
           /* SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

            con.Open();
            SqlCommand cnd = con.CreateCommand();
            cnd.CommandType = System.Data.CommandType.Text;
            //   cnd.CommandText = "select * from Codehub";
            cnd.CommandText = "SELECT * FROM Report";
            try
            {
                SqlDataReader dr = cnd.ExecuteReader();
                while (dr.Read())
                {

                    password.AppendText(dr["Password"].ToString());

                  /*  textBox1.AppendText(dr["Name"].ToString());
                    textBox2.AppendText(dr["Query"].ToString());
                    textBox3.AppendText(dr["Language"].ToString());
                    textBox4.AppendText(dr["Source"].ToString());
                    //textBox5.AppendText(dr["Query"].ToString());
                    textBox5.AppendText(dr["Search"].ToString());
                    textBox6.AppendText(dr["Date"].ToString());
                    textBox7.AppendText(dr["Time"].ToString());
                    textBox10.AppendText(dr["Email"].ToString());
                    listBox1.Items.Add(dr["Recommended"].ToString());
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
*/
        }

        private void rate_Click(object sender, RoutedEventArgs e)
        {
            
            SqlConnection coni = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
            coni.Open();
            SqlCommand cndi = coni.CreateCommand();
            cndi.CommandType = System.Data.CommandType.Text;
            // cnd.CommandText = "SELECT URL FROM Codehub WHERE id = 1";
            try
            {
                cndi.CommandText = "select * from Report where Password='" + password.Text + "' update Report set Remarks ='" + Value + "' where Password='" + password.Text + "'";

                //   cndi.CommandText = "insert into Remarks values('" + radioButton1.Text + "')";
                cndi.ExecuteNonQuery();
                coni.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            coni.Close();
            MessageBox.Show("Successfully Submit Your Response!");
        }
    }
}
