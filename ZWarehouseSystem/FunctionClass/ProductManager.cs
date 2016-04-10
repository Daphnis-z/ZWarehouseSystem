using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

namespace ZWarehouseSystem.FunctionClass
{
    class ProductManager
    {
        private const int CRITICAL_VALUE = 100;
        private string _databasePath,
            _productTableName;
        private ZDatabaseManager _zdManager;

        public ProductManager(string databasePath, string productTableName)
        {
            _databasePath = databasePath;
            _productTableName = productTableName;

            _zdManager = new ZDatabaseManager(_databasePath);
        }

        /// <summary>
        /// 获取所有商品
        /// </summary>
        /// <returns></returns>
        public ICollection<Product> GetProducts()
        {
            string sql = string.Format("select * from {0}", _productTableName);
            DataSet ds = _zdManager.GetSomeData(sql);
            ObservableCollection<Product> products = new ObservableCollection<Product>();
            foreach (DataRow productRow in ds.Tables[0].Rows)
            {
                Product p = new Product(
                    (int)productRow["ID"],
                    (string)productRow["Num"], (string)productRow["ProductName"],
                    (string)productRow["Producer"], (string)productRow["Category"],
                    (int)productRow["LeftNum"], (int)productRow["SaleNum"]
                    );
                products.Add(p);
            }
            return products;
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <returns></returns>
        public bool AddProduct(Product product)
        {
            string sql = string.Format("insert into {0} (Num,ProductName,Producer,Category,LeftNum,SaleNum) values ('{1}','{2}','{3}','{4}',{5},{6})",
                _productTableName,
                product.Num,product.ProductName,product.Producer,
                product.Category,product.LeftNum,product.SaleNum);
            if (_zdManager.UpdateDatabase(sql))
                return true;
            return false;
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <returns></returns>
        public bool RemoveProduct(int id)
        {
            string sql = string.Format("delete from {0} where ID={1}",_productTableName,id);
            if (_zdManager.UpdateDatabase(sql))
                return true;
            return false;
        }

        /// <summary>
        /// 修改商品信息（入库、出库）
        /// </summary>
        /// <returns></returns>
        public bool ModifyProduct(Product product)
        {
            string sql = string.Format(
                "update {0} set Num='{1}',ProductName='{2}',Producer='{3}',Category='{4}',LeftNum={5},SaleNum={6} where ID={7}",
                _productTableName,
                product.Num, product.ProductName, product.Producer,
                product.Category, product.LeftNum, product.SaleNum,
                product.ID);
            if (_zdManager.UpdateDatabase(sql))
                return true;
            return false;
        }

        /// <summary>
        /// 打印订货单
        /// </summary>
        public List<string> PrintBookProductList()
        {
            List<string> bookList = new List<string>();
            var products = GetProducts();
            foreach(var v in products)
            {
                if (v.LeftNum < 100)
                    bookList.Add(v.ProductName + "：" + (100 + v.LeftNum));
            }
            return bookList;
        }

        /// <summary>
        /// 打印商品销售统计信息
        /// </summary>
        public List<string> PrintSaleStatisticsInfo()
        {
            List<string> staList = new List<string>();
            var products = GetProducts();
            foreach (var v in products)
            {
                if (v.SaleNum > 100)
                    staList.Add(v.ProductName + "，售出：" +v.SaleNum );
            }
            return staList;
        }

    }
}