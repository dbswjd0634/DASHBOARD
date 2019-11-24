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
using System.Data.SQLite;
using dashboard3_;


namespace dashboard3_수정
{

   
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        double orginalWidth, originalHeight;
        ScaleTransform scale = new ScaleTransform();
        management MG;
        public MainWindow()
        {
            InitializeComponent();
            //디비 연동해서 디바이스 카메라 초기에 리스트에 담아두기
            MG = management.instance();
            MG.AddToDevice();
            MG.AddToCamera();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            this.MouseLeftButtonDown += Window1_MouseLeftButtonDown;

            //       SQLiteConnection conn = null;
            //         conn = new SQLiteConnection(@"Data Source=C:\Users\Endas\Desktop\test.db;Version=3;");
            //        conn.Open();


            frame.Source = new Uri("dashboard.xaml", UriKind.Relative);
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);

            this.Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            MG.CloseWindows = 1;
        }

        void Window1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // window 창 이동
        {
            this.DragMove();
        }
        private void dashboard_Click(object sender, RoutedEventArgs e)
        {
            frame.Source = new Uri("dashboard.xaml", UriKind.Relative);

            if (dashboardButton.Content == FindResource("Stop1"))
            {
                dashboardButton.Content = FindResource("Play1");
                logButton.Content = FindResource("Stop2");
                setupButton.Content = FindResource("Stop3");
            }
        }

        private void log_Click(object sender, RoutedEventArgs e)
        {
            frame.Source = new Uri("log.xaml", UriKind.Relative);
            if (logButton.Content == FindResource("Stop2"))
            {
                logButton.Content = FindResource("Play2");
                dashboardButton.Content = FindResource("Stop1");
                setupButton.Content = FindResource("Stop3");
            }
        }

        private void setup_Click(object sender, RoutedEventArgs e)
        {

            frame.Source = new Uri("setup.xaml", UriKind.Relative);
            if (setupButton.Content == FindResource("Stop3"))
            {
                setupButton.Content = FindResource("Play3");
                logButton.Content = FindResource("Stop2");
                dashboardButton.Content = FindResource("Stop1");
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            orginalWidth = this.Width;
            originalHeight = this.Height;

            if (this.WindowState == WindowState.Maximized)
            {
                ChangeSize(this.ActualWidth, this.ActualHeight);
            }
            this.SizeChanged += new SizeChangedEventHandler(Window1_SizeChanged);
        }

        void Window1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ChangeSize(e.NewSize.Width, e.NewSize.Height);
        }

        private void ChangeSize(double width, double height)
        {
            scale.ScaleX = width / orginalWidth;
            scale.ScaleY = height / originalHeight;

            FrameworkElement rootElement = this.Content as FrameworkElement;
            rootElement.LayoutTransform = scale;
        }
        private void Maximize_Click(object sender, RoutedEventArgs e) // 최대, 최소, 종료 버튼
        {
            this.WindowState = (this.WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Mimimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                rectMax.Visibility = Visibility.Hidden;
                rectMin.Visibility = Visibility.Visible;
            }
            else
            {
                rectMax.Visibility = Visibility.Visible;
                rectMin.Visibility = Visibility.Hidden;
            }
        }
    }
}