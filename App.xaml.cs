using System.Windows;
using cpll.Data;
using MySqlConnector;

namespace cpll
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (!TestarConexao())
            {
                Shutdown();
                return;
            }

            var window = new Views.MainWindowHost();
            window.Show();
        }

        private bool TestarConexao()
        {
            try
            {
                var factory = new ConnectionFactory();

                using (MySqlConnection conn = factory.CreateConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Não foi possível conectar ao banco de dados.\n\n" +
                    $"Detalhes: {ex.Message}",
                    "Falha de conexão",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return false;
            }
        }
    }

}
