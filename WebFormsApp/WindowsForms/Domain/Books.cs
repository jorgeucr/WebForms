using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms.Domain
{
    public class Books
    {
        private int idBook;
        private String bookName;
        private float bookPrice;
        private Author bookAuthor;
        private LinkedList<Publisher> publisherList;

      
        
        public Books()
        {
            publisherList = new LinkedList<Publisher>();
        }

        public Books(int idBook, String bookName, float bookPrice, Author bookAuthor, LinkedList<Publisher> publisherList)
        {
            this.idBook=idBook;
            this.bookName=bookName;
            this.bookPrice=bookPrice;
            this.bookAuthor=bookAuthor;
            this.publisherList = publisherList;
        }

        
        public LinkedList<Publisher> PublisherList
        {
            get { return publisherList; }
            set { publisherList = value; }
        }
        

        public Author BookAuthor
        {
            get { return bookAuthor; }
            set { bookAuthor = value; }
        }
        

        public float BookPrice
        {
            get { return bookPrice; }
            set { bookPrice = value; }
        }
        

        public String BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }
        

        public int IdBook
        {
            get { return idBook; }
            set { idBook = value; }
        }


        
    }
}
