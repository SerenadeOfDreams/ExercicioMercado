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
        Console.Write("\n\tInforme o título da lista a editar: ");
        string titulo = Console.ReadLine()!;

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
    }

    private void EditarTituloDaLista(Dictionary<string, Lista> listaDeCompras, Lista lista)
    // Esse é o método que altera o título da lista, substituindo o que foi informado e identificado através do método acima
    // pelo novo título desejado.
    {
        Console.Write("\n\tInforme o novo título: ");
        string novoTitulo = Console.ReadLine()!;

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

            lista.EditarTituloDaLista(tituloOriginal, novoTitulo);
            // Chamada do método EditarTituloDaLista(), da classe Lista.

            listaDeCompras.Remove(tituloOriginal);
            // Remoção do título anterior, chamado de 'original'.

            listaDeCompras.Add(novoTitulo, lista);
            // Adição, logo em seguida, do novo título.

            // Mesmo que o 'título 'original' tenha recebido esse nome, o título novo passa a ser o 'original' e quando é feita a alteraçaõ do título
            // mais uma vez, o que era o título 'novo', dentro do contexto desses métodos, vira o título 'original'.
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

            if (produtoParaEditar == "sair")
            {
                Console.WriteLine("\n\tEdição cancelada.");
                Thread.Sleep(500);
                return; // Sai do método EditarItemDaLista
            }

            // Encontra o item na lista pelo produto
            Item itemParaEditar = lista.EncontrarItem(produtoParaEditar);

            if (itemParaEditar == null)
            {
                Console.WriteLine("\n\tProduto não encontrado na lista.");
                return;
            }

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
                    return;
                }
            
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
                        itemParaEditar.Produto = novoValorString;
                        break;
                    case "quantidade":
                        if (!int.TryParse(novoValorString, out novoValorInt))
                        {
                            Console.WriteLine("\n\tValor de quantidade inválido. Por favor, insira um número inteiro.");
                            continue; // Retorna ao início do loop para solicitar novo valor
                        }
                        itemParaEditar.Quantidade = novoValorInt;
                        break;
                    case "valor":
                        if (!decimal.TryParse(novoValorString, out novoValorDecimal))
                        {
                            Console.WriteLine("\n\tValor de quantidade inválido. Por favor, insira um número decimal.");
                            continue; // Retorna ao início do loop para solicitar novo valor
                        }
                        itemParaEditar.Valor = novoValorDecimal;
                        break;
                }

                Console.WriteLine("\n\tEdição realizada com sucesso.");
                break; // Sai do loop após a edição ser realizada com sucesso  
            }

        }

    }

}

