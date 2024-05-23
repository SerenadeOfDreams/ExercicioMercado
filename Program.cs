using ExercicioMercado.Modelos; //Passando o using para instanciar o que for necessário das classes da pasta Modelos.
using ExercicioMercado.Menus; // Passando o using pois as classes da pasta Menus são as que carregam as telas do sistema.

Dictionary<string, Lista> listaDeCompras = new(); // criando o dicionário que armazena as listas de compra.

// Onde o Thread.Sleep, no decorrer dos códigos, foi usado, o programa aguarda de acordo com os milisegundos dos parênteses até realizar a próxima ação.

//----------------------------------------------------------------------------------------------------------------------------
// Também no decorrer do programa, foi usado o Console.Clear() para limpar o console e deixar a visualização mais confortável.

//-----------------------------------------------------------------------------------------------------------------------------------------------------
// Onde é solicitado que o usuário insira alguma informação, é usado um Console.Write no texto de solicitação ao invés de um Console.WriteLine,
// pois o WriteLine pula uma linha para a próxima ação do programa. Com o Console.Write, o que o usuário escrever ficará na mesma linha da solicitação.

void VoltarAoMenu() // Esse método serve para retornar ao método ExibirMenuDoMercado após a ação desejada pelo usuário for finalizada.
{
    Console.Write("\n\tPressione qualquer tecla para voltar ao menu");
    Console.ReadKey();
    Thread.Sleep(2000);
    ExibirMenuDoMercado();
}

void Encerramento() // Esse é só um método estilizado para quando o usuário for encerrar o programa.
{
    // Eu usei o Console.Write nesse método para que, na 'animação' de encerramento, o programa não fique pulando uma linha a cada texto apresentado.
    // É por estética.
    Console.Clear();
    Console.Write("\t.");
    Thread.Sleep(400);
    Console.Clear();

    Console.Write("\t..");
    Thread.Sleep(400);
    Console.Clear();

    Console.Write("\t...");
    Thread.Sleep(400);
    Console.Clear();

    Console.Write("\t..");
    Thread.Sleep(400);
    Console.Clear();

    Console.Write("\t.");
    Thread.Sleep(400);
    Console.Clear();

    Console.Write("\t");
    Thread.Sleep(400);
    Console.Clear();

    Console.Write("\t.");
    Thread.Sleep(400);
    Console.Clear();

    Console.Write("\t..");
    Thread.Sleep(400);
    Console.Clear();

    Console.Write("\t...");
    Thread.Sleep(400);
    Console.Clear();

    Console.Write("\t..");
    Thread.Sleep(400);
    Console.Clear();

    Console.Write("\t.");
    Thread.Sleep(400);
    Console.Clear();

    Console.Write("\t");
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

void ExibirMenuDoMercado() // Esse é o método principal, que direciona o usuário até as funções do programa.
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

    switch(opcao) // Pega o número passado no Console.ReadLine e, de acordo com a opção, realiza a função especificada dentro de cada 'case'.
    {
        case 1: // O case 1 cria uma lista de compras.
            MenuCriarLista menu1 = new MenuCriarLista();
            menu1.Executar(listaDeCompras);
            VoltarAoMenu();
            break;
        case 2: // I case 2 adiciona um item à lista de compras já criada.
            MenuAdicionarItem menu2 = new MenuAdicionarItem();
            menu2.Executar(listaDeCompras);
            VoltarAoMenu();
            break;
        case 3: // O case 3 exibe uma lista de compras já criada.
            MenuExibirLista menu3 = new MenuExibirLista();
            menu3.Executar(listaDeCompras);
            VoltarAoMenu();
            break;
        case 4: // O case 4 permite a edição de uma lista de compras já criada.
            MenuEditarLista menu4 = new MenuEditarLista();
            menu4.Executar(listaDeCompras);
            VoltarAoMenu();
            break;
        case 5: // O case 5 permite a exclusão de uma lista de compras já criada.
            MenuExcluirLista menu5 = new MenuExcluirLista();
            menu5.Executar(listaDeCompras);
            VoltarAoMenu();
            break;
        case 6: // O case 6 finaliza a compra de acordo com a lista passada pelo usuário.
            MenuFinalizarCompra menu6 = new MenuFinalizarCompra();
            menu6.Executar(listaDeCompras);
            VoltarAoMenu();
            break;
        case 7: // O case 7 é para fechar o programa.
            Encerramento();
            break;
        default: // O default é para caso o usuário insira qualquer coisa na opção que não seja um número inteiro e que seja dentro da faixa de opções.
            Console.WriteLine("\n\tOpção inválida.");
            break;
    }

}

ExibirMenuDoMercado(); // Essa é a chamada do ponto de entrada do programa.