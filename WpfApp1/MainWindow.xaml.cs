using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfApp1
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string Path1 { get; set; }
        string Path2 { get; set; }
        string Path3 { get; set; }
        public void FileAdd(string Tag)
        {
            
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".txt";
           // dlg.Filter = "txt Files (*.txt)";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                switch (Tag)
                {
                    case "1":
                        ThreadPool.QueueUserWorkItem(
                   new WaitCallback(ReadFile), dlg.FileName);
                        //ReadFile(dlg.FileName);
                        break;
                    case "2":
                        Path2 = dlg.FileName;
                        break;
                    case "3":
                        Path3 = dlg.FileName;
                        break;
                    default:
                        break;
                }
            }

           

        }

        private void ReadFile(object path1)
        {
            //using (FileStream fs = new FileStream(path,FileMode.Open,FileAccess.Read))
            //{
            //    byte[] buffer = new byte[fs.Length];
            //    fs.Read(buffer, 0, buffer.Length);
            //    var value = fs.ReadByte();
            //    string text = Encoding.Default.GetString(buffer);
            //    txt1.Items.Add(value.ToString());
            //}
            string path = path1.ToString();

            using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            using StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                 txt1.Items.Add(sr.ReadLine());
            }
          //  Console.WriteLine(sr.ReadToEnd());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                switch (btn.Tag)
                {
                    case "1":
                        FileAdd("1");
                        btn_2.Visibility = Visibility.Visible;
                        break;
                    case "2":
                        btn_3.Visibility = Visibility.Visible;
                        break;
                    case "3":
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
