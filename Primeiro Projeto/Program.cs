using System;
// Anotar
using System.Threading;
using System.Linq;
using System.Collections.Generic;


namespace Primeiro_Projeto
{
    class Program
    {
        static void Main()
        {
            //Screen Sound             
            string mensagemdeBoasVindas = "Boas Vindas ao Screen Sound";
            // List<string> listaDasBandas = new List<string> {"U2", "The Beatles", "Calypso" };

            Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
            bandasRegistradas.Add("Linkin Park", new List<int> { 10, 8, 6 });
            bandasRegistradas.Add("The Beatles", new List<int>());
            
            void ExibirLogo()
            {                
                Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
                Console.WriteLine(mensagemdeBoasVindas);
            }

            void ExibirOpcoesDoMenu()
            {
                ExibirLogo();

                Console.WriteLine("\nDigite 1 para registrar uma bandas");
                Console.WriteLine("Digite 2 para mostrar todas as bandas");
                Console.WriteLine("Digite 3 para avaliar uma banda");
                Console.WriteLine("Digite 4 para exibir a média de uma banda");
                Console.WriteLine("Digite 5 para sair");
              
                Console.Write("\nDigite a sua opção: ");
               
                string opcaoEscolhida = Console.ReadLine()!;
                int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

                switch (opcaoEscolhidaNumerica)
                {
                    case 1: RegistrarBanda();                      
                        break;
                    case 2: MostrarBandasRegistradas();                       
                        break;
                    case 3: AvaliarUmaBanda();
                        break;
                    case 4: MediaDeUmaBanda();
                        break;
                    case 5: break;
                    default:
                        Console.WriteLine("Opção Invalida");
                        break;
                }
            }

            void RegistrarBanda()
            {
                Console.Clear();
                ExibirTituloDaOpcao("Registro das Bandas");
                Console.Write("Digite o nome da banda que deseja registrar: ");
                string nomeDaBanda = Console.ReadLine()!;
                bandasRegistradas.Add(nomeDaBanda, new List<int>());
                Console.WriteLine($"\nA banda {nomeDaBanda} foi registrada com sucesso");
                Thread.Sleep(2000);
                Console.Clear();
                ExibirOpcoesDoMenu();
            }

            void MostrarBandasRegistradas()
            {
                Console.Clear();
                ExibirTituloDaOpcao("Exibindo todas as bandas registradas");

                // Count
                //for(int i = 0; i < listaDasBandas.Count; i++)
                //{
                //    Console.WriteLine($"Banda: {listaDasBandas[i]}");
                //}

                foreach(string banda in bandasRegistradas.Keys)
                {
                    Console.WriteLine($"Banda: {banda}");
                }

                Console.WriteLine("\nDigite uma tecla para voltar ao voltar ao menu principal");
                // ReadKey
                Console.ReadKey();
                Console.Clear();
                ExibirOpcoesDoMenu();
            }

            void ExibirTituloDaOpcao(string titulo)
            {
                int quantidadeDeLetras = titulo.Length;
                // Anotar 
                string astesriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
                Console.WriteLine(astesriscos);
                Console.WriteLine(titulo);
                Console.WriteLine(astesriscos + "\n");
            }

            void AvaliarUmaBanda()
            {
                //digite qual bnada deseja avaliar 
                // se a banda existir no dicionario >> atribuir uma nota 
                // senão, volta ao menu principal 
                Console.Clear();
                ExibirTituloDaOpcao("Avaliar Banda");
                Console.Write("Digite o nome da banda que deseja avaliar: ");
                string nomeDaBanda = Console.ReadLine();
                if (bandasRegistradas.ContainsKey(nomeDaBanda))
                {
                    Console.Write($"Qual a nota que a banda {nomeDaBanda} merece:");
                    int nota = int.Parse(Console.ReadLine()!);
                    bandasRegistradas[nomeDaBanda].Add(nota);
                    Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
                    Thread.Sleep(4000);
                    Console.Clear();
                    ExibirOpcoesDoMenu();
                } else
                {
                    Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada");
                    Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                    Console.ReadKey();
                    Console.Clear();
                    ExibirOpcoesDoMenu();
                }

            }

            void MediaDeUmaBanda()
            {                                   
                Console.Clear();
                ExibirTituloDaOpcao("Exibir Média da Banda");
                // Perguntar qual banda deseja ver a média
                Console.WriteLine("Qual a banda deseja saber a média?");
                string nomeDaBanda = Console.ReadLine()!;
                // Consultar se a banda esta inserida no dicionario da aplicação
                if (bandasRegistradas.ContainsKey(nomeDaBanda))
                {
                    // Realizar o Calculo da Média
                    List<int> mediaDaBanda = bandasRegistradas[nomeDaBanda];
                    //Interpolção de string
                    Console.WriteLine($"\nA média da banda {nomeDaBanda} foi de {mediaDaBanda.Average()}.");
                    Console.WriteLine("Digite qualquer tecla para sair");
                    Console.ReadKey();
                    Console.Clear();
                    ExibirOpcoesDoMenu();
                } else
                {
                    Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada.");
                    Console.WriteLine("Digite qualquer tecla para sair");
                    Console.ReadKey();
                    Console.Clear();
                    ExibirOpcoesDoMenu();
                }
                
            }

            ExibirOpcoesDoMenu();            
        }
    }
}

//        Aulas Exercicios  
//        Aula 2   
//        // Desafios do Alura 1
//        int notaMedia = 6;
//        if (notaMedia >= 6)
//        {
//            Console.WriteLine("\nNota suficiente para a aprovação.");
//        }

//        // Desafios do Alura 2 e 3
//        List<string> linguagens = new List<string> { "\nC#", "\nJava", "\nJavaScript" };
//        Console.WriteLine(linguagens[0]);

//        // Desafio 4 
//        int posicao = int.Parse(Console.ReadLine());
//        Console.WriteLine(linguagens[posicao]);




//        // Desafio 5 - jogo do numero aleatorio

//            // Gerar um numero aleatorio entre 0 e 100
//            Random aleatorio = new Random();       
//            int numeroAleatorio = aleatorio.Next(1, 101);

//        Console.Clear();
//        //estrutura de repetição repita ou faça - enquanto/do - while();
//        do
//        {                
//            Console.Write("\nDigite um numero entre 1 e 100: ");
//            // para leitura dos tipos inteiros é necessario colocar o int.Parse para ler o numero exato
//            int resposta = int.Parse(Console.ReadLine());

//            if (resposta == numeroAleatorio)
//            {
//                Console.WriteLine("\nParabens voce acertou!!!");
//                break;
//            }
//            else if(resposta < numeroAleatorio)
//            {
//                Console.WriteLine("\nO numero é maior");
//            } else
//            {
//                Console.WriteLine("\nO numero é menor");
//            }
//        } while (true);


// Aula 3
// Desafio 1
//void ExibirQuatroOperaçoes()
//    // float
//{
//    float a = 4;
//    float b = 7;

//    float soma = a + b;
//    float subtrair = a - b;
//    float multiplicar = a * b;
//    float divisao = a / b;

//    Console.WriteLine($"a + b = {soma}");
//    Console.WriteLine($"a - b = {subtrair}");
//    Console.WriteLine($"a * b = {multiplicar}");
//    Console.WriteLine($"a / b = {divisao}");
//}
//ExibirQuatroOperaçoes();

//// Desafio 2
//List<string> bandasminhas = new List<string>();
//bandasminhas.Add("AC DC");
//bandasminhas.Add("KISS");
//bandasminhas.Add("Queen");
//bandasminhas.Add("Ira");

//// Desafio 3 
//for(int i = 0; i < bandasminhas.Count; i++)
//{
//    Console.WriteLine($"Banda: {bandasminhas[i]}");
//}

//// Desafio 4 
//List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, };
//int soma = 0;

//foreach(int numero in numeros)
//{
//    soma += numero;
//}
//Console.WriteLine($"A soma dos elementos da lista é: {soma}");

//// Desafio Faça como eu fiz 
//List<int> listaNumeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8};

//for(int i = 0; i < listaNumeros.Count; i++)
//{
//    if(listaNumeros[i] % 2 == 0)
//    {
//        Console.WriteLine(listaNumeros[i]);
//    }
//}

//foreach (int numbers in listaNumeros)
//{
//    if(numbers % 2 == 0)
//    {
//        Console.WriteLine(numbers);
//    }
//}

//Aula 4 
//Desafio 1
// Adicione notas para alguns alunos
//Dictionary<string, List<double>> notasAlunos = new Dictionary<string, List<double>>();

//notasAlunos["João"] = new List<double> { 8.5, 9.0, 7.5 };
//notasAlunos["Maria"] = new List<double> { 7.0, 8.0, 6.5 };

//foreach (var aluno in notasAlunos)
//{
//    double soma = 0;
//    for (int i = 0; i < aluno.Value.Count; i++)
//    {
//        soma += aluno.Value[i];
//    }
//    double media = soma / aluno.Value.Count;
//    Console.WriteLine($"Média de {aluno.Key}: {media}");
//}


//// Desafio 2 
//Dictionary<string, int> estoque = new Dictionary<string, int>
//            {
//                { "camisetas", 50 },
//                { "calças", 30 },
//                { "tênis", 20 },
//                // Adicione mais produtos conforme necessário
//            };

//string produto = "camisetas";

//if (estoque.ContainsKey(produto))
//{
//    Console.WriteLine($"Quantidade em estoque de {produto}: {estoque[produto]} unidades.");
//}
//else
//{
//    Console.WriteLine("Produto não encontrado no estoque.");
//}

//// Desafio 3
//Dictionary<string, string> perguntasERespostas = new Dictionary<string, string>
//            {
//                { "Qual é a capital do Brasil?", "Brasília" },
//                { "Quanto é 7 vezes 8?", "56" },
//                { "Quem escreveu 'Romeu e Julieta'?", "William Shakespeare" },
//                // Adicione mais perguntas e respostas conforme necessário
//            };

//int pontuacao = 0;

//foreach (var pergunta in perguntasERespostas)
//{
//    Console.WriteLine(pergunta.Key);
//    Console.Write("Sua resposta: ");
//    string respostaUsuario = Console.ReadLine();

//    if (respostaUsuario.ToLower() == pergunta.Value.ToLower())
//    {
//        Console.WriteLine("Correto!\n");
//        pontuacao++;
//    }
//    else
//    {
//        Console.WriteLine($"Incorreto. A resposta correta é: {pergunta.Value}\n");
//    }
//}

//Console.WriteLine($"Pontuação final: {pontuacao} de {perguntasERespostas.Count}");

////Desafio 4
//Dictionary<string, string> usuarios = new Dictionary<string, string>
//            {
//                { "user1", "senha123" },
//                { "user2", "abc456" },
//                // Adicione mais usuários conforme necessário
//            };

//string nomeUsuario = "user1";
//string senha = "senha123";

//if (usuarios.ContainsKey(nomeUsuario) && usuarios[nomeUsuario] == senha)
//    Console.WriteLine("Login bem-sucedido!");
//else
//    Console.WriteLine("Nome de usuário ou senha incorretos.");
