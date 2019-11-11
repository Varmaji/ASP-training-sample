using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


namespace ConsoleApp1.ProductManagement
{
    internal class ProductDAO
    {
        //All Stored Procedure names go here. Verify the actual/correct names later.
        const string GETALL = "sp_GetAllProducts";
        const string GETDETAILS = "sp_particularProduct";
        const string INSERT = "sp_AddNewProduct";
        const string UPDATE = "sp_UpdateProduct";

        SqlConnection connection;
        string connectionString = $@"Data Source=VAAYU\SQLDEV2016;initial catalog=northwind;integrated security=sspi";

        #region Helper Methods for connection management
        private void CreateConnection()
        {
            if (connection == null)
                connection = new SqlConnection(connectionString);
        }
        private void OpenConnection()
        {
            if (connection == null) CreateConnection();
            if (connection.State != ConnectionState.Open) connection.Open();
        }
        private void CloseConnection()
        {
            if (connection != null)
                if (connection.State != ConnectionState.Closed) connection.Close();
            connection = null;
        }
        private Product CreateProductFromReader(SqlDataReader reader)
        {
            Product p = new Product();
            p.ProductId = Convert.ToInt32("0" + reader["ProductId"].ToString());
            p.ProductName = reader["ProductName"].ToString();
            p.UnitPrice = Convert.ToDecimal("0" + reader["UnitPrice"].ToString());
            p.UnitsInStock = Convert.ToInt16("0" + reader["UnitsInStock"].ToString());
            p.Discontinued = Convert.ToBoolean(reader["Discontinued"].ToString());
            p.CategoryId = Convert.ToInt32("0" + reader["CategoryId"].ToString());
            return p;
        }
        #endregion

        #region DataAccess Public Methods 
        public List<Product> GetProducts(string criteria)
        {
            //Check whether the argument is passed or not
            //if (string.IsNullOrEmpty(criteria))
            //{
            //    throw new ArgumentNullException(nameof(criteria), "Required argument missing.");
            //}

            List<Product> productList = new List<Product>();
            //Create the command and setup the parameters 
            CreateConnection();
            SqlCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.CommandText = GETALL;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@search", criteria);
            //Open the connection and execute the statements within the try catch block 
            SqlDataReader reader = null;
            try
            {
                OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var product = CreateProductFromReader(reader);
                    productList.Add(product);
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (reader != null) if (!reader.IsClosed) reader.Close();
                CloseConnection();
            }
            return productList;
        }
        public Product GetProductsDetails(int productId) {

            Product product = new Product();
            if (productId>0)
            {
                
                CreateConnection();
                SqlCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = GETDETAILS;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@productId", productId);
                SqlDataReader reader = null;
              
                    try
                    {
                        OpenConnection();
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                             product = CreateProductFromReader(reader);
                        //productList.Add(product);
                        }
                    }
                    catch (SqlException)
                    {
                        throw;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        if (reader != null) if (!reader.IsClosed) reader.Close();
                        CloseConnection();
                    }

            }
            
            else
            {
                Console.WriteLine("ProductId is not valid ,Enter the Valid ProductId");
            }
            return product;
        }

             
        public void CreateProduct(Product item) {//Add the Product to ProductDetails
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Required argument missing.");
            CreateConnection();
            //Build a command and assign all the the parameters
            SqlCommand command = new SqlCommand(INSERT, connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter();
            command.Parameters.Add(new SqlParameter("@productId", item.ProductId));
            p1.ParameterName = "@ProductName";
            p1.SqlDbType = SqlDbType.VarChar;
            p1.Size = 50;
            p1.Direction = ParameterDirection.Input;
            p1.Value = item.ProductName;
            command.Parameters.Add(p1);
            command.Parameters.Add(new SqlParameter("@UnitPrice",item.UnitPrice));
            command.Parameters.Add(new SqlParameter("@UnitsInStock", item.UnitsInStock));
            command.Parameters.Add(new SqlParameter("@Discontinued", item.Discontinued));
            command.Parameters.Add(new SqlParameter("@CategoryId", item.CategoryId));


            OpenConnection();
            SqlTransaction trans = connection.BeginTransaction();
            command.Transaction = trans;

            try
            {
                command.ExecuteNonQuery();
                trans.Commit();

            }
            catch(SqlException)
            {
                trans.Rollback();
                throw;
            }

            catch(Exception)
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                CloseConnection();
            }


        }
        public void UpdateProductById(Product item) {

          //  GetProductsDetails(ProductId);
            CreateConnection();
            //Build a command and assign all the the parameters
            SqlCommand command = new SqlCommand(UPDATE, connection);
            command.CommandType = CommandType.StoredProcedure;
           // SqlParameter p1 = new SqlParameter();
           // Product Prod = new Product();
            command.Parameters.AddWithValue("@productId", item.ProductId);
            command.Parameters.AddWithValue("@productname", item.ProductName);

            
            command.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
            command.Parameters.AddWithValue("@UnitsInStock", item.UnitsInStock);
            command.Parameters.AddWithValue("@Discontinued", item.Discontinued);
            command.Parameters.AddWithValue("@CategoryId", item.UnitPrice);


            OpenConnection();
            SqlTransaction trans = connection.BeginTransaction();
            command.Transaction = trans;

            try
            {
                command.ExecuteNonQuery();
                trans.Commit();

            }
            catch (SqlException)
            {
                trans.Rollback();
                throw;
            }

            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                CloseConnection();
            }


        }
        #endregion 




    }
}
