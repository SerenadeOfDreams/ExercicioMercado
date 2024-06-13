namespace ExercicioMercado.Modelos; // Passando o namespace de acordo com a pasta onde a classe está, para que ela possa interagir melhor com as classes que precisar.

// Quando um Console.WriteLine($""); estiver como nesse exemplo, é para pegar o valor de uma variável local ou de outra classe e
// jogar no texto sem que seja necessário abrir um Console.Write ou outra função de exibição. Isso permite que seja apresentado,
// no console, a variável que o usuário preencheu.

internal class Lista // Dentro dessa classe interna é onde ocorrem todos os processos dessa classe.
{   
    private List<Item> itens = []; // Intanciando que, dentro do dicionário, tem a lista que possui os itens.
    public Lista(string titulo)
    {
        Titulo = titulo;
    }

    public string Titulo { get; set;} // A instância da varável de texto para o título de uma lista.

    public List<Item> Itens => itens;
    public void AdicionarItem(Item item) // Este é o método que adiciona itens a uma lista de compras que já existe, de acordo com os parâmetros da classe Item.
    {
        itens.Add(item);
    }

    public void ExibirItens() // Esse é o método que exibe os itens na tela, de acordo com os parâmetros da classe Item.
    {
        foreach(Item item in itens) // O foreach faz a verificação dos itens contidos na lista informada e, 
                                    //de acordo com os parâmetros da classe Item, aciona o método Conteúdo(), também da classe Item.
        {
            item.Conteudo();
        }
    }

    public void EditarTitulo(string tituloOriginal, string novoTitulo)
    //Esse método permite a alteração do título da lista que for informado.
    {
        if (novoTitulo != Titulo) // Verificando se o título passado é igual ao existente.
        {
            Titulo = novoTitulo; // Essa linha joga o valor do novo título onde estava o anterior.
            Console.WriteLine($"\n\tTítulo alterado de: {tituloOriginal} para: {novoTitulo}");
            // return novoTitulo;
        }
        else // Se for igual, ele não permitirá a alteração, pois não fará sentido alterar para o mesmo título.
        {
            Console.WriteLine("\n\tO novo título é igual ao título atual. Nenhuma alteração realizada.");
            // return tituloOriginal;
        }
    }
    
    public void FecharCompra() // Esse é o método que finaliza a compra do usuário,
                               // somando o que estiver dentro do campo 'valor' em cada item adicionado pelo usuário.
    {
        decimal valorTotal = 0; // Como o campo valor, que será visto na classe Item, é de valor decimal,
                                // aqui também é para evitar qualquer problema.

            foreach (var item in Itens) // Foreach percorrendo a lista informada para procurar o que há no campo 'valor' de cada item registrado.
            {
                valorTotal += item.Valor; // Fazendo a soma de cada valor decimal identificado no campo 'valor'.
            }

            Console.WriteLine($"\n\tO valor total da lista '{Titulo}' é: R$ {valorTotal}");
    }
}