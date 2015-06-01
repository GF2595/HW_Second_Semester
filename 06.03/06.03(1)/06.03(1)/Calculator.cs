using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeNamespace
{
    /// <summary>
    /// Tree-based expression calculator
    /// </summary>
    public class Calculator
    {
        private Tree tree;
        private int expressionResult = 0;

        /// <summary>
        /// Calculator constructor
        /// </summary>
        /// <param name="expressionFileReference">Expression-containing file directory</param>
        public Calculator(string expressionFileReference)
        {
            tree = new Tree();

            tree.FillTree(expressionFileReference);
            expressionResult = tree.CalculateTree();
        }

        /// <summary>
        /// Returns result of expression recorded in calculators' memory
        /// </summary>
        /// <returns>Expression result</returns>
        public int GetExpressionResult()
        {
            return this.expressionResult;
        }
    }
}
