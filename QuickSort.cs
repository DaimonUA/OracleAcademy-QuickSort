using System;
namespace QuickSort
{
    class QuickSort
    {
        static void Main()
        {
            int[] myArray = GetArray();
            int step = 0; //этап сортировки
            DisplayArray.ListCurrentlyArray(ref myArray,step);
            OrderArray(ref myArray,step,0,myArray.Length-1);
            Console.ReadKey();
        }

        static void OrderArray(ref int[] array, int step, int leftIndex, int rightIndex)
        {
            if (leftIndex > rightIndex) return;
            step++;
            int begin = leftIndex;
            int end = rightIndex;
            int pivotIndex = 0;
            bool rebuilding = false;
            while (!GetPivot(ref array, ref begin, ref end))
            {
                pivotIndex = end;
                DisplayArray.ListCurrentlyArray(ref array, step, pivotIndex);
                rebuilding = true;
            }
            if (rebuilding)
            {
                OrderArray(ref array, step, leftIndex, pivotIndex-1);
                OrderArray(ref array, step, pivotIndex+1, rightIndex);
            }
        }

        /// <summary>
        /// возвращает false, если опорный элемент выделенного отрезка массива (с indexInc по indexDec) находится не на своем месте;
        /// при это происходит перестроение элентов массива.
        /// Иначе возвращется true.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="indexInc"></param>
        /// <param name="indexDec"></param>
        /// <returns></returns>
        static bool GetPivot(ref int[] array, ref int indexInc, ref int indexDec)
        {
            int i = indexInc;
            int j = indexDec;
            int pivot = array[j];
            while ((pivot > array[i]) && (i<j))
                {
                i++;
                }

            if (i < j)
            {
                RebuildItems(ref array, i, j);
                indexDec--;
                indexInc = i;
                return false;

            }
            
            return indexInc >= (--indexDec);

        }

        static void RebuildItems(ref int[] array, int leftIndex, int rightIndex)
        {
               if (rightIndex-leftIndex > 1)
                {
                    int tmp = array[rightIndex - 1];
                    array[rightIndex-1] = array[rightIndex];
                    array[rightIndex] = array[leftIndex];
                    array[leftIndex] = tmp;
                 }
                 else
                {
                    array[rightIndex] = array[leftIndex]+array[rightIndex];
                    array[leftIndex] = array[rightIndex]-array[leftIndex];
                    array[rightIndex] = array[rightIndex]-array[leftIndex];
                }

        }

        static int[] GetArray()
        {
            int[] resArray = { 3, 7, 8, 5, 2, 1, 9, 5, 4 }; //from Wiki
            //int[] resArray = { 3, 7, 8, 5, 2, 1, 9, 6, 14 };
            //int[] resArray = { -34, 45, 28, 10, 4, 47, 23, 15, 61, 88, 55 };
            //int[] resArray = { -34,0,1,2,71,70, -34 };
            return resArray;
        }

    }
}
