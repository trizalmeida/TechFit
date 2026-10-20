using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace TechFitCSV
{
    public class ClienteCSV
    {
        private string caminho = "clientes.csv";

        public ClienteCSV()
        {
            if (!File.Exists(caminho))
            {
                File.WriteAllText(caminho,
                    "id_cliente;nome;idade;data_nascimento;sexo;cartao_acesso;id_plano;inicio_plano"
                    + Environment.NewLine);
            }
        }

        public List<Cliente> LerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            string[] linhas = File.ReadAllLines(caminho);

            for (int i = 1; i < linhas.Length; i++)
            {
                string[] dados = linhas[i].Split(';');

                if (dados.Length != 8)
                    continue;

                if (!int.TryParse(dados[0], out int id))
                    continue;

                if (!int.TryParse(dados[2], out int idade))
                    continue;

                if (!int.TryParse(dados[6], out int idPlano))
                    continue;

                if (!DateTime.TryParse(dados[3], out DateTime nascimento))
                    continue;

                if (!DateTime.TryParse(dados[7], out DateTime inicioPlano))
                    continue;

                Cliente cliente = new Cliente(
                    id,
                    dados[1],
                    idade,
                    nascimento,
                    dados[4],
                    dados[5],
                    idPlano,
                    inicioPlano
                );

                clientes.Add(cliente);
            }

            return clientes;
        }

        public void EscreverCliente(Cliente cliente)
        {
            string linha = string.Join(";",
                cliente.IdCliente,
                cliente.Nome,
                cliente.Idade,
                cliente.DataNascimento.ToString("yyyy-MM-dd"),
                cliente.Sexo,
                cliente.CartaoAcesso,
                cliente.IdPlano,
                cliente.InicioPlano.ToString("yyyy-MM-dd")
            );

            File.AppendAllText(caminho, linha + Environment.NewLine);
        }
    }
}