using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace ProjetoFinal
{
    /// <summary>
    /// Lógica interna para Utilizador.xaml
    /// </summary>
    public partial class Utilizador : Window
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Utilizador"/>.
        /// </summary>
        public Utilizador()
        {
            InitializeComponent();
            DataTable? dt = BLL.FullTickets();
            if (dt != null)
            {
                Datagrid_utilizador.ItemsSource = dt.DefaultView;
            }
        }

        /// <summary>
        /// Manipulador de evento para o clique do botão de adicionar ticket.
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento de roteamento.</param>
        private void AddTicketButton_Click(object sender, RoutedEventArgs e)
        {
            string servico = combox_servico.Text;
            string descricao = txt_descricao.Text;

            string msg = BLL.InsertTicket(servico, descricao);
            MessageBox.Show(msg);
        }

        /// <summary>
        /// Manipulador de evento para a mudança de seleção na DataGrid de utilizador.
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento de mudança de seleção.</param>
        private void Datagrid_utilizador_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid? grid = sender as DataGrid;
            if (grid != null)
            {
                var rowview = grid.SelectedItem as DataRowView;
                if (rowview != null)
                {
                    DataRow row = rowview.Row;
                    // Lógica a ser implementada ao selecionar uma linha, se necessário.
                }
            }
        }

        /// <summary>
        /// Manipulador de evento para o clique do botão de atualizar.
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento de roteamento.</param>
        private void AddRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            DataTable? dt = BLL.FullTickets();
            if (dt != null)
            {
                Datagrid_utilizador.ItemsSource = dt.DefaultView;
            }
        }
    }
}
