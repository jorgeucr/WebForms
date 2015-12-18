using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsForms.DataAccess;
using WindowsForms.Domain;

namespace WindowsForms.Business
{
    public class BookBusiness
    {
        private String connectionString;

        public BookBusiness(String connectionString)
        {
            this.connectionString = connectionString;
        }

        public Books insertBook(Books newBook)
        {
            return new BookData(connectionString).insertBook(newBook);
        }
    }
}
