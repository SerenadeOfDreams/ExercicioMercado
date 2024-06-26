partial class Program
{
    static void VoltarAoMenu()
    {
        Console.Write("\n\tPressione qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Thread.Sleep(1000);
        ExibirMenuDoMercado();
    }
}