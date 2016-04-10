using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZWarehouseSystem.FunctionClass;
using ZWarehouseSystem.ChildWindow;
using ZMessageBoxDll;

namespace ZWarehouseSystem
{
    class BlackBoxTest
    {
        public BlackBoxTest()
        {

        }

        /// <summary>
        /// 账户模块测试
        /// </summary>
        public void UserPartTest()
        {
            UserManager userManager = new UserManager(@"Database\ZWarehouse.mdb", "Accounts");
            //添加账户
            userManager.AddUser("Daphnis","123","group");

            //登录
            userManager.Login("Daphnis", "123");

            //删除账户
            userManager.RemoveUser("Daphnis");

            //获取账户列表
            var users=userManager.GetUserList();
        }

        /// <summary>
        /// 商品基础操作测试
        /// </summary>
        public void ProductOperationTest()
        {
            ProductManager pdtManager = new ProductManager(@"Database\ZWarehouse.mdb", "Products");
            Product product = new Product(5, "007", "香酥怪味蚕豆", "成都明渲畜牧发展有限公司", "豆制品类",35,55);
            //增加商品
            pdtManager.AddProduct(product);

            //删除商品
            pdtManager.RemoveProduct(5);

            //修改商品
            pdtManager.ModifyProduct(product);

            //查看商品
            var products = pdtManager.GetProducts();
        }

        /// <summary>
        /// 商品统计类功能测试
        /// </summary>
        public void ProductStaTest()
        {
            ProductManager pdtManager = new ProductManager(@"Database\ZWarehouse.mdb", "Products");
            //订货单打印
            var bookList=pdtManager.PrintBookProductList();

            //查看最受欢迎商品
            var mpp = pdtManager.PrintSaleStatisticsInfo();
        }
    }
}