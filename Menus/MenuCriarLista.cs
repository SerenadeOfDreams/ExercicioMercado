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
            string path = $"Listas/{titulo}.txt";

            if (titulo.ToLower() == "sair")
            {
                Thread.Sleep(500);
                return;
            }

            if (listaDeCompras.ContainsKey(titulo) || File.Exists(path))
            {
                Console.WriteLine($"\n\tA lista '{titulo}' já existe.");
            }
            else
            {
                Lista lista = new(titulo);
                listaDeCompras.Add(titulo, lista);
                Console.WriteLine($"\n\tLista '{titulo}' foi criada com sucesso");

                Console.WriteLine("\n\tGerar arquivo para a lista?");
                Console.Write("\n\t1 - Sim / 2 - Não ");
                var opt = int.Parse(Console.ReadLine()!);

                if (opt == 1)
                {
                    using var fluxoDeArquivo = new FileStream(path, FileMode.CreateNew);

                    var encoding = Encoding.UTF8;

                    Console.WriteLine($"\n\tO arquivo '{titulo}.txt' foi criado com sucesso.");
                }
                else if (opt == 2)
                {
                    Thread.Sleep(500);
                    return;
                }

            }
        }
    }
}