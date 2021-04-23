using System;
using AVL_Tree.Structure;

namespace AVL_Tree.Test
{
    public class Testes
    {
        public static void Teste()
        {
            Console.WriteLine(("TESTE AUTOMÁTICO").PadLeft(45));
            
            AVLTree tree = new AVLTree(33);
            tree.InsertNode(13);
            tree.InsertNode(53);
            tree.InsertNode(9);
            tree.InsertNode(21);
            tree.InsertNode(61);
            tree.InsertNode(8);
            tree.InsertNode(11);
            Console.WriteLine("\nApós inserir os valores: 33, 13, 53, 9, 21, 61, 8, 11.\n");
            tree.PrintTree();

            tree.DeleteNode(13);
            Console.WriteLine("\nApós deletar o valor 13:\n");
            tree.PrintTree();

            Console.Write("\nTecle Enter para sair do teste aoumático...");
            Console.ReadLine();
        }
    }
}