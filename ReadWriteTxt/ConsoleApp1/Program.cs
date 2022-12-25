using System;
using System.IO;

namespace RWtxt
{
    class Program
    {
        static void Main(string[] args)
        {
            start:  //ссылка для перехода к началу программы
            Console.WriteLine("Для записи введите 1\nДля чтения 2\n Для выхода введите 0");
            int a = int.Parse(Console.ReadLine());
            switch (a)
            {

                case 1:
                    {
                        string path = @"TextTest.txt";
                        if (!File.Exists(path))
                        {
                            File.Create(path).Close();
                        }
                        Console.WriteLine("Введите \"!s\" для прекращения записи в файл.");
                        {
                            using (var file = new StreamWriter(@"TextTest.txt"))
                            {
                                while (true)
                                {
                                    Console.Write("Введите текст для записи: ");
                                    var line = Console.ReadLine();  // Получаем текст  

                                    // прерываем цикл 
                                    if (line == "!s")
                                        goto start; // переход к началу программы
  
                                    file.WriteLine(line);   // Записываем в файл

                                }
                            }

                        }
                        
                    }
                case 2:
                     
                    try
                    {

                        StreamReader stringreader = new StreamReader(@"TextTest.txt");
                        Console.WriteLine("Ваш текстовый файл:\n-----------------\n");
                        String readln = stringreader.ReadLine();    //Читаем первую линию текста
                        while (readln != null)  //Продолжаем читать 

                        {

                            Console.WriteLine(readln);

                            readln = stringreader.ReadLine();
                        }
                        Console.WriteLine("\n-----------------\n");
                        stringreader.Close();
                        
                        goto start; // переход к началу программы
                    }
                    catch (Exception) // исключения
                    {

                    }

                    break;
                case 0:  //выход
                    {
                        Environment.Exit(0);
                        break;
                    }

            }
        }
    }
}