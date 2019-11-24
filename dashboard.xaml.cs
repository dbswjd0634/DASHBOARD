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

namespace dashboard3_수정
{
    /// <summary>
    /// dashboard.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class dashboard : Page
    {
        public dashboard()
        {
            InitializeComponent();
            frame.Source = new Uri("home.xaml", UriKind.Relative);
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {

            SubButton1.Content = FindResource("Play1");
            SubButton2.Content = FindResource("Stop2");
            SubButton3.Content = FindResource("Stop3");
            SubButton4.Content = FindResource("Stop4");
            SubButton5.Content = FindResource("Stop5");
            frame.Source = new Uri("home.xaml", UriKind.Relative);
        }

        private void ssm_Click(object sender, RoutedEventArgs e)
        {
            SubButton2.Content = FindResource("Play2");
            SubButton1.Content = FindResource("Stop1");
            SubButton3.Content = FindResource("Stop3");
            SubButton4.Content = FindResource("Stop4");
            SubButton5.Content = FindResource("Stop5");
            frame.Source = new Uri("ssm.xaml", UriKind.Relative);
        }

        private void CCTV_Click(object sender, RoutedEventArgs e)
        {
            SubButton3.Content = FindResource("Play3");
            SubButton2.Content = FindResource("Stop2");
            SubButton1.Content = FindResource("Stop1");
            SubButton4.Content = FindResource("Stop4");
            SubButton5.Content = FindResource("Stop5");
            frame.Source = new Uri("cctv.xaml", UriKind.Relative);
        }

        private void OS_Click(object sender, RoutedEventArgs e)
        {
            SubButton4.Content = FindResource("Play4");
            SubButton2.Content = FindResource("Stop2");
            SubButton3.Content = FindResource("Stop3");
            SubButton1.Content = FindResource("Stop1");
            SubButton5.Content = FindResource("Stop5");
            frame.Source = new Uri("os.xaml", UriKind.Relative);
        }

        private void fallover_Click(object sender, RoutedEventArgs e)
        {
            SubButton5.Content = FindResource("Play5");
            SubButton2.Content = FindResource("Stop2");
            SubButton3.Content = FindResource("Stop3");
            SubButton4.Content = FindResource("Stop4");
            SubButton1.Content = FindResource("Stop1");
            frame.Source = new Uri("failover.xaml", UriKind.Relative);
        }

        private void frame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
