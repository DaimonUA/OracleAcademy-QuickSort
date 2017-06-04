using System;

namespace QuickSort
{
    class DisplayArray
    {
        /// <summary>
        /// выводит текущее состояние массива:
        /// array - выводимый массив (передается по ссылке);
        /// step - шаг операции сортировкиж;
        /// basicItem - индекс текущего опорного элемента сортировки массива (необязательный)
        /// </summary>
        /// <param name="currArray"></param>
        /// <param name="step"></param>
        /// <param name="basicItem"></param>
        internal static void ListCurrentlyArray(ref int[] currArray, int step, int basicItem = -1)
        {
            Console.Write("step {0}:\t", step);
            char addSymb = '\0';

            var bgcBasic = Console.BackgroundColor;
            for (int i = 0; i < currArray.Length; i++)
            {
                Console.Write("{0}", addSymb);
                if (i == basicItem)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                Console.Write("{0}", currArray[i]);
                Console.BackgroundColor = bgcBasic;
                addSymb = ',';
            }
            Console.BackgroundColor = bgcBasic;
            Console.WriteLine("");
        }
    }
}
