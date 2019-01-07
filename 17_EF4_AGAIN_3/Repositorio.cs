using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace _17_EF4_AGAIN_3
{
    public class Repositorio
    {
        public List<Cazador> CazadoresRepo { get; set; }

        CazadoresDBContext cazadoresDBContext = new CazadoresDBContext();

        public List<Cazador> GetCazadores()
        {
            return cazadoresDBContext.Cazadores.ToList();
        }

        public List<Arma> GetArmas()
        {
            return cazadoresDBContext.Armas.ToList();
        }

        public List<Cazador> GetCazadoresByArma(int ID)
        {
            List<Cazador> cazadores = new List<Cazador>();
            string cs = ConfigurationManager.ConnectionStrings["CazadoresDBContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cazadors WHERE Arma_ID = @arma", con);
                SqlParameter ParamArma = new SqlParameter("@arma", ID);
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
                    CazadoresRepo.Add(cazador);
                }
            }
            return cazadores; //Aquí se devuelve.
        }

    


    public void InsertarCazador(Cazador cazador)
        {

            cazadoresDBContext.Cazadores.Add(cazador);
            cazadoresDBContext.SaveChanges();
        }

        public void ActualizarCazador(Cazador cazador)
        {
            Cazador cazadorAActualizar = cazadoresDBContext.Cazadores.FirstOrDefault(x => x.ID == cazador.ID);
            cazadorAActualizar.Nombre = cazador.Nombre;
            cazadorAActualizar.Apellido = cazador.Apellido;
            cazadorAActualizar.Edad = cazador.Edad;
            cazadorAActualizar.Arma = cazador.Arma;

            cazadoresDBContext.SaveChanges();
        }

        public void BorrarCazador(Cazador cazador)
        {
            Cazador cazadorAborrar = cazadoresDBContext.Cazadores.FirstOrDefault(x => x.ID == cazador.ID);
            cazadoresDBContext.Cazadores.Remove(cazadorAborrar);
            cazadoresDBContext.SaveChanges();
        }
    }
}