using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public Conta Conta { get; set; } = new Conta();

        // Construtor convencional
        public Cliente()
        {
        }

        // Construtor especializado
        public Cliente(int id, string nome, int idade, string email, Conta conta)
        {
            this.Id = id;
            this.Nome = nome;
            this.Idade = idade;
            this.Email = email;
            this.Conta = conta;
        }

        public string MostrarDados()
        {
            return $"Cliente - ID: {Id}, Nome: {Nome}, Idade: {Idade}, Email: {Email}, \nDados da conta: {Conta.MostrarDados()}";
        }
    }
}
