using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Generics.Heap
{
    public class BinaryHeap<T>
    {
        private readonly ArrayList _content;
        private readonly HeapType _heapType;

        public BinaryHeap(HeapType type = HeapType.MinHeap)
        {
            _content = new ArrayList();
            _heapType = type;
        }

        public int Insert(T item, double priority)
        {
            var index = _content.Add(Tuple.Create(item, priority));
            index = BubbleUp(index);
            return index;
        }

        public T ExtractBest()
        {
            var result = GetBest();
            DeleteBest();
            return result;
        }

        public T GetBest()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Heap is empty.");
            }

            return GetItemAtIndex(0);
        }

        public void DeleteBest()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Heap is empty.");
            SwitchItems(0, GetCount() - 1);
            _content.RemoveAt(GetCount() - 1);
            if (!IsEmpty())
                BubbleDown(0);
        }

        public int GetCount()
        {
            return _content.Count;
        }

        public bool IsEmpty()
        {
            return GetCount() == 0;
        }

        public void Clear()
        {
            _content.Clear();
        }

        private int GetParentIndex(int index)
        {
            if (index < 0 || index > GetCount() - 1)
                throw new System.InvalidOperationException("Invalid index.");
            var result = (int)Math.Floor(((double)index - 1) / 2);
            return result;
        }

        private int GetLeftChildIndex(int index)
        {
            if (index < 0 || index > GetCount() - 1)
                throw new System.InvalidOperationException("Invalid index.");
            var result = (2 * index) + 1;
            if (result > GetCount() - 1)
                result = index; // return itself if no children
            return result;
        }

        private int GetRightChildIndex(int index)
        {
            if (index < 0 || index > GetCount() - 1)
                throw new System.InvalidOperationException("Invalid index.");
            var result = (2 * index) + 2;
            if (result > GetCount() - 1)
                result = index; // return itself if no children
            return result;
        }

        private int BubbleUp(int index)
        {
            if (index == 0)
                return 0;
            var parent = GetParentIndex(index);
            // while parent is smaller and item not on root already
            while ((_heapType == HeapType.MinHeap && index != 0 && IsFirstBigger(parent, index))
                || (_heapType == HeapType.MaxHeap && index != 0 && IsFirstBigger(index, parent)))
            {
                SwitchItems(index, parent);
                index = parent;
                parent = GetParentIndex(parent);
            }
            return index;
        }

        private int BubbleDown(int index)
        {
            var finished = false;
            do
            {
                var leftChild = GetLeftChildIndex(index);
                var rightChild = GetRightChildIndex(index);
                // if left child is bigger then right child
                if (leftChild == index && rightChild == index) // when no children, get child will return element itself
                {
                    finished = true; // bubbled down to the end
                }
                else // bubble further
                {
                    int targetChild;
                    if ((_heapType == HeapType.MinHeap && IsFirstBigger(leftChild, rightChild)) ||
                        (_heapType == HeapType.MaxHeap && IsFirstBigger(rightChild, leftChild)))
                        targetChild = rightChild;
                    else
                        targetChild = leftChild;
                    // if smaller item at index is bigger than smaller child
                    if ((_heapType == HeapType.MinHeap && IsFirstBigger(index, targetChild))
                        || (_heapType == HeapType.MaxHeap && IsFirstBigger(targetChild, index)))
                    {
                        SwitchItems(targetChild, index);
                        index = targetChild;
                    }
                    else
                        finished = true;
                }
            }
            while (!finished);
            return index;
        }

        private void SwitchItems(int index1, int index2)
        {
            var temp = _content[index1];
            _content[index1] = _content[index2];
            _content[index2] = temp;
        }

        // Helper Methods
        private bool IsFirstBigger(int first, int second)
        {
            return GetPriorityAtIndex(first) > GetPriorityAtIndex(second);
        }

        private T GetItemAtIndex(int index)
        {
            var item = (Tuple<T, double>)_content[index];
            return item.Item1;
        }

        private double GetPriorityAtIndex(int index)
        {
            var item = (Tuple<T, double>)_content[index];
            return item.Item2;
        }
    }
}
