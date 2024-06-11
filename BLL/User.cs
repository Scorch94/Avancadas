using System;

namespace ProjetoFinal
{
    /// <summary>
    /// Representa um usuário com nome de usuário, senha e tipo.
    /// </summary>
    public class User
    {
        #region Propriedades

        /// <summary>
        /// Nome de usuário.
        /// </summary>
        public string? Username { get; set; } = null;

        /// <summary>
        /// Senha do usuário.
        /// </summary>
        public string? Password { get; set; } = null;

        /// <summary>
        /// Tipo de usuário.
        /// </summary>
        public string? Tipo { get; set; } = null;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="User"/>.
        /// </summary>
        public User() { }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="User"/> com nome de usuário, senha e tipo.
        /// </summary>
        /// <param name="username">Nome de usuário.</param>
        /// <param name="password">Senha do usuário.</param>
        /// <param name="tipo">Tipo de usuário.</param>
        public User(string username, string password, string tipo)
        {
            Username = username;
            Password = password;
            Tipo = tipo;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Retorna uma string que representa o objeto <see cref="User"/>.
        /// </summary>
        /// <returns>Uma string que representa o usuário.</returns>
        public override string ToString()
        {
            return $"{Username} - {Password} - {Tipo}";
        }

        #endregion
    }
}
