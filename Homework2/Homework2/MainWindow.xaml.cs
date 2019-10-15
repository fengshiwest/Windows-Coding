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

using Microsoft.Win32;

namespace Homework2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //选择文件目录
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "文本文件|*.txt";
            if (dialog.ShowDialog() == true)
            {
                if (listBox1.Items.Contains(System.IO.Path.GetFullPath(dialog.FileName)))
                {
                    MessageBox.Show("该文件已添加！");
                }
                else
                {
                    listBox1.Items.Add(System.IO.Path.GetFullPath(dialog.FileName));
                }
                
            }
        }

        //添加到目标集
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                if (listBox2.Items.Contains(listBox1.SelectedItems[i].ToString()))
                {
                    MessageBox.Show("该文件已添加！");
                }
                else
                {
                    listBox2.Items.Add(listBox1.SelectedItems[i].ToString());
                }
            }
        }

        //清空目标集
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            listBox2.Items.Clear();
        }

        //上移
        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            String s = listBox2.SelectedItem.ToString();
        }
    }
}
