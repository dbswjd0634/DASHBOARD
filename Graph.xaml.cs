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

using System.Threading;
using System.Diagnostics;
using System.Windows.Threading;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace dashboard3_수정
{
    /// <summary>
    /// graph.xaml에 대한 상호 작용 논리
    /// </summary>
    public class value
    {
        public static int a;
    }
    
    public partial class graph : UserControl
    {
        const int USE = 0;
        const int NOTUSE = 1;
        /*public int SetValue(int num)
        {
            if (num >= 0 && num <= 100) return num;
            else return -1;
        }*/
        int a = 0;
        int ErrorNum=0;
        int AllDevice=0;
        public void setValue(int data)
        {
            a = data;
        }
        public graph()
        {

            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "사용",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(AllDevice-ErrorNum) },
                    DataLabels = true,FontSize=15
                },
                new PieSeries
                {
                    Title = "미사용",
                    Values = new ChartValues<ObservableValue> { new ObservableValue((ErrorNum)) },
                    DataLabels = true,FontSize=15
                }
            };
            DataContext = this;
           
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        public void SetVaule(int errorNum, int allDevice) // 그래프에 할당할 값을 받아옴
        {
            ErrorNum = errorNum;
            AllDevice = allDevice;
            Play();
        }

        private void Play()
        {
            int index = 0;
            foreach (var series in SeriesCollection)
            {
                if (index == USE)
                {
                    foreach (var observable in series.Values.Cast<ObservableValue>())
                    {
                        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                        {
                            observable.Value = AllDevice-ErrorNum; // 정상 실행 중인 장치 값 저장
                          
                            int per = (AllDevice-ErrorNum) * 100 / AllDevice;
                            
                            gName.Content = per.ToString() + "%";
                        }));
                    }
                }
                else
                {
                    foreach (var observable in series.Values.Cast<ObservableValue>())
                    {
                        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                        {
                            observable.Value = ErrorNum; // 비정상 실행 중인 장치 값 저장
                        }));
                    }
                }
                index++;
            }
        }
        public SeriesCollection SeriesCollection { get; set; }

        private void Chart_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
