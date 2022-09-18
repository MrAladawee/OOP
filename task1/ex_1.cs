using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {

        static string q(string string1, string string2)
        {
            Dictionary<char, int> Letter = new Dictionary<char, int>();

            for (int i = 0; i < string1.Length; i++)
            {
                if (string1[i] == ' ') continue;

                char temps = string1[i]; // добавление временного хранения буквы
                int temp = 0; // добавление временного хранения кол-ва для буквы temps

                for (int j = 0; j < string1.Length; j++)
                {
                    if (string1[j] == temps)
                    {
                        temp++;
                    }
                }

                if (Letter.ContainsKey(temps) == false)
                {
                    Letter.Add(temps, temp);
                }

            } // окончание for для первого слова

            for (int i = 0; i < string2.Length; i++)
            {
                if (string2[i] == ' ') continue;
                int temp2 = 0;
                char temps2 = string2[i];

                for (int j = 0; j < string2.Length; j++)
                {
                    if (string2[j] == temps2)
                    {
                        temp2++;
                    }
                } // окончание поиска кол-ва буквы

                if (Letter.ContainsKey(temps2) == true)
                {
                    if (Letter[temps2] != temp2)
                    {
                        return "no";
                    }

                }
            } // окончание перебора

            return "yes";

        }

        static void Main(string[] args)
        {
            Console.WriteLine(q("ssa", "sas"));
            Console.WriteLine(q("ssa", "sss"));
            Console.WriteLine(q("school master", "the classroom"));
        }
    }
}
