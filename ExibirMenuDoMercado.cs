using ExercicioMercado.Modelos;
using ExercicioMercado.Menus;

partial class Program
{
    public static Dictionary<string, Lista> listaDeCompras = new();

    static void
    ExibirMenuDoMercado()
    {

        Dictionary<int, Menu> opcoes = new();
        opcoes.Add(1, new MenuCriarLista());
        opcoes.Add(2, new MenuAdicionarItem());
        opcoes.Add(3, new MenuExibirLista());
        opcoes.Add(4, new MenuEditarLista());
        opcoes.Add(5, new MenuExcluirLista());
        opcoes.Add(6, new MenuFinalizarCompra());

        while (true)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n\t1 - Criar lista de compras");
                Console.WriteLine("\t2 - Preencher lista de compras");
                Console.WriteLine("\t3 - Visualizar lista de compras");
                Console.WriteLine("\t4 - Editar lista de compras");
                Console.WriteLine("\t5 - Excluir lista de compras");
                Console.WriteLine("\t6 - Finalizar compra");
                Console.WriteLine("\t7 - Sair");
                Console.Write("\n\tDigite a opção desejada: ");

                int opcao = int.Parse(Console.ReadLine()!);

                if (opcoes.ContainsKey(opcao))
                {
                    Menu menuASerExibido = opcoes[opcao];
                    menuASerExibido.Executar(listaDeCompras);
                    VoltarAoMenu();
                }
                else if (opcao == 7)
                {
                    Encerramento();
                }
                else
                {
                    Console.WriteLine("\n\tOpção inválida.");
                    continue;
                }
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\tHouve um problema: {ex.Message}");
                Thread.Sleep(3000);
            }
        }
    }
}