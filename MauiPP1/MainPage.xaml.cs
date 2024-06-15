using System;

namespace MauiPP1
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BTNola_Clicked(object sender, EventArgs e)
        {
            // Verifica se os campos de entrada estão preenchidos
            if (string.IsNullOrWhiteSpace(quantidadeDadosEntry.Text) || string.IsNullOrWhiteSpace(ladosDadosEntry.Text))
            {
                await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
                return;
            }

            // Converte os valores das entradas para inteiros
            if (!int.TryParse(quantidadeDadosEntry.Text, out int quantidadeDados) || !int.TryParse(ladosDadosEntry.Text, out int ladosDados))
            {
                await DisplayAlert("Erro", "Por favor, insira números válidos.", "OK");
                return;
            }

            // Verifica se os valores inseridos são válidos
            if (quantidadeDados <= 0 || ladosDados <= 0)
            {
                await DisplayAlert("Erro", "Por favor, insira valores maiores que zero.", "OK");
                return;
            }

            // Gera números aleatórios para simular o lançamento dos dados
            Random random = new Random();
            int total = 0;
            string resultado = "";

            for (int i = 0; i < quantidadeDados; i++)
            {
                int valorDado = random.Next(1, ladosDados + 1); // Gera um número entre 1 e ladosDados
                total += valorDado;
                resultado += $"Dado {i + 1}: {valorDado}\n";
            }

            // Exibe o resultado em um alerta
            await DisplayAlert("Resultado", $"Resultado total: {total}\n\n{resultado}", "OK");
        }
    }
}
