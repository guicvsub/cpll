using System.Configuration;
using System.Data;
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
            TestarConexao();
            var window = new Views.MainWindowHost();
            window.Show();
        }

        private void TestarConexao()
        {
            try
            {
                var factory = new ConnectionFactory();

                using (MySqlConnection conn = factory.CreateConnection())
                {
                    conn.Open();
                    MessageBox.Show("✅ Conectou no banco!");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("❌ Erro ao conectar: " + ex.Message);
            }
        }
    }

}
