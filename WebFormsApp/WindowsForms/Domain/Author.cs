using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms.Domain
{
    public class Author
    {
        private int idAuthor;
        private String authorname;
        private String  authorLastname;

        public Author(int idAuthor, String authorname, String authorLastname)
        {
            this.idAuthor = idAuthor;
            this.authorname = authorname;
            this.authorLastname = authorLastname;
        }

        public Author()
        {

        }

        public String  AuthorLastname
        {
            get { return authorLastname; }
            set { authorLastname = value; }
        }
        

        public String Authorname
        {
            get { return authorname; }
            set { authorname = value; }
        }
        

        public int IdAuthor
        {
            get { return idAuthor; }
            set { idAuthor = value; }
        }
        
    }

}
