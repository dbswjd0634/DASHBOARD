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
using System.Diagnostics;
using System.IO;

namespace dashboard3_수정
{
    /// <summary>
    /// setup.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class setup : Page
    {
        public setup()
        {
            InitializeComponent();
        }
        private SQLiteConnection conn = null;

  
        /// <summary>
        /// device 추가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            conn = new SQLiteConnection(@"Data Source=C:\Users\Endas\Desktop\test.db;Version=3;");
            conn.Open();
       
            String sql = "INSERT INTO Device VALUES ('" + device_ip.Text + "','" + device_id.Text + "','" + device_pw.Text + "','" + device_Mac.Text + "','" + device_subn.Text +"')";
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            int result = command.ExecuteNonQuery();
            management MG = management.instance();
            Device NewDevice = new Device(device_ip.Text ,device_id.Text, device_pw.Text,device_Mac.Text,device_subn.Text);
            MG.AddToDevice(NewDevice);

            conn.Close();
        }

        private void device_svbn_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
