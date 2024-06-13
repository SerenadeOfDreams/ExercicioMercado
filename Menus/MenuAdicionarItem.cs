using System.Text.RegularExpressions; // Utilizando esta biblioteca para verificar se um campo de string contém somente letras.
using ExercicioMercado.Modelos; // Passando o using para que as classes da pasta Menus possam ler as classes que precisam da pasta Modelos.

namespace ExercicioMercado.Menus; // Passando o namespace de acordo com a pasta onde a classe está, para que ela possa interagir melhor com as classes que precisar.

// Quando um Console.WriteLine($""); estiver como nesse exemplo, é para pegar o valor de uma variável local ou de outra classe e
// jogar no texto sem que seja necessário abrir um Console.Write ou outra função de exibição. Isso permite que seja apresentado,
// no console, a variável que o usuário preencheu.

internal class MenuAdicionarItem : Menu // Dentro dessa classe interna é onde ocorrem todos os processos dessa classe.
{
    public override void Executar(Dictionary<string, Lista> listaDeCompras)
    // O método Executar é o que realiza a ação de acordo com a opção descrita no menú principal.
    {
        Console.Clear();
        while (true)
        {
            // O operador de loop 'while' é para que o programa retorne a um ponto específico no código e execute a ação novamente,
            // até que o usuário cancele essa ação. Aqui, ele retorna à solicitação do título de uma lista já existente, para que
            // sejam atribuídos a ela os itens.

            Console.Write("\n\tInforme o título da lista que deseja preencher ou digite 'sair' para interromper: ");
            string titulo = Console.ReadLine()!;

            if (titulo.ToLower() == "sair")
            // Se, no console, o cliente enviar a palavra 'sair', o programa irá fechar o loop 'while' e seguir com o 'script padrão'.
            // Se voltar à classe Program, você verá que, no 'switch', após a chamada de uma classe de acordo com a opção, há uma chamada
            // do método VoltarAoMenu(). Essa chamada é o 'script padrão', pois ele solicita que seja digitada qualquer tecla para retornar
            // ao menú do programa
            {
                Thread.Sleep(500);
                return; // Sai do método Executar
            }
        
            if(listaDeCompras.ContainsKey(titulo)) // Verificando se foi o que foi passado é o título de alguma lista.
            {
                // Se foi:
                string registroProduto;
                while (true)
                {
                    Console.Write($"\n\tInforme o produto: ");
                    // Essa parte verifica se o que foi passado em 'string registroProduto' contém somente letras, maiúsculas ou minúsculas.
                    // Caso contenha, o programa atinge o 'break' e passa para a próxima solicitação.
                    registroProduto = Console.ReadLine()!;
                    if (Regex.IsMatch(registroProduto, @"^[a-zA-Z]+$"))
                    {
                        break;
                    }
                    // Caso não contenha, ele vem para cá e informa o seguinte:
                    Console.WriteLine("\n\tProduto inválido. Insira um nome contendo apenas letras.");
                }
                // O while está mandando o programa voltar à solicitação enquanto o parâmetro não for atingido.
                
                int registroQuantidade;
                while (true)
                {
                    Console.Write($"\n\tInforme a quantidade: ");
                    // Essa parte verifica se o que foi passado em 'int registroQuantidade' é um número inteiro e acima de zero.
                    // Caso seja, o programa atinge o 'break' e passa para a próxima solicitação.
                    if (int.TryParse(Console.ReadLine(), out registroQuantidade) && registroQuantidade > 0)
                    {
                        break;
                    }
                    // Caso não seja, ele vem para cá e informa o seguinte:
                    Console.WriteLine("\n\tQuantidade inválida. Insira um valor inteiro, maior que 0.");
                }
                // O while está mandando o programa voltar à solicitação da quantidade enquanto o parâmetro não for atingido.

                decimal registroValor;
                while (true)
                {
                    Console.Write($"\n\tInforme o valor da unidade: ");
                    // Essa parte verifica se o que foi passado em 'decimal registroValor' é um número decimal e acima de zero.
                    // Caso seja, o programa atinge o 'break' e passa para a próxima solicitação.
                    if (decimal.TryParse(Console.ReadLine(), out registroValor) && registroValor > 0)
                    {
                        break;
                    }
                    // Caso não seja, ele vem para cá e informa o seguinte: 
                    Console.WriteLine("\n\tValor inválido. Insira um valor decimal válido.");
                }
                // O while está mandando o programa voltar à solicitação da quantidade enquanto o parâmetro não for atingido.

                // decimal total = registroValor * registroQuantidade;
                // Esse decimal é para multiplicar o valor decimal passado em 'registroValor' pela quantidade passada em 'registroQuantidade'.
                // Exemplo: se o usuário passar '20' na quantidade e '101,57' no valor, essa variável multiplica um pelo outro e entrega o resultado
                // em 'Item novosItens = new()', logo abaixo. No caso do exemplo, a saída do valor na exibição do item cadastrado seria de 'R$ 2031,40'.

                Lista lista = listaDeCompras[titulo];
                Item novosItens = new(produto: registroProduto, quantidade: registroQuantidade, precoUnitario: registroValor);
                lista.AdicionarItem(novosItens);
                novosItens.Conteudo();
                
            } else
            {
                // Se não foi:
                Console.WriteLine($"\n\tA lista {titulo} não foi localizada");
            }
        }
    }
}