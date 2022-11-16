using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpdater
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Введите путь к файлу, который необходимо открыть:");
            string path = Console.ReadLine();
            string[] pathParts = path.Split('.');
            string fileType = pathParts[1];
            Console.WriteLine(fileType);
            char[] letters = new char[100];
            List<char[]> chars = new List<char[]>();
            int pos = Console.CursorLeft;
            int pos1 = Console.CursorTop;
            if (fileType.Equals("txt"))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    int count = 0;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        Console.WriteLine(line);
                        //chars.AddRange(line.ToCharArray());
                        char[] temp = line.ToCharArray();
                        //if (count == 0 || count == 3 || count == 4)
                        //{
                            for (int i = 0; i < temp.Length; i++)
                            {
                                letters[i] = temp[i];
                            }
                            chars.Add(letters);
                        //}
                        //else
                        //{

                        //}
                        //for (int i = 0; i < temp.Length; i++)
                        //{
                        //    letters[i] = temp[i];
                        //}
                        //chars.Add(line.ToCharArray());
                        //chars.Add(letters);
                    }
                }
            }
            int pos2 = Console.CursorTop;
            ConsoleKeyInfo info;
            //List<char> chars = new List<char>();

            while (true)
            {
                info = Console.ReadKey(true);
                if (info.Key == ConsoleKey.Backspace && Console.CursorLeft > pos)
                {
                    //chars.RemoveAt(chars[Console.CursorTop - pos1][Console.CursorLeft]);
                    chars[Console.CursorTop - pos1][Console.CursorLeft] = ' ';
                    Console.CursorLeft -= 1;
                    Console.Write(' ');
                    //Console.Write(Console.CursorLeft);
                    Console.CursorLeft -= 1;

                }
                if (info.Key == ConsoleKey.RightArrow)
                {
                    //chars.RemoveAt(chars[Console.CursorTop - pos1].Length - 1);
                    Console.CursorLeft += 1;
                    //Console.Write(' ');
                    //Console.CursorLeft -= 1;

                }
                if (info.Key == ConsoleKey.LeftArrow && Console.CursorLeft > pos)
                {
                    Console.CursorLeft -= 1;
                }
                if (info.Key == ConsoleKey.UpArrow && Console.CursorTop > pos1)
                {
                    //chars.RemoveAt(chars.Count - 1);
                    Console.CursorTop -= 1;
                    //Console.WriteLine(Console.CursorTop);
                    //Console.Write(' ');
                    //Console.CursorTop -= 1;

                }
                if (info.Key == ConsoleKey.DownArrow && Console.CursorTop < pos2)
                {
                    Console.CursorTop += 1;
                }
                //else if (info.Key == ConsoleKey.Enter) { Console.Write(Environment.NewLine); break; }
                //Here you need create own checking of symbols
                else if (char.IsLetterOrDigit(info.KeyChar))
                {
                    Console.Write(info.KeyChar);
                    chars[Console.CursorTop - pos1][Console.CursorLeft] = info.KeyChar;
                }
                if (info.Key == ConsoleKey.Enter && Console.CursorTop == pos2)
                {
                    char[] letters_new = new char[100];
                    chars.Add(letters_new);
                    Console.CursorTop += 1;
                    Console.CursorLeft = pos;
                }
                {

                }
            }
            //ConsoleKeyInfo info = Console.ReadKey();
            //Console.WriteLine(info.KeyChar);
            for (int i = 0; i < chars.Count; i++)
            {
                Console.WriteLine(new string(chars[i].ToArray()));
            }
            //Console.WriteLine(new string(chars.ToArray()));
            Console.ReadKey();

        }
    }
}
