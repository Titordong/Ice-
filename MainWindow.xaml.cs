using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LitJson;
using Microsoft.Win32;
namespace Ice云盘
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public int logid { get; set; }
        public MainWindow()
        {
            // Register register = new Register();
            //register.ShowDialog();
            // this.Close();
              Login login = new Login();
              login.ShowDialog();
              if (login.DialogResult == false)
              {
                  this.Close();
              }
            this.logid = login.logid;
            /*  ListBoxItem listBoxItem = new ListBoxItem();
              Thickness tick = new Thickness();
              tick.Top = 50;
              //将样式添加给这个ListBoxItem
              listBoxItem.BorderThickness = tick;
              listbox.Items.Add(listBoxItem);*/
            // mytext.Text = "1111";
            this.Loaded += MainWindow_Loaded1;
            this.Visibility = Visibility;
            InitializeComponent();
            
        }

        private void MainWindow_Loaded1(object sender, RoutedEventArgs e)
        {
            /*ListBoxItem listBoxItem = new ListBoxItem();
             Thickness tick = new Thickness();
             tick.Top = 50;
             //将样式添加给这个ListBoxItem
             listBoxItem.BorderThickness = tick;
            mylist.Items.Add(listBoxItem);*/
            string url = Util.host + "Getfolder?" + string.Format("id={0}&curd={1}", logid, "");
            JsonData data = Util.GetHttpResponse(url, 6000);
            List<FileListItem> list = new List<FileListItem>();
            data = data["mlist"];           
            foreach(JsonData t in data)
            {
                FileListItem fileListItem = new FileListItem();
                fileListItem.type =(FileListItem.Filetype) int.Parse(t["type"].ToString());
                fileListItem.name = t["name"].ToString();
                list.Add(fileListItem);
            }
            mylist.ItemsSource = list;

        }
        /// <summary>
        /// Http上传文件
        /// </summary>

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择文件上传";
            if (openFileDialog.ShowDialog() == false)
            {
                return;
            }
            string textfile = openFileDialog.FileName;
            // WebClient webClient = new WebClient();
            //webClient.UploadFile("https://ice.titordong.cn/UploadFile","POST",@""+textfile+"");
            JsonData data=Util.HttpUploadFile("https://ice.titordong.cn/UploadFile?age=1", textfile);
            string flag = data["flag"].ToString();
            if (flag == "1")
            {
                string url = data["url"].ToString();
                MyEditBox myEditBox = new MyEditBox();
                myEditBox.ed1.Text = url;
                myEditBox.ShowDialog();
            }
           
            
        }

        private void CreateFolder_Click(object sender, RoutedEventArgs e)
        {
            NewFolder newFolder = new NewFolder();
            newFolder.ShowDialog();
            if (newFolder.DialogResult == true)
            {
                // MessageBox.Show(newFolder.foldername.Text);
                string url = Util.host + "Create_fd?" + string.Format("id={0}&curd={1}&fname={2}", logid, "", newFolder.foldername.Text);
                JsonData data = Util.GetHttpResponse(url, 6000);
                string flag = data["flag"].ToString();
                string str= (flag == "0"? "创建失败" : "创建成功");
                MessageBox.Show(str);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            mytext.Text = "这个还没写";
        }

        private void Flash_Click(object sender, RoutedEventArgs e)
        {
            string url = Util.host + "Getfolder?" + string.Format("id={0}&curd={1}", logid, "");
            JsonData data = Util.GetHttpResponse(url, 6000);
            List<FileListItem> list = new List<FileListItem>();
            data = data["mlist"];
            foreach (JsonData t in data)
            {
                FileListItem fileListItem = new FileListItem();
                fileListItem.type = (FileListItem.Filetype)int.Parse(t["type"].ToString());
                fileListItem.name = t["name"].ToString();
                list.Add(fileListItem);
            }
            mylist.ItemsSource = list;
        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择文件上传";
            if (openFileDialog.ShowDialog() == false)
            {
                return;
            }
            string textfile = openFileDialog.FileName;
            // WebClient webClient = new WebClient();
            //webClient.UploadFile("https://ice.titordong.cn/UploadFile","POST",@""+textfile+"");
            JsonData data = Util.HttpUploadFile(string.Format("https://ice.titordong.cn/UploadFile?id={0}",logid), textfile);
            string flag = data["flag"].ToString();
            if (flag == "1")
            {
                string url = data["url"].ToString();
               /* MyEditBox myEditBox = new MyEditBox();
                myEditBox.ed1.Text = url;*/
                MessageBox.Show("上传成功");
              //  myEditBox.ShowDialog();
            }
        }
    }
}

 


