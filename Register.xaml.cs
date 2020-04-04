using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Register.xaml 的交互逻辑
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Bregister_Click(object sender, RoutedEventArgs e)
        {
          
            string name = TBname.Text;
            string secret = TBsecret1.Text;
            if (name.Length == 0 || secret.Length == 0)
            {
                MessageBox.Show("请输入完整账号密码");
                return;
            }
            MyBar.Visibility = Visibility;
            string str = string.Format("name={0}&secret={1}&regtime={2}", name, secret,DateTime.Now.ToString());
            string url = "https://ice.titordong.cn/Register?" + str;
            JsonData data = Util.GetHttpResponse(url, 6000);
            JsonData t = data["flag"];
            int x= int.Parse(t.ToString());
            if(x==0)
                MessageBox.Show("注册失败");
            else
            {
                MessageBox.Show("注册成功");
                this.Close();
            }
        }
    }
}
