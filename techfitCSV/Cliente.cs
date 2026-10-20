using System;

namespace TechFitCSV
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string CartaoAcesso { get; set; }
        public int IdPlano { get; set; }
        public DateTime InicioPlano { get; set; }

        public Cliente(int idCliente, string nome, int idade,
            DateTime dataNascimento, string sexo, string cartaoAcesso,
            int idPlano, DateTime inicioPlano)
        {
            IdCliente = idCliente;
            Nome = nome;
            Idade = idade;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            CartaoAcesso = cartaoAcesso;
            IdPlano = idPlano;
            InicioPlano = inicioPlano;
        }
    }
}