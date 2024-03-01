using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public class Conta
    {
        public string Agencia { get; set; }
        public string Numero { get; set; }
        public double Saldo { get; set; }

        // Construtor convencional
        public Conta()
        {
        }

        // Construtor especializado
        public Conta(string agencia, string numero, double saldo)
        {
            this.Agencia = agencia;
            this.Numero = numero;
            this.Saldo = saldo;
        }

        public virtual string MostrarDados()
        {
            return $"Conta - Agência: {Agencia}, Número: {Numero}, Saldo: {Saldo}";
        }
    }

}
