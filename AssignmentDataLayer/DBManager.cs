using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB = AssignmentDBConnector;

namespace AssignmentDataLayer
{
    public class DBManager
    {
        public DataTable GetProductList()
        {
            string sqlCommandSting;
            DB.DBConnection objConn = new DB.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandSting = "USP_ProductMasterList";
                    SqlCommand objCommand = new SqlCommand(sqlCommandSting, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    DataTable table = new DataTable();
                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;

                        _Data.Fill(table);
                    }
                    connection.Close();

                    return table;

                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }
        }

        public DataTable GetProductOrderList()
        {
            string sqlCommandSting;
            DB.DBConnection objConn = new DB.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandSting = "USP_ProductOrderList";
                    SqlCommand objCommand = new SqlCommand(sqlCommandSting, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    DataTable table = new DataTable();
                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;

                        _Data.Fill(table);
                    }
                    connection.Close();

                    return table;

                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }
        }

        public DataTable AddOrEditOrder(int iD, int productID, decimal mRP, int qTY, decimal amount, decimal payableAmount, decimal discount, int mode)
        {
            string sqlCommandSting;
            DB.DBConnection objConn = new DB.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandSting = "USP_AddOrEditProductOrder";
                    SqlCommand objCommand = new SqlCommand(sqlCommandSting, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ID", iD);
                    objCommand.Parameters.AddWithValue("@ProductID", productID);
                    objCommand.Parameters.AddWithValue("@MRP", mRP);
                    objCommand.Parameters.AddWithValue("@QTY", qTY);
                    objCommand.Parameters.AddWithValue("@Amount", amount);
                    objCommand.Parameters.AddWithValue("@Discount", discount);
                    objCommand.Parameters.AddWithValue("@PayableAmount", payableAmount);
                    objCommand.Parameters.AddWithValue("@Mode", mode);

                    DataTable table = new DataTable();
                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;

                        _Data.Fill(table);
                    }
                    connection.Close();

                    return table;

                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }
        }

        public DataTable DeleteOrder(int iD)
        {
            string sqlCommandSting;
            DB.DBConnection objConn = new DB.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandSting = "USP_DeleteProduct";
                    SqlCommand objCommand = new SqlCommand(sqlCommandSting, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ID", iD);
                    DataTable table = new DataTable();
                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(table);
                    }
                    connection.Close();

                    return table;

                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }
        }

        public DataTable ProductOrderDetail(int iD)
        {
            string sqlCommandSting;
            DB.DBConnection objConn = new DB.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandSting = "USP_ProductOrderDetail";
                    SqlCommand objCommand = new SqlCommand(sqlCommandSting, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ID", iD);
                    DataTable table = new DataTable();
                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(table);
                    }
                    connection.Close();

                    return table;

                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }
        }
    }
}
