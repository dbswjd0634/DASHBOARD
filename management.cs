
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dashboard3_;
using System.Data.SQLite;
using System.Diagnostics;

namespace dashboard3_수정
{

    class management
    {
        private List<Camera> CameraList = new List<Camera>();
        private List<Device> DeviceList = new List<Device>();
        private int closeWindows = 0;

        private static management _instance = new management();

        protected management()
        {

        }
        public static management instance()
        {
            if (_instance == null)
            {
                _instance = new management();
            }
            return _instance;
        }
        /// <summary>
        /// cameralist가져오기
        /// </summary>
        /// <returns></returns>
        public List<Camera> GetCameraList()
        {
            return CameraList;
        }
        /// <summary>
        /// device List 가져오기
        /// </summary>
        /// <returns></returns>
        public List<Device> GetDeiviceList()
        {
            return DeviceList;
        }
       
        /// <summary>
        /// sqlite에서 불러운 db에서 Device테이블에 속한 디바이스 정보 불러오기
        /// </summary>
        public void AddToDevice()
        {
            SQLiteConnection conn = null;
            conn = new SQLiteConnection(@"Data Source=C:\Users\34937\Desktop\Dash\test.db;Version=3;");
            conn.Open();

            string sql = "select * from Device";

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Device device = new Device(rdr);
                DeviceList.Add(device);
            }

        }
        /// <summary>
        /// sqlite에서 불러운 db에서 Camera 테이블에 속한 카메라 정보 불러오기
        /// </summary>
        public void AddToCamera()
        {
            SQLiteConnection conn = null;
            conn = new SQLiteConnection(@"Data Source=C:\Users\34937\Desktop\Dash.db;Version=3;");
            conn.Open();

            string sql = "select * from Camera";

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Camera camera = new Camera(rdr);
                for(int i = 0; DeviceList.Count() > i; i++)//mac같은거 device에 camera를 cameralist에 넣어주기 
                {
                    if (DeviceList[i].MAC == camera.DEVICEMAC)
                        DeviceList[i].Insert_Camera(camera);

                }
                CameraList.Add(camera);
            }

        }
        /// <summary>
        /// 카메라 리스트에 특정 카메라 넣어주기
        /// </summary>
        /// <param name="camera"></param>
        public void AddToCamera(Camera camera)
        {
            CameraList.Add(camera);
        }
        /// <summary>
        /// 디바이스리스트에 특정 디바이스 넣어주기
        /// </summary>
        /// <param name="NewDevice"></param>
        public void AddToDevice(Device NewDevice)
        {
            DeviceList.Add(NewDevice);
        }

        /// <summary>
        /// device 수 가져오기
        /// </summary>
        /// <returns></returns>
        public int CountDevice()
        {
            return DeviceList.Count();
        }
        /// <summary>
        /// camera 수 가져오기
        /// </summary>
        /// <returns></returns>
        public int CountCamera()
        {
            return CameraList.Count();
        }
        /// <summary>
        ///  MAinwindow 시
        /// </summary>
        public int CloseWindows
        {
            get
            {
                return this.closeWindows;
            }
            set
            {
                this.closeWindows = value;
            }
        }
    }
}
