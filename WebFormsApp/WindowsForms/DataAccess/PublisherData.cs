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
    public class PublisherData
    {
        private String connectionString;

        public PublisherData(String connectionString)
        {
            this.connectionString = connectionString;
        }

        public LinkedList<Publisher> publisherList()
        {
            String sqlSelect = "Select * from tbl_publisher";
            SqlConnection conexion = new SqlConnection(connectionString);
            SqlDataAdapter daAutores = new SqlDataAdapter();
            daAutores.SelectCommand = new SqlCommand(sqlSelect, conexion);
            DataSet dsPublisher = new DataSet();
            daAutores.Fill(dsPublisher, "Publishers");
            DataTable dtPublisher = dsPublisher.Tables["Publishers"];
            LinkedList<Publisher> publisherList = new LinkedList<Publisher>();
            foreach (DataRow fila in dtPublisher.Rows)
            {
                Publisher publisher = new Publisher();
                publisher.IdPublisher = Int32.Parse(fila["id"].ToString());
                publisher.PublisherName = fila["publisher_name"].ToString();
                publisher.PublisherPhone = fila["publisher_phone"].ToString();
                publisher.PublisherUrl = fila["publisher_url"].ToString();
                publisherList.AddLast(publisher);
            }
            return publisherList;
        }
    }
}
