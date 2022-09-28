using System;
namespace PracticeExercise1
{
    public class ArrayList : IList
    {
        private int[] array;
        private int length;

        public ArrayList()
        {
            array = new int[16];
            length = 0;
        }

        /// <summary>
        /// Returns first element in list, null if empty.
        /// </summary>
        public int? First
        {
            get => IsEmpty ? null : array[0];
        }

        // TOD0
        public int? Last { get => IsEmpty ? null : array[Length - 1]; }

        /// <summary>
        /// Returns true if list is has no elements; false otherwise.
        /// </summary>
        public bool IsEmpty { get => Length == 0; }

        /// <summary>
        /// Number of elements in list.
        /// </summary>
        public int Length { get => length; }

        // TODO fix capacity bug
        /// <summary>
        /// Adds given value to end of list.
        /// </summary>
        /// <param name="value"></param>
        public void Append(int value)
        {
            if (Length == array.Length)
            {
                Resize();
            }

            array[length] = value;
            length++;
        }

        /// <summary>
        /// Checks if the list contains the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true if value is in list; false otherwise</returns>
        public bool Contains(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (array[i] == value)
                {
                    return true;
                }
            }

            return false;
        }

        // TODO
        /// <summary>
        /// Find index of first element with matching value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Index of first element with value; -1 if element is not found</returns>
        public int FirstIndexOf(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (array[i] == value) { return i; }
            }
            return -1;
        }

        // TODO
        /// <summary>
        /// Insert new value after first instance of existing value.
        /// If existingValue is not in list, then add new value to end of list.
        /// </summary>
        /// <param name="newValue"></param>
        /// <param name="existingValue"></param>
        public void InsertAfter(int newValue, int existingValue)
        {
            if (Length == array.Length)
            {
                Resize();
            }
            if (Contains(existingValue) == false)
            {
                Append(newValue);
            }
            else
            {
                InsertAt(newValue, FirstIndexOf(existingValue) + 1);
            }
        }

        // TODO
        /// <summary>
        /// Insert value at given index 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="index"></param>
        public void InsertAt(int value, int index)
        {
            if (Length == array.Length)
            {
                Resize();
            }
            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            ShiftRight(index);
            array[index] = value;
            length++;
        }

        /// <summary>
        /// Add value to beginning of list
        /// </summary>
        /// <param name="value"></param>
        public void Prepend(int value)
        {
            if (Length == array.Length)
            {
                Resize();
            }

            // shift elements to right
            ShiftRight(0);

            array[0] = value;
            length++;

        }

        private void ShiftRight(int index)
        {
            for (int i = Length - 1; i >= index; i--)
            {
                array[i + 1] = array[i];
            }
        }

        private void ShiftLeft(int startingIndex)
        {
            for (int i = startingIndex + 1; i <= Length; i++)
            {
                array[i - 1] = array[i];
            }
        }


        // TODO
        /// <summary>
        /// Remove first item with given value
        /// </summary>
        /// <param name="value">value of item to be removed</param>
        public void Remove(int value)
        {
            int FI = FirstIndexOf(value);
            if (FI != -1)
            {
                Remove(FI);
            }
        }

        // TODO
        /// <summary>
        /// Remove item at specififed index.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (IsEmpty == true)
            {
                throw new NotImplementedException();
            }
            if (index > Length - 1 || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            ShiftLeft(index);
            length--;
        }

        public override string ToString()
        {
            if (this.IsEmpty)
            {
                return "[}";
            }
            // caused problems and I dont know why
            string str = "[ ";

            for (int i = 0; i < Length - 1; i++)
            {
                str += array[i] + ", ";
            }

            str += array[Length - 1];
            str += "]";

            return str;

        }

        /// <summary>
        /// Return the element at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>The element at the given index.</returns>
        public int Get(int index)
        {
            if (index > Length - 1 || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            int element = array[index];

            return element;

        }

        /// <summary>
        /// Remove all elements from list
        /// </summary>
        public void Clear()
        {
            length = 0;
        }

        /// <summary>
        /// Return a new copy of list in reverse order
        /// </summary>
        /// <returns></returns>
        public IList Reverse()
        {
            IList reverse = new ArrayList();

            for (int i = 0; i < Length; i++)
            {
                reverse.Prepend(array[i]);
            }

            return reverse;
        }


        private void Resize()
        {
            Array.Resize(ref array, 2 * array.Length);
        }

    }
}



