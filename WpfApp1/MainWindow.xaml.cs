using System;
using System.Windows;
using MiniCrudEscola.Models;
using MiniCrudEscola.Data;

namespace MiniCrudEscola
{
    public partial class MainWindow : Window
    {
        private AlunoDAO dao = new AlunoDAO();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Inserir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Aluno aluno = new Aluno
                {
                    Nome = txtNome.Text,
                    Idade = int.Parse(txtIdade.Text)
                };

                dao.Inserir(aluno);
                MessageBox.Show("Aluno inserido!");
                Listar_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void Listar_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = dao.Listar();
        }

        private void Atualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Aluno aluno = new Aluno
                {
                    Id = int.Parse(txtId.Text),
                    Nome = txtNome.Text,
                    Idade = int.Parse(txtIdade.Text)
                };

                dao.Atualizar(aluno);
                MessageBox.Show("Aluno atualizado!");
                Listar_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void Remover_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                dao.Remover(id);

                MessageBox.Show("Aluno removido!");
                Listar_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
    }
}