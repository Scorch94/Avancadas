using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System; 
using System.Windows; 

namespace ProjetoFinal.Tests 
{
    [TestClass] // Indica que a classe contém métodos de teste
    public class MainWindowTests 
    {
        private bool mainWindowClosed; // Variável para verificar se a janela MainWindow foi fechada

        [TestInitialize] // Método de inicialização dos testes
        public void TestInitialize() 
        {
            mainWindowClosed = false; 
        }

        [TestMethod] // Indica que o método é um teste unitário
        public void Button_Click_ValidUser_ClientWindowOpened() // Teste para o clique do botão com um usuário válido
        {
            // Arrange (Organizar): Prepara o cenário de teste
            var mainWindow = new MainWindow(); 
            var mockMessageBox = new Mock<IMessageBoxWrapper>(); 
            var expectedUsername = "validUser"; 
            var expectedPassword = "validPassword"; 
            var expectedUser = new User(expectedUsername, expectedPassword, "Cliente");

            mainWindow.Closed += (sender, e) => mainWindowClosed = true; // Adiciona um evento para verificar se a janela foi fechada

            // Act (Atuar): Executa a ação que será testada
            mainWindow.txt_username.Text = expectedUsername; 
            mainWindow.txt_password.Text = expectedPassword;
            mainWindow.Button_Click(null, null); 

            // Assert (Afirmação): Verifica se o resultado esperado ocorreu
            Assert.IsTrue(mainWindowClosed);
            Assert.IsInstanceOfType(Application.Current.Windows[0], typeof(Utilizador)); 
            Assert.AreEqual(BLL.colaborador, expectedUsername);
            mockMessageBox.Verify(m => m.Show(It.IsAny<string>()), Times.Never); 
        }

        // Outros métodos de teste

        public interface IMessageBoxWrapper // Interface para envolver a funcionalidade da caixa de mensagem
        {
            MessageBoxResult Show(string messageBoxText); // Método para exibir uma caixa de mensagem com um texto
        }
    }
}

