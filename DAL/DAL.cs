using System;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoFinal
{
    /// <summary>
    /// Classe de acesso a dados (Data Access Layer) para manipulação do banco de dados Ticket2Help.
    /// </summary>
    public class DAL
    {
        #region Campos

        /// <summary>
        /// String de conexão com o banco de dados.
        /// </summary>
        private static string conStr = @"Data Source=DESKTOP-96LAVPQ;Initial Catalog=Ticket2Help;Integrated Security=True";

        #endregion

        #region Métodos

        /// <summary>
        /// Executa uma instrução SQL no banco de dados.
        /// </summary>
        /// <param name="sql">Instrução SQL a ser executada.</param>
        /// <returns>Retorna verdadeiro se a execução foi bem-sucedida, caso contrário, falso.</returns>
        public static bool execBD(string sql)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Obtém um usuário do banco de dados com base na instrução SQL e parâmetros fornecidos.
        /// </summary>
        /// <param name="sql">Instrução SQL para obter o usuário.</param>
        /// <param name="parameters">Parâmetros SQL para a consulta.</param>
        /// <returns>Um DataTable contendo os dados do usuário, ou null se ocorrer um erro.</returns>
        public static DataTable GetUser(string sql, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    con.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Preenche um DataTable com os dados retornados pela instrução SQL fornecida.
        /// </summary>
        /// <param name="sql">Instrução SQL para obter os dados.</param>
        /// <returns>Um DataTable contendo os dados, ou null se ocorrer um erro.</returns>
        public static DataTable? fillDGV(string sql)
        {
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
