using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NORTHWND_DAO
{
    public class Products
    {
       private string _ProductID;

       public string ProductID
       {
         get { return _ProductID; }
          set { _ProductID = value; }
       }
        private string _ProductName;

        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
        private string _SupID;

        public string SupID
        {
            get { return _SupID; }
            set { _SupID = value; }
        }
        private string _CatID;

        public string CatID
        {
            get { return _CatID; }
            set { _CatID = value; }
        }
        private string _Quantity;

        public string Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        private string _money;

        public string Money
        {
            get { return _money; }
            set { _money = value; }
        }
        private string _Stock;

        public string Stock
        {
            get { return _Stock; }
            set { _Stock = value; }
        }
        private string _Order;

        public string Order
        {
            get { return _Order; }
            set { _Order = value; }
        }
        private string _ReOrder;

        public string ReOrder
        {
            get { return _ReOrder; }
            set { _ReOrder = value; }
        }
        private string _DisCon;

        public string DisCon
        {
            get { return _DisCon; }
            set { _DisCon = value; }
        }
        public Products(string id,string name,string supid,string catid,string quan,string money,string stock,string order,string reorder,string discon)
        {
            this._ProductID = id;
            this.ProductName = name;
            this.SupID = supid;
            this.CatID = catid;
            this.Quantity = quan;
            this.Money = money;
            this.Stock = stock;
            this.Order = order;
            this.ReOrder = reorder;
            this.DisCon = discon;
        }
        public Products()
        {
            this.ProductName = " ";
            this.SupID = "";
            this.CatID = "";
            this.Quantity = "";
            this.Money = "";
            this.Stock = "";
            this.Order = "";
            this.ReOrder = "";
            this.DisCon = "";
        }
    }
}
