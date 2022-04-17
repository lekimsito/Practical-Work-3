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
            List<Contents> ListContents = new List<Contents>();
            List<Contents.Movie> ListMovie = new List<Contents.Movie>();
            List<Contents.Shows> ListShows = new List<Contents.Shows>();
            List<Contents.Podcast> ListPodcast = new List<Contents.Podcast>();
            List<Episode> ListEpisodes = new List<Episode>();
            ListContents.AddRange(ListMovie);
            ListContents.AddRange(ListShows);
            ListContents.AddRange(ListPodcast);

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

                catch (Exception)
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





            var path2 = "../../contents.txt";
            char separator2 = ';';

            int Index_ListMovie = 0, Index_ListShow = 0, Index_ListPodcast = 0, Index_ListEpisodes = 0;

            if (File.Exists("../../contents.txt"))
            {
                Console.WriteLine("Loading...");
                StreamReader sr2 = File.OpenText(path2);
                try
                {
                    string line = null;
                    int show = 0, podcast = 0;
                    float[] score = {0,0};

                    while ((line = sr2.ReadLine()) != null)
                    {
                        string[] values = line.Split(separator2);
                        
                            if(values[0] == "MOVIE")
                            {
                                ListMovie.Add(new Contents.Movie());
                                ListMovie[Index_ListMovie].SetName(values[1]);
                                ListMovie[Index_ListMovie].SetPlatform(values[2]);
                                ListMovie[Index_ListMovie].SetDescription(values[3]);
                                ListMovie[Index_ListMovie].SetAge(Convert.ToInt32(values[4]));
                                ListMovie[Index_ListMovie].SetGender(values[5]);
                                score[0] = Convert.ToSingle(values[6]);
                                score[1] = Convert.ToSingle(values[7]);

                                ListMovie[Index_ListMovie].SetScore(score);
                                ListMovie[Index_ListMovie].SetTypeCont(values[8]);
                                ListMovie[Index_ListMovie].SetExpiration(values[9]);
                                Index_ListMovie++;
                            }

                            else if (values[0] == "SHOW")
                            {
                                show = 1;
                                podcast = 0;
                                ListShows.Add(new Contents.Shows());
                                ListShows[Index_ListShow].SetName(values[1]);
                                ListShows[Index_ListShow].SetPlatform(values[2]);
                                ListShows[Index_ListShow].SetDescription(values[3]);
                                ListShows[Index_ListShow].SetAge(Convert.ToInt32(values[4]));
                                ListShows[Index_ListShow].SetGender(values[5]);
                                score[0] = Convert.ToSingle(values[6]);
                                score[1] = Convert.ToSingle(values[7]);
                                
                                ListShows[Index_ListShow].SetScore(score);
                                ListShows[Index_ListShow].SetSeasonShow(Convert.ToInt32(values[8]));
                                Index_ListShow++;
                            }

                            else if (values[0] == "PODCAST")
                            {
                                show = 0;
                                podcast = 1;
                                ListPodcast.Add(new Contents.Podcast());
                                ListPodcast[Index_ListPodcast].SetName(values[1]);
                                ListPodcast[Index_ListPodcast].SetPlatform(values[2]);
                                ListPodcast[Index_ListPodcast].SetDescription(values[3]);
                                ListPodcast[Index_ListPodcast].SetAge(Convert.ToInt32(values[4]));
                                ListPodcast[Index_ListPodcast].SetGender(values[5]);
                                score[0] = Convert.ToSingle(values[6]);
                                score[1] = Convert.ToSingle(values[7]);

                                ListPodcast[Index_ListPodcast].SetScore(score);
                                ListPodcast[Index_ListPodcast].SetTypeCont(values[8]);
                                ListPodcast[Index_ListPodcast].SetExpiration(values[9]);
                                Index_ListPodcast++;
                            }

                            else if (values[0] == "EPISODES")
                            {
                                ListEpisodes.Add(new Episode());
                                if (show == 1)
                                {
                                    ListEpisodes[Index_ListEpisodes].SetContentName(values[1]);
                                    ListEpisodes[Index_ListEpisodes].SetSeason(Convert.ToInt32(values[2]));
                                    ListEpisodes[Index_ListEpisodes].SetTitle(values[3]);
                                    ListEpisodes[Index_ListEpisodes].SetMinutes(Convert.ToInt32(values[4]));
                                }

                                if (podcast == 1)
                                {
                                    ListEpisodes[Index_ListEpisodes].SetContentName(values[1]);
                                    ListEpisodes[Index_ListEpisodes].SetSeason(0);
                                    ListEpisodes[Index_ListEpisodes].SetTitle(values[2]);
                                    ListEpisodes[Index_ListEpisodes].SetMinutes(Convert.ToInt32(values[3]));
                                }
                            Index_ListEpisodes++;
                            }

                        
                    }
                }

                catch (Exception)
                {
                    Console.WriteLine("Esto es un error");
                }

                finally
                {
                    sr2.Close();
                }
            }
            else
            {
                Console.WriteLine("Content file does not exist in the current directory.");
            }

            string menu = "5", menu2, menu3, userinfo, contentinfo;
            int indexlist;
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

                            if (menu2 == "1")
                            {
                                //Adding a new content
                                menu3 = "4";
                                while (menu3 != "0")
                                {
                                    Console.Clear();
                                    Console.WriteLine();
                                    Console.WriteLine("What type of content do you want to add?");
                                    Console.WriteLine("1. Movie");
                                    Console.WriteLine("2. Show");
                                    Console.WriteLine("3. Podcast");
                                    Console.WriteLine("0. Save");
                                    Console.WriteLine();
                                    Console.Write("Choose an option: ");
                                    menu3 = Console.ReadLine();

                                    if (menu3 == "1")
                                    {
                                        //Adding movie
                                        Console.Clear();
                                        indexlist = ListMovie.Count;
                                        Console.WriteLine("\nYou are adding a new movie.\n\nIntroduce the name of the movie: ");
                                        contentinfo = Console.ReadLine();

                                        int exists = 0;
                                        for (int i = 0; i < ListMovie.Count; i++)
                                        {
                                            if (ListMovie[i].GetName() == contentinfo)
                                                exists = 1;
                                        }

                                        if(exists == 0)
                                        {
                                            ListMovie.Add(new Contents.Movie());
                                            ListMovie[indexlist].SetName(contentinfo);
                                            Console.WriteLine("\nIntroduce the platform where it is: ");
                                            contentinfo = Console.ReadLine();
                                            ListMovie[indexlist].SetPlatform(contentinfo);
                                            Console.WriteLine("\nIntroduce a description for the movie: ");
                                            contentinfo = Console.ReadLine();
                                            ListMovie[indexlist].SetDescription(contentinfo);
                                            Console.WriteLine("\nIntroduce the age rating: ");
                                            contentinfo = Console.ReadLine();
                                            try
                                            {
                                                // Program body which can cause exception. 
                                                Convert.ToInt32(contentinfo);
                                            }
                                            catch (Exception)
                                            {
                                                // error handling code
                                                Console.WriteLine("Not a valid value");
                                                Thread.Sleep(1000);
                                                ListMovie.RemoveAt(indexlist);
                                                menu3 = "0";
                                            }
                                            if (menu3 != "0")
                                            {
                                                ListMovie[indexlist].SetAge(Convert.ToInt32(contentinfo));
                                                Console.WriteLine("\nIntroduce the gender of the movie: ");
                                                contentinfo = Console.ReadLine();
                                                ListMovie[indexlist].SetGender(contentinfo);
                                                Console.WriteLine("\nIntroduce the release type (cinema / exclusive / exclusive for a time): ");
                                                contentinfo = Console.ReadLine();
                                                ListMovie[indexlist].SetTypeCont(contentinfo);
                                                Console.WriteLine("\nIntroduce the DAY of expiration, example: 07 (if there is not write NO): ");
                                                string contentinfoday = Console.ReadLine();
                                                Console.WriteLine("\nIntroduce the MONTH of expiration, example: 07 (if there is not write NO): ");
                                                string contentinfomonth = Console.ReadLine();
                                                Console.WriteLine("\nIntroduce the YEAR of expiration, example: 2022 (if there is not write NO): ");
                                                string contentinfoyear = Console.ReadLine();
                                                if (contentinfoday.ToUpper() == "NO")
                                                {
                                                    ListMovie[indexlist].SetExpiration("No expiration date");
                                                }
                                                else
                                                    ListMovie[indexlist].SetExpiration(contentinfoday + "-" + contentinfomonth + "-" + contentinfoyear);
                                            }
                                        }
                                        
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Movie already exists");
                                            Thread.Sleep(1500);
                                        }
                                    }
                                    else if (menu3 == "2")
                                    {
                                        //Adding show
                                        Console.Clear();
                                        indexlist = ListShows.Count;
                                        Console.WriteLine("\nYou are adding a new show.\n\nIntroduce the name of the show: ");
                                        contentinfo = Console.ReadLine();
                                        Console.WriteLine("\nIntroduce the number of season you are adding: ");
                                        string contentinfo2 = Console.ReadLine();
                                        try
                                        {
                                            // Program body which can cause exception. 
                                            Convert.ToInt32(contentinfo2);
                                        }
                                        catch (Exception)
                                        {
                                            // error handling code
                                            Console.WriteLine("Not a valid value");
                                            Thread.Sleep(1000);
                                            ListMovie.RemoveAt(indexlist);
                                            menu3 = "0";
                                        }
                                        if (menu3 != "0")
                                        {
                                            int exists = 0;
                                            for (int i = 0; i < ListShows.Count; i++)
                                            {
                                                if ((ListShows[i].GetName() == contentinfo) && (ListShows[i].GetSeasonShow() == Convert.ToInt32(contentinfo2)))
                                                    exists = 1;
                                            }

                                            if (exists == 0)
                                            {
                                                ListShows.Add(new Contents.Shows());
                                                ListShows[indexlist].SetSeasonShow(Convert.ToInt32(contentinfo2));
                                                ListShows[indexlist].SetName(contentinfo);
                                                Console.WriteLine("\nIntroduce the platform where it is: ");
                                                contentinfo = Console.ReadLine();
                                                ListShows[indexlist].SetPlatform(contentinfo);
                                                Console.WriteLine("\nIntroduce a description for the show: ");
                                                contentinfo = Console.ReadLine();
                                                ListShows[indexlist].SetDescription(contentinfo);
                                                Console.WriteLine("\nIntroduce the age rating: ");
                                                contentinfo = Console.ReadLine();
                                                try
                                                {
                                                    // Program body which can cause exception. 
                                                    Convert.ToInt32(contentinfo);
                                                }
                                                catch (Exception)
                                                {
                                                    // error handling code
                                                    Console.WriteLine("Not a valid value");
                                                    Thread.Sleep(1000);
                                                    ListMovie.RemoveAt(indexlist);
                                                    menu3 = "0";
                                                }
                                                if (menu3 != "0")
                                                {
                                                    ListShows[indexlist].SetAge(Convert.ToInt32(contentinfo));
                                                    Console.WriteLine("\nIntroduce the gender of the show: ");
                                                    contentinfo = Console.ReadLine();
                                                    ListShows[indexlist].SetGender(contentinfo);
                                                }
                                            }

                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Show already exists");
                                                Thread.Sleep(1500);
                                            }
                                        }
                                        
                                    }
                                    else if (menu3 == "3")
                                    {
                                        //Adding podcast
                                        Console.Clear();
                                        indexlist = ListPodcast.Count;
                                        Console.WriteLine("\nYou are adding a new podcast.\n\nIntroduce the name of the podcast: ");
                                        contentinfo = Console.ReadLine();
                                        int exists = 0;
                                        for (int i = 0; i < ListPodcast.Count; i++)
                                        {
                                            if (ListPodcast[i].GetName() == contentinfo)
                                                exists = 1;
                                        }
                                        if (exists == 0)
                                        {
                                            ListPodcast.Add(new Contents.Podcast());
                                            ListPodcast[indexlist].SetName(contentinfo);
                                            Console.WriteLine("\nIntroduce the platform where it is: ");
                                            contentinfo = Console.ReadLine();
                                            ListPodcast[indexlist].SetPlatform(contentinfo);
                                            Console.WriteLine("\nIntroduce a description for the podcast: ");
                                            contentinfo = Console.ReadLine();
                                            ListPodcast[indexlist].SetDescription(contentinfo);
                                            Console.WriteLine("\nIntroduce the age rating: ");
                                            contentinfo = Console.ReadLine();
                                            try
                                            {
                                                // Program body which can cause exception. 
                                                Convert.ToInt32(contentinfo);
                                            }
                                            catch (Exception)
                                            {
                                                // error handling code
                                                Console.WriteLine("Not a valid value");
                                                Thread.Sleep(1000);
                                                ListMovie.RemoveAt(indexlist);
                                                menu3 = "0";
                                            }
                                            if (menu3 != "0")
                                            {
                                                ListPodcast[indexlist].SetAge(Convert.ToInt32(contentinfo));
                                                Console.WriteLine("\nIntroduce the gender of the podcast: ");
                                                contentinfo = Console.ReadLine();
                                                ListPodcast[indexlist].SetGender(contentinfo);
                                                Console.WriteLine("\nIntroduce the type of podcast (video / audio): ");
                                                contentinfo = Console.ReadLine();
                                                ListPodcast[indexlist].SetTypeCont(contentinfo);
                                                Console.WriteLine("\nIntroduce the DAY of expiration, example: 07 (if there is not write NO): ");
                                                string contentinfoday = Console.ReadLine();
                                                Console.WriteLine("\nIntroduce the MONTH of expiration, example: 07 (if there is not write NO): ");
                                                string contentinfomonth = Console.ReadLine();
                                                Console.WriteLine("\nIntroduce the YEAR of expiration, example: 2022 (if there is not write NO): ");
                                                string contentinfoyear = Console.ReadLine();
                                                if (contentinfoday.ToUpper() == "NO")
                                                {
                                                    ListPodcast[indexlist].SetExpiration("No expiration date");
                                                }
                                                else
                                                    ListPodcast[indexlist].SetExpiration(contentinfoday + "-" + contentinfomonth + "-" + contentinfoyear);
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Podcast already exists");
                                            Thread.Sleep(1500);
                                        }
                                        
                                    }
                                    else if (menu3 != "0")
                                    {
                                        //Errors
                                        Console.WriteLine("\nChoose a valid option (1, 2, 3 or 0)");
                                        Thread.Sleep(1000);
                                    }
                                }
                            }
                            else if (menu2 == "2")
                            {
                                //Adding a new episode
                                menu3 = "4";
                                while (menu3 != "0")
                                {
                                    Console.Clear();
                                    Console.WriteLine();
                                    Console.WriteLine("From what type of content is the episode you want to add?");
                                    Console.WriteLine("1. Show");
                                    Console.WriteLine("2. Podcast");
                                    Console.WriteLine("0. Cancel");
                                    Console.WriteLine();
                                    Console.Write("Choose an option: ");
                                    menu3 = Console.ReadLine();

                                    string titletosearch;

                                    if (menu3 == "1")
                                    {
                                        Console.WriteLine("\nIntroduce the title of the show: ");
                                        titletosearch = Console.ReadLine();
                                        Console.WriteLine("Introduce the season of the episode:");
                                        string seasonepi = Console.ReadLine();
                                        try
                                        {
                                            // Program body which can cause exception. 
                                            Convert.ToInt32(seasonepi);
                                        }
                                        catch (Exception)
                                        {
                                            // error handling code
                                            Console.WriteLine("Not a valid value");
                                            Thread.Sleep(1000);
                                            menu3 = "0";
                                        }
                                        if (menu3 != "0")
                                        {
                                            int season = Convert.ToInt32(seasonepi);
                                            int showfound = 0;
                                            for (int i = 0; i < ListShows.Count; i++)
                                            {
                                                if ((ListShows[i].GetName() == titletosearch) && (ListShows[i].GetSeasonShow() == season))
                                                    showfound = 1;
                                            }
                                            if (showfound == 1)
                                            {
                                                string info;
                                                int i = ListEpisodes.Count;
                                                ListEpisodes.Add(new Episode());
                                                Console.Clear();
                                                ListEpisodes[i].SetContentName(titletosearch);
                                                ListEpisodes[i].SetSeason(season);
                                                Console.WriteLine("Introduce the title of the episode:");
                                                info = Console.ReadLine();
                                                ListEpisodes[i].SetTitle(info);
                                                Console.WriteLine("Introduce the duration of the episode:");
                                                info = Console.ReadLine();
                                                try
                                                {
                                                    // Program body which can cause exception. 
                                                    Convert.ToInt32(info);
                                                }
                                                catch (Exception)
                                                {
                                                    // error handling code
                                                    Console.WriteLine("Not a valid value");
                                                    Thread.Sleep(1000);
                                                    ListEpisodes.RemoveAt(i);
                                                    menu3 = "0";
                                                }
                                                if (menu3 != "0")
                                                {
                                                    ListEpisodes[i].SetMinutes(Convert.ToInt32(info));
                                                }

                                            }
                                            else if (showfound == 0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("There is none existing show with that name");
                                                Thread.Sleep(1500);
                                            }
                                        }
                                    }
                                    else if (menu3 == "2")
                                    {
                                        Console.WriteLine("\nIntroduce the title of the podcast: ");
                                        titletosearch = Console.ReadLine();
                                        int podcastfound = 0;
                                        for (int i = 0; i < ListPodcast.Count; i++)
                                        {
                                            if (ListPodcast[i].GetName() == titletosearch)
                                                podcastfound = 1;
                                        }

                                        if (podcastfound == 1)
                                        {
                                            string info;
                                            int i = ListEpisodes.Count;
                                            ListEpisodes.Add(new Episode());
                                            Console.Clear();
                                            ListEpisodes[i].SetContentName(titletosearch);
                                            Console.WriteLine("Introduce the title of the podcast:");
                                            info = Console.ReadLine();
                                            ListEpisodes[i].SetTitle(info);
                                            Console.WriteLine("Introduce the duration of the podcast:");
                                            info = Console.ReadLine();
                                            try
                                            {
                                                // Program body which can cause exception. 
                                                Convert.ToInt32(info);
                                            }
                                            catch (Exception)
                                            {
                                                // error handling code
                                                Console.WriteLine("Not a valid value");
                                                Thread.Sleep(1000);
                                                ListEpisodes.RemoveAt(i);
                                                menu3 = "0";
                                            }
                                            if (menu3 != "0")
                                            {
                                                ListEpisodes[i].SetMinutes(Convert.ToInt32(info));
                                            }
                                        }
                                        if (podcastfound == 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("There is none existing podcast with that name");
                                            Thread.Sleep(1500);
                                        }
                                    }
                                    else if (menu3 != "0")
                                    {
                                        Console.WriteLine("\nChoose a valid option (1, 2 or 0)");
                                        Thread.Sleep(1000);
                                    }
                                }

                            }
                            else if (menu2 == "3")
                            {
                                string titletosearch;
                                //Searching for content
                                Console.WriteLine("\nIntroduce the title of the content: ");
                                titletosearch = Console.ReadLine();
                                int moviefound = 0, showfound = 0, podcastfound = 0;
                                for (int i = 0; i < ListMovie.Count; i++)
                                {
                                    if (ListMovie[i].GetName() == titletosearch)
                                        moviefound = 1;
                                }
                                for (int i = 0; i < ListShows.Count; i++)
                                {
                                    if (ListShows[i].GetName() == titletosearch)
                                        showfound = 1;
                                }
                                for (int i = 0; i < ListPodcast.Count; i++)
                                {
                                    if (ListPodcast[i].GetName() == titletosearch)
                                        podcastfound = 1;
                                }
                                int contentfound = moviefound + podcastfound + showfound;
                                if(contentfound != 0)
                                {
                                    Console.Clear();
                                }
                                if (moviefound == 1)
                                {
                                    Console.WriteLine("\n\nMOVIES");
                                    for (int j = 0; j < ListMovie.Count; j++)
                                    {
                                        //Añadir aquí el script para imprimir la pelicula
                                        Console.WriteLine(ListMovie[j].PrintMovie());
                                    }
                                }
                                if(showfound == 1)
                                {
                                    Console.WriteLine("\n\nSHOWS");
                                    for (int j = 0; j < ListShows.Count; j++)
                                    {
                                        //Añadir aquí el script para imprimir la serie
                                        Console.WriteLine(ListShows[j].PrintShow());
                                        for (int k = 0; k < ListEpisodes.Count; k++)
                                        {
                                            if ((ListShows[j].GetName() == ListEpisodes[k].GetContentName()) && (ListShows[j].GetSeasonShow() == ListEpisodes[k].GetSeason()))
                                            {
                                                Console.WriteLine(ListEpisodes[k].PrintEpisodes());
                                            }
                                        }

                                    }
                                }
                                if(podcastfound == 1)
                                {
                                    Console.WriteLine("\n\nPODCASTS");
                                    for (int k = 0; k < ListPodcast.Count; k++)
                                    {
                                        //Añadir aquí el script para imprimir el podcast
                                        Console.WriteLine(ListPodcast[k].PrintPodcast());
                                        for (int j = 0; j < ListEpisodes.Count; j++)
                                        {
                                            if ((ListPodcast[k].GetName() == ListEpisodes[j].GetContentName()) && (ListEpisodes[j].GetSeason() == 0))
                                            {
                                                Console.WriteLine(ListEpisodes[j].PrintEpisodes());
                                            }
                                        }
                                    }
                                }
                                
                                if (contentfound == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("There is none existing content with that name");
                                    Thread.Sleep(1500);
                                }
                                else
                                {
                                    Console.WriteLine("Press ENTER to return");
                                    Console.ReadLine();
                                }
                            }
                            else if (menu2 == "4")
                            {
                                //Showing all contents
                                int existingcontent = ListMovie.Count + ListShows.Count + ListPodcast.Count;
                                
                                if (existingcontent == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("There is none existing content");
                                    Thread.Sleep(1500);
                                }
                                else
                                {
                                    Console.Clear();
                                    if (ListMovie.Count != 0)
                                    {
                                        Console.WriteLine("\n\nMOVIES");
                                        for (int i = 0; i < ListMovie.Count; i++)
                                        {
                                            //Añadir aquí el script para imprimir la pelicula
                                            Console.WriteLine(ListMovie[i].PrintMovie());
                                        }
                                    }
                                    if(ListShows.Count != 0)
                                    {
                                        Console.WriteLine("\n\nSHOWS");
                                        for (int i = 0; i < ListShows.Count; i++)
                                        {
                                            //Añadir aquí el script para imprimir la serie
                                            Console.WriteLine(ListShows[i].PrintShow());
                                            for (int j = 0; j < ListEpisodes.Count; j++)
                                            {
                                                if ((ListShows[i].GetName() == ListEpisodes[j].GetContentName()) && (ListShows[i].GetSeasonShow() == ListEpisodes[j].GetSeason()))
                                                {
                                                    Console.WriteLine(ListEpisodes[j].PrintEpisodes());
                                                }
                                            }

                                        }
                                    }
                                    if (ListPodcast.Count != 0)
                                    {
                                        Console.WriteLine("\n\nPODCASTS");
                                        for (int i = 0; i < ListPodcast.Count; i++)
                                        {
                                            //Añadir aquí el script para imprimir el podcast
                                            Console.WriteLine(ListPodcast[i].PrintPodcast());
                                            for (int j = 0; j < ListEpisodes.Count; j++)
                                            {
                                                if ((ListPodcast[i].GetName() == ListEpisodes[j].GetContentName()) && (ListEpisodes[j].GetSeason() == 0))
                                                {
                                                    Console.WriteLine(ListEpisodes[j].PrintEpisodes());
                                                }
                                            }
                                        }
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("Press ENTER to return");
                                    Console.ReadLine();
                                }

                            }
                            else if (menu2 == "5")
                            {
                                //Showing content ranking (Top 10)





                            }
                            else if (menu2 == "6")
                            {
                                //Evaluating content
                                menu3 = "5";
                                while(menu3 != "0")
                                {
                                    string title;
                                    string season;
                                    int seasontosearch;
                                    Console.Clear();
                                    Console.WriteLine("\nYou are evaluating a content.");
                                    Console.WriteLine("What type of content do you want to evaluate?");
                                    Console.WriteLine("1. Movie");
                                    Console.WriteLine("2. Show");
                                    Console.WriteLine("3. Podcast");
                                    Console.WriteLine("0. Cancel");
                                    Console.Write("Choose an option: ");
                                    menu3 = Console.ReadLine();
                                    if (menu3 == "1")
                                    {
                                        Console.Clear();
                                        Console.Write("Introduce the title of the movie: ");
                                        title = Console.ReadLine();
                                        int foundmovie = 0, positionfound = 0;
                                        for (int i = 0; i < ListMovie.Count; i++)
                                        {
                                            if (ListMovie[i].GetName() == title)
                                            {
                                                foundmovie = 1;
                                                positionfound = i;
                                            }
                                        }
                                        if(foundmovie == 1)
                                        {
                                            menu3 = "1";
                                            float score = ListMovie[positionfound].GetScore();
                                            float votes = ListShows[positionfound].GetScoreVotes();
                                            float newscore2 = 11;
                                            while (newscore2 < 0 || newscore2 > 10)
                                            {
                                                Console.WriteLine("What is your score for this movie (from 0-10)?");
                                                string newscore = Console.ReadLine();
                                                try
                                                {
                                                    // Program body which can cause exception. 
                                                    Convert.ToSingle(newscore);
                                                }
                                                catch (Exception)
                                                {
                                                    // error handling code
                                                    Console.WriteLine("Not a valid value");
                                                    Thread.Sleep(1000);
                                                    menu3 = "0";
                                                }
                                                if (menu3 != "0")
                                                {
                                                    newscore2 = Convert.ToSingle(newscore);
                                                    if(newscore2 >= 0 && newscore2 <=10)
                                                    {
                                                        float calculo = ((score * votes) + newscore2) / (votes + 1);
                                                        votes = votes++;
                                                        float[] newscore3 = new float[2] { calculo, votes };
                                                        ListMovie[positionfound].SetScore(newscore3);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Not a valid score");
                                                        Thread.Sleep(1500);
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Not movie found");
                                            Thread.Sleep(1500);
                                        }
                                    }
                                    else if (menu3 == "2")
                                    {
                                        Console.Clear();
                                        Console.Write("Introduce the title of the show: ");
                                        title = Console.ReadLine();
                                        Console.Write("Introduce the season of the show: ");
                                        season = Console.ReadLine();
                                        try
                                        {
                                            // Program body which can cause exception. 
                                            Convert.ToInt32(season);
                                        }
                                        catch (Exception)
                                        {
                                            // error handling code
                                            Console.WriteLine("Not a valid season");
                                            Thread.Sleep(1000);
                                            menu3 = "0";
                                        }
                                        if (menu3 != "0")
                                        {
                                            int foundshow = 0, positionfound = 0;
                                            seasontosearch = Convert.ToInt32(season);
                                            for (int i = 0; i < ListShows.Count; i++)
                                            {
                                                if ((ListShows[i].GetName() == title) && (ListShows[i].GetSeasonShow() == seasontosearch))
                                                {
                                                    foundshow = 1;
                                                    positionfound = i;
                                                }
                                            }
                                            if(foundshow == 1)
                                            {
                                                float score = ListShows[positionfound].GetScore();
                                                float votes = ListShows[positionfound].GetScoreVotes();
                                                float newscore2 = 11;
                                                while (newscore2 < 0 || newscore2 > 10)
                                                {
                                                    menu3 = "2";
                                                    Console.WriteLine("What is your score for this show (from 0-10)?");
                                                    string newscore = Console.ReadLine();
                                                    try
                                                    {
                                                        // Program body which can cause exception. 
                                                        Convert.ToSingle(newscore);
                                                    }
                                                    catch (Exception)
                                                    {
                                                        // error handling code
                                                        Console.WriteLine("Not a valid value");
                                                        Thread.Sleep(1000);
                                                        menu3 = "0";
                                                    }
                                                    if (menu3 != "0")
                                                    {
                                                        newscore2 = Convert.ToSingle(newscore);
                                                        if (newscore2 >= 0 && newscore2 <= 10)
                                                        {
                                                            float calculo = ((score * votes) + newscore2) / (votes + 1);
                                                            votes = votes++;
                                                            float[] newscore3 = new float[2] { calculo, votes };
                                                            ListShows[positionfound].SetScore(newscore3);
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Not a valid score");
                                                            Thread.Sleep(1500);
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("There is not any show with this info");
                                                Thread.Sleep(1500);
                                            }
                                        }
                                    }
                                    else if (menu3 == "3")
                                    {
                                        Console.Clear();
                                        Console.Write("Introduce the title of the podcast: ");
                                        title = Console.ReadLine();
                                        int foundpodcast = 0, positionfound = 0;
                                        for (int i = 0; i < ListPodcast.Count; i++)
                                        {
                                            if (ListPodcast[i].GetName() == title)
                                            {
                                                foundpodcast = 1;
                                                positionfound = i;
                                            }
                                        }
                                        if (foundpodcast == 1)
                                        {
                                            float score = ListPodcast[positionfound].GetScore();
                                            float votes = ListPodcast[positionfound].GetScoreVotes();
                                            float newscore2 = 11;
                                            while (newscore2 < 0 || newscore2 > 10)
                                            {
                                                menu3 = "3";
                                                Console.WriteLine("What is your score for this podcast (from 0-10)?");
                                                string newscore = Console.ReadLine();
                                                try
                                                {
                                                    // Program body which can cause exception. 
                                                    Convert.ToSingle(newscore);
                                                }
                                                catch (Exception)
                                                {
                                                    // error handling code
                                                    Console.WriteLine("Not a valid value");
                                                    Thread.Sleep(1000);
                                                    menu3 = "0";
                                                }
                                                if (menu3 != "0")
                                                {
                                                    newscore2 = Convert.ToSingle(newscore);

                                                    if (newscore2 >= 0 && newscore2 <= 10)
                                                    {
                                                        float calculo = ((score * votes) + newscore2) / (votes + 1);
                                                        votes = votes++;
                                                        float[] newscore3 = new float[2] { calculo, votes };
                                                        ListPodcast[positionfound].SetScore(newscore3);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Not a valid score");
                                                        Thread.Sleep(1500);
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Not podcast found");
                                            Thread.Sleep(1500);
                                        }
                                    }
                                    else if (menu3 != "0")
                                    {
                                        Console.WriteLine("\nChoose a valid option (1, 2, 3 or 0)");
                                        Thread.Sleep(1500);
                                    }
                                }
                                
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


                    StreamWriter sw2 = File.CreateText(path2);
                    for (int i = 0; i < ListMovie.Count; i++)
                    {
                        sw2.WriteLine(ListMovie[i].PrintMovieTxt());
                    }
                    for (int i = 0; i < ListShows.Count; i++)
                    {
                        sw2.WriteLine(ListShows[i].PrintShowTxt());
                        for (int j = 0; j < ListEpisodes.Count; j++)
                        {
                            if((ListShows[i].GetName() == ListEpisodes[j].GetContentName()) && (ListShows[i].GetSeasonShow() == ListEpisodes[j].GetSeason()))
                            {
                                sw2.WriteLine(ListEpisodes[j].PrintEpisodesShowTxt());
                            }
                        }
                    }
                    for (int i = 0; i < ListPodcast.Count; i++)
                    {
                        sw2.WriteLine(ListPodcast[i].PrintPodcastTxt());
                        for (int j = 0; j < ListEpisodes.Count; j++)
                        {
                            if ((ListPodcast[i].GetName() == ListEpisodes[j].GetContentName()) && (ListEpisodes[j].GetSeason() == 0))
                            {
                                sw2.WriteLine(ListEpisodes[j].PrintEpisodesPodcastTxt());
                            }
                        }
                    }

                    sw2.Close();
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
