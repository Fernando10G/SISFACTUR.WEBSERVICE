using SISTEM.FACTUR.ENTITY.Parametros;
using SISTEM.FACTUR.ENTITY.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEM.FACTUR.DATOS
{
    public class DAPaises
    {
        public List<ResponsePais> listarPaises(ENRegistroEmpresa paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponsePais>();
                
                
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("usp_listarPaises", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponsePais();
                            resul.idpais = Convert.ToInt32(rdr["idpais"]);
                            resul.pais = Convert.ToString(rdr["pais"]);
                            lista.Add(resul);
                        }
                    }
                }
                return lista;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<ResponseMoneda> listarMoneda(ENRegistroEmpresa paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseMoneda>();


                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("usp_listarMoneda", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseMoneda();
                            resul.idmoneda = Convert.ToInt32(rdr["idmoneda"]);
                            resul.moneda = Convert.ToString(rdr["moneda"]);
                            lista.Add(resul);
                        }
                    }
                }
                return lista;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }



        public List<ResponseTImpuestos> listarTImpuestos(ENRegistroEmpresa paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseTImpuestos>();


                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("usp_listarTImpuestos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseTImpuestos();
                            resul.idtimpuestos = Convert.ToInt32(rdr["idtimpuestos"]);
                            resul.timpuestos = Convert.ToString(rdr["impuestos"]);
                            lista.Add(resul);
                        }
                    }
                }
                return lista;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<ResponsePImpuestos> listarPImpuestos(ENRegistroEmpresa paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponsePImpuestos>();


                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("usp_listarpImpuestos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponsePImpuestos();
                            resul.idpimpuestos = Convert.ToInt32(rdr["idpimpuestos"]);
                            resul.pimpuestos = Convert.ToInt32(rdr["pimpuestos"]);
                            lista.Add(resul);
                        }
                    }
                }
                return lista;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
