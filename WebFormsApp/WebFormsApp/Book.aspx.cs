using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using WindowsForms.Business;
using WindowsForms.DataAccess;
using WindowsForms.Domain;

namespace WebFormsApp
{
    public partial class Book1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                AuthorBusiness authorBusiness = new AuthorBusiness(WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                //DropDownList
                ddlBookAuthor.DataSource = authorBusiness.authorsList();
                ddlBookAuthor.DataTextField = "authorname";
                ddlBookAuthor.DataValueField = "idAuthor";
                ddlBookAuthor.DataBind();

                PublisherBusiness publisherBusiness = new PublisherBusiness(WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                //ListBox
                lbxPublishersList.DataSource = publisherBusiness.publisherList();
                lbxPublishersList.DataTextField = "publisherName";
                lbxPublishersList.DataValueField = "idPublisher";
                lbxPublishersList.DataBind();

            }
        }

        public void Reload()
        {
            string currentPage = this.Page.Request.AppRelativeCurrentExecutionFilePath;
            Response.Redirect(currentPage);
        }

        protected void btnAddPublisher_Click(object sender, EventArgs e)
        {
            Books book = new Books();
            book.BookName =txbBookName.Text;
            book.BookPrice = float.Parse(txbBookPrice.Text);
            Author author = new Author();
            author.IdAuthor=Int32.Parse(ddlBookAuthor.SelectedValue);
            book.BookAuthor= author;
            
            //obtener elementos
            foreach (ListItem item in lbxSelectedPublisherList.Items) { 
                Publisher publisher = new Publisher();
                publisher.IdPublisher = Int32.Parse(item.Value);
                book.PublisherList.AddLast(publisher);
            }

            new BookBusiness(WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString()).insertBook(book);
            Server.Transfer("Success.aspx");
        }

        protected void btnSendPublisherToList_Click(object sender, EventArgs e)
        {
            lbxSelectedPublisherList.Items.Add(lbxPublishersList.SelectedItem);
            lbxPublishersList.Items.Remove(lbxPublishersList.SelectedItem);
            //txbBookName.Text = lbxPublishersList.SelectedItem.Text;

            //lbxPublishersList.DataTextField = "publisherName";
            //lbxPublishersList.DataValueField = "idPublisher";
            //lbxPublishersList.DataBind();
           
        }
    }
}