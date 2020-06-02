using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados
{

    public class DUsuario
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public int Inserir(DUsuario usuario)
        {
            int ret = 0;
            SqlConnection sqlCon = null;
            SqlCommand sqlCmd = null;

            try
            {
                sqlCon = new SqlConnection();
                sqlCon.ConnectionString = Conexao.Cn;

                sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "";
                ret = sqlCmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                ret = 0;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }

            return ret;
        }


        public int Login(DUsuario usuario)
        {
            int ret = 0;
            SqlConnection sqlCon = null;
            SqlCommand sqlCmd = null;
            DataTable dtRes = new DataTable("usuarios");

            try
            {
                sqlCon = new SqlConnection();
                sqlCon.ConnectionString = Conexao.Cn;
                sqlCon.Open();

                sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "select id from usuarios " +
                                     "where usuario = '"+ Usuario +"' and senha = '"+Senha+"'";

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtRes);

                foreach(DataRow dtRow in dtRes.Rows)
                {
                    ret = Convert.ToInt32( dtRow["id"] );                     
                }

            }
            catch (Exception ex)
            {
                ret = 0;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }

            return ret;
        }


    }
}
