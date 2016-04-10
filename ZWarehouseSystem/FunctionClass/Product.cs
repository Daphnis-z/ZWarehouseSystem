using System.ComponentModel;

namespace ZWarehouseSystem.FunctionClass
{
    public class Product : INotifyPropertyChanged
    {
#region 成员域
        /// <summary>
        /// 唯一标识一件商品
        /// </summary>
        private int id;
        public int ID
        {
            get{return id;}
            set{id=value;}
        }

        /// <summary>
        /// 商品编号
        /// </summary>
        private string num;
        public string Num
        {
            get { return num; }
            set
            {
                num = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Num"));
            }
        }

        /// <summary>
        /// 商品名称
        /// </summary>
        private string productName;
        public string ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ProductName"));
            }
        }

        /// <summary>
        /// 制造商
        /// </summary>
        private string producer;
        public string Producer
        {
            get { return producer; }
            set
            {
                producer = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Producer"));
            }
        }

        /// <summary>
        /// 类别
        /// </summary>
        private string category;
        public string Category
        {
            get { return category; }
            set 
            { 
                category = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Category"));
            }
        }

        /// <summary>
        /// 库存数量
        /// </summary>
        private int leftNum;
        public int LeftNum
        {
            get { return leftNum; }
            set
            {
                leftNum = value;
                OnPropertyChanged(new PropertyChangedEventArgs("LeftNum"));
            }
        }

        /// <summary>
        /// 售出数量
        /// </summary>
        private int saleNum;
        public int SaleNum
        {
            get { return saleNum; }
            set
            {
                saleNum = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SaleNum"));
            }
        }
#endregion

        public Product(int id,string num, string productName,string producer, string category,int leftNum,int saleNum)
        {
            ID = id;
            Num = num;
            ProductName = productName;
            Producer = producer;
            Category = category;
            LeftNum = leftNum;
            SaleNum = saleNum;
        }

        public override string ToString()
        {
            return ProductName + " (" + Num + ")";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

    }
}