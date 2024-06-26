using ExercicioMercado.Modelos;

namespace ExercicioMercado.Menus;

internal class MenuExcluirLista : Menu
{
    public override void Executar(Dictionary<string, Lista> listaDeCompras)
    {
        Console.Clear();

        while (true)
        {
            Console.Write("\n\tInforme a lista a excluir ou digite 'sair' para interromper: ");
            string titulo = Console.ReadLine()!;

            if (titulo.ToLower() == "sair")
            {
                Thread.Sleep(500);
                return;
            }

            if (listaDeCompras.TryGetValue(titulo, out Lista? lista))
            {
                listaDeCompras.Remove(titulo);

                Console.WriteLine($"\n\tLista '{titulo}' excluída com sucesso.");
            }
            else
            {
                Console.WriteLine($"\n\tLista '{titulo}' não localizada.");
            }
        }
    }
}