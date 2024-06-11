using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace ProjetoFinal
{
    /// <summary>
    /// Lógica interna para Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        /// <summary>
        /// ID selecionado da linha da DataGrid.
        /// </summary>
        private string selectedId = "";

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Admin"/>.
        /// </summary>
        public Admin()
        {
            InitializeComponent();
            DataTable? dt = BLL.FullTicketsAdm();
            if (dt != null)
            {
                Datagrid_adm.ItemsSource = dt.DefaultView;
            }
        }

        /// <summary>
        /// Manipulador de evento para o clique do botão de filtro.
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento de roteamento.</param>
        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            string estado = combox_servico.Text;

            if (!string.IsNullOrEmpty(selectedId))
            {
                string msg = BLL.MudarTicket(estado, selectedId);
                MessageBox.Show(msg);
            }
            else
            {
                MessageBox.Show("Nenhuma linha selecionada.");
            }
        }

        /// <summary>
        /// Manipulador de evento para o clique do botão de geração de relatório.
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento de roteamento.</param>
        private void GenerateReportButton_Click(object sender, RoutedEventArgs e)
        {
            DataTable? dt = BLL.FullTicketsAdm();
            if (dt != null)
            {
                Datagrid_adm.ItemsSource = dt.DefaultView;
            }
        }

        /// <summary>
        /// Manipulador de evento para a mudança de seleção no ComboBox de filtro.
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento de mudança de seleção.</param>
        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Lógica a ser implementada para mudanças de seleção no ComboBox de filtro, se necessário.
        }

        /// <summary>
        /// Manipulador de evento para a mudança de seleção na DataGrid de administração.
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento de mudança de seleção.</param>
        private void Datagrid_admin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid? grid = sender as DataGrid;
            if (grid != null)
            {
                var rowview = grid.SelectedItem as DataRowView;
                if (rowview != null)
                {
                    DataRow row = rowview.Row;
                    // Assumindo que a coluna ID é a primeira coluna
                    selectedId = row[0].ToString();  // Use row[0] em vez de row.ItemArray[0] para simplificação
                }
            }
        }
    }
}
