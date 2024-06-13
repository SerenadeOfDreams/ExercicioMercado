namespace ExercicioMercado.Modelos; // Passando o namespace de acordo com a pasta onde a classe está, para que ela possa interagir melhor com as classes que precisar.

// Quando um Console.WriteLine($""); estiver como nesse exemplo, é para pegar o valor de uma variável local ou de outra classe e
// jogar no texto sem que seja necessário abrir um Console.Write ou outra função de exibição. Isso permite que seja apresentado,
// no console, a variável que o usuário preencheu.

internal class Item // Dentro dessa classe interna é onde ocorrem todos os processos dessa classe.
{
    public Item(string produto, int quantidade, decimal precoUnitario)
    {
        Produto = produto;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;
    }

    public string Produto { get; set;} // A intância da variável de texto para o produto que o cliente inserir.
    public int Quantidade { get; set;} // A intância da variável numérica inteira para a quantidade do produto que o cliente inserir.
    public decimal PrecoUnitario { get; set; }
    public decimal Valor => PrecoUnitario * Quantidade; // A intância da variável decimal para o valor do produto que o cliente inserir.
    // private decimal precoUnitario;
    // public decimal PrecoUnitario
    // {
    //     get {return precoUnitario; }
    //     set
    //     {
    //         precoUnitario = value;
    //         Valor = Quantidade * precoUnitario;
    //     }
    // }


    public void Conteudo() // Este é o método que mostra o conteúdo de uma lista de compras,
                           // assim como informado na classe Lista.
    {
        Console.WriteLine("\n\tProduto\t\tQuantidade\tValor unitario\t  Valor total");
        // Esse Console.WriteLine é para separar, na parte de cima da visualização da lista,
        // qual campo representa o produto, a quantidade e o valor dos itens.

        Console.WriteLine($"\n\t{Produto}\t\t{Quantidade}\t\tR$ {PrecoUnitario}\t\tR$ {Valor}");
        // Esse Console.WriteLine é o que exibe, de fato, esses itens,
        // concatenando de acordo com a regra acima e de forma espaçada.
        
        Console.WriteLine("\t-------------------------------------");
        // Esse Console.WriteLine é para separar uma linha de produto da outra. O foreach no método ExibirItens(), na classe Lista, faz a exibição
        // de tudo o que estiver na lista, de acordo com a concatenação do Console.WriteLine anterior, mesmo que haja vários produtos.
    }

}