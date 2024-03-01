using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class ContaCorrente : Conta
    {
        public double ChequeEspecial { get; set; }


        // Construtor convencional
        public ContaCorrente()
        {
        }

        // Construtor especializado
        public ContaCorrente(string agencia, string numero, double saldo, double chequeEspecial)
        {
            this.Agencia = agencia;
            this.Numero = numero;
            this.Saldo = saldo;
            this.ChequeEspecial = chequeEspecial;
        }


        // Método sobrescrito da classe pai (Conta)
        public override string MostrarDados()
        {
            return $"Conta corrente - Agência: {Agencia}, Número: {Numero}, Saldo: {Saldo}, Cheque Especial: {ChequeEspecial}";
        }
    }

}
