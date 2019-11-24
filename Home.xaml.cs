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
using dashboard3_;
using System.Threading;
using System.IO;

namespace dashboard3_수정
{
    /// <summary>
    /// home.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class home : Page
    {
        management mg;
        Object obj = new object();
        public home()
        {
            
            InitializeComponent();
            mg = management.instance();
            int CameraNum = mg.CountCamera();
            int DeviceNum = mg.CountDevice();
   //         SaveOp.setValue(DeviceNum);
   //         CCTV.setValue(CameraNum);

            Thread tt = new Thread(ThreadDeviceCheck);
            tt.Start();
            Thread t = new Thread(ThreadDevice);
            t.Start();
            Thread CCTV_TT = new Thread(ThreadCCTVCheck);
            CCTV_TT.Start();
            Thread CCTV_T = new Thread(ThreadCCTV);
            CCTV_T.Start();
        }
        private void ThreadDeviceCheck()
        {
            
            while (mg.CloseWindows == 0)
            { 
                Random rand = new Random();
                int number = rand.Next(mg.CountDevice());
                int index = 0;
                lock(obj)
                {
                    foreach (Device d in mg.GetDeiviceList())
                    {
                        if (index < number)
                        {
                            d.STATUS = Device.ERROR;
                        }
                        else
                        {
                            d.STATUS = Device.NOTERROR;
                        }
                        index++;
                    }
                }
                
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// 영상저장장치 그래프를 위한 쓰레드
        /// </summary>
        private void ThreadDevice()
        {
           
            while (mg.CloseWindows == 0)
            {
                int errorCount = 0;
                lock (obj)
                {
                    foreach (Device d in mg.GetDeiviceList())
                    {
                        if (d.STATUS == Device.ERROR)
                        {
                            errorCount++;
                        }
                    }
                }
         
                SaveOp.SetVaule(errorCount, mg.CountDevice());
                Thread.Sleep(1000);
            }
        }

        
        private void ThreadCCTVCheck()
        {

            while (mg.CloseWindows == 0)
            {
                Random rand = new Random();
                int number = rand.Next(mg.CountCamera());
                int index = 0;
                lock (obj)
                {
                    foreach (Camera c in mg.GetCameraList())
                    {
                        if (index < number)
                        {
                            c.STATUS = Device.ERROR;
                        }
                        else
                        {
                            c.STATUS = Device.NOTERROR;
                        }
                        index++;
                    }
                }

                Thread.Sleep(1000);
            }

        }
        /// <summary>
        /// CCTV 장치 그래프를 위한 쓰레드
        /// </summary>
        private void ThreadCCTV()
        {

            while (mg.CloseWindows == 0)
            {
                int errorCount = 0;
                lock (obj)
                {
                    foreach (Camera c in mg.GetCameraList())
                    {
                        if (c.STATUS == Camera.ERROR)
                        {
                            errorCount++;
                        }
                    }
                }
                CCTV.SetVaule(errorCount, mg.CountCamera());
                Thread.Sleep(1000);
            }
        }
        private void graph_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
