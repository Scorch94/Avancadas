using System;

namespace ProjetoFinal
{
    /// <summary>
    /// Representa um ticket com detalhes de criação, modificação, colaborador, serviço, estado e descrição.
    /// </summary>
    public class Ticket
    {
        #region Propriedades

        /// <summary>
        /// Identificador do ticket.
        /// </summary>
        public int? Id { get; set; } = null;

        /// <summary>
        /// Data e hora de criação do ticket.
        /// </summary>
        public DateTime Hora_criacao { get; set; } = DateTime.Now;

        /// <summary>
        /// Data e hora da última modificação do ticket.
        /// </summary>
        public DateTime? Hora_modificacao { get; set; } = null;

        /// <summary>
        /// Nome do colaborador responsável pelo ticket.
        /// </summary>
        public string? Colaborador { get; set; } = null;

        /// <summary>
        /// Tipo de serviço do ticket.
        /// </summary>
        public string? Servico { get; set; } = null;

        /// <summary>
        /// Estado atual do ticket.
        /// </summary>
        public string? Estado { get; set; } = null;

        /// <summary>
        /// Descrição detalhada do ticket.
        /// </summary>
        public string? Descricao { get; set; } = null;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Ticket"/>.
        /// </summary>
        public Ticket() { }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Ticket"/> com todos os parâmetros.
        /// </summary>
        /// <param name="id">Identificador do ticket.</param>
        /// <param name="hora_criacao">Data e hora de criação do ticket.</param>
        /// <param name="hora_modificacao">Data e hora da última modificação do ticket.</param>
        /// <param name="colaborador">Nome do colaborador responsável pelo ticket.</param>
        /// <param name="servico">Tipo de serviço do ticket.</param>
        /// <param name="estado">Estado atual do ticket.</param>
        /// <param name="descricao">Descrição detalhada do ticket.</param>
        public Ticket(int id, DateTime hora_criacao, DateTime hora_modificacao, string colaborador, string servico, string estado, string descricao)
        {
            Id = id;
            Hora_criacao = hora_criacao;
            Hora_modificacao = hora_modificacao;
            Colaborador = colaborador;
            Servico = servico;
            Estado = estado;
            Descricao = descricao;
        }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Ticket"/> com serviço e descrição.
        /// </summary>
        /// <param name="servico">Tipo de serviço do ticket.</param>
        /// <param name="descricao">Descrição detalhada do ticket.</param>
        public Ticket(string servico, string descricao)
        {
            Servico = servico;
            Descricao = descricao;
        }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Ticket"/> com identificador, serviço e descrição.
        /// </summary>
        /// <param name="id">Identificador do ticket.</param>
        /// <param name="servico">Tipo de serviço do ticket.</param>
        /// <param name="descricao">Descrição detalhada do ticket.</param>
        public Ticket(int id, string servico, string descricao) : this(servico, descricao)
        {
            Id = id;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Retorna uma string que representa o objeto <see cref="Ticket"/>.
        /// </summary>
        /// <returns>Uma string que representa o ticket.</returns>
        public override string ToString()
        {
            return $"{Id} - {Hora_criacao} - {Colaborador} - {Servico} - {Descricao}";
        }

        #endregion
    }
}
