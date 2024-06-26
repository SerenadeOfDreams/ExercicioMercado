using ExercicioMercado.Modelos;

namespace ExercicioMercado.Menus;

internal class MenuExibirLista : Menu
{
    public override void Executar(Dictionary<string, Lista> listaDeCompras)
    {
        Console.Clear();

        while (true)
        {
            Console.Write($"\n\tInforme o titulo da lista a visualizar ou digite 'sair' para interromper: ");
            string titulo = Console.ReadLine()!;

            if (titulo.ToLower() == "sair")
            {
                Thread.Sleep(500);
                return;
            }

            if (listaDeCompras.ContainsKey(titulo))
            {
                Lista lista = listaDeCompras[titulo];
                Console.WriteLine($"\n\t{titulo}");
                lista.ExibirItens();
            }
            else
            {
                Console.WriteLine($"\n\tA lista {titulo} não foi localizada.");
            }
        }
    }
}