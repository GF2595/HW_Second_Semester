using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TreeNamespace
{
    /// <summary>
    /// References-based binary tree
    /// </summary>
    class Tree
    {
        private TreeNode head = null;

        private abstract class TreeNode
        {
            internal TreeNode Left { get; set; }
            internal TreeNode Right { get; set; }

            /// <summary>
            /// Calculates result of expression starting from current node
            /// </summary>
            /// <returns>Expression result</returns>
            abstract internal int CalculateNode();

            /// <summary>
            /// Prints expression starting from current node
            /// </summary>
            abstract internal void PrintNode();

            /// <summary>
            /// Fills tree staring from current node with expression starting from specified position in string
            /// </summary>
            /// <param name="buffer">Expression-representing string</param>
            /// <param name="position">Expression start position</param>
            /// <returns>Filled node</returns>
            internal static TreeNode FillNode(string buffer, ref int position)
            {
                if (IsBorder(buffer[position]))
                {
                    ++position;
                    return FillNode(buffer, ref position);
                }
		        else if (IsOperation(buffer[position]))
		        {
                    TreeNode temp = new Operation(buffer[position]);

                    ++position;

                    temp.Left = FillNode(buffer, ref position);
                    temp.Right = FillNode(buffer, ref position);

                    return temp;
		        }
		        else
                {
                    ++position;

                    return new Number(buffer[position - 1] - '0');
		        }
            }
        }

        private class Number : TreeNode
        {
            private int _Number = 0;

            /// <summary>
            /// Number constructor
            /// </summary>
            /// <param name="number">TreeNode number value</param>
            internal Number(int number)
            {
                this._Number = number;
            }

            internal override int CalculateNode()
            {
                return _Number;
            }

            internal override void PrintNode()
            {
                Console.Write("{0} ", this._Number);
            }
        }

        private class Operation : TreeNode
        {
            private char _Operation = ' ';

            /// <summary>
            /// Operation constructor
            /// </summary>
            /// <param name="operation">TreeNode operation symbol</param>
            internal Operation(char operation)
            {
                this._Operation = operation;
            }

            internal override int CalculateNode()
            {
                int result = 0;

                switch (this._Operation)
                {
                    case '+':
                        {
                            result = this.Left.CalculateNode() + this.Right.CalculateNode();
                        }
                        break;
                    case '-':
                        {
                            result = this.Left.CalculateNode() - this.Right.CalculateNode();
                        }
                        break;
                    case '*':
                        {
                            result = this.Left.CalculateNode() * this.Right.CalculateNode();
                        }
                        break;
                    case '/':
                        {
                            int temp = this.Right.CalculateNode();

                            if (temp == 0)
                            {
                                throw new DivisionByZeroException();
                            }

                            result = this.Left.CalculateNode() / temp;
                        }
                        break;
                    default:
                        {
                            result = 0;
                        }
                        break;
                }

                return result;
            }

            internal override void PrintNode()
            {
                Console.Write("( {0} ", this._Operation);
                this.Left.PrintNode();
                this.Right.PrintNode();
                Console.Write(") ");
            }
        }

        /// <summary>
        /// Checks, if symbol is symbol of operation
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <returns>"true" if symbol represents operation, "false" otherwise</returns>
        private static bool IsOperation(char symbol)
        {
            return symbol == '+' || symbol == '-' || symbol == '/' || symbol == '*';
        }

        /// <summary>
        /// Checks, if symbol is symbol of border
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <returns>"true" if symbol represents border, "false" otherwise</returns>
        private static bool IsBorder(char symbol)
        {
            return symbol == '(' || symbol == ')' || symbol == ' ';
        }   

        /// <summary>
        /// Fills tree with expression from file
        /// </summary>
        /// <param name="filePath">Expression-containing file directory</param>
        public void FillTree(string filePath)
        {
            StreamReader streamReader = new StreamReader(filePath);
            string buffer = "";

            while (!streamReader.EndOfStream)
            {
                buffer += streamReader.ReadLine();
            }

            int position = 0;

            this.head = TreeNode.FillNode(buffer, ref position);
        }

        /// <summary>
        /// Prints tree
        /// </summary>
        public void PrintTree()
        {
            this.head.PrintNode();

            Console.WriteLine();
        }

        /// <summary>
        /// Calculates result of expression in tree
        /// </summary>
        /// <returns>Expression result</returns>
        internal int CalculateTree()
        {
            if (this.head != null)
            {
                return this.head.CalculateNode();
            }
            else
            {
                return 0;
            }
        }
    }
}
