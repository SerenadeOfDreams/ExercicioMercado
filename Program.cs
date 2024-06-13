using ExercicioMercado.Modelos; //Passando o using para instanciar o que for necessário das classes da pasta Modelos.
using ExercicioMercado.Menus; // Passando o using pois as classes da pasta Menus são as que carregam as telas do sistema.

Dictionary<string, Lista> listaDeCompras = new(); // criando o dicionário que armazena as listas de compra.

// Onde o Thread.Sleep, no decorrer dos códigos, foi usado, o programa aguarda de acordo com os milisegundos dos parênteses até realizar a próxima ação.

//----------------------------------------------------------------------------------------------------------------------------
// Também no decorrer do programa, foi usado o Console.Clear() para limpar o console e deixar a visualização mais confortável.

//-----------------------------------------------------------------------------------------------------------------------------------------------------
// Onde é solicitado que o usuário insira alguma informação, é usado um Console.Write no texto de solicitação ao invés de um Console.WriteLine,
// pois o WriteLine pula uma linha para a próxima ação do programa. Com o Console.Write, o que o usuário escrever ficará na mesma linha da solicitação.

void Encerramento() // Esse é só um método estilizado para quando o usuário for encerrar o programa.
{
    // Eu usei o Console.Write nesse método para que, na 'animação' de encerramento, o programa não fique pulando uma linha a cada texto apresentado.
    // É por estética.
    Console.Clear();
    Console.Write("\tEncerrando");
    Thread.Sleep(400);
    Console.Clear();

    Console.Clear();
    Console.Write("\tEncerrando.");
    Thread.Sleep(400);
    Console.Clear();

    Console.Write("\tEncerrando..");
    Thread.Sleep(400);
    Console.Clear();

    Console.Write("\tEncerrando...");
    Thread.Sleep(400);
    Console.Clear();

    Console.Write("\tEncerrando..");
    Thread.Sleep(400);
    Console.Clear();

    Console.Write("\tEncerrando.");
    Thread.Sleep(400);
    Console.Clear();

    Console.Clear();
    Console.Write("\tEncerrando");
    Thread.Sleep(400);
    Console.Clear();

    Console.Write("\tEncerrando.");
    Thread.Sleep(400);
    Console.Clear();

    Console.Write("\tEncerrando..");
    Thread.Sleep(400);
    Console.Clear();

    Console.Write("\tEncerrando...");
    Thread.Sleep(450);
}

Dictionary<int, Menu> opcoes = new();
opcoes.Add(1, new MenuCriarLista());
opcoes.Add(2, new MenuAdicionarItem());
opcoes.Add(3, new MenuExibirLista());
opcoes.Add(4, new MenuEditarLista());
opcoes.Add(5, new MenuExcluirLista());
opcoes.Add(6, new MenuFinalizarCompra());

void ExibirMenuDoMercado() // Esse é o método principal, que direciona o usuário até as funções do programa.
{
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
            // Pega o número que o usuário digitou de opção e converte para o Console.ReadLine na mesma linha de código.
            // Essa conversão para ReadLine também funciona com variáveis do tipo decimal e double.
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
            Thread.Sleep(2000);
        }
    }
}

ExibirMenuDoMercado(); // Essa é a chamada do ponto de entrada do programa.

void VoltarAoMenu() // Esse método serve para retornar ao método ExibirMenuDoMercado após a ação desejada pelo usuário for finalizada.
{
    Console.Write("\n\tPressione qualquer tecla para voltar ao menu");
    Console.ReadKey();
    Thread.Sleep(1000);
    ExibirMenuDoMercado();
}