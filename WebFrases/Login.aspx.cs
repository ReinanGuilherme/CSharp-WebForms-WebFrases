using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFrases.DAL;
using WebFrases.MODELO;

namespace WebFrases
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void btlogar_Click(object sender, EventArgs e)
        {
            string email = txbLogin.Text;
            string senha = txbSenha.Text;

            DALUsuario du = new DALUsuario();
            ModeloUsuario u = du.GetRegistroEmail(email);
            if(email == u.Email && senha == u.Senha)
            {
                Session["id"] = u.Id;
                Session["nome"] = u.Nome;
                Session["email"] = u.Email;
                Response.Redirect("~/Default.aspx");
            } else
            {
                String msg = "<script> alert('Login ou Senha incorretos!!!'); </script>";
                Response.Write(msg);
            }
        }
    }
}