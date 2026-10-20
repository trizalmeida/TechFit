using System;
using System.IO;

namespace techfitCSV
{
    internal class CsvManager
    {
        private readonly string pastaDados =
            Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Dados");

        private readonly string[] arquivos =
        {
            "clientes.csv",
            "Planos.csv",
            "Matriculas.csv",
            "funcionario.csv",
            "cargos.csv",
            "administradores.csv",
            "representantes.csv",
            "marcas.csv",
            "Aparelhos.csv",
            "Estoque_Interno.csv",
            "Estoque_vendas.csv"
        };

        public string[] ListarArquivos()
        {
            return arquivos;
        }

        public void ListarRegistros(string arquivo)
        {
            string caminho = Path.Combine(pastaDados, arquivo);

            if (!File.Exists(caminho))
            {
                Console.WriteLine("Arquivo não encontrado: " + caminho);
                return;
            }

            string[] linhas = File.ReadAllLines(caminho);

            foreach (string linha in linhas)
            {
                Console.WriteLine(linha);
            }
        }

        public void AdicionarRegistro(string arquivo)
        {
            string caminho = Path.Combine(pastaDados, arquivo);

            if (!File.Exists(caminho))
            {
                Console.WriteLine("Arquivo não encontrado: " + caminho);
                return;
            }

            string[] cabecalho = File.ReadAllLines(caminho)[0].Split(';');
            string[] valores = new string[cabecalho.Length];

            Console.WriteLine("\nPreencha os campos abaixo:");

            for (int i = 0; i < cabecalho.Length; i++)
            {
                Console.Write(cabecalho[i] + ": ");
                valores[i] = Console.ReadLine() ?? "";

                if (valores[i].Contains(';'))
                {
                    Console.WriteLine("Não utilize ponto e vírgula.");
                    return;
                }
            }

            string novoRegistro = string.Join(";", valores);

            File.AppendAllText(
                caminho,
                novoRegistro + Environment.NewLine
            );

            Console.WriteLine("Registro cadastrado com sucesso!");
        }
    }
}