using System;
using AVL_Tree.Structure.Interfaces;

namespace AVL_Tree.Structure
{
    public class Node : INode
    {
        #region Atributes
        public const int INIT_HEIGHT = 1;
        public int Element { get; private set; }
        public int Height { get; private set; }
        public Node LeftNode { get; private set; }
        public Node RightNode { get; private set; }
        #endregion

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="element">Valor do nodo</param>
        public Node(int element)
        {
            this.Element = element;
            this.Height = INIT_HEIGHT;
        }

        /// <summary>
        /// Método para alterar o valor do elemento do nodo.
        /// </summary>
        /// <param name="element">Valor novo</param>
        public void SetElement(int element)
        {
            this.Element = element;
        }

        /// <summary>
        /// Método para alterar a altura do nodo.
        /// </summary>
        /// <param name="height">Valor da nova altura</param>
        public void SetHeight(int height)
        {
            this.Height = height;
        }

        /// <summary>
        /// Método para alterar a subárvore esquerda do nodo.
        /// </summary>
        /// <param name="leftNode">Referência da nova subárvore esquerda do nodo</param>
        public void SetLeftNode(Node leftNode)
        {
            this.LeftNode = leftNode;
        }

        /// <summary>
        /// Método para alterar a subárvore direitda do nodo.
        /// </summary>
        /// <param name="rightNode">Referência da nova subárvore direita do nodo</param>
        public void SetRightNode(Node rightNode)
        {
            this.RightNode = rightNode;
        }

        /// <summary>
        /// Método para imprimir o nodo de forma simples.
        /// </summary>
        public void PrintNode()
        {
            Console.WriteLine(
                "Element: " + this.Element + 
                "\nHeight: " + this.Height +
                "\nLeftNode: " + 
                    (this.LeftNode != null 
                    ? this.LeftNode.Element.ToString() 
                    : "não possui subárvore à esquerda") +
                "\nRightNode: " + 
                    (this.RightNode != null 
                    ? this.RightNode.Element.ToString() 
                    : "não possui subárvore à direita") + "\n");
        }
    }
}