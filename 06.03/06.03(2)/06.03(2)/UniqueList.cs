using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListNamespace
{
    /// <summary>
    /// _List-based uniqueList
    /// </summary>
    public class UniqueList : _List
    {
        public UniqueList()
            :base()
        {
        }

        /// <summary>
        /// Adds value to the end of a list
        /// </summary>
        /// <param name="value">Value to be added</param>
        public override void AddElement(int value)
        {
            if (this.FindElement(value) != -1)
            {
                throw new AlreadyAddedElementAddingException();
            }
            else            
                base.AddElement(value);
        }
        
        /// <summary>
        /// Places value on specified place in list
        /// </summary>
        /// <param name="value">Value to be added</param>
        /// <param name="position">Position on which element will be placed</param>
        public override void PlaceElement(int value, int position)
        {
            if (this.FindElement(value) != -1)
            {
                throw new AlreadyAddedElementAddingException();
            }
            else
            {
                base.PlaceElement(value, position);
            }
        }
    }
}
