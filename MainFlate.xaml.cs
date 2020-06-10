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

namespace CODEHUB
{
    /// <summary>
    /// Interaction logic for MainFlate.xaml
    /// </summary>
    public partial class MainFlate : Window
    {
        public MainFlate(string Q, string L, string S)
        {
            InitializeComponent();
            Query.Text = Q;
            Language.Text = L;
            Source.Text = S;
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
           
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            int index = ListViewMenu.SelectedIndex;
           // Array[]int= new Array[//];
            MoveCursorMenu(index);

            switch (index)
            {
                
                
                   
                case 0:

                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Crawling(Query.Text, Language.Text, Source.Text));

                    break;
                case 1:
                    //if(index)
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Filter(Query.Text,Language.Text,Source.Text));
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Ranking(Query.Text, Language.Text, Source.Text));
                    break;
                case 3:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Recommendation(Query.Text, Language.Text, Source.Text));
                    break;
                case 4:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Report());
                    break;
                case 5:
                     GridPrincipal.Children.Clear();
                     GridPrincipal.Children.Add(new History());
                     break;
                 case 6:
                  GridPrincipal.Children.Clear();
                     GridPrincipal.Children.Add(new StarRating());
                     break;
                    
                case 7:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new About());
                    break;
                case 8:
                    Welcome welcome = new Welcome();
                    welcome.Owner = this;
                    this.Hide();
                    welcome.ShowDialog();
                    break;
                default:
                    break;
            }
        }
        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

            DragMove();
        }

        private void ListViewMenu_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListViewMenu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            { int n = 1;
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new Crawling(Query.Text, Language.Text, Source.Text));
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ////help user control
        }
    }
}
