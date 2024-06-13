using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using ExercicioMercado.Modelos; // Passando o using para que as classes da pasta Menus possam ler as classes que precisam da pasta Modelos.

namespace ExercicioMercado.Menus; // Passando o namespace de acordo com a pasta onde a classe está, para que ela possa interagir melhor com as classes que precisar.

// Quando um Console.WriteLine($""); estiver como nesse exemplo, é para pegar o valor de uma variável local ou de outra classe e
// jogar no texto sem que seja necessário abrir um Console.Write ou outra função de exibição. Isso permite que seja apresentado,
// no console, a variável que o usuário preencheu.

//-----------------------------------------------------------------------------------------------------------------------------
// Se, no console, o cliente enviar a palavra 'sair', o programa irá fechar o loop 'while' e seguir com o 'script padrão'.
// Se voltar à classe Program, você verá que, no 'switch', após a chamada de uma classe de acordo com a opção, há uma chamada
// do método VoltarAoMenu(). Essa chamada é o 'script padrão', pois ele solicita que seja digitada qualquer tecla para retornar
// ao menú do programa

internal class MenuEditarLista // Dentro dessa classe interna é onde ocorrem todos os processos dessa classe.
{
    internal void Executar(Dictionary<string, Lista> listaDeCompras)
    // O método Executar é o que realiza a ação de acordo com a opção descrita no menú principal.
    {
        Console.Clear();
        while (true)
        {
            Console.Write("\n\tInforme o título da lista a editar ou digite 'sair' para interromper: ");
            string titulo = Console.ReadLine()!;
            if (titulo.ToLower() == "sair")
            {
                Thread.Sleep(500);
                return;
            }

            if (listaDeCompras.TryGetValue(titulo, out Lista? lista)) // Verificando se foi o que foi passado é o título de alguma lista.
            {
                // Se foi:
                Console.WriteLine("\n\t1 - Editar título da lista");
                Console.WriteLine("\t2 - Editar item da lista");
                Console.Write("\n\tDigite a opção desejada: ");
                //Parecido com o switch na classe Program.

                int opcao = int.Parse(Console.ReadLine()!);

                switch (opcao)
                {
                    case 1:
                        EditarTituloDaLista(listaDeCompras, lista);
                        break;
                    case 2:
                        EditarItemDaLista(lista);
                        break;
                    default:
                        Console.WriteLine("\n\tOpção inválida.");
                        break;
                }
            }
            else
            {
                // Se não foi:
                Console.WriteLine($"\n\tLista '{titulo}' não localizada.");
            }
            break;
        }
    }

    private void EditarTituloDaLista(Dictionary<string, Lista> listaDeCompras, Lista lista)
    // Esse é o método que altera o título da lista, substituindo o que foi informado e identificado através do método acima
    // pelo novo título desejado.
    {
        while(true)
        {
            Console.Write("\n\tInforme o novo título ou digite 'sair' para interromper a edição: ");
            string novoTitulo = Console.ReadLine()!;

            if (novoTitulo.ToLower() == "sair")
            {
                Console.WriteLine("\n\tEdição cancelada.");
                Thread.Sleep(500);
                return; // Sai do método EditarTituloDaLista
            }

            // Verifica se o novo título já existe
            if (listaDeCompras.ContainsKey(novoTitulo)) // Verificando se foi o que foi passado é o título de alguma lista.
            {
                // Se foi:
                Console.WriteLine($"\n\tLista '{novoTitulo}' já existe.");
            }
            else
            {
                // Se não foi:
                string tituloOriginal = lista.Titulo;
                // Informa o programa que o titulo original dentro do método EditarTituloDaLista() é o mesmo que o título padrão da lista informada
                // no método acima.

                lista.EditarTitulo(tituloOriginal, novoTitulo);
                // Chamada do método EditarTituloDaLista(), da classe Lista.

                listaDeCompras.Remove(tituloOriginal);
                // Remoção do título anterior, chamado de 'original'.

                listaDeCompras.Add(novoTitulo, lista);
                // Adição, logo em seguida, do novo título.

                // Mesmo que o 'título 'original' tenha recebido esse nome, o título novo passa a ser o 'original' e quando é feita a alteração do título
                // mais uma vez, o que era o título 'novo', dentro do contexto desses métodos, vira o título 'original'.
            }
            break;
        }
    }

    private void EditarItemDaLista(Lista lista)
    // Método para alteração dos itens inseridos na lista.
    {
        while (true)
        {
            // O operador de loop 'while' é para que o programa retorne a um ponto específico no código e execute a ação novamente,
            // até que o usuário cancele essa ação. Aqui, ele retorna à solicitação do produto de uma lista já existente, para que
            // sejam verificados os campos existentes de produto, quantidade e valor dentro dessa lista e ocorram as alterações.

            Console.Write("\n\tInforme o produto que será editado ou digite 'sair' para interromper a edição: ");
            string produtoParaEditar = Console.ReadLine()!;

            if (produtoParaEditar.ToLower() == "sair")
            {
                Console.WriteLine("\n\tEdição cancelada.");
                Thread.Sleep(500);
                return; // Sai do método EditarItemDaLista
            }

            // Encontra o item na lista pelo produto
            Item? itemParaEditar = EncontrarItem(produtoParaEditar, lista.Itens);

            if (itemParaEditar == null)
            {
                Console.WriteLine("\n\tProduto não encontrado na lista.");
                return;
            }
            else
            {
                ProcurarCampo(itemParaEditar);
            }
            break;
        }
    }

    private void ProcurarCampo(Item itemParaEditar)
    {
        while (true)
        {
            // Aqui, o while volta à solicitação de qual campo será alterado. Após, o usuário informará o que será inserido no campo.
            // Isso se repete até que o usuário envie 'sair' no console para voltar ao menu.

            Console.Write("\n\tInforme o campo que será alterado ('produto', 'quantidade' ou 'valor') ou digite 'sair' para interromper a edição: ");
            string campoAlteracao = Console.ReadLine()!.ToLower();

            if (campoAlteracao.ToLower() == "sair")
            {
                Console.WriteLine("\n\tEdição cancelada.");
                return; // Sai do método EditarItemDaLista
            }

            if (campoAlteracao != "produto" && campoAlteracao != "quantidade" && campoAlteracao != "valor")
            // Aqui é verificado se o que foi passado no console pelo usuário corresponde ao disponível na lista para alteração.
            {
                Console.WriteLine("\n\tCampo inválido. Por favor, escolha 'produto', 'quantidade' ou 'valor'.");
                continue;
            }
            else
            {
                EditarCampo(itemParaEditar, campoAlteracao);
            }
            Console.WriteLine("\n\tEdição realizada com sucesso.");
            break; // Sai do loop após a edição ser realizada com sucesso
        }
    }

    private void EditarCampo(Item itemParaEditar, string campoAlteracao)
    {
        while (true)
        {
            string novoValorString;
            int novoValorInt;
            decimal novoValorDecimal;

            Console.Write($"\n\tInforme o novo {campoAlteracao} ou digite 'sair' para interromper a edição: ");
            novoValorString = Console.ReadLine()!;

            if (novoValorString.ToLower() == "sair")
            {
                Console.WriteLine("\n\tEdição cancelada.");
                return; // Sai do método EditarItemDaLista
            }

            switch (campoAlteracao)
            {
                // Aqui é usado o switch para consultar o que foi escrito em 'campoAlteração' e, de acordo com o case, com base no que foi passado
                // no console, o programa segue para alteração do conteúdo do campo desejado.
                case "produto":
                    // novoValorString = Console.ReadLine()!;
                    
                    if (Regex.IsMatch(novoValorString, @"^[a-zA-z]+$"))
                    {
                        itemParaEditar.Produto = novoValorString;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n\tProduto inválido. Insira um nome contendo apenas letras");
                        continue;
                    }
                case "quantidade":
                    if (int.TryParse(novoValorString, out novoValorInt) && novoValorInt > 0)
                    {
                        itemParaEditar.Quantidade = novoValorInt;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n\tValor de quantidade inválido. Por favor, insira um número inteiro.");
                        continue; // Retorna ao início do loop para solicitar o novo valor
                    }
                case "valor":
                    if (decimal.TryParse(novoValorString, out novoValorDecimal))
                    {
                        itemParaEditar.PrecoUnitario = novoValorDecimal;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n\tValor de quantidade inválido. Por favor, insira um número decimal.");
                        continue; // Retorna ao início do loop para solicitar o novo valor
                    }                
            }
            break;
        }
    }

    private Item? EncontrarItem(string produtoOriginal, List<Item> itens)
    //Esse método é para identificar um item dentro de uma lista de acordo com o produto específico que está na lista,
    //permitindo, assim, a alteração do item.
    {
        foreach (Item item in itens) //Esse foreach é para, novamente, percorrer a lista informada,
                                     //mas, dessa vez, procurando o campo 'produto' dentro da lista.
        {
            if (item.Produto == produtoOriginal)
            {
                return item;
            }
        }
        return null;
    }
}