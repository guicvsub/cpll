using System.Windows;
using System.Windows.Controls;
using cpll.Controllers;
using cpll.Models;

namespace cpll.Views
{
    public partial class MainWindowHost : Window
    {
        private readonly AlunoController _controller = new AlunoController();

        public MainWindowHost()
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

                MessageBox.Show("Aluno inserido.");

                LimparFormulario();
                AtualizarGrade();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (GridAlunos.SelectedItem is not Aluno selecionado)
                {
                    MessageBox.Show("Selecione um aluno na grade.");
                    return;
                }

                string nome = TxtNome.Text;
                string email = TxtEmail.Text;
                int idade = int.Parse(TxtIdade.Text);

                _controller.Atualizar(selecionado.Id, nome, email, idade);

                MessageBox.Show("Aluno atualizado.");
                AtualizarGrade();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (GridAlunos.SelectedItem is not Aluno selecionado)
                {
                    MessageBox.Show("Selecione um aluno na grade.");
                    return;
                }

                _controller.Excluir(selecionado.Id);
                MessageBox.Show("Aluno excluído.");
                LimparFormulario();
                AtualizarGrade();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void BtnListar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AtualizarGrade();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            LimparFormulario();
        }

        private void GridAlunos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GridAlunos.SelectedItem is Aluno a)
            {
                TxtNome.Text = a.Nome;
                TxtEmail.Text = a.Email;
                TxtIdade.Text = a.Idade.ToString();
            }
        }

        private void LimparFormulario()
        {
            TxtNome.Clear();
            TxtEmail.Clear();
            TxtIdade.Clear();
            GridAlunos.SelectedItem = null;
        }

        private void AtualizarGrade()
        {
            GridAlunos.ItemsSource = null;
            GridAlunos.ItemsSource = _controller.Listar();
        }
    }
}
