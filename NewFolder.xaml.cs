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

namespace Ice云盘
{
    /// <summary>
    /// NewFolder.xaml 的交互逻辑
    /// </summary>
    public partial class NewFolder : Window
    {
        public NewFolder()
        {
            
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if(this.foldername.Text.Length!=0)
                this.DialogResult = true;
            else
            {
                this.Close();
            }
        }
    }
}
