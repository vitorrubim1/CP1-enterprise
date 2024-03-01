using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class ContaSalario : Conta
    {
        public double SalarioMensal { get; set; }


        // Construtor convencional
        public ContaSalario()
        {
        }

        // Construtor especializado
        public ContaSalario(string agencia, string numero, double saldo, double salarioMensal)
        {
            this.Agencia = agencia;
            this.Numero = numero;
            this.Saldo = saldo;
            this.SalarioMensal = salarioMensal;
        }

        // Construtor que chama outro construtor
        public ContaSalario(string agencia, string numero, double salarioMensal) : this(agencia, numero, 0, salarioMensal)
        {
        }
    
        // Métodos private, protected e internal
        private void DeduzirImpostosDoSalario()
        {
            Console.WriteLine("Impostos deduzidos do salário.");
        }

        protected void PagarBonusAoTitular()
        {
            Console.WriteLine("Bônus pago ao titular da conta.");
        }

        internal void NotificarDepartamentoRH()
        {
            Console.WriteLine("Notificação enviada ao RH.");
        }

        public void ExibirLogs()
        {
            DeduzirImpostosDoSalario();
            PagarBonusAoTitular();  
            NotificarDepartamentoRH();
        }

        // Método sobrescrito da classe pai (Conta)
        public override string MostrarDados()
        {
            return $"Conta salário - Agência: {Agencia}, Número: {Numero}, Saldo: {Saldo}, Salário mensal: {SalarioMensal}";
        }

    }

}
