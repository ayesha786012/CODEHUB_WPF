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

namespace CODEHUB
{
    /// <summary>
    /// Interaction logic for Service.xaml
    /// </summary>
    public partial class Service : UserControl
    {
        public Service()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CODEHUB.SOURCEDataSet sOURCEDataSet = ((CODEHUB.SOURCEDataSet)(this.FindResource("sOURCEDataSet")));
            // Load data into the table Report. You can modify this code as needed.
            CODEHUB.SOURCEDataSetTableAdapters.ReportTableAdapter sOURCEDataSetReportTableAdapter = new CODEHUB.SOURCEDataSetTableAdapters.ReportTableAdapter();
            sOURCEDataSetReportTableAdapter.Fill(sOURCEDataSet.Report);
            System.Windows.Data.CollectionViewSource reportViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("reportViewSource")));
            reportViewSource.View.MoveCurrentToFirst();

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
