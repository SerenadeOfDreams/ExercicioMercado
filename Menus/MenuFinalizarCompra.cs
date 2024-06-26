using ExercicioMercado.Modelos;

namespace ExercicioMercado.Menus;

internal class MenuFinalizarCompra : Menu
{
    public override void Executar(Dictionary<string, Lista> listaDeCompras)
    {
        Console.Clear();

        while (true)
        {
            Console.Write("\n\tInforme a lista em que deseja fechar ou digite 'sair' para interromper: ");
            string titulo = Console.ReadLine()!;

            if (titulo.ToLower() == "sair")
            {
                Thread.Sleep(500);
                return;
            }

            if (listaDeCompras.TryGetValue(titulo, out Lista? lista))
            {
                lista.ExibirItens();
                lista.FecharCompra();
            }
            else
            {
                Console.WriteLine($"\n\tLista '{titulo}' não localizada.");
            }
        }
    }
}