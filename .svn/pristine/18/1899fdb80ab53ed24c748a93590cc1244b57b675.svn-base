using Lumex.Project.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace lmxIpos.Services
{
    /// <summary>
    /// Summary description for productAvaiablebycenter
    /// </summary>
    public class productAvaiablebycenter : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            var id = context.Request.QueryString["id"];
           
            DataTable dt = new DataTable();
            ProductBLL product = new ProductBLL();
            if (id[0] == 'W')
            {
                dt = product.GetAvailableProductListByWarehouse(id);
            }
            else if (id[0] == 'W')
            {
                dt = product.GetAvailableProductListBySalesCenter(id);
            }
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string productName = dt.Rows[i]["ProductId"].ToString() + "[" + dt.Rows[i]["ProductName"].ToString() + "]" + ";";
                sb.Append(productName).Append(Environment.NewLine);
            }

            context.Response.Write(sb.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}