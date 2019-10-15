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
using Microsoft.International.Converters.PinYinConverter;
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;
using DotNetSpeech;


namespace Homework1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public String text_origin;
        public String text_result;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            text_origin = this.textBox.Text;

        }

        //汉字转拼音
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //清空
            text_result = "";
            if(text_origin == "")
            {
                MessageBox.Show("输入内容不能为空！");
                return;
            }

            foreach (char c in text_origin.Trim())
            {
                ChineseChar chineseChar = new ChineseChar(c);
                text_result += chineseChar.Pinyins[0].Substring(0, chineseChar.Pinyins[0].Length - 1).ToLower();
            }

            textBox1.Text = text_result;
        }

        //简体到繁体
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            text_result = "";
            if (text_origin == "")
            {
                MessageBox.Show("输入内容不能为空！");
                return;
            }

            foreach (char c in text_origin.Trim())
            {
                if (ChineseChar.IsValidChar(c))
                {
                    text_result += ChineseConverter.Convert(c.ToString(), ChineseConversionDirection.SimplifiedToTraditional);
                }
                else
                {
                    text_result += c.ToString();
                }
            }

            textBox1.Text = text_result;


        }

        //繁体到简体
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            text_result = "";
            if (text_origin == "")
            {
                MessageBox.Show("输入内容不能为空！");
                return;
            }

            foreach (char c in text_origin.Trim())
            {
                if (ChineseChar.IsValidChar(c))
                {
                    text_result += ChineseConverter.Convert(c.ToString(), ChineseConversionDirection.TraditionalToSimplified);
                }
                else
                {
                    text_result += c.ToString();
                }
            }

            textBox1.Text = text_result;
        }

        //文本到发音
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (text_origin == "")
            {
                MessageBox.Show("输入内容不能为空！");
                return;
            }

            SpVoice sp = new SpVoice();
            SpeechVoiceSpeakFlags sFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;
            sp.Speak(text_origin, sFlags);
        }
    }
}
