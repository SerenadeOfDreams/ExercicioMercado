namespace ExercicioMercado.Modelos;

internal class Item
{
    public Item(string produto, int quantidade, decimal precoUnitario)
    {
        Produto = produto;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;
    }

    public string Produto { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public decimal Valor => PrecoUnitario * Quantidade;

    public void Conteudo()
    {
        Console.WriteLine("\n\tProduto\t\tQuantidade\tValor unitario\t  Valor total");

        Console.WriteLine($"\n\t{Produto}\t\t{Quantidade}\t\tR$ {PrecoUnitario}\t\tR$ {Valor}");

        Console.WriteLine("\t-------------------------------------");
    }
}