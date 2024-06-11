using System;
using System.Windows;
using System.Windows.Controls;

namespace ProjetoFinal
{

    /// <summary>
    /// Lógica de interação para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="MainWindow"/>.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Manipulador de evento para o clique do botão de login.
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento de roteamento.</param>
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Text;

            User? user = BLL.Aceder(username, password);
            if (user != null)
            {
                MessageBox.Show("Login com sucesso!");

                if (user.Tipo == "Cliente")
                {
                    // Navega para a janela Utilizador
                    Utilizador utilizador = new Utilizador();
                    BLL.colaborador = username;
                    utilizador.Show();
                }
                else if (user.Tipo == "Tecnico")
                {
                    // Navega para a janela Admin
                    Admin admin = new Admin();
                    admin.Show();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro: nome ou senha invalidos");
            }
        }

        /// <summary>
        /// Manipulador de evento para a mudança de seleção no ComboBox de função.
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento de mudança de seleção.</param>
        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Lógica a ser implementada para mudanças de seleção no ComboBox de função, se necessário.
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
        /// Manipulador de evento para o clique do botão de registro.
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento de roteamento.</param>
        private void btn_register_Click(object sender, RoutedEventArgs e)
        {
            Registo registo = new Registo();
            registo.Show();
        }
    }
}
