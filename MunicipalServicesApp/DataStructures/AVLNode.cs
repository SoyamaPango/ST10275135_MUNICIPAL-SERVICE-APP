using System;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.DataStructures
{
    // Node class for AVL Tree
    public class AVLNode
    {
        public ServiceRequest Data;
        public AVLNode Left;
        public AVLNode Right;
        public int Height;

        public AVLNode(ServiceRequest data)
        {
            Data = data;
            Height = 1; // New node has height 1
        }
    }

    public class AVLTree
    {
        public AVLNode Root;

        // Utility function to get height of a node
        private int Height(AVLNode node) => node?.Height ?? 0;

        // Balance factor
        private int GetBalance(AVLNode node) => node == null ? 0 : Height(node.Left) - Height(node.Right);

        // Right rotation
        private AVLNode RightRotate(AVLNode y)
        {
            AVLNode x = y.Left;
            AVLNode T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;

            return x;
        }

        // Left rotation
        private AVLNode LeftRotate(AVLNode x)
        {
            AVLNode y = x.Right;
            AVLNode T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;

            return y;
        }

        // Insert a new ServiceRequest
        public AVLNode Insert(AVLNode node, ServiceRequest data)
        {
            if (node == null) return new AVLNode(data);

            if (data.DateSubmitted < node.Data.DateSubmitted)
                node.Left = Insert(node.Left, data);
            else if (data.DateSubmitted > node.Data.DateSubmitted)
                node.Right = Insert(node.Right, data);
            else
                return node; // Duplicate dates not allowed (or handle differently)

            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
            int balance = GetBalance(node);

            // Left Left Case
            if (balance > 1 && data.DateSubmitted < node.Left.Data.DateSubmitted)
                return RightRotate(node);

            // Right Right Case
            if (balance < -1 && data.DateSubmitted > node.Right.Data.DateSubmitted)
                return LeftRotate(node);

            // Left Right Case
            if (balance > 1 && data.DateSubmitted > node.Left.Data.DateSubmitted)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            // Right Left Case
            if (balance < -1 && data.DateSubmitted < node.Right.Data.DateSubmitted)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        // Public Insert method
        public void Insert(ServiceRequest data)
        {
            Root = Insert(Root, data);
        }

        // In-order traversal to get sorted list
        public void InOrderTraversal(AVLNode node, System.Collections.Generic.List<ServiceRequest> list)
        {
            if (node == null) return;

            InOrderTraversal(node.Left, list);
            list.Add(node.Data);
            InOrderTraversal(node.Right, list);
        }

        public System.Collections.Generic.List<ServiceRequest> GetSortedList()
        {
            var list = new System.Collections.Generic.List<ServiceRequest>();
            InOrderTraversal(Root, list);
            return list;
        }
    }
}
