using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class ProductController : Controller
    {
        String connectionstring = @"Data Source = DESKTOP-ERUKNF9\DHIVYALEARN; Initial Catalog = Employee_Registration; Integrated Security=True";
       [HttpGet]
        public ActionResult Index()

        {
            DataTable dtblProcut = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Employee", sqlcon);
                sqlDa.Fill(dtblProcut);
            }
                return View(dtblProcut);
        }

       [HttpGet]
        public ActionResult Create()
        {
            return View(new ProductModel());
        }


        [HttpPost]
        public ActionResult Create(ProductModel productModel)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                
                sqlcon.Open();
                string query = "INSERT INTO Employee VALUES (@LastName ,@Firstname ,@Nationality ,@PlaceofBirth ,@CountryofBirth ,@Gender ,@TelephoneNumber ,@EmailAddress )";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@LastName", productModel.LastName);
                sqlcmd.Parameters.AddWithValue("@Firstname", productModel.Firstname);
                sqlcmd.Parameters.AddWithValue("@Nationality", productModel.Nationality);
                sqlcmd.Parameters.AddWithValue("@PlaceofBirth", productModel.PlaceofBirth);
                sqlcmd.Parameters.AddWithValue("@CountryofBirth", productModel.CountryofBirth);
                sqlcmd.Parameters.AddWithValue("@Gender", productModel.Gender);
                sqlcmd.Parameters.AddWithValue("@TelephoneNumber", productModel.TelephoneNumber);
                sqlcmd.Parameters.AddWithValue("@EmailAddress", productModel.EmailAddress);
                sqlcmd.ExecuteNonQuery();
               
            }
           
          
            return RedirectToAction("Index");
        }

        // GET: Product/Edit/5
        // GET: Product/Edit/5
       
        public ActionResult Edit( string id)
        {
            ProductModel productModel = new ProductModel();
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                string query = "SELECT * FROM Employee Where LastName = @LastName";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlcon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@LastName", id);
                sqlDa.Fill(dtblProduct);
            }
            if (dtblProduct.Rows.Count == 1)
            {
                productModel.LastName = dtblProduct.Rows[0][0].ToString();
                productModel.Firstname = dtblProduct.Rows[0][1].ToString();
                productModel.Nationality = dtblProduct.Rows[0][2].ToString();
                productModel.PlaceofBirth = dtblProduct.Rows[0][3].ToString();
                productModel.CountryofBirth = dtblProduct.Rows[0][4].ToString();
                productModel.Gender = dtblProduct.Rows[0][5].ToString();
                productModel.TelephoneNumber = Convert.ToDouble(dtblProduct.Rows[0][6].ToString());
                productModel.EmailAddress = dtblProduct.Rows[0][7].ToString();

                return View(productModel);

            }
            else
                return RedirectToAction("Index");
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductModel productModel)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                string query = "UPDATE Employee SET LastName=@LastName,Firstname=@Firstname,Nationality=@Nationality,PlaceofBirth=@PlaceofBirth,CountryofBirth=@CountryofBirth,Gender=@Gender,TelephoneNumber=@TelephoneNumber where EmailAddress=@EmailAddress";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@LastName", productModel.LastName);
                sqlcmd.Parameters.AddWithValue("@Firstname", productModel.Firstname);
                sqlcmd.Parameters.AddWithValue("@Nationality", productModel.Nationality);
                sqlcmd.Parameters.AddWithValue("@PlaceofBirth", productModel.PlaceofBirth);
                sqlcmd.Parameters.AddWithValue("@CountryofBirth", productModel.CountryofBirth);
                sqlcmd.Parameters.AddWithValue("@Gender", productModel.Gender);
                sqlcmd.Parameters.AddWithValue("@TelephoneNumber", productModel.TelephoneNumber);
                sqlcmd.Parameters.AddWithValue("@EmailAddress", productModel.EmailAddress);
                sqlcmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Product/Delete/5
        public ActionResult Delete(string id)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                string query = "DELETE from Employee where LastName=@LastName";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@LastName", id);
                
                sqlcmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        
    }
}
