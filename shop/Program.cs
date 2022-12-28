using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Text.Json;

    namespace shop
    {
        class Program
        {
               static  List<adminestrator> AllAcount;
    
               static int MENU = 0;


            static void Main()
        {
            string LOG_IN = null;

            read();
            LOG_IN = login(LOG_IN);

            while (true)
            {


                Console.Clear();

                Console.WriteLine("ваш логин, " + LOG_IN);

                Console.WriteLine("ползователи:");

                foreach (adminestrator user in AllAcount)
                {
                    Console.WriteLine("  " + user.log_in);
                }




                Console.SetCursorPosition(0, 2 + MENU);
                Console.WriteLine(">>");


                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (MENU > 0)
                        {
                            MENU--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (MENU < AllAcount.Count - 1)
                        {
                            MENU++;
                        }

                        break;

                    case ConsoleKey.Tab:
                        Console.Clear();

                        Console.WriteLine("логин " + AllAcount[MENU].log_in + " пароль " + AllAcount[MENU].password);

                        Console.ReadKey();
                        break;
                    case ConsoleKey.Insert:
                        neww();
                        break;
                    case ConsoleKey.Escape:
                        write();
                        return;
                    case ConsoleKey.Delete:
                        del();
                        break;


                    case ConsoleKey.E:
                        edit();
                        break;


                    case ConsoleKey.F:
                        find();
                        break;

                }
            }
        }

        private static void write()
        {
            File.WriteAllText("j.json", JsonSerializer.Serialize(AllAcount));
        }

        private static string login(string LOG_IN)
        {
            do
            {
                Console.WriteLine(" логин");

                string name = Console.ReadLine();

                Console.WriteLine(" пароль");
                string pass = "";

                do
                {

                    ConsoleKeyInfo ky = Console.ReadKey(true);
                    if (ky.Key != ConsoleKey.Enter)
                    {
                        pass += ky.KeyChar;

                        Console.Write('*');
                    }
                    else
                    {
                        break;
                    }


                } while (true);

                Console.WriteLine();

                foreach (adminestrator oneUSER in AllAcount)
                {
                    if (name == oneUSER.log_in &&

                        pass == oneUSER.password)
                    {
                        LOG_IN = name;
                        break;
                    }
                }

                if (LOG_IN != null)
                {
                    break;
                }

                Console.Clear();
                Console.WriteLine("попробуйте еще раз");
            } while (true);

            return LOG_IN;
        }

        private static void read()
        {
            if (!File.Exists("j.json"))
            {
                AllAcount = new List<adminestrator>
                    {
                        new adminestrator(1, "юзер", "парол", roles_enum.adminestrator)

                    };
            }
            else
            {

                readd();
            }
        }

        private static void readd()
        {
            string fil = File.ReadAllText("j.json");

            AllAcount = JsonSerializer.Deserialize<List<adminestrator>>(fil);
   }

        static void exit()
            {
            
            }

             static void find()
            {
                Console.Clear();
                Console.WriteLine("1 логин, 2 пароль");
                int prop = int.Parse(Console.ReadLine());

                Console.WriteLine("введите поиск");
                string val = Console.ReadLine();

                Console.WriteLine("найдены");

                switch (prop)
                {
                    case 1:
                        foreach (adminestrator user in AllAcount)
                        {
                            if (user.log_in.Contains(val))
                            {
                                Console.WriteLine(user.log_in);
                            }
                        }
                        break;
                    case 2:
                        foreach (adminestrator user in AllAcount)
                        {
                            if (user.password.Contains(val))
                            {
                                Console.WriteLine(user.log_in);
                            }
                        }
                        break;
                    default:
                        break;
                }

                Console.ReadKey();
            }

            static void del()
            {
                if (AllAcount.Count > 0)
                {
                    AllAcount.RemoveAt(MENU);
                    MENU = 0;
                }
            }

             static void edit()
            {
                Console.Clear();
                Console.WriteLine(" новый логин");


                string log = Console.ReadLine();
                Console.WriteLine(" новый пароль");



                string pww = Console.ReadLine();
            int old_id = AllAcount[MENU].id;
                AllAcount[MENU] = new adminestrator(old_id, log, pww, roles_enum.adminestrator);
            }

             static void neww()
            {
                Console.Clear();

                Console.WriteLine(" логин");

                string login = Console.ReadLine();
                Console.WriteLine(" пароль");

                string password = Console.ReadLine();
                AllAcount.Add(new adminestrator(newid(), login, password, roles_enum.adminestrator));
            }

         static int newid()
        {
            int newid = 0;
            foreach (adminestrator oneAcc in AllAcount)
            {
                if (oneAcc.id > newid)
                { newid = oneAcc.id;
                }
        }
                return newid+1;
        }
    }}