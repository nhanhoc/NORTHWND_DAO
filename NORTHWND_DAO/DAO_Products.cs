using Northwnd;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NORTHWND_DAO
{
    public class DAO_Products
    {
        Products pd;
        public Products SetProduct(string id, string name, string supid, string catid, string quan, string money, string stock, string order, string reorder, string discon)
        {
            Products pd2 = new Products();
            pd2.ProductID = id;
            pd2.ProductName = name;
            pd2.SupID = supid;
            pd2.CatID = catid;
            pd2.Quantity = quan;
            pd2.Money = money;
            pd2.Stock = stock;
            pd2.Order = order;
            pd2.ReOrder = reorder;
            pd2.DisCon = discon;
            return pd = pd2;
        }
        public DataTable DanhSachProduct()
        {
            Provider Connect = new Provider();
            Connect.Connect();
            DataTable dt;
            dt = Connect.Select(CommandType.Text, "SELECT * FROM PRODUCTS", null);
            Connect.Disconnect();
            return dt;
        }
        public void GetList(ref List<string> a, ref List<string> b)
        {
            string getSup = "SELECT SupplierID FROM SUPPLIERS ORDER BY SupplierID";
            string getCat = "SELECT CategoryID FROM CATEGORIES ORDER BY CategoryID";
            Provider connect = new Provider();
            connect.Connect();
            a = connect.CbList(CommandType.Text, getSup, "SupplierID");
            connect.Disconnect();
            connect.Connect();
            b = connect.CbList(CommandType.Text, getCat, "CategoryID");
            connect.Disconnect();
        }
        public int AddProducts()
        {
            try
            {
                int flag = -1;
                Provider connect = new Provider();
                connect.Connect();
                string getmax = "SELECT MAX(ProductID) FROM PRODUCTS";
                int id = connect.GetFirstValue(CommandType.Text, getmax, null) + 1;
                string on = "SET IDENTITY_INSERT Products ON;";
                string off = "SET IDENTITY_INSERT Products OFF";
                string insert = "INSERT INTO PRODUCTS(ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued) VALUES (@id,@name,@sup,@cat,@quan,@price,@stock,@order,@reorder,@dis);";
                connect.ExecuteNonQuery(CommandType.Text, on + insert + off,
                    new SqlParameter { ParameterName = "@id", Value = id },
                    new SqlParameter { ParameterName = "@name", Value = pd.ProductName },
                    new SqlParameter { ParameterName = "@sup", Value = pd.SupID },
                    new SqlParameter { ParameterName = "@cat", Value = pd.CatID },
                    new SqlParameter { ParameterName = "@quan", Value = pd.Quantity },
                    new SqlParameter { ParameterName = "@price", Value = pd.Money },
                    new SqlParameter { ParameterName = "@stock", Value = pd.Stock },
                    new SqlParameter { ParameterName = "@order", Value = pd.Order },
                    new SqlParameter { ParameterName = "@reorder", Value = pd.ReOrder },
                    new SqlParameter { ParameterName = "@dis", Value = pd.DisCon }
                );
                connect.Disconnect();
                flag = 1;
                return flag;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int DeleteProduct()
        {
            try
            {
                int flag = -1;
                string delete = "DELETE FROM PRODUCTS WHERE ProductID=@id and ProductName=@name";
                Provider conn = new Provider();
                conn.Connect();
                conn.ExecuteNonQuery(CommandType.Text, delete, new SqlParameter { ParameterName = "@id", Value = pd.ProductID },
                    new SqlParameter { ParameterName = "@name", Value = pd.ProductName });
                conn.Disconnect();
                flag = 1;
                return flag;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int UpdateProduct()
        {
            try
            {
                int flag = -1;
                string delete = "UPDATE PRODUCTS SET ProductName=@name,SupplierID=@sup,CategoryID=@cat,QuantityPerUnit=@quan,UnitPrice=@price,UnitsInStock=@stock,UnitsOnOrder=@order,ReorderLevel=@reorder,Discontinued=@dis WHERE ProductID=@id";
                Provider conn = new Provider();
                conn.Connect();
                conn.ExecuteNonQuery(CommandType.Text, delete,     
                    new SqlParameter { ParameterName = "@name", Value = pd.ProductName },
                    new SqlParameter { ParameterName = "@sup", Value = pd.SupID },
                    new SqlParameter { ParameterName = "@cat", Value = pd.CatID },
                    new SqlParameter { ParameterName = "@quan", Value = pd.Quantity },
                    new SqlParameter { ParameterName = "@price", Value = pd.Money },
                    new SqlParameter { ParameterName = "@stock", Value = pd.Stock },
                    new SqlParameter { ParameterName = "@order", Value = pd.Order },
                    new SqlParameter { ParameterName = "@reorder", Value = pd.ReOrder },
                    new SqlParameter { ParameterName = "@dis", Value = pd.DisCon },
                    new SqlParameter { ParameterName = "@id", Value = pd.ProductID });
                conn.Disconnect();
                flag = 1;
                return flag;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
