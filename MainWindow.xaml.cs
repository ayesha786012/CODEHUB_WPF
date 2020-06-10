using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GC.Collect(); GC.WaitForPendingFinalizers();
            Thread.Sleep(1000);
            pb_LengthyTaskProgress.Value = 0;

            Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(50);
                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        pb_LengthyTaskProgress.Value = i;
                        //  lbl_CountDownTimer.Text = i.ToString();
                        if (pb_LengthyTaskProgress.Value == 100)
                        {

                            Welcome welcome = new Welcome();
                            welcome.Owner = this;
                            this.Hide();
                            welcome.ShowDialog();
                            Close();
                        }
                    });
                }
            });
        }
    }
}
