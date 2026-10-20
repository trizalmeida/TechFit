using System;

namespace techfitCSV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CsvManager gerenciador = new CsvManager();

            int opcao = 0;

            while (opcao != 3)
            {
                Console.WriteLine("\n===== TECH FIT =====");
                Console.WriteLine("1 - Escolher entidade");
                Console.WriteLine("2 - Listar arquivos disponíveis");
                Console.WriteLine("3 - Sair");
                Console.Write("Escolha uma opção: ");

                int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1:
                        EscolherEntidade(gerenciador);
                        break;

                    case 2:
                        MostrarArquivos(gerenciador);
                        break;

                    case 3:
                        Console.WriteLine("Encerrando sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        static void MostrarArquivos(CsvManager gerenciador)
        {
            Console.WriteLine("\n===== ENTIDADES DISPONÍVEIS =====");

            string[] arquivos = gerenciador.ListarArquivos();

            for (int i = 0; i < arquivos.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {arquivos[i]}");
            }
        }

        static void EscolherEntidade(CsvManager gerenciador)
        {
            string[] arquivos = gerenciador.ListarArquivos();

            MostrarArquivos(gerenciador);

            Console.Write("\nEscolha uma entidade: ");

            if (!int.TryParse(Console.ReadLine(), out int escolha) ||
                escolha < 1 || escolha > arquivos.Length)
            {
                Console.WriteLine("Opção inválida!");
                return;
            }

            string arquivo = arquivos[escolha - 1];

            int opcao = 0;

            while (opcao != 3)
            {
                Console.WriteLine($"\n===== {arquivo.ToUpper()} =====");
                Console.WriteLine("1 - Listar registros");
                Console.WriteLine("2 - Cadastrar registro");
                Console.WriteLine("3 - Voltar");
                Console.Write("Escolha uma opção: ");

                int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1:
                        gerenciador.ListarRegistros(arquivo);
                        break;

                    case 2:
                        gerenciador.AdicionarRegistro(arquivo);
                        break;

                    case 3:
                        Console.WriteLine("Voltando ao menu...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }
    }
}