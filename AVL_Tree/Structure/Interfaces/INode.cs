using System;

namespace AVL_Tree.Structure.Interfaces
{
    public interface INode
    {
        /// <summary>
        /// Método para alterar o valor do elemento do nodo.
        /// </summary>
        /// <param name="element">Novo elemento do nodo</param>
        void SetElement(int element);

        /// <summary>
        /// Método para alterar a altura do nodo.
        /// </summary>
        /// <param name="height">Nova altura do nodo</param>
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
        /// Calcula o valor de balanceamento atual do nodo.
        /// </summary>
        /// <returns>Valor do balanceamento do nodo</returns>
        int NodeBalance();

        /// <summary>
        /// Calcular o valor do balanceamento atual e atualiza a altura do nodo.
        /// </summary>
        /// <returns>Nodo com a altura atualizada e o valor do seu balanceamento</returns>
        (Node, int) NodeBalanceAndUpdateHeight();

        /// <summary>
        /// Obtém a altura da maior subárvore do nodo.
        /// </summary>
        /// <returns>Altura da maior subárvore do nodo</returns>
        int GetHeightOfLargestSubtree();

        /// <summary>
        /// Método para imprimir o nodo de forma simples.
        /// </summary>
        void PrintNode();
    }
}