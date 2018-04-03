using AlkeshPatelFullStackLib.dal;
using AlkeshPatelFullStackLib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlkeshPatelFullStackMaster
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = GetCategories();
            GridView1.DataBind();
        }

        #region Web Methods
        [WebMethod]
        public static string GetCategoryInfoById(string categoryId)
        {
            CategoryCalculations cc = new CategoryCalculations();
           return cc.GetCategoryInfo(int.Parse(categoryId));
          
        }

        [WebMethod]
        public static string GetCategoryInfoByLevel(string level)
        {
            CategoryCalculations cc = new CategoryCalculations();
            return cc.GetCategoryLevel(int.Parse(level),1,"-1");

        }

       public List<Category> GetCategories()
        {
            CategoryCalculations cc = new CategoryCalculations();
            return cc.GetAllCategories();

        }
        #endregion
    }
}