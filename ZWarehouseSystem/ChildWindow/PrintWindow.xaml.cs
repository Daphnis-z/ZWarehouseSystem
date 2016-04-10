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

namespace ZWarehouseSystem.ChildWindow
{
    /// <summary>
    /// PrintWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PrintWindow : Window
    {
        private List<string> _content;

        public PrintWindow()
        {
            InitializeComponent();
        }

        public PrintWindow(List<string> content)
        {
            _content = content;
            InitializeComponent();
        }


        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void LabExit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            string ctt="";
            foreach(string str in _content)
            {
                ctt += str + '\n';
            }
            TextBlockPrint.Text = ctt;
        }


    }
}
