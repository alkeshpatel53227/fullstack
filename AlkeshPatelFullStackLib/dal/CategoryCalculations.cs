using AlkeshPatelFullStackLib.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkeshPatelFullStackLib.dal
{
    public class CategoryCalculations
    {
        /***
         * Find Category Info by Category Id
         * 
         ***/
        public string GetCategoryInfo(int categoryId)
        {
            string parentCategoryId = "";
            string catName = "";
            string catKeyword = "";
            try
            {
                string statement = @"Select top 1 * from AlkeshPatel where CategoryId =" + categoryId;
                using (var conn = DBConnection.GetConnection())
                {
                    using (SqlCommand comm = new SqlCommand(statement, conn))
                        try
                        {
                            using (SqlDataReader dr = comm.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        parentCategoryId = dr["ParentCategoryId"].ToString();
                                        catName = dr["Name"].ToString();
                                        if (dr["Keyword"] != DBNull.Value && !string.IsNullOrEmpty(dr["Keyword"].ToString()))
                                        {
                                            catKeyword = dr["Keyword"].ToString();
                                        }
                                        else
                                        {
                                            catKeyword = GetParentCategoryKeyWord(parentCategoryId, conn);
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return !string.IsNullOrEmpty(catName) ? string.Format(@"ParentCategoryID={0}, Name={1}, Keyword={2}", parentCategoryId, catName, catKeyword) : "No Information found for this category Id.";
        }

        public string GetParentCategoryKeyWord(string parentCatId, SqlConnection conn)
        {
            string parentCategoryId = "";
            string catKeyword = "";
            try
            {
                string statement = @"Select top 1 * from AlkeshPatel where CategoryId =" + parentCatId;
                using (SqlCommand comm = new SqlCommand(statement, conn))
                    try
                    {
                        using (SqlDataReader dr = comm.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    parentCategoryId = dr["ParentCategoryId"].ToString();
                                    if (dr["Keyword"] != DBNull.Value && !string.IsNullOrEmpty(dr["Keyword"].ToString()))
                                    {
                                        return dr["Keyword"].ToString();
                                    }
                                    else
                                    {
                                        catKeyword = GetParentCategoryKeyWord(parentCategoryId, conn);
                                    }

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                conn.Close();

            }
            catch (Exception ex)
            {

            }
            return "";
        }

        /***
         * Find Category Info by Category Level
         * 
         ***/

        public string GetCategoryLevel(int categoryLevel, int currentLevel, string parentCatId)
        {
            string catName = "";
            
            try
            {
                string statement = @"Select * from AlkeshPatel where ParentCategoryId =" + parentCatId;
                using (var conn = DBConnection.GetConnection())
                {
                    using (SqlCommand comm = new SqlCommand(statement, conn))
                        try
                        {
                            using (SqlDataReader dr = comm.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        if(categoryLevel == currentLevel)
                                        {
                                            catName = catName+ dr["Name"].ToString() + "("+ dr["CategoryId"].ToString()+"),";
                                        }
                                        else
                                        {
                                            int nextLevel = currentLevel + 1;
                                            catName = catName+ GetCategoryLevel(categoryLevel, nextLevel, dr["CategoryId"].ToString());
                                        }
                                        
                                       
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return catName;
        }

        /***
         * Find Category List
         * 
         ***/
         public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            try
            {
                string statement = @"Select * from AlkeshPatel";
                using (var conn = DBConnection.GetConnection())
                {
                    using (SqlCommand comm = new SqlCommand(statement, conn))
                        try
                        {
                            using (SqlDataReader dr = comm.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        Category category = new Category();
                                        category.CategoryId = int.Parse(dr["CategoryId"].ToString());
                                        category.ParentCategoryId = int.Parse(dr["ParentCategoryId"].ToString());
                                        category.CategoryName = dr["Name"].ToString();
                                        if (dr["Keyword"] != DBNull.Value && !string.IsNullOrEmpty(dr["Keyword"].ToString()))
                                        {
                                            category.CategoryKeyword = dr["Keyword"].ToString();
                                        }
                                        categories.Add(category);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }

            return categories;
        }

    }
}
