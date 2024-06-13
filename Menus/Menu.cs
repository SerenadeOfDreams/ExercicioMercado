using ExercicioMercado.Modelos;

namespace ExercicioMercado.Menus;

internal class Menu
{
    public virtual void Executar(Dictionary<string, Lista> listaDeCompras)
    {
        Console.Clear();
    }
}