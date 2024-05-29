using ExercicioMercado.Modelos; // Passando o using para que as classes da pasta Menus possam ler as classes que precisam da pasta Modelos.

namespace ExercicioMercado.Menus; // Passando o namespace de acordo com a pasta onde a classe está, para que ela possa interagir melhor com as classes que precisar.

// Quando um Console.WriteLine($""); estiver como nesse exemplo, é para pegar o valor de uma variável local ou de outra classe e
// jogar no texto sem que seja necessário abrir um Console.Write ou outra função de exibição. Isso permite que seja apresentado,
// no console, a variável que o usuário preencheu.

internal class MenuFinalizarCompra // Dentro dessa classe interna é onde ocorrem todos os processos dessa classe.
{
    internal void Executar(Dictionary<string, Lista> listaDeCompras)
    // O método Executar é o que realiza a ação de acordo com a opção descrita no menú principal.
    {
        Console.Clear();

        while(true)
        {
            // O operador de loop 'while' é para que o programa retorne a um ponto específico no código e execute a ação novamente,
            // até que o usuário cancele essa ação. Aqui, ele retorna à solicitação do título de uma lista já existente para finalização.

            Console.Write("\n\tInforme a lista em que deseja fechar ou digite 'sair' para interromper: ");
            string titulo = Console.ReadLine()!;

            if (titulo == "sair")
            // Se, no console, o cliente enviar a palavra 'sair', o programa irá fechar o loop 'while' e seguir com o 'script padrão'.
            // Se voltar à classe Program, você verá que, no 'switch', após a chamada de uma classe de acordo com a opção, há uma chamada
            // do método VoltarAoMenu(). Essa chamada é o 'script padrão', pois ele solicita que seja digitada qualquer tecla para retornar
            // ao menú do programa
            {
                Thread.Sleep(500);
                return; // Sai do método Executar
            }

            if(listaDeCompras.TryGetValue(titulo, out Lista? lista)) // Verificando se foi o que foi passado é o título de alguma lista.
            {
                // Se foi:
                lista.FecharCompra(); // Chama o método FecharCompra, da classe Lista.
            } else
            {
                // Se não foi:
                Console.WriteLine($"\n\tLista '{titulo}' não localizada.");
            }
        }

        
    }
}