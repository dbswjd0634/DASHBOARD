using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dashboard3_;
using System.Data.SQLite;
namespace dashboard3_수정
{
    class Device
    {
        public const int NOTERROR = 0;
        public const int ERROR = 1;
        

        private string ip;
        private string id;
        private string pw;
        private string mac;
        private string subn;
        private int status = 0;
        private List<Camera> CameraList = new List<Camera>();
        /// <summary>
        ///device 여러개 불러올때 사용
        /// </summary>
        public Device(SQLiteDataReader rdr)
        {
            ip = rdr["ip"].ToString();
            id = rdr["id"].ToString();
            pw = rdr["pw"].ToString();
            mac = rdr["mac"].ToString();
            subn = rdr["subn"].ToString();
        }
        /// <summary>
        /// 특정 device 가져오기
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="id"></param>
        /// <param name="pw"></param>
        /// <param name="mac"></param>
        /// <param name="subn"></param>
        public Device(string ip,string id,string pw,string mac,string subn)
        {
            this.ip = ip;
            this.id = id;
            this.pw = pw;
            this.mac = mac;
            this.subn = subn;
        }
        /// <summary>
        /// 해당 Device에 포함되는 카메라를 디바이스에 속한 카메라리스트에 넣어준다.
        /// </summary>
        /// <param name="camera"></param>
        public void Insert_Camera(Camera camera)
        {
            CameraList.Add(camera);
        }
        public int CameraNUM()
        {
            return CameraList.Count();
        }
        /// <summary>
        /// 해당 카메라 리스트 가져오기
        /// </summary>
        /// <returns></returns>
        public List<Camera> GetCameraList()
        {
            return CameraList;
        }
        /// <summary>
        /// 디바이스에서 CameraName과 같은 name을 가진 카메라들 가져오기
        /// </summary>
        /// <param name="CameraName"></param>
        /// <returns></returns>
        public List<Camera> GetSelectedCameraList(string CameraName)
        {
            List<Camera> SelectedCameraList = new List<Camera>();
            for(int i = 0; CameraList.Count() > i; i++)
            {
                bool stringExists = CameraList[i].NAME.Contains(CameraName);
                if (stringExists == true)
                {
                    SelectedCameraList.Add(CameraList[i]);
                }
            }
            return SelectedCameraList;
        }

        


        /// <summary>
        /// MAC 가져오기
        /// </summary>
        public string MAC
        {
            get { return mac; }
            set { mac = value; }
        }
        public string DEVICEIP
        {
            get
            {
                return ip;
            }
            set
            {
                ip = value;
            }
        }
        public int STATUS
        {
            get
            {
                return status;
            }
            set
            {
                if(this.status >= 0 || this.status <= 1)
                {
                    this.status = value;
                }
                else
                {
                    this.status = 0;
                }
            }
        }
    }
}
