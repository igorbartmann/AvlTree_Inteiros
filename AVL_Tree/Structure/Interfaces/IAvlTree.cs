using System;

namespace AVL_Tree.Structure.Interfaces
{
    public interface IAvlTree
    {
        /// <summary>
        /// Alterar o valor da propriedade Root (raíz).
        /// </summary>
        /// <param name="root">Nova referência para o nodo raíz</param>
        void SetRoot(Node root);

        /// <summary>
        /// Inserir elementos na árvore.
        /// </summary>
        /// <param name="element">Valor a ser inserido na árvore</param>
        void InsertNode(int element);

        /// <summary>
        /// Buscar um elemento na árvore através do seu valor.
        /// </summary>
        /// <param name="element">Valor a ser buscado na árvore</param>
        /// <returns>Nodo encontrado pela busca</returns>
        Node FindNode(int element);

        /// <summary>
        /// Deletar um elemento da árvore através do seu valor.
        /// </summary>
        /// <param name="element">Valor a ser deletado da árvore</param>
        void DeleteNode(int element);

        /// <summary>
        /// Imprimir a árvore percorrendo em pré-ordem.
        /// </summary>
        void PreOrdem();

        /// <summary>
        /// Imprimir a árvore percorrendo Em-Ordem.
        /// </summary>
        void EmOrdem();

        /// <summary>
        /// Imprimir a árvore percorrendo em Pós-Ordem.
        /// </summary>
        void PosOrdem();

        /// <summary>
        /// Método para imprimir a árvore.
        /// </summary>
        void PrintTree();
    }
}