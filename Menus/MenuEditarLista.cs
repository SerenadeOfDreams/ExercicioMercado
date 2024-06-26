using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using ExercicioMercado.Modelos;

namespace ExercicioMercado.Menus;

internal class MenuEditarLista : Menu
{
    public override void Executar(Dictionary<string, Lista> listaDeCompras)
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

            if (listaDeCompras.TryGetValue(titulo, out Lista? lista))
            {
                Console.WriteLine("\n\t1 - Editar título da lista");
                Console.WriteLine("\t2 - Editar item da lista");
                Console.Write("\n\tDigite a opção desejada: ");

                int opcao = int.Parse(Console.ReadLine()!);

                switch (opcao)
                {
                    case 1:
                        EditarTituloDaLista(listaDeCompras, lista);
                        continue;
                    case 2:
                        EditarItemDaLista(lista);
                        continue;
                    default:
                        Console.WriteLine("\n\tOpção inválida.");
                        continue;
                }
            }
            else
            {
                Console.WriteLine($"\n\tLista '{titulo}' não localizada.");
                continue;
            }
        }
    }

    private void EditarTituloDaLista(Dictionary<string, Lista> listaDeCompras, Lista lista)
    // Esse é o método que altera o título da lista, substituindo o que foi informado e identificado através do método acima
    // pelo novo título desejado.
    {
        while (true)
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
    {
        while (true)
        {
            Console.Write("\n\tInforme o produto que será editado ou digite 'sair' para interromper a edição: ");
            string produtoParaEditar = Console.ReadLine()!;

            if (produtoParaEditar.ToLower() == "sair")
            {
                Console.WriteLine("\n\tEdição cancelada.");
                Thread.Sleep(500);
                return;
            }

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
            Console.Write("\n\tInforme o campo que será alterado ('produto', 'quantidade' ou 'valor') ou digite 'sair' para interromper a edição: ");
            string campoAlteracao = Console.ReadLine()!.ToLower();

            if (campoAlteracao.ToLower() == "sair")
            {
                Console.WriteLine("\n\tEdição cancelada.");
                return;
            }

            if (campoAlteracao != "produto" && campoAlteracao != "quantidade" && campoAlteracao != "valor")
            {
                Console.WriteLine("\n\tCampo inválido. Por favor, escolha 'produto', 'quantidade' ou 'valor'.");
                continue;
            }
            else
            {
                EditarCampo(itemParaEditar, campoAlteracao);
            }
            Console.WriteLine("\n\tEdição realizada com sucesso.");
            break;
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
                return;
            }

            switch (campoAlteracao)
            {
                case "produto":
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
                        continue;
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
                        continue;
                    }
            }
            break;
        }
    }

    private Item? EncontrarItem(string produtoOriginal, List<Item> itens)
    {
        foreach (Item item in itens)
        {
            if (item.Produto == produtoOriginal)
            {
                return item;
            }
        }
        return null;
    }
}