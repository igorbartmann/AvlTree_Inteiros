using System;
using AVL_Tree.Test;
using AVL_Tree.Structure;

namespace AVL_Tree
{
    public class Principal
    {
        public static void Main(string[] args)
        {
            AVLTree tree = new AVLTree();
            int option, value;

            while(true)
            {
                (option, value) = MenuPrincipal(tree);
                ExecuteActionSelected(option, value, tree);
            }
        }

        /// <summary>
        /// Método para exibir o menu principal da aplicação.
        /// </summary>
        /// <returns>A ação desejada e o valor a ser utilizado para a execução da ação</returns>
        public static (int option, int value) MenuPrincipal(AVLTree tree)
        {
            int option, value;

            Console.Clear();
            Console.WriteLine(("MENU-PRINCIPAL\n").PadLeft(45) +
                "\n[1] ADICIONAR ELEMENTO.\n" +
                "[2] BUSCAR ELEMENTO.\n" +
                "[3] DELETAR ELEMENTO.\n" +
                "[4] IMPRIMIR A ÁRVORE.\n" +
                "[5] RODAR TESTE AUTOMÁTICO.\n" +
                "[6] FECHAR O APLICATIVO.\n");

            option = ValidarEntradaInt("Digite o valor correspondente a opção desejada: ", 6, 1);

            Console.Clear();
            switch (option)
            {
                case 1:
                    value = ValidarEntradaInt("Digite o valor a ser adicionado: ");
                    break;
                case 2:
                    if(tree.Root == null)
                    {
                        Console.WriteLine("Ops, a árvore está vazia! Tente adicionar valores primeiro.");
                        value = 0;
                    }
                    else
                    {
                        value = ValidarEntradaInt("Digite o valor a ser pesquisado: ");
                    }
                    break;
                case 3:
                    if (tree.Root == null)
                    {
                        Console.WriteLine("Ops, a árvore está vazia! Tente adicionar valores primeiro.");
                        value = 0;
                    }
                    else
                    {
                        value = ValidarEntradaInt("Digite o valor a ser deletado: ");
                    }                    
                    break;
                case 4:
                    Console.WriteLine(("FORMATOS DE IMPRESSÃO DISPONÍVEIS\n").PadLeft(55) +
                                "\n[1] PADRÃO DO SISTEMA.\n" +
                                "[2] PRÉ-OREDEM.\n" +
                                "[3] EM-ORDEM.\n" +
                                "[4] PÓS-ORDEM.\n" +
                                "[5] VOLTAR AO MENU PRINCIPAL.");

                    value = ValidarEntradaInt("Digite o valor da opção desejada: ", 5, 1);
                    break;
                case 5:
                    value = 5;
                    break;
                default:
                    value = 6;
                    break;
            }

            return (option, value);
        }

        /// <summary>
        /// Método que executa a ação dentro dos parâmetros escolhidos pelo usuário.
        /// </summary>
        /// <param name="option">Ação a ser executada</param>
        /// <param name="value">Valor a ser passado para a ação</param>
        public static void ExecuteActionSelected(int option, int value, AVLTree tree)
        {
            if(value != 0)
            {
                switch (option)
                {
                    case 1:
                        tree.InsertNode(value);
                        break;

                    case 2:
                        Node found = tree.FindNode(value);
                        if (found != null)
                        {
                            Console.WriteLine("\nELEMENTO ENCONTRADO:");
                            found.PrintNode();
                        }
                        else
                        {
                            Console.Write("O valor " + value + " não foi encontrado na árvore.\n");
                        }
                        break;

                    case 3:
                        tree.DeleteNode(value);
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine(("ÁRVORE:\n").PadLeft(40));

                        if (value == 5)
                        {
                            return;
                        }
                        else if (tree.Root == null)
                        {
                            Console.WriteLine("\nA árvore está vazia!");
                        }
                        else
                        {
                            tree.PrintTree();
                        }

                        if (value == 1)
                        {
                            Console.WriteLine("\nINDICADORES: [L] = Left e [R] = Right");
                        }
                        else if (value == 2)
                        {
                            Console.Write("\nPré-Ordem: ");
                            tree.PreOrdem();
                            Console.WriteLine();
                        }
                        else if (value == 3)
                        {
                            Console.Write("\nEm-Ordem: ");
                            tree.EmOrdem();
                            Console.WriteLine();
                        }
                        else if (value == 4)
                        {
                            Console.Write("\nPós-Ordem: ");
                            tree.PosOrdem();
                            Console.WriteLine();
                        }
                        break;

                    case 5:
                        Testes.Teste();
                        break;

                    default:
                        Environment.Exit(0);
                        break;
                }

                if (option == 1 || option == 3)
                {
                    Console.Clear();
                    Console.WriteLine(("Estado da árvore após a ação:\n").PadLeft(30));
                    tree.PrintTree();
                }
            }
            
            if(option != 5 || value == 0)
            {
                Console.Write("Tecle Enter para voltar ao Menu Principal...");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Método para validar entradas do tipo inteirno por parte do usuário.
        /// </summary>
        /// <param name="msg">Mensagem de pergunta a ser impressa na tela</param>
        /// <param name="max">Valor inteirno máximo permitido para aresposta</param>
        /// <param name="min">Valor inteiro mínimo permitido para a resposta</param>
        /// <returns></returns>
        public static int ValidarEntradaInt(string msg, int max = 0, int min = 0)
        {
            int resposta, validador = min - 1;

            do
            {
                try
                {
                    Console.Write(msg);
                    resposta = Convert.ToInt16(Console.ReadLine());

                    if (min != max && (resposta < min || resposta > max))
                    {
                        throw new ArgumentException();
                    }
                }
                catch (FormatException)
                {
                    resposta = validador;
                    Console.WriteLine("Erro! O formato digitado é inválido.");
                }
                catch (ArgumentException)
                {
                    resposta = validador;
                    Console.WriteLine("Opção inválida! Você deve digitar um valor entre " + min + " e " + max + ".");
                }
            } while (resposta == validador);

            return resposta;
        }
    }
}