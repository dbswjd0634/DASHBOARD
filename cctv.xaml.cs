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
    /// cctv.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class cctv : Page
    {
        List<Camera> CameraCollection = new List<Camera>();
        Device SelectedDevice = null;
        List<Device> DeviceCollection = null;
        string DeviceIP=null;
        List<Camera> AllCameraList = new List<Camera>();
        public cctv()
        {
            InitializeComponent();

            Camera_Connect();
            management MG = management.instance();
            DeviceCollection = MG.GetDeiviceList();

              DeviceBox.Items.Add("전체보기");
            for (int i = 0; DeviceCollection.Count() > i; i++)
            {
                DeviceBox.Items.Add(DeviceCollection[i].DEVICEIP);
            }

            DeviceBox.SelectedItem = "전체보기";

        }



        /// <summary>
        /// Camera와 연동
        /// camera 정보를 가져와 Camera 클래스에 넣어주고 CameraCollection에 추가해준다.
        /// </summary>
        public void Camera_Connect()
        {
            management MG = management.instance();

            AllCameraList = MG.GetCameraList();
            listView.ItemsSource = AllCameraList;

            /* SQLiteConnection conn = null;
             conn = new SQLiteConnection(@"Data Source=C:\Users\Endas\Desktop\test.db;Version=3;");
             conn.Open();

             string sql = "select * from Camera";

             SQLiteCommand cmd = new SQLiteCommand(sql, conn);
             SQLiteDataReader rdr = cmd.ExecuteReader();
             while (rdr.Read())
             {
                 Camera camera=new Camera(rdr);
                 CameraCollection.Add(camera);
             }
             listView.ItemsSource = CameraCollection;
             //  rdr.Close();
             //    conn.Close();*/
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DeviceBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        /// <summary>
        /// 해당 디바이스에 해당 카메라 리스트에 보여주기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Find_Click(object sender, RoutedEventArgs e)
        {
            DeviceIP = DeviceBox.SelectedItem.ToString();
          
            if (DeviceIP == "전체보기") //다시 전체 리스트 보여주기
            {
                if (CameraText.Text=="") //해당 다이스 모든 카메라 리스트 보여주기
            {
                    listView.ItemsSource = AllCameraList;
                    return;
            }
                List<Camera> cameralist = new List<Camera>();
                for (int i = 0; DeviceCollection.Count() > i; i++)
                {
                    for (int j = 0; DeviceCollection[i].GetSelectedCameraList(CameraText.Text).Count() > j; j++)
                    {
                        cameralist.Add(DeviceCollection[i].GetSelectedCameraList(CameraText.Text)[j]);
                    }
                }
                listView.ItemsSource = cameralist;
               
                return;
            }


            for (int i = 0; DeviceCollection.Count() > i; i++)
            {
                if (DeviceCollection[i].DEVICEIP == DeviceIP)
                {
                    SelectedDevice = DeviceCollection[i];
                    break;
                }
            }

            if (CameraText.Text == "") //해당 다이스 모든 카메라 리스트 보여주기
            {
                listView.ItemsSource = SelectedDevice.GetCameraList();
            }
            else
            {
                
                    listView.ItemsSource = SelectedDevice.GetSelectedCameraList(CameraText.Text);
            
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window win2 = new TestWindow();
            win2.Show();
        }
        private void WEB_Click(object sender, RoutedEventArgs e)
        {
            Window win2 = new WebWindow();
            win2.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
