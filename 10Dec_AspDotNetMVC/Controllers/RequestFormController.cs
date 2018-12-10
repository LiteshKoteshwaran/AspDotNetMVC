using _10Dec_AspDotNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _10Dec_AspDotNetMVC.Controllers
{
    public class RequestFormController : Controller
    {
        DataTable dataTable;
        // GET: RequestForm
        public ActionResult Index()
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            string query = "select * from students";

            var model = new List<ViewRequestFormDetails>();

            using (SqlConnection conn = new SqlConnection(connString))

            {

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())

                {

                    var viewRequestFormDetails = new ViewRequestFormDetails();

                    viewRequestFormDetails.Id = Convert.ToInt32(rdr["Id"]);

                    viewRequestFormDetails.Name = rdr["Name"].ToString();

                    model.Add(viewRequestFormDetails);

                }
            }

            return View(model);
        }
        // GET: RequestForm/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RequestForm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RequestForm/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RequestForm/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RequestForm/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RequestForm/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RequestForm/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
