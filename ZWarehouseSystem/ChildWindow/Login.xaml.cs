using System.Windows;
using System.Windows.Input;
using ZWarehouseSystem.FunctionClass;
using ZMessageBoxDll;

namespace ZWarehouseSystem.ChildWindow
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        /// <summary>
        /// 是否已登录
        /// </summary>
        public bool _isLogined = false;

        private UserManager _uManager;

        public Login()
        {
            InitializeComponent();
        }
        public Login(UserManager uManager):this()
        {
            _uManager = uManager;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void LabExit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(WTUsername.Text==""||WTUsername.Text=="")
            {
                ZMessageBox.Show("信息不完整..");
                return;
            }

            if (_uManager.Login(WTUsername.Text, WTPassword.Text))
            {
                _isLogined = true;
                this.Close();
            }
            else
                ZMessageBox.Show("登录失败..\n请检查用户名与密码..");
        }

    }
}