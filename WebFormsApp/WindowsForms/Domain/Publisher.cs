using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms.Domain
{
    public class Publisher
    {
        private int idPublisher;
        private String publisherName;
        private String publisherUrl;
        private String publisherPhone;

        public Publisher()
        {

        }

        public Publisher(int idPublisher, String publisherName, String publisherUrl, String publisherPhone)
        {
            this.idPublisher = idPublisher;
            this.publisherName = publisherName;
            this.publisherUrl = publisherUrl;
            this.publisherPhone = publisherPhone;

        }
        public String PublisherPhone
        {
            get { return publisherPhone; }
            set { publisherPhone = value; }
        }
        

        public String PublisherUrl
        {
            get { return publisherUrl; }
            set { publisherUrl = value; }
        }
        

        public String PublisherName
        {
            get { return publisherName; }
            set { publisherName = value; }
        }
        

        public int IdPublisher
        {
            get { return idPublisher; }
            set { idPublisher = value; }
        }
        
    }
}
