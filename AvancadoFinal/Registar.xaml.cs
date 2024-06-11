using System;
using System.Windows;
using System.Windows.Controls;

namespace ProjetoFinal
{
    /// <summary>
    /// Lógica interna para Registo.xaml
    /// </summary>
    public partial class Registo : Window
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Registo"/>.
        /// </summary>
        public Registo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Manipulador de evento para o clique do botão de fechar.
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento de roteamento.</param>
        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Manipulador de evento para o clique do botão de registrar.
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento de roteamento.</param>
        private void btn_registar_Click(object sender, RoutedEventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Text;
            string tipo = combo_box.Text;

            string msg = BLL.InsertLogin(username, password, tipo);
            MessageBox.Show(msg);
        }
    }
}
