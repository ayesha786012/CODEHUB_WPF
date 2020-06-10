using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ADMINFLATE.xaml
    /// </summary>
    public partial class ADMINFLATE : Window
    {
        public ADMINFLATE()
        {
            InitializeComponent();
            //ListViewMenu.SelectedIndex = ;
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
                    GridPrincipal.Children.Add(new Service());

                    break;
                case 1:
                    //if(index)
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Performance());
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new AdminHistory());
                    break;
                case 3:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new About());
                    break;
                case 4:
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

        private void ListViewMenu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                int n = 1;
                GridPrincipal.Children.Clear();
            //    GridPrincipal.Children.Add(new Crawling(Query.Text, Language.Text, Source.Text));
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
