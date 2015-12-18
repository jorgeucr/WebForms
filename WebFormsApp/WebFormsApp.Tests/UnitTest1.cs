using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsForms.Domain;
using System.Diagnostics;
using WindowsForms.Business;
using System.Collections.Generic;

namespace WebFormsApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Author a = new Author();
            a.AuthorLastname = "Castillo";
            a.Authorname = "JORGE";
            a.IdAuthor = 14;
            String connectionString = "Data Source=JORGE-PC\\SQLEXPRESS;Initial Catalog=BD_WebFormsCode;User ID=sa;Password=Gamma26";

           // LinkedList<Author>authorsList = new AuthorBusiness(connectionString).authorsList();
           // new AuthorBusiness(connectionString).DeleteAuthor(a);
            //new AuthorBusiness(connectionString).InsertAuthorSP(a);
             new AuthorBusiness(connectionString).UpdateAuthor(a);

            //Debug.Write(authorsList.Count);
        }
    }
}
