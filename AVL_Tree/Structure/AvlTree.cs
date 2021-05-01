using System;
using AVL_Tree.Structure.Interfaces;

namespace AVL_Tree.Structure
{
    public class AVLTree : IAvlTree
    {
        #region Atributes
        public Node Root { get; private set; }
        #endregion

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public AVLTree() { }

        /// <summary>
        /// Construtor da classe, já adicionando um primeiro valor como raíz.
        /// </summary>
        /// <param name="element">Valor do primeiro elemento a ser inserido na árvore</param>
        public AVLTree(int element)
        {
            this.Root = new Node(element);
        }

        /// <summary>
        /// Alterar o valor da propriedade Root (raíz).
        /// </summary>
        /// <param name="root">Nova referência para o nodo raíz</param>
        public void SetRoot(Node root)
        {
            this.Root = root;
        }      

        /// <summary>
        /// Inserir elementos na árvore.
        /// </summary>
        /// <param name="element">Valor a ser inserido na árvore</param>
        public void InsertNode(int element)
        {
            this.Root = InsertNode(this.Root, element);
        }

        /// <summary>
        /// Inserir elementos na árvore (recursivo).
        /// </summary>
        /// <param name="node">Nodo raíz da árvore</param>
        /// <param name="element">Valor a ser inserido na árvore</param>
        /// <returns>Nova raíz da árvore com o nodo inserido</returns>
        private Node InsertNode(Node node, int element)
        {
            if(node == null)
            {
                return new Node(element);
            }
            if (element < node.Element)
            {
                node.SetLeftNode(InsertNode(node.LeftNode, element));
            }
            else if (element > node.Element)
            {
                node.SetRightNode(InsertNode(node.RightNode, element));
            }
            else
            {
                return node;
            }

            return TreeBalanceAfterInsert(node, element);
        }

        /// <summary>
        /// Buscar um elemento na árvore através do seu valor.
        /// </summary>
        /// <param name="element">Valor a ser buscado na árvore</param>
        /// <returns>Nodo encontrado pela busca</returns>
        public Node FindNode(int element)
        {
            return FindNode(this.Root, element);
        }

        /// <summary>
        /// Buscar um elemento na árvore através do seu valor.
        /// </summary>
        /// <param name="node">Nodo atual analisado pela busca</param>
        /// <param name="element">Valor a ser buscado na árvore</param>
        /// <returns>Nodo encontrado pela busca</returns>
        private Node FindNode(Node node, int element)
        {
            if (node == null || node.Element == element)
            {
                return node;
            }
            else if (element < node.Element)
            {
                return FindNode(node.LeftNode, element);
            }
            return FindNode(node.RightNode, element);
        }

        /// <summary>
        /// Deletar um valor da árvore através do seu valor.
        /// </summary>
        /// <param name="element">Valor a ser deletado da árvore</param>
        public void DeleteNode(int element)
        {
            this.Root = DeleteNode(this.Root, element);
        }

        /// <summary>
        /// Deletar um nodo da árvore através do seu valor.
        /// </summary>
        /// <param name="node">Nodo atual analisado pelo método</param>
        /// <param name="element">Valor a ser deletado da árvore</param>
        /// <returns>Nova raíz da árvore com o nodo deletado</returns>
        private Node DeleteNode(Node node, int element)
        {
            if (node == null)
            {
                return null;
            }
            if(element < node.Element)
            {
                node.SetLeftNode(DeleteNode(node.LeftNode, element));
            }
            else if(element > node.Element)
            {
                node.SetRightNode(DeleteNode(node.RightNode, element));
            }
            else
            {
                node = DeleteNodeAccordingChildren(node);
            }

            if(node == null)
            {
                return null;
            }

            return TreeBalanceAfterDelete(node);
        }

        /// <summary>
        /// Efetuar rotação para a esquerda.
        /// </summary>
        /// <param name="node">Nodo base para a rotação</param>
        /// <returns>Nodo com a rotação efetuada sobre ele</returns>
        private Node LeftRotate(Node node)
        {
            Node T1 = node.RightNode;
            Node T2 = T1.LeftNode;
            T1.SetLeftNode(node);
            node.SetRightNode(T2);
            node.SetHeight(node.GetHeightOfLargestSubtree());
            T1.SetHeight(T1.GetHeightOfLargestSubtree());
            return T1;
        }

        /// <summary>
        /// Efetuar rotação para a direita.
        /// </summary>
        /// <param name="node">Nodo base para a rotação</param>
        /// <returns>Nodo com a rotação efetuada sobre ele</returns>
        private Node RightRotate(Node node)
        {
            Node T1 = node.LeftNode;
            Node T2 = T1.RightNode;
            T1.SetRightNode(node);
            node.SetLeftNode(T2);
            T1.SetHeight(T1.GetHeightOfLargestSubtree());
            node.SetHeight(node.GetHeightOfLargestSubtree());
            return T1;
        }

        /// <summary>
        /// Efetuar o balanceamento da árvore após inserção.
        /// </summary>
        /// <param name="nodeInput">Nodo base para o balanceamento</param>
        /// <param name="element">Valor que se deseja inserir na árvore</param>
        /// <returns>Árvore balanceada a partir do nodo informado</returns>
        private Node TreeBalanceAfterInsert(Node nodeInput, int element)
        {

            (Node node, int balanceValue) = nodeInput.NodeBalanceAndUpdateHeight();

            if (balanceValue > 1)
            {
                if (element < node.LeftNode.Element)
                {
                    return RightRotate(node);
                }
                else if (element > node.LeftNode.Element)
                {
                    node.SetLeftNode(LeftRotate(node.LeftNode));
                    return RightRotate(node);
                }
            }
            if (balanceValue < -1)
            {
                if (element > node.RightNode.Element)
                {
                    return LeftRotate(node);
                }
                else if (element < node.RightNode.Element)
                {
                    node.SetRightNode(RightRotate(node.RightNode));
                    return LeftRotate(node);
                }
            }
            return node;
        }

        /// <summary>
        /// Efetuar o balanceamento da árvore após deleção.
        /// </summary>
        /// <param name="nodeInput">Nodo base para o balanceamento</param>
        /// <returns>Árvore balanceada a partir do nodo informado</returns>
        private Node TreeBalanceAfterDelete(Node nodeInput)
        {
            (Node node, int balanceValue) = nodeInput.NodeBalanceAndUpdateHeight();

            if (balanceValue > 1)
            {
                if (node.LeftNode.NodeBalance() >= 0)
                {
                    return RightRotate(node);
                }
                else
                {
                    node.SetLeftNode(LeftRotate(node.LeftNode));
                    return RightRotate(node);
                }
            }
            else if (balanceValue < -1)
            {
                if (node.RightNode.NodeBalance() <= 0)
                {
                    return LeftRotate(node);
                }
                else
                {
                    node.SetRightNode(RightRotate(node.RightNode));
                    return LeftRotate(node);
                }
            }

            return node;
        }

        /// <summary>
        /// Remover o node passado por parâmetro e mover seus filhos.
        /// </summary>
        /// <param name="node">Nodo a ser deletado da árvore</param>
        /// <returns>Nodo a ser posicionado no local do deletado</returns>
        private Node DeleteNodeAccordingChildren(Node node)
        {
            Node aux;
            if (node.LeftNode == null || node.RightNode == null)
            {
                if (node.LeftNode != null)
                {
                    aux = node.LeftNode;
                }
                else
                {
                    aux = node.RightNode;
                }

                if (aux == null)
                {
                    node = null;
                }
                else
                {
                    node = aux;
                }
            }
            else
            {
                aux = NodeWithMinimumValue(node.RightNode);
                node.SetElement(aux.Element);
                node.SetRightNode(DeleteNode(node.RightNode, aux.Element)); ;
            }

            return node;
        }

        /// <summary>
        /// Procurar o nodo com menor valor da árvore.
        /// </summary>
        /// <param name="node">Nodo raíz da consulta</param>
        /// <returns>Nodo que possui o menor valor da árvore</returns>
        private Node NodeWithMinimumValue(Node node)
        {
            Node current = node;
            while (current.LeftNode != null)
            {
                current = current.LeftNode;
            }

            return current;
        }

        /// <summary>
        /// Imprimir a árvore percorrendo em pré-ordem.
        /// </summary>
        public void PreOrdem()
        {
            PreOrdem(this.Root);
        }

        /// <summary>
        /// Imprimir a árvore percorrendo em pré-ordem.
        /// </summary>
        /// <param name="node">Nodo raíz para o percurso</param>
        private void PreOrdem (Node node)
        {
            if(node != null)
            {
                Console.Write(node.Element + "  ");
                PreOrdem(node.LeftNode);
                PreOrdem(node.RightNode);
            }
        }

        /// <summary>
        /// Imprimir a árvore percorrendo Em-Ordem.
        /// </summary>
        public void EmOrdem()
        {
            EmOrdem(this.Root);
        }

        /// <summary>
        /// Imprimir a árvore percorrendo Em-Ordem.
        /// </summary>
        /// <param name="node">Nodo raíz para o percurso</param>
        private void EmOrdem(Node node)
        {
            if(node != null)
            {
                EmOrdem(node.LeftNode);
                Console.Write(node.Element + "  ");
                EmOrdem(node.RightNode);
            }   
        }

        /// <summary>
        /// Imprimir a árvore percorrendo em Pós-Ordem.
        /// </summary>
        public void PosOrdem()
        {
            PosOrdem(this.Root);
        }

        /// <summary>
        /// Imprimir a árvore percorrendo em Pós-Ordem.
        /// </summary>
        /// <param name="node">Nodo raíz para o percurso</param>
        private void PosOrdem(Node node)
        {
            if(node != null)
            {
                PosOrdem(node.LeftNode);
                PosOrdem(node.RightNode);
                Console.Write(node.Element + "  ");
            }
        }

        /// <summary>
        /// Método para imprimir a árvore.
        /// </summary>
        public void PrintTree()
        {
            PrintTree(this.Root, string.Empty, true);
        }

        /// <summary>
        /// Método para imprimir a árvore.
        /// </summary>
        /// <param name="currPrt">Node atual da impressão</param>
        /// <param name="indent">identação utilizada para a escrita em tela</param>
        /// <param name="rightPath">Flag que indica se o nó atual é para o lado direito da subárvore analisada</param>
        private void PrintTree(Node currPrt, string indent, bool rightPath)
        {
            if(currPrt != null)
            {
                Console.Write(indent);
                if (indent.Equals(string.Empty))
                {
                    Console.Write("Root-");
                    indent += "   ";
                }
                else if (rightPath)
                {
                    Console.Write("R----");
                    indent += "   ";
                }
                else
                {
                    Console.Write("L----");
                    indent += "|   ";
                }
                Console.WriteLine(currPrt.Element);
                PrintTree(currPrt.LeftNode, indent, false);
                PrintTree(currPrt.RightNode, indent, true);
            }
        }
    }
}