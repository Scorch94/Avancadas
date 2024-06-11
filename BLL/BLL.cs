using System.Data;
using System.Data.SqlClient;
using ProjetoFinal;

namespace ProjetoFinal
{
    /// <summary>
    /// Classe de lógica de negócios (Business Logic Layer) para manipulação de usuários e tickets.
    /// </summary>
    public class BLL
    {
        #region Métodos para Gerenciamento de Usuários

        /// <summary>
        /// Insere um novo login de usuário no banco de dados.
        /// </summary>
        /// <param name="username">Nome de usuário.</param>
        /// <param name="password">Senha do usuário.</param>
        /// <param name="tipo">Tipo de usuário.</param>
        /// <returns>Uma string indicando o sucesso ou falha da operação.</returns>
        public static string InsertLogin(string username, string password, string tipo)
        {
            User user = new User(username, password, tipo);
            string sql = $"insert into usuario values('{user.Username}', '{user.Password}', '{user.Tipo}')";
            if (DAL.execBD(sql))
                return $"Success: {user.ToString()}";
            else
                return "Error";
        }

        /// <summary>
        /// Acede um usuário no banco de dados.
        /// </summary>
        /// <param name="username">Nome de usuário.</param>
        /// <param name="password">Senha do usuário.</param>
        /// <returns>Um objeto User se encontrado, caso contrário, null.</returns>
        public static User? Aceder(string username, string password)
        {
            string sql = "SELECT * FROM usuario WHERE nome = @username AND password = @password";
            SqlParameter[] parameters = {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };

            DataTable dt = DAL.GetUser(sql, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new User(
                    row["nome"].ToString(),
                    row["password"].ToString(),
                    row["tipo"].ToString()
                );
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Atributos

        /// <summary>
        /// Nome do colaborador atualmente logado.
        /// </summary>
        public static string colaborador;

        #endregion

        #region Métodos para Gerenciamento de Tickets

        /// <summary>
        /// Insere um novo ticket no banco de dados.
        /// </summary>
        /// <param name="servico">Tipo de serviço do ticket.</param>
        /// <param name="descricao">Descrição do ticket.</param>
        /// <returns>Uma string indicando o sucesso ou falha da operação.</returns>
        public static string InsertTicket(string servico, string descricao)
        {
            DateTime data = DateTime.Now;
            Ticket ticket = new Ticket(servico, descricao);
            string sql = $"insert into ticket (hora_criacao, hora_modificacao, colaborador, tipo_servico, estado, descricao) " +
                $"values('{data}', '{data}', '{colaborador}', '{ticket.Servico}', 'porAtender', '{ticket.Descricao}');";
            if (DAL.execBD(sql))
                return $"Success: {ticket.ToString()}";
            else
                return "Error";
        }

        /// <summary>
        /// Obtém todos os tickets associados ao colaborador atualmente logado.
        /// </summary>
        /// <returns>Um DataTable contendo os tickets, ou null se não houver tickets.</returns>
        public static DataTable? FullTickets()
        {
            string sql = $"select id, tipo_servico, descricao, estado, hora_criacao from ticket where colaborador = '{colaborador}';";
            DataTable? dt = DAL.fillDGV(sql);
            return dt;
        }

        /// <summary>
        /// Obtém todos os tickets com estado 'porAtender' ou 'emAtendimento'.
        /// </summary>
        /// <returns>Um DataTable contendo os tickets, ou null se não houver tickets.</returns>
        public static DataTable? FullTicketsAdm()
        {
            string sql = $"select id, tipo_servico, descricao, estado, hora_modificacao from ticket where estado = 'porAtender' or estado= 'emAtendimento';";
            DataTable? dt = DAL.fillDGV(sql);
            return dt;
        }

        /// <summary>
        /// Atualiza o estado de um ticket no banco de dados.
        /// </summary>
        /// <param name="estado">Novo estado do ticket.</param>
        /// <param name="id_mod">ID do ticket a ser modificado.</param>
        /// <returns>Uma string indicando o sucesso ou falha da operação.</returns>
        public static string MudarTicket(string estado, string id_mod)
        {
            DateTime data = DateTime.Now;
            string sql = $"UPDATE ticket SET estado = '{estado}', hora_modificacao = '{data}' WHERE id = '{id_mod}'";

            if (DAL.execBD(sql))
                return $"Sucesso";
            else
                return "Error";
        }

        #endregion
    }
}
