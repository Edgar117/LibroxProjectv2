using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Librox2.BO;
using Librox2.DAO;
namespace Librox2.GUI
{
    public partial class PreciosLibros : System.Web.UI.Page
    {
        Ranking RankingBO = new Ranking();
        RankingDAO RanKingDao = new RankingDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategorias();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Accion = Convert.ToString(e.CommandName);
            switch (Accion)
            {
                case "btneliminar":
                    int indexEliminar = Convert.ToInt32(e.CommandArgument);
                    GridViewRow rowEliminar = GridView1.Rows[indexEliminar];
                    string ID = Server.HtmlDecode(rowEliminar.Cells[3].Text);
                    if (ID == "")
                    {

                    }
                    else
                    {
                        RankingBO.ID = int.Parse(ID);
                        if (RanKingDao.DeletePrecio(RankingBO) == 1)
                        {
                            LoadCategorias();
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "error();", true);
                        }
                    }
                    break;
                case "btnactualizar":
                    int indexUpdate = Convert.ToInt32(e.CommandArgument);
                    GridViewRow rowUpdate = GridView1.Rows[indexUpdate];
                 //   SelectCategoria();
                    RankingBO.ID = int.Parse(Server.HtmlDecode(rowUpdate.Cells[3].Text));
                    RankingBO.Precio =float.Parse( txtPrecio.Text);
                    if (RanKingDao.UpdatePrecio(RankingBO) == 1)
                    {
                        LoadCategorias();
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
                    }
                    break;
                case "btnseleccionar":
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView1.Rows[index];
                    txtPrecio.Text = Server.HtmlDecode(row.Cells[5].Text);
                    this.DPGeneraSc.Text = Server.HtmlDecode(row.Cells[4].Text);
                    break;

                default:
                    break;
            }
        }
        private void LoadCategorias()
        {
            GridView1.DataSource = RanKingDao.ConsultarRankgin();
            GridView1.DataBind();
        }
        protected void btnRegisterPrecio_Click(object sender, EventArgs e)
        {
             RankingBO.RankingNom=DPGeneraSc.Text;
            RankingBO.Precio = float.Parse(txtPrecio.Text);
            if (RanKingDao.SaveRanking(RankingBO) == 1)
            {
                LoadCategorias();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
            }
        }
    }
}