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
    public class DALogin
    {
        public ResponseLogin Authenticate(ENLogin paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                var lista = new List<ResponseLogin>();


                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("usp_ValidarUserToken", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@usertoken", paramss.usertoken));
                    cmd.Parameters.Add(new SqlParameter("@passwordtoken", paramss.passwordtoken));
                    cmd.Parameters.Add(new SqlParameter("@proyecto", paramss.proyecto));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseLogin();

                            resul.responsetoken = Convert.ToString(rdr["response"]);

                            lista.Add(resul);
                        }
                    }
                }
                return lista.FirstOrDefault();
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }





        public ResponseLogin Acceder(ENLogin paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                var lista = new List<ResponseLogin>();


                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("usp_ValidarAccesos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ruc", paramss.ruc));
                    cmd.Parameters.Add(new SqlParameter("@user", paramss.user));
                    cmd.Parameters.Add(new SqlParameter("@password", paramss.pass));
                    cmd.Parameters.Add(new SqlParameter("@proyecto", paramss.proyecto));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseLogin();

                            resul.response = Convert.ToString(rdr["response"]);

                            lista.Add(resul);
                        }
                    }
                }
                return lista.FirstOrDefault();
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
