using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;

namespace CalculadoraAportes
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Calcular_Clicked(object sender, EventArgs e)
        {
            // Variables
            decimal salarioBasico;
            decimal aporteSalud;
            decimal aportePension;
            decimal aporteFPS = 0;
            decimal salarioNeto;

            // Obtener el salario básico ingresado por el usuario
            if (!decimal.TryParse(SalarioEntry.Text, out salarioBasico))
            {
                DisplayAlert("Error", "Ingrese un valor numérico válido para el salario básico.", "OK");
                return;
            }

            // Cálculos
            aporteSalud = salarioBasico * 0.04m;
            aportePension = salarioBasico * 0.04m;

            // Verificar si el salario es igual o superior a 4 salarios mínimos
            if (salarioBasico >= (4 * SalarioMinimo))
            {
                if (salarioBasico < 16 * SalarioMinimo)
                    aporteFPS = salarioBasico * 0.01m;
                else if (salarioBasico < 17 * SalarioMinimo)
                    aporteFPS = salarioBasico * 0.012m;
                else if (salarioBasico < 18 * SalarioMinimo)
                    aporteFPS = salarioBasico * 0.014m;
                else if (salarioBasico < 19 * SalarioMinimo)
                    aporteFPS = salarioBasico * 0.016m;
                else if (salarioBasico < 20 * SalarioMinimo)
                    aporteFPS = salarioBasico * 0.018m;
                else
                    aporteFPS = salarioBasico * 0.02m;
            }

            // Calcular salario neto
            salarioNeto = salarioBasico - aporteSalud - aportePension - aporteFPS;

            // Mostrar resultados
            AporteSaludLabel.Text = $"Aporte a salud: {aporteSalud:C}";
            AportePensionLabel.Text = $"Aporte a pensión: {aportePension:C}";
            AporteFPSLabel.Text = $"Aporte FPS: {aporteFPS:C}";
            SalarioNetoLabel.Text = $"Salario neto: {salarioNeto:C}";
        }

        // Constante para el salario mínimo
        const decimal SalarioMinimo = 1000; // Este valor debe ser ajustado según el salario mínimo en tu país
    }
}
