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
    public partial class Categoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        public void AtualizaGrid()
        {
            DALCategoria dal = new DALCategoria();
            gvCategorias.DataSource = dal.Localizar();
            gvCategorias.DataBind();
        }

        private void LimparCampos()
        {
            tbId.Text = "";
            tbNome.Text = "";
            btnSalvar.Text = "Inserir";
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string msg = "";

            ModeloCategoria obj = new ModeloCategoria();
            obj.NomeCategoria = tbNome.Text;

            DALCategoria dal = new DALCategoria();

            try
            {

                if (btnSalvar.Text == "Inserir")
                {
                    dal.Inserir(obj);
                    msg = $"<script> alert('O código gerado foi: {obj.Id}') </script>";
                } else
                {
                    obj.Id = Convert.ToInt32(tbId.Text);
                    dal.Alterar(obj);
                    msg = $"<script> alert('O registro foi alterado com sucesso') </script>";
                }

                Response.Write(msg);
                this.LimparCampos();
            }
            catch (Exception error)
            {
                Response.Write($"<script> alert('O código gerado foi: {error.Message}') </script>");
            }

            AtualizaGrid();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
        }

        protected void gvCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            int cod = Convert.ToInt32(gvCategorias.Rows[index].Cells[2].Text);
            DALCategoria dal = new DALCategoria();
            dal.Excluir(cod);
            AtualizaGrid();
        }

        protected void gvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = gvCategorias.SelectedIndex;
            int cod = Convert.ToInt32(gvCategorias.Rows[index].Cells[2].Text);
            DALCategoria dal = new DALCategoria();
            ModeloCategoria c = dal.GetRegistro(cod);

            if(c.Id != 0)
            {
                tbId.Text = c.Id.ToString();
                tbNome.Text = c.NomeCategoria.ToString();
                btnSalvar.Text = "Alterar";
            }
        }
    }
}