using System;
using System.IO;
using System.Net;

using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace NetworkClient
{
    public class Programm
    {
        public static void Main()
        {
            string link;
            while (true)
            {
                Console.WriteLine("Укажите ссылку на сайт, exit - выход");
                link = Console.ReadLine();
                if (link == "exit")
                    Environment.Exit(0);
                WebRequest request = WebRequest.Create(link);
                request.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Console.WriteLine(response.StatusDescription);


                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                Console.WriteLine(responseFromServer);

                string path = @"TextTest.txt";
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }


                if (response == null || response.StatusCode != HttpStatusCode.OK)
                {
                    Console.WriteLine("\nСайт {0} не доступен\n", link);  // failed
                    using (var file = new StreamWriter(@"TextTest.txt", true))
                    {
                        var line ="Сайт не доступен" + link;  // Получаем текст  
                        file.WriteLine(line);   // Записываем в файл
                    }
                }
                else
                {
                    Console.WriteLine("\nСайт {0} доступен\n", link);
                    using (var file = new StreamWriter(@"TextTest.txt", true))
                    {
                        var line = "Сайт доступен " + link;  // Получаем текст  
                        file.WriteLine(line);   // Записываем в файл
                    }
                }

                reader.Close();
                dataStream.Close();
                response.Close();
            }
        }
    }
}