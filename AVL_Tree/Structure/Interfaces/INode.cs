using System;

namespace AVL_Tree.Structure.Interfaces
{
    public interface INode
    {
        /// <summary>
        /// Método para alterar o valor do elemento do nodo.
        /// </summary>
        /// <param name="element">Valor novo</param>
        void SetElement(int element);

        /// <summary>
        /// Método para alterar a altura do nodo.
        /// </summary>
        /// <param name="height">Valor da nova altura</param>
        void SetHeight(int height);

        /// <summary>
        /// Método para alterar a subárvore esquerda do nodo.
        /// </summary>
        /// <param name="leftNode">Referência da nova subárvore esquerda do nodo</param>
        void SetLeftNode(Node leftNode);

        /// <summary>
        /// Método para alterar a subárvore direitda do nodo.
        /// </summary>
        /// <param name="rightNode">Referência da nova subárvore direita do nodo</param>
        void SetRightNode(Node rightNode);

        /// <summary>
        /// Método para imprimir o nodo de forma simples.
        /// </summary>
        void PrintNode();
    }
}