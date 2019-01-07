using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace _17_EF4_AGAIN_3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataTable dataTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList2.Items.Insert(0, new ListItem("seleccione tablaaaaa", "-1"));
            DropDownList2.DataBind();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Nombre");
            dataTable.Columns.Add("Apellido");
            dataTable.Columns.Add("Edad");
            dataTable.Columns.Add("ID_arma");
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        { 
            List<Cazador> cazadores = new List<Cazador>();
            string cs = ConfigurationManager.ConnectionStrings["CazadoresDBContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cazadors WHERE Arma_ID = @arma", con);
                SqlParameter ParamArma = new SqlParameter("@arma", DropDownList1.SelectedValue);
                cmd.Parameters.Add(ParamArma);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())

                {
                    //Se irán cargando los datos en los atributos de persona
                    Cazador cazador = new Cazador(); //Creamos la clase Persona y la instanciamos
                    cazador.ID = Convert.ToInt32(rdr["ID"]); //para convertir a entero.
                    cazador.Nombre = rdr["dni"].ToString();
                    cazador.Apellido = rdr["nombre"].ToString();
                    cazador.Edad = Convert.ToInt32(rdr["Edad"]);
                    cazadores.Add(cazador);//Aquí se añadirá a la lista

                    DataRow dataRow = dataTable.NewRow();
                    dataRow["ID"] = cazador.ID;
                    dataRow["Nombre"] = cazador.Nombre;
                    dataRow["Apellido"] = cazador.Apellido;
                    dataRow["Edad"] = cazador.Edad;

                    dataTable.Rows.Add(dataRow);
                }
                con.Close();
                
            }

            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DropDownList1.Items.Insert(0, new ListItem("seleccione tabla", "-1"));
            DropDownList1.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("selecciona una tabla", "-1"));
            DropDownList2.DataBind();
        }
    }
}