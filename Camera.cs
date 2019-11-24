using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Diagnostics;

namespace dashboard3_
{
    class Camera
    {
        public const int NOTERROR = 0;
        public const int ERROR = 1;

        private string name = string.Empty;
        private string id = string.Empty;
        private string ip = string.Empty;
        private string pwd = string.Empty;
        private int webport = 0;
        private int videoport = 0;
        private string deviceID = string.Empty;
        private string deviceMac = string.Empty;
        private string substeam = string.Empty;
        private int status = 0;
        //videoport
        public int STATUS
        {
            get
            {
                return status;
            }
            set
            {
                if (this.status >= 0 || this.status <= 1)
                {
                    this.status = value;
                }
                else
                {
                    this.status = 0;
                }
            }
        }
        /// <summary>
        /// db에 있는값들 넣어주기
        /// </summary>
        /// <param name="rdr"></param>
        public Camera(SQLiteDataReader rdr) {
            Debug.WriteLine("NAme == > "+ rdr["name"].ToString());
            name = rdr["name"].ToString();
            ip = rdr["ip"].ToString();
            id = rdr["id"].ToString();
            pwd = rdr["pw"].ToString();
            deviceID = rdr["deviceID"].ToString();
            deviceMac = rdr["deviceMac"].ToString();
            substeam = rdr["svbstream"].ToString();
            webport = Convert.ToInt32(rdr["webport"]);
            videoport = Convert.ToInt32(rdr["videoport"]);
        }

        public Camera(string name, string id,string ip, string pw,int webport, int videoport,string deviceID,string deviceMac,string substream)
        {
            this.name = name;
            this.id = id;
            this.ip = ip;
            this.pwd = pw;
            this.webport= webport;

            this.videoport = videoport;
            this.deviceID = deviceID;
            this.deviceMac = deviceMac;
            this.substeam= substream;
        }

        public string NAME
        {
            get { return name; }
            set { name = value; }
        }
        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public string PWD
        {
            get { return pwd; }
            set { pwd = value; }
        }
        public string DEVICEID
        {
            get { return deviceID; }
            set { deviceID = value; }
        }
        public string DEVICEMAC
        {
            get { return deviceMac; }
            set { deviceMac = value; }
        }
        public string SVBSTREAM
        {
            get { return substeam; }
            set { substeam = value; }
        }
        public int WEBPORT
        {
            get { return webport; }
            set { webport = value; }
        }
        public int VIDEOPORT
        {
            get { return videoport; }
            set {
                videoport = value;
            }
        }
    }
}
