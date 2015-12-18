using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsForms.DataAccess;
using WindowsForms.Domain;

namespace WindowsForms.Business
{
    public class PublisherBusiness
    {
        private String connectionString;

        public PublisherBusiness(String connectionString)
        {
            this.connectionString = connectionString;
        }

        public LinkedList<Publisher> publisherList()
        {
            return new PublisherData(connectionString).publisherList();
        }
    }
}
