using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Practical_work_3
{
    internal class Agenda
    {   
        public Agenda()
        {

        }

        public static void Login()
        {
            List<User> ListUsers = new List<User>();

            var path = "../../users.txt";
            char separator = ';';

            int Index_ListUsers = 0;

            if (File.Exists("../../users.txt"))
            {
                Console.WriteLine("Loading...");
                StreamReader sr = File.OpenText(path);
                try
                {
                    string line = null;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] values = line.Split(separator);
                        ListUsers.Add(new User());
                        for (int i = 0; i < values.Length; i++)
                        {
                            if (i == 0)
                                ListUsers[Index_ListUsers].SetUser(values[i]);
                            if (i == 1)
                                ListUsers[Index_ListUsers].SetPassword(values[i]);
                            if (i == 2)
                                ListUsers[Index_ListUsers].SetUsername(values[i]);
                        }
                        Index_ListUsers++;
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine("Esto es un error");
                }

                finally
                {
                    sr.Close();
                }
            }
            else
            {
                Console.WriteLine("Specified file does not exist in the current directory.");
            }

            string menu = "5", menu2, userinfo;
            int indexlist = 0;
            while (menu != "0")
            {
                Console.Clear();
                Console.WriteLine("WELCOME TO MOVIESHARE");
                Console.WriteLine("1. Sign up");    //Create account
                Console.WriteLine("2. Sign in");    //Access your account
                Console.WriteLine("0. Close app");    //Close program
                Console.Write("CHOOSE YOUR OPTION: ");
                menu = Console.ReadLine();

                if (menu == "1")
                {//Creating account
                    Console.Clear();
                    indexlist = ListUsers.Count;
                    ListUsers.Add(new User());
                    Console.WriteLine("\nYou are creating your account.\n\nIntroduce your mail: ");
                    userinfo = Console.ReadLine();
                    ListUsers[indexlist].SetUser(userinfo);
                    Console.WriteLine("\nIntroduce your password: ");
                    userinfo = Console.ReadLine();
                    ListUsers[indexlist].SetPassword(userinfo);
                    Console.WriteLine("\nIntroduce a username to access: ");
                    userinfo = Console.ReadLine();
                    ListUsers[indexlist].SetUsername(userinfo);

                    Console.WriteLine("Nice!");
                    Thread.Sleep(2500);
                    Console.WriteLine("Your account has been created!");
                    Thread.Sleep(2500);
                }

                else if (menu == "2")
                {//Accessing acount
                    Console.Clear();
                    string mailtosearch, pswdtosearch;
                    Console.WriteLine("\nWrite your username/mail: ");
                    mailtosearch = Console.ReadLine();
                    Console.WriteLine("\nWrite your password: ");
                    pswdtosearch = Console.ReadLine();
                    int usercorrect = 0;
                    for (int i = 0; i < ListUsers.Count; i++)
                    {
                        if ((ListUsers[i].GetUser() == mailtosearch && ListUsers[i].GetPassword() == pswdtosearch) || (ListUsers[i].GetUsername() == mailtosearch && ListUsers[i].GetPassword() == pswdtosearch))
                            usercorrect = 1;
                    }
                    if(usercorrect == 0)
                    {
                        Console.WriteLine("Invalid user/mail or password");
                        Thread.Sleep(1000);
                    }
                    if (usercorrect == 1)
                    {
                        menu2 = "5";
                        while (menu2 != "0")
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("What do you want to do now?");
                            Console.WriteLine("1. Add a new content");
                            Console.WriteLine("2. Add a new episode in existing content");
                            Console.WriteLine("3. Search for content");
                            Console.WriteLine("4. Show all contents");
                            Console.WriteLine("5. Show content ranking (Top 10)");
                            Console.WriteLine("6. Evaluate content");
                            Console.WriteLine("0. Log out");
                            Console.WriteLine();
                            Console.Write("Choose an option: ");
                            menu2 = Console.ReadLine();

                            if(menu2 == "1")
                            {

                            }
                            else if (menu2 == "2")
                            {

                            }
                            else if (menu2 == "3")
                            {

                            }
                            else if (menu2 == "4")
                            {

                            }
                            else if (menu2 == "5")
                            {

                            }
                            else if (menu2 == "6")
                            {

                            }
                            else if (menu2 != "0")
                            {
                                Console.WriteLine("\nChoose a valid option (1, 2, 3, 4, 5, 6 or 0)");
                                Thread.Sleep(1000);
                            }
                        }
                    }
                   
                }
                else if (menu == "0")
                {
                    StreamWriter sw = File.CreateText(path);
                    for (int i = 0; i < ListUsers.Count; i++)
                    {
                        sw.WriteLine(ListUsers[i].PrintUser());
                    }

                    sw.Close();
                }
                else
                {
                    Console.WriteLine("Choose a valid option (1,2 or 0)");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
