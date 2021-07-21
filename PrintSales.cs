using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Coffee_Shop.Configs;
using Coffee_Shop.Models;

namespace Coffee_Shop
{

    public class PrintSales
    {
        private readonly List<Reports> SalesReports = new List<Reports>();
        private DbConfig Db = new DbConfig();

        public void Reports()
        {
            SqlConnection sqlcon = new SqlConnection(Db._Sqlconnection);
            string QuryReport = "select TblSales.SaleId,TblProducts.CoffeeType,TblProducts.CoffeePrice,TblSales.Qty,TblSales.Total from TblProducts inner join TblSales on TblSales.ProductId = TblProducts.ProductId";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(QuryReport, sqlcon);
            var rows = cmd.ExecuteReader();
            while (rows.Read())
            {
                SalesReports.Add(new Reports(rows.GetInt32(0), rows.GetString(1), rows.GetDecimal(2), rows.GetInt32(3), rows.GetDecimal(4)));
                string reports = string.Format("{0,-10}|{1,-10}|{2,-10}|{3,-10}|{4,-5}",rows.GetInt32(0)+"\t",rows.GetString(1)+"\t"+"\t","R"+rows.GetDecimal(2)+"\t"+"\t",rows.GetInt32(3)+"\t"+"\t",rows.GetDecimal(4));
                Console.WriteLine(reports);
            }
            sqlcon.Close();
        }
    }

}