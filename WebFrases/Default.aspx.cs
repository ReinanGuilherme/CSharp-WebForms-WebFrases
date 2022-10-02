using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFrases.MODELO;

namespace WebFrases
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                lbNome.Text = Session["nome"].ToString();
                lbEmail.Text = Session["email"].ToString();
            }
        }
    }
}