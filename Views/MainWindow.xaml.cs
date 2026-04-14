using System.Windows;
using System.Windows.Controls;
using cpll.Controllers;


namespace cpllv2.Views
{
    public partial class MainWindow : Page
    {
        private readonly AlunoController _controller = new AlunoController();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnInserir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nome = TxtNome.Text;
                string email = TxtEmail.Text;
                int idade = int.Parse(TxtIdade.Text);

                _controller.Criar(nome, email, idade);

                MessageBox.Show("✅ Aluno inserido!");

                TxtNome.Clear();
                TxtEmail.Clear();
                TxtIdade.Clear();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("❌ Erro: " + ex.Message);
            }
        }

        private void BtnListar_Click(object sender, RoutedEventArgs e)
        {
            var alunos = _controller.Listar();

            string resultado = "";

            foreach (var a in alunos)
            {
                resultado += $"{a.Nome} - {a.Email}\n";
            }

            MessageBox.Show(resultado);
        }
    }
}