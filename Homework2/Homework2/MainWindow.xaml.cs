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
using System.IO;
using System.Collections;
using System.Windows.Forms;


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
        public static string folder_path;
        private void Button1_Click(object sender, RoutedEventArgs e)
        {

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            //folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            if(folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                folder_path = folderBrowserDialog.SelectedPath;
                label3.Content = folder_path;
            }
            /*
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "文本文件|*.txt";
            if (dialog.ShowDialog() == true)
            {
                if (listBox1.Items.Contains(System.IO.Path.GetFullPath(dialog.FileName)))
                {
                    System.Windows.MessageBox.Show("该文件已添加！");
                }
                else
                {
                    
                    //listBox1.Items.Add(System.IO.Path.GetFullPath(dialog.FileName));
                }
                
            }
            */
        }

        //查找所有文件
        public static string[] folder_files;
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(folder_path))
            {
                folder_files = Directory.GetFiles(folder_path, textBox1.Text, SearchOption.AllDirectories);
                listBox1.Items.Clear();
                int selected_index = 0;
                foreach(string folder_file in folder_files)
                {
                    selected_index = listBox1.Items.Add(folder_file);
                    listBox1.SelectedIndex=1;
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
                    System.Windows.MessageBox.Show("该文件已添加！");
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
            int sel_index = listBox2.SelectedIndex;
            string sel_str = listBox2.SelectedItem.ToString();
            if(sel_index > 0)
            {
                listBox2.Items[sel_index] = listBox2.Items[sel_index - 1];
                listBox2.Items[sel_index - 1] = sel_str;
            }
        }

        //下移
        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            int sel_index = listBox2.SelectedIndex;
            string sel_str = listBox2.SelectedItem.ToString();
            if (sel_index < listBox2.Items.Count - 1)
            {
                listBox2.Items[sel_index] = listBox2.Items[sel_index + 1];
                listBox2.Items[sel_index + 1] = sel_str;
            }
        }

        //目标文件名
        public static string dest_file;
        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.Title = "选择要合并后的文件";
            dialog.InitialDirectory = System.Environment.SpecialFolder.DesktopDirectory.ToString();
            dialog.OverwritePrompt = false;
            if(dialog.ShowDialog() == true)
            {
                dest_file = dialog.FileName;
                label2.Content = dest_file;
            }
            
        }

        //合并文件
        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            if(dest_file == null)
            {
                System.Windows.MessageBox.Show("请先添加目标文件名!");
                return;
            }
            if (File.Exists(dest_file))
            {
                File.Delete(dest_file);
            }
            FileStream fs_dest = new FileStream(dest_file, FileMode.CreateNew, FileAccess.Write);
            byte[] DataBuffer = new byte[100000];
            byte[] file_name_buf;
            FileStream fs_sourse = null;
            int read_len;
            FileInfo fi_a = null;
            for(int i = 0; i < listBox2.Items.Count; i++)
            {
                fi_a = new FileInfo(listBox2.Items[i].ToString());
                //file_name_buf = Encoding.Default.GetBytes(fi_a.Name);
                file_name_buf = Encoding.UTF8.GetBytes(fi_a.Name);
                //文件合并时添加文件名
                if(checkBox2.IsChecked == true)
                {
                    fs_dest.Write(file_name_buf, 0, file_name_buf.Length);
                }
                
                //fs_dest.WriteByte((byte)13);
                //fs_dest.WriteByte((byte)10);
                fs_sourse = new FileStream(fi_a.FullName, FileMode.Open, FileAccess.Read);
                read_len = fs_sourse.Read(DataBuffer, 0, 100000);
                while(read_len > 0)
                {
                    fs_dest.Write(DataBuffer, 0, read_len);
                    read_len = fs_sourse.Read(DataBuffer, 0, 100000);
                }
                //文件合并时换行
                if(checkBox1.IsChecked == true)
                {
                    fs_dest.WriteByte((byte)13);
                    fs_dest.WriteByte((byte)10);
                    fs_sourse.Close();
                }
                

            }
            fs_sourse.Dispose();
            fs_dest.Flush();
            fs_dest.Close();
            fs_dest.Dispose();

            //打开合并后的文件
            if(checkBox3.IsChecked == true)
            {
                System.Diagnostics.Process.Start(dest_file);
            }
            
        }

        //打开选中文件
        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            if(listBox2.SelectedItems.Count == 0)
            {
                System.Windows.MessageBox.Show("请先选中文件!");
                return;
            }
            for (int i = 0; i < listBox2.SelectedItems.Count; i++)
            {
                System.Diagnostics.Process.Start(listBox2.SelectedItems[i].ToString());
            }
                
        }

        
    }
}
