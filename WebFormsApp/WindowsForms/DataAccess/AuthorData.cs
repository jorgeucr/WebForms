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
    public class AuthorData
    {
        private String connectionString;

        public AuthorData(String connectionString)
        {
            this.connectionString = connectionString;
        }

        public Author InsertAuthor(Author newAuthor)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string sqlIns = "INSERT INTO tbl_author (author_name, author_lastname) VALUES (@authorName, @authorLastname)";
            sqlConnection.Open();
            try
            {
                SqlCommand cmdIns = new SqlCommand(sqlIns, sqlConnection); 
                cmdIns.Parameters.AddWithValue("@authorName", newAuthor.Authorname);
                cmdIns.Parameters.AddWithValue("@authorLastname", newAuthor.AuthorLastname);     
                cmdIns.ExecuteNonQuery();
                cmdIns.Parameters.Clear();
                cmdIns.CommandText = "SELECT @@IDENTITY";
                int IdAuthor = Convert.ToInt32(cmdIns.ExecuteScalar());
                cmdIns.Dispose();
                cmdIns = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
            finally
            {
                sqlConnection.Close();
            }
            return newAuthor;
        }

        public Author InsertAuthorSP(Author newAuthor)
        {
            SqlConnection conexion = new SqlConnection(connectionString);
            String sqlStoreProcedure = "sp_insert_author";
            conexion.Open();
            SqlCommand cmdInsertar = new SqlCommand(sqlStoreProcedure, conexion);
            try
            {
                cmdInsertar.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int);
                parameter.Direction = ParameterDirection.Output;
                cmdInsertar.Parameters.Add(parameter);
                cmdInsertar.Parameters.Add(new SqlParameter("@authorName", newAuthor.Authorname));
                cmdInsertar.Parameters.Add(new SqlParameter("@authorLastname", newAuthor.AuthorLastname));
                cmdInsertar.ExecuteNonQuery();
                newAuthor.IdAuthor = Int32.Parse(cmdInsertar.Parameters["@id"].Value.ToString());
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
            return newAuthor;
        }

        public LinkedList<Author> authorsList()
        {
            String sqlSelect = "Select * from tbl_author";
            SqlConnection conexion = new SqlConnection(connectionString);
            SqlDataAdapter daAutores = new SqlDataAdapter();
            daAutores.SelectCommand = new SqlCommand(sqlSelect, conexion);
            DataSet dsAuthors = new DataSet();
            daAutores.Fill(dsAuthors, "Authors");
            DataTable dtAuthors = dsAuthors.Tables["Authors"];
            LinkedList<Author> authorsList = new LinkedList<Author>();
            foreach (DataRow fila in dtAuthors.Rows)
            {

                Author author = new Author();
                author.IdAuthor = Int32.Parse(fila["id"].ToString());
                author.Authorname = fila["author_name"].ToString();
                author.AuthorLastname = fila["author_lastname"].ToString();
                authorsList.AddLast(author);
            }
            return authorsList;
        }
        public void DeleteAuthor(Author author)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string sqlIns = "Delete from tbl_author where id=@id";
            sqlConnection.Open();
            try
            {
                SqlCommand cmdIns = new SqlCommand(sqlIns, sqlConnection);
                cmdIns.Parameters.AddWithValue("@id",author.IdAuthor);
                cmdIns.ExecuteNonQuery();
                cmdIns.Parameters.Clear();
                cmdIns.Dispose();
                cmdIns = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public Author UpdateAuthor(Author author)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string sqlIns = "Update tbl_author set author_name=@name, author_lastname=@lastname where id =@id";
            sqlConnection.Open();
            try
            {
                SqlCommand cmdIns = new SqlCommand(sqlIns, sqlConnection);
                cmdIns.Parameters.AddWithValue("@id", author.IdAuthor);
                cmdIns.Parameters.AddWithValue("@name", author.Authorname);
                cmdIns.Parameters.AddWithValue("@lastname", author.AuthorLastname);
                cmdIns.ExecuteNonQuery();
                cmdIns.Parameters.Clear();
                cmdIns.Dispose();
                cmdIns = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
            finally
            {
                sqlConnection.Close();
            }
            return author;
        }
    }
}
