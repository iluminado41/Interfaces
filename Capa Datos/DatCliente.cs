using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Entidad;

namespace Capa_Datos
{
    public class DatCliente
    {
        #region sigleton
        //Patron Singleton
        // Variable estática para la instancia
        private static readonly DatCliente _instancia = new DatCliente();
        //privado para evitar la instanciación directa
        public static DatCliente Instancia
        {
            get
            {
                return DatCliente._instancia;
            }
        }
        #endregion singleton
        #region metodos

        ////////////////////listado de Clientes
        public List<EntCliente> ListarCliente()
        {
            SqlCommand cmd = null;
            List<EntCliente> lista = new List<EntCliente>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spListaCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntCliente Cli = new EntCliente();
                    Cli.idCliente = Convert.ToInt32(dr["idCliente"]);
                    Cli.razonSocial = dr["razonSocial"].ToString();
                    Cli.idTipoCliente = Convert.ToInt32(dr["idTipoCliente"]);
                    Cli.fecRegCliente = Convert.ToDateTime(dr["fecRegCliente"]);
                    Cli.idCiudad = Convert.ToInt32(dr["idCiudad"]);
                    Cli.estCliente = Convert.ToBoolean(dr["estCliente"]);
                    lista.Add(Cli);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }
        #endregion metodos;
    }
}
