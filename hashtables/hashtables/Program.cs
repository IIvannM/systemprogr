using System;
using System.Collections;
using System.Xml.Linq;

namespace hashtables
{
    class GFG
    {

        static public void Main()
        {
            
            Hashtable hTable = new Hashtable();  // создание хеш таблицы с использованием класса Hashtable
            ICollection c = hTable.Keys;

            hTable.Add("#1", "Данные #1");     //добавление ключей и данных
            hTable.Add("#2", "Данные #2");
            hTable.Add("#3", "Данные #3");

            Console.WriteLine("Данные в хеш таблице:");
            foreach (DictionaryEntry element in hTable) // DictionaryEntry определяет ключ-значение, которое надо извлечь  
            {
                Console.WriteLine("{0} : {1} ", element.Key, element.Value);
            }

            while (true)
            {
                Console.WriteLine("\n1 - добавить\n2 - вывести всю таблицу на экран \n3 - поиск по ключу\n4 - удалить элемент" +
                    "\n 5 - очистить всю таблицу\n 0 - выход из программы");
                int choice = int.Parse(Console.ReadLine());
                string key;
                string data;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nКлюч:");
                        key = Console.ReadLine();
                        if (hTable.ContainsKey(key))
                            Console.WriteLine("Ключ уже определен в таблице");
                        else
                        {
                            Console.WriteLine("\nДанные:");
                            data = Console.ReadLine();
                            hTable.Add(key, data);
                        }
                        break;

                    case 2:

                        Console.WriteLine("Данные в хеш таблице:");
                        foreach (DictionaryEntry element in hTable) // DictionaryEntry определяет ключ-значение, которое надо извлечь  
                        {
                            Console.WriteLine("{0} : {1} ", element.Key, element.Value);
                        }
                        break;

                    case 3:

                        Console.WriteLine("\nДанные по ключу:");
                        key = Console.ReadLine();
                        if (!hTable.ContainsKey(key))
                            Console.WriteLine("Ключ не определен в таблице");
                        else
                        {
                            
                            Console.WriteLine(key + ": " + hTable[key]);
                        }
                        
                        break;

                    case 4:
                        Console.WriteLine("\nКлюч:");
                        key = Console.ReadLine();
                        
                        if (hTable.ContainsKey(key))
                            hTable.Remove(key);
                        else
                        {
                            Console.WriteLine("\nТакого ключа нет в таблице");
                        }
                        break;

                    case 5:
                        hTable.Clear();
                        Console.WriteLine("Данные в хеш таблице:");
                        foreach (DictionaryEntry element in hTable) // DictionaryEntry определяет ключ-значение, которое надо извлечь  
                        {
                            Console.WriteLine("{0} : {1} ", element.Key, element.Value);
                        }
                        break;

                    case 0:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
