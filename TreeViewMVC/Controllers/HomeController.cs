using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreeViewMVC.Models;
using Newtonsoft.Json;

namespace TreeViewMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult TreeView()
        {
            var db = new context();
            return View(db.Categories.Where(x => !x.parentNodeId.HasValue).ToList());
        }

        public ActionResult SPTreeView()
        {
            List<Category> nodes = new List<Category>();
            nodes = Selectalldata();
            ViewBag.Json = JsonConvert.SerializeObject(nodes);
            return View();
        }

        public List<Category> Selectalldata()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<Category> custlist = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand("SP_GetCategories", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                custlist = new List<Category>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Category cobj = new Category();
                    cobj.nodeId = Convert.ToInt32(ds.Tables[0].Rows[i]["nodeId"].ToString());
                    cobj.nodeName = ds.Tables[0].Rows[i]["nodeName"].ToString();
                    cobj.IsActive =Convert.ToBoolean(ds.Tables[0].Rows[i]["IsActive"].ToString());
                    cobj.startdate =Convert.ToDateTime(ds.Tables[0].Rows[i]["startdate"].ToString());
                    if (ds.Tables[0].Rows[i]["parentNodeId"] == null || ds.Tables[0].Rows[i]["parentNodeId"].ToString() == "")
                    {
                        cobj.parentNodeId = null;
                    }
                    else
                    {
                        cobj.parentNodeId = Convert.ToInt32(ds.Tables[0].Rows[i]["parentNodeId"]);
                    }
                    cobj.parentNodeId = Convert.ToInt32(ds.Tables[0].Rows[i]["parentNodeId"]);


                    custlist.Add(cobj);
                }
                return custlist;
            }
            catch
            {
                return custlist;
            }
            finally
            {
                con.Close();
            }
        }
    }
}