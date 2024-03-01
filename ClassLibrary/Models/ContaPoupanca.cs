using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class ContaPoupanca : Conta
    {
        public double Rentabilidade { get; set; }


        // Construtor convencional
        public ContaPoupanca()
        {
        }

        // Construtor especializado
        public ContaPoupanca(string agencia, string numero, double saldo, double rentabilidade)
        {
            this.Agencia = agencia;
            this.Numero = numero;
            this.Saldo = saldo;
            this.Rentabilidade = rentabilidade;
        }


        // Método sobrescrito da classe pai (Conta)
        public override string MostrarDados()
        {
            return $"Conta poupança - Agência: {Agencia}, Número: {Numero}, Saldo: {Saldo}, Rentabilidade: {Rentabilidade}";
        }

    }

}
