using System.Text.RegularExpressions;
using ExercicioMercado.Modelos;

namespace ExercicioMercado.Menus;

internal class MenuAdicionarItem : Menu
{
    public override void Executar(Dictionary<string, Lista> listaDeCompras)

    {
        Console.Clear();
        while (true)
        {
            Console.Write("\n\tInforme o título da lista que deseja preencher ou digite 'sair' para interromper: ");
            string titulo = Console.ReadLine()!;

            if (titulo.ToLower() == "sair")
            {
                Thread.Sleep(500);
                return;
            }

            if (listaDeCompras.ContainsKey(titulo))
            {
                string registroProduto;
                while (true)
                {
                    Console.Write($"\n\tInforme o produto: ");
                    registroProduto = Console.ReadLine()!;
                    if (Regex.IsMatch(registroProduto, @"^[a-zA-Z]+$"))
                    {
                        break;
                    }
                    Console.WriteLine("\n\tProduto inválido. Insira um nome contendo apenas letras.");
                }

                int registroQuantidade;
                while (true)
                {
                    Console.Write($"\n\tInforme a quantidade: ");
                    if (int.TryParse(Console.ReadLine(), out registroQuantidade) && registroQuantidade > 0)
                    {
                        break;
                    }
                    Console.WriteLine("\n\tQuantidade inválida. Insira um valor inteiro, maior que 0.");
                }

                decimal registroValor;
                while (true)
                {
                    Console.Write($"\n\tInforme o valor da unidade: ");
                    if (decimal.TryParse(Console.ReadLine(), out registroValor) && registroValor > 0)
                    {
                        break;
                    }
                    Console.WriteLine("\n\tValor inválido. Insira um valor decimal válido.");
                }

                Lista lista = listaDeCompras[titulo];
                Item novosItens = new(produto: registroProduto, quantidade: registroQuantidade, precoUnitario: registroValor);
                lista.AdicionarItem(novosItens);
                novosItens.Conteudo();

            }
            else
            {
                Console.WriteLine($"\n\tA lista {titulo} não foi localizada");
            }
        }
    }
}