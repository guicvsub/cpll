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
                if (!TryGetDadosFormulario(out string nome, out string email, out int idade))
                {
                    return;
                }

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

                if (!TryGetDadosFormulario(out string nome, out string email, out int idade))
                {
                    return;
                }

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

        private bool TryGetDadosFormulario(out string nome, out string email, out int idade)
        {
            nome = TxtNome.Text.Trim();
            email = TxtEmail.Text.Trim();
            idade = 0;

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Informe o nome do aluno.");
                TxtNome.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            {
                MessageBox.Show("Informe um e-mail válido.");
                TxtEmail.Focus();
                return false;
            }

            if (!int.TryParse(TxtIdade.Text, out idade) || idade < 0)
            {
                MessageBox.Show("Informe uma idade válida (número inteiro maior ou igual a 0).");
                TxtIdade.Focus();
                return false;
            }

            return true;
        }
    }
}
