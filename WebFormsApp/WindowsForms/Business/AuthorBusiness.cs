using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsForms.DataAccess;
using WindowsForms.Domain;

namespace WindowsForms.Business
{
    public class AuthorBusiness
    {
        private String connectionString;


        public AuthorBusiness(String connectionString)
        {
            this.connectionString = connectionString;
        }

        public Author InsertAuthor(Author newAuthor)
        {
            return new AuthorData(connectionString).InsertAuthor(newAuthor);
        }
        public Author InsertAuthorSP(Author newAuthor)
        {
            return new AuthorData(connectionString).InsertAuthorSP(newAuthor);
        }
        public LinkedList<Author> authorsList()
        {
            return new AuthorData(connectionString).authorsList();
        }
        public void DeleteAuthor(Author author)
        {
            new AuthorData(connectionString).DeleteAuthor(author);
        }
        public Author UpdateAuthor(Author author)
        {
            return new AuthorData(connectionString).UpdateAuthor(author);
        }
    }
}
