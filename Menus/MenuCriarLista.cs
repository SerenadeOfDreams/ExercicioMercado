using System.Text;
using ExercicioMercado.Modelos;

namespace ExercicioMercado.Menus;

internal class MenuCriarLista : Menu
{
    public override void Executar(Dictionary<string, Lista> listaDeCompras)
    {
        Console.Clear();
        while (true)
        {
            Console.Write($"\n\tInforme o titulo da lista ou digite 'sair' para enterromper: ");
            string titulo = Console.ReadLine()!;

            if (titulo.ToLower() == "sair")
            {
                Thread.Sleep(500);
                return;
            }

            if (listaDeCompras.ContainsKey(titulo))
            {
                Console.WriteLine($"\n\tA lista '{titulo}' já existe.");
            }
            else
            {
                Lista lista = new(titulo);
                listaDeCompras.Add(titulo, lista);
                Console.WriteLine($"\n\tLista '{titulo}' foi criada com sucesso");
            }
        }
    }
}