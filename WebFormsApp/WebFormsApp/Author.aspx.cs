using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using WindowsForms.Business;
using WindowsForms.Domain;

namespace WebFormsApp
{
    public partial class Book : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AuthorBusiness authorBusiness = new AuthorBusiness(WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
               //DropDownList
                ddlAuthors.DataSource = authorBusiness.authorsList();
                ddlAuthors.DataTextField = "authorname";
                ddlAuthors.DataValueField = "idAuthor";
                ddlAuthors.DataBind();
                //ddlAuthors.SelectedIndex = 0;
                FillGridView();
            }

        }

        public void Reload()
        {
            string currentPage = this.Page.Request.AppRelativeCurrentExecutionFilePath;
            Response.Redirect(currentPage);
        }

        private void FillGridView()
        {
            // Modo 1 de llenar el GridView
            // Se especifica el DataSource del GridView del mismo modo en que se especificaría para el DropDownList
            //gvLibros.DataSource = libros;
            //gvLibros.DataBind();

            // Modo 2 de llenar el GridView
            //Se crea un DataTable personalizado que mostrará únicamente las columnas deseadas
            DataTable dtAuthor = new DataTable("Authors");
            dtAuthor.Columns.Add("id");
            dtAuthor.Columns.Add("Author Name");
            dtAuthor.Columns.Add("Author Lastname");

            // Con un ciclo se itera sobre la lista declarada e inicializada previamente, para agregar en las filas específicas
            // los datos obtenidos de la lista.
            AuthorBusiness authorBusiness = new AuthorBusiness(WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
               
            foreach (Author author in authorBusiness.authorsList())
            {
                DataRow fila = dtAuthor.NewRow();
                fila["id"] = author.IdAuthor;
                fila["Author Name"] = author.Authorname;
                fila["Author Lastname"] = author.AuthorLastname;
                dtAuthor.Rows.Add(fila);
            }
            // 4. Se especifica el DataSource del GridView, usando específicamente la tabla personalizada anteriormente
            gdvAuthors.DataSource = dtAuthor;
            gdvAuthors.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           AuthorBusiness authorBusinness = new AuthorBusiness(WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            String authorName = txbAuthorName.Text;
            String authorLastname = txAuthorLastname.Text;
            Author author = new Author();
            author.Authorname = authorName;
            author.AuthorLastname = authorLastname;

            try
            {
                authorBusinness.InsertAuthor(author);
                Reload();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(ddlAuthors.SelectedValue);
            AuthorBusiness authorBusiness = new AuthorBusiness(WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            foreach (Author author in authorBusiness.authorsList())
            {
                if (author.IdAuthor == id)
                {
                    authorBusiness.DeleteAuthor(author);
                    Reload();
                    return;
                }
            }
        }

        protected void ddlAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Recuerde el AutoPostBack
            //txbBorrar.Text = ddlAuthors.SelectedItem.ToString();           
            int id = Int32.Parse(ddlAuthors.SelectedValue);
            AuthorBusiness authorBusiness = new AuthorBusiness(WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            foreach (Author author in authorBusiness.authorsList())
            {
                if (author.IdAuthor == id)
                {
                    txbBorrar.Text = author.Authorname + " " + author.AuthorLastname;
                    return;
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}