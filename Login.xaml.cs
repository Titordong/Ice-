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
using System.Windows.Shapes;
using LitJson;
namespace Ice云盘
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public int logid { get; set; }
        public Login()
        {
           
            InitializeComponent();
            
           /* ImageBrush b = new ImageBrush();
            b.ImageSource = new BitmapImage(new Uri("pack://application:,,,/bg.jpg"));
            b.Stretch = Stretch.Fill;
            this.Background = b;*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }

        private void BTlogin_Click(object sender, RoutedEventArgs e)
        {
            string name = acount.Text;
            string secret = password.Password;
            string str = string.Format("name={0}&secret={1}", name, secret);
            string url = "https://ice.titordong.cn/Login?" + str;
            JsonData data = Util.GetHttpResponse(url, 6000);
            JsonData t = data["flag"];
            int x = int.Parse(t.ToString());
            if (x == 1)
            {
                MessageBox.Show("登录成功");
                this.logid = int.Parse(data["id"].ToString());
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("登录失败");
            }
        }
    }
}
