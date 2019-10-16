using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using Homework3DLL;

namespace Homework3
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("CalculatorDLL.dll", EntryPoint = "add_int", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int add_int(int a, int b);

        [DllImport("CalculatorDLL.dll", EntryPoint = "mult_int", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int mult_int(int a, int b);

        [DllImport("Homework3.dll")]
        public static extern int factorial(int a);

        [DllImport("Homework3.dll")]
        public static extern int fibonacci(int a);

        int num1 = 0;
        int num2 = 0;
        Homework3DLL.Class1 dll = new Homework3DLL.Class1();

        public MainWindow()
        {
            InitializeComponent();
        }

        //加法
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("请输入值！");
                return;
            }
            try
            {
                num1 = int.Parse(textBox1.Text);
                num2 = int.Parse(textBox2.Text);
            }
            catch
            {
                Console.WriteLine("输入数据格式错误！");
                MessageBox.Show("请输入正确的格式！");
            }

            textBox4.Text = add_int(num1, num2).ToString();
        }

        //乘法
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("请输入值！");
                return;
            }
            try
            {
                num1 = int.Parse(textBox1.Text);
                num2 = int.Parse(textBox2.Text);
            }
            catch
            {
                Console.WriteLine("输入数据格式错误！");
                MessageBox.Show("请输入正确的格式！");
            }

            textBox4.Text = mult_int(num1, num2).ToString();
        }

        //阶乘
        int num3 = 0;
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            

            if (textBox3.Text == "")
            {
                MessageBox.Show("请输入值！");
                return;
            }
            try
            {
                num3 = int.Parse(textBox3.Text);
            }
            catch
            {
                Console.WriteLine("输入数据格式错误！");
                MessageBox.Show("请输入正确的格式！");
            }

            textBox4.Text = dll.factorial(num3).ToString();
        }

        //斐波拉契数列
        int num4 = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("请输入值！");
                return;
            }
            try
            {
                num4 = int.Parse(textBox3.Text);
            }
            catch
            {
                Console.WriteLine("输入数据格式错误！");
                MessageBox.Show("请输入正确的格式！");
            }

            textBox4.Text = dll.fibonacci(num4).ToString();
        }
    }
}
