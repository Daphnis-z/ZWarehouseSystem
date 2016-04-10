using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

using ZWarehouseSystem.FunctionClass;
using ZMessageBoxDll;

namespace ZWarehouseSystem.ChildWindow
{
    /// <summary>
    /// UserManageWindow.xaml 的交互逻辑
    /// </summary>
    public partial class UserManageWindow : Window
    {
        private string _databasePath,
            _atName;
        private UserManager _userManager;
        private List<string> _users;

        public UserManageWindow()
        {
            InitializeComponent();
        }

        public UserManageWindow(string databasePath,string atName)
        {
            _databasePath = databasePath;
            _atName = atName;
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
            _userManager = new UserManager(_databasePath, _atName);
            _users = _userManager.GetUserList();
            if (_users != null)
                ListBoxAccounts.ItemsSource = _users;
        }

        //添加账户
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string group=ComboBoxGroup.Text;
            if(WTUsername.Text==""||WTPassword.Text=="")
            {
                ZMessageBox.Show("信息不完整..");
                return;
            }

            if (_userManager.AddUser(WTUsername.Text, WTPassword.Text, group))
            {
                ZMessageBox.Show("添加成功..");
                _users.Add(WTUsername.Text);
                ListBoxAccounts.Items.Refresh();
            }
            else
                ZMessageBox.Show("添加失败..");
        }

        //删除账户
        private void Remove_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var acc =(string)ListBoxAccounts.SelectedItem;
            if (_userManager.RemoveUser(acc))
            {
                ZMessageBox.Show("删除成功..");
                _users.Remove(acc);
                ListBoxAccounts.Items.Refresh();
            }
            else
                ZMessageBox.Show("删除失败..");
        }


    }
}
