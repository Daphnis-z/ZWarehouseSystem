using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

using ZWarehouseSystem.FunctionClass;
using ZWarehouseSystem.ChildWindow;
using ZMessageBoxDll;

namespace ZWarehouseSystem
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string DATABASE_PATH = @"Database\ZWarehouse.mdb",
            AT_NAME="Accounts",
            PT_NAME="Products";

        private UserManager _userManager;
        private ProductManager _productManager;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }
        private void LabMin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void LabExit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

#region 调整窗体大小
        private void Window_ReadyForChangeSize(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            rect.CaptureMouse();
            e.Handled = true;
        }
        private void Window_Widen(object sender, MouseEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            if (rect.IsMouseCaptured)
            {
                double newWidth = e.GetPosition(this).X + 5;
                this.Width = newWidth > 0 ? newWidth : this.Width;
            }
        }
        private void Window_Heighten(object sender, MouseEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            if (rect.IsMouseCaptured)
            {
                double newHeight = e.GetPosition(this).Y + 5;
                this.Height = newHeight > 0 ? newHeight : this.Height;
            }
        }
        private void Window_EndChangeSize(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            rect.ReleaseMouseCapture();
        }
#endregion

        private void Window_Initialized(object sender, EventArgs e)
        {
            if (!Login())
                Environment.Exit(-1);
            if(_userManager._group!="admin")
            {
                DataGridProducts.IsReadOnly = true;
                BtnApply.Visibility = Visibility.Hidden;
                BtnUserManage.Visibility = Visibility.Hidden;
            }

            _productManager = new ProductManager(DATABASE_PATH,PT_NAME);
            DataGridProducts.ItemsSource = _productManager.GetProducts();
        }

        private bool Login()
        {
            _userManager = new UserManager(DATABASE_PATH, AT_NAME);
            Login login = new Login(_userManager);
            login.ShowDialog();
            if (login._isLogined)
                return true;
            return false;
        }

#region 商品信息表相关
        private bool _isAdding = false;

    #region 右键菜单
        private void Add_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var products= DataGridProducts.ItemsSource as ObservableCollection<Product>;
            products.Add(new Product(0,"000", "新建商品", "制造商", "类别", 0, 0));
            DataGridProducts.SelectedIndex = DataGridProducts.Items.Count-1;
            DataGridProducts.ScrollIntoView(DataGridProducts.SelectedItem);
            _isAdding = true;
        }
        private void Remove_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var prt=DataGridProducts.SelectedItem as Product;
            if (_productManager.RemoveProduct(prt.ID))
            {
                ZMessageBox.Show("删除成功..");
                var prts = DataGridProducts.ItemsSource as ICollection<Product>;
                prts.Remove(prt);
            }
            else
                ZMessageBox.Show("删除失败..");
        }
        private void BookList_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            PrintWindow pw = new PrintWindow(_productManager.PrintBookProductList());
            pw.LabTitle.Content = "订货单";
            pw.ShowDialog();
        }
        private void SaleSta_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            PrintWindow pw = new PrintWindow(_productManager.PrintSaleStatisticsInfo());
            pw.LabTitle.Content = "受欢迎商品单";
            pw.ShowDialog();
        }
    #endregion

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            var prt=DataGridProducts.SelectedItem as Product;
            if (prt == null)
                return;

            if (_isAdding)//应用添加商品操作
            {
                _isAdding=false;
                if (_productManager.AddProduct(prt))
                    ZMessageBox.Show("商品添加成功..");
                else
                    ZMessageBox.Show("商品添加失败..");
            }
            else//应用修改商品操作
            {
                if (_productManager.ModifyProduct(prt))
                    ZMessageBox.Show("商品修改成功..");
                else
                    ZMessageBox.Show("商品修改失败..");
            }
        }
#endregion

        //账户管理
        private void BtnUserManage_Click(object sender, RoutedEventArgs e)
        {
            UserManageWindow umw = new UserManageWindow(DATABASE_PATH,AT_NAME);
            umw.ShowDialog();
        }


    }
}