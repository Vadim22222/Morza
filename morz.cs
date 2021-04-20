using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class morz
    {
        static void Main(string[] args)
        {
            string[] mz = new string[27];
            string[] en = new string[27];
            string s, ret = "", smz = ""; int i1, t;

            string path = @"G:\CU\ConsoleApp1\morza.txt";

            

            //Чтение языка морза
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    mz[i] = line;
                    i++;
                }
            }

            for (int i = 0; i < 27; i++)
            {
                Console.Write(i + 1); Console.Write(". "); Console.WriteLine(mz[i]);
            }


            //Чтение аглийского языка
            path = @"G:\CU\ConsoleApp1\EN.txt";

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    en[i] = line;
                    i++;
                }
            }

            for (int i = 0; i < 27; i++)
            {
                Console.Write(i + 1); Console.Write(". "); Console.WriteLine(en[i]);
            }


            Console.WriteLine("Примечание: для записи языка морза после каждой буквы и пробела писать '|'. Пример: .-|-...|-.-.| |-..|.| ");

            //Управление переводом
            while (true)
            {

                Console.WriteLine("1. EN to Morza, 2. Morza to EN, 0. Выйти");
                t = Convert.ToInt32(Console.ReadLine());

                if (t == 0) { break; }

                switch (t)
                {
                        //Перевод из EN в Морзу
                    case 1:
                        {
                            Console.WriteLine("Введите текст: ");
                            s = Console.ReadLine();

                            ret = "";

                            for (int i = 0; i < s.Length; i++)
                            {
                                for (int j = 0; j < 27; j++)
                                {
                                    if (en[j][0] == s[i])
                                    {
                                       
                                        ret = ret + mz[j] + "|";
                                        break;
                                    }
                                }
                            }

                            Console.WriteLine(ret);
                            break;
                        }
                        
                        //Перевод из Морзы в EN
                    case 2:
                        {
                            Console.WriteLine("Введите текст: ");
                            s = Console.ReadLine();

                            ret = "";

                            for (int i = 0; i < s.Length; i++)
                            {
                                if (s[i] != '|')
                                {
                                    smz = smz + s[i];
                                }
                                else
                                {
                                    for (int j = 0; j < 27; j++)
                                    {
                                        if (mz[j] == smz)
                                        {
                                            ret = ret + en[j];

                                            break;
                                        }
                                    }
                                    smz = "";
                                }
                            }

                            Console.WriteLine(ret);

                            break;
                        }
                }
            }
        }
    }
}
