using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TAT2019.Kuzniatsou.Task1
{
    class Subsequence
    {
        public string inputLine;

        public Subsequence(string line)
        {
                inputLine = line;
        }

        public void SearchSubsequences()
        {
            // Подпоследовательность между повторяющимися символами.
            string outputLine = string.Empty;
            // Список всех подпоследовательностей.
            List<string> subSequences = new List<string>();
            // Индекс первого и последнего элемента в подпоследовательности.
            int indexFirst = 0;
            int indexEnd = 0;
            do
            {
                for(indexEnd = indexFirst; indexEnd < inputLine.Length; indexEnd++)
                {
                    // Исключение для последнего элемента, чтобы не было выхода за границы.
                    if (indexEnd == inputLine.Length - 1)
                    {
                        // Проверка на то, что был добавлен предыдущий символ
                        // для добавления последнего символа перед повторяющимися символами.
                        if ((indexEnd - indexFirst) > 0) 
                        {
                            outputLine += inputLine[indexEnd];
                        }
                        break;
                    }
                    // Сравнение символов.
                    if (inputLine[indexEnd] != inputLine[indexEnd + 1])
                    {
                        // Добавляем символ в подпоследовательность.
                        outputLine += inputLine[indexEnd];
                    }
                    else
                    {
                        if ((indexEnd - indexFirst) > 0) 
                        {
                            outputLine += inputLine[indexEnd];
                        }
                        break;
                    }
                }
                // Для исключения: первые два символа повторяются.
                // Чтобы не записывало пустую строку в список.
                if (outputLine != String.Empty)
                {
                    // Добавляем в список данную подпоследовательность.
                    subSequences.Add(outputLine);
                    // Ищем все комбинации подпоследовательностей в данной подпоследовательности.
                    for (int i = 0; i < outputLine.Length; i++)
                        for (int j = outputLine.Length - 1; j > i; j--)
                        {
                            // Выделение подпоследовательности в подпоследовательности.
                            string subLine = outputLine.Substring(i, j - i + 1);
                            if (!subSequences.Contains(subLine) && subLine.Length >= 2)
                            {
                                // Добавление в список.
                                subSequences.Add(subLine);
                            }
                        }
                }
                // Перемещаем начальный индекс на новое место.
                indexFirst = indexEnd + 1;
                // Очищаем строку для нахождения новой подпоследовательности.
                outputLine = string.Empty;
            }
            // Ходим в цикле пока начальный индекс не уйдет за пределы строки.
            while (indexFirst < inputLine.Length - 1);
            OutputOnDisplay(subSequences);
        }

        // Вывод на экран.
        public void OutputOnDisplay(List<string> line) 
        {
            foreach (string i in line)
                Console.WriteLine(i);
        }
    }
}
