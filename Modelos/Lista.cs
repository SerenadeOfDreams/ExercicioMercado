namespace ExercicioMercado.Modelos;

internal class Lista
{
    private List<Item> itens = [];
    public Lista(string titulo)
    {
        Titulo = titulo;
    }

    public string Titulo { get; set; }

    public List<Item> Itens => itens;
    public void AdicionarItem(Item item)
    {
        itens.Add(item);
    }

    public void ExibirItens()
    {
        foreach (Item item in itens)
        {
            item.Conteudo();
        }
    }

    public void EditarTitulo(string tituloOriginal, string novoTitulo)
    {
        if (novoTitulo != Titulo)
        {
            Titulo = novoTitulo;
            Console.WriteLine($"\n\tTítulo alterado de: {tituloOriginal} para: {novoTitulo}");
        }
        else
        {
            Console.WriteLine("\n\tO novo título é igual ao título atual. Nenhuma alteração realizada.");
        }
    }

    public void FecharCompra()
    {
        decimal valorTotal = 0;

        foreach (var item in Itens)
        {
            valorTotal += item.Valor;
        }

        Console.WriteLine($"\n\tO valor total da lista '{Titulo}' é: R$ {valorTotal}");
    }
}