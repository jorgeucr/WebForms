using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsForms.Domain;

namespace WindowsForms.DataAccess
{
    public class BookData
    {
        private String connectionString;

        public BookData(String connectionString)
        {
            this.connectionString = connectionString;
        }

        public Books insertBook(Books newBook)
        {
            SqlConnection conexion = new SqlConnection(connectionString);
            String sqlStoreProcedure = "sp_insert_book";
            String sqlStoreProcedure2 = "sp_insert_book_publisher";
            conexion.Open();

            SqlTransaction transaction = conexion.BeginTransaction();

            SqlCommand cmdInsertar = new SqlCommand(sqlStoreProcedure, conexion, transaction);
            try
            {

                cmdInsertar.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int);
                parameter.Direction = ParameterDirection.Output;
                cmdInsertar.Parameters.Add(parameter);
                cmdInsertar.Parameters.Add(new SqlParameter("@book_name", newBook.BookName));
                cmdInsertar.Parameters.Add(new SqlParameter("@book_price", newBook.BookPrice));
                cmdInsertar.Parameters.Add(new SqlParameter("@book_author", newBook.BookAuthor.IdAuthor));

                cmdInsertar.ExecuteNonQuery();

                newBook.IdBook = Int32.Parse(cmdInsertar.Parameters["@id"].Value.ToString());


                foreach (Publisher publisher in newBook.PublisherList)
                {
                    SqlCommand cmdInsertar2 = new SqlCommand(sqlStoreProcedure2, conexion, transaction);
                    cmdInsertar2.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdInsertar2.Parameters.Add(new SqlParameter("@idBook", newBook.IdBook));
                    cmdInsertar2.Parameters.Add(new SqlParameter("@idPublisher", publisher.IdPublisher));
                    cmdInsertar2.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch (SqlException e)
            {
                transaction.Rollback();
                throw e;
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
            return newBook;
        }
    }
}
