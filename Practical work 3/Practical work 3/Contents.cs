using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Practical_work_3
{
    public abstract class Contents
    {
        private string name;
        private string platform;
        private string description;
        private int age;
        private string gender;
        private float[] score = new float[2] {0,0};
        private int episodes;
        private string date;
        private string type;
        public Contents()
        {
            for (int i = 0; i < score.Length; i++)
            {
                this.score[i] = 0;
            }
        }

        public string PrintContent()
        {
            return ("\n\tNAME: " + this.GetName() + "\n\tPLATFORM: " + this.GetPlatform()
                + "\n\tDESCRIPTION: " + this.GetDescription() + "\n\tAGE RATING: "
                + this.GetAge() + "\n\tGENDER: " + this.GetGender() + "\n\tSCORE: " + this.GetScore());
        }

        public string PrintContentTxt()
        {
            return (this.GetName() + ";" + this.GetPlatform()
                + ";" + this.GetDescription() + ";"
                + this.GetAge() + ";" + this.GetGender() + ";" + this.GetScore() + ";" + this.GetScoreVotes());
        }

        public void SetAge(int age)
        {
            this.age = age;
        }

        public int GetAge()
        {
            return age;
        }

        public void SetScore(float[] score)
        {   
            for(int i = 0; i < score.Length; i++)
            {
                this.score[i] = score[i];
            }
        }

        public float GetScore()
        {
            return score[0];
        }
        public float GetScoreVotes()
        {
            return score[1];
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void SetPlatform(string platform)
        {
            this.platform = platform;
        }

        public string GetPlatform()
        {
            return platform;
        }

        public void SetDescription(string description)
        {
            this.description = description;
        }

        public string GetDescription()
        {
            return description;
        }

        public void SetGender(string gender)
        {
            this.gender = gender;
        }

        public string GetGender()
        {
            return gender;
        }

        public abstract void SetExpiration(string date);
        public abstract void SetTypeCont(string type);
        public abstract void SetEpisodes(int episodes);

        public abstract string GetExpiration();
        public abstract string GetTypeCont();
        public abstract int GetEpisodes();

        public class Movie : Contents
        {
            public override void SetExpiration(string date)
            {
                this.date = date;
            }
            public override string GetExpiration()
            {
                return date;
            }

            public override void SetTypeCont(string type)
            {
                this.type = type;
            }
            public override string GetTypeCont()
            {
                return type;
            }

            public override void SetEpisodes(int episodes)
            {
                throw new NotImplementedException();
            }
            public override int GetEpisodes()
            {
                throw new NotImplementedException();
            }


            public string PrintMovie()
            {
                return (PrintContent() + "\n\tRELEASE TYPE: " + this.GetTypeCont() + "\n\tEXPIRATION DATE: " + this.GetExpiration() );
            }

            public string PrintMovieTxt()
            {
                return ("MOVIE;" + PrintContentTxt() + ";" + this.GetTypeCont() + ";" + this.GetExpiration());
            }
        }

        public class Shows : Contents
        {
            private int season;

            public Shows()
            {

            }

            public void SetSeasonShow(int season)
            {
                this.season = season;
            }
            public int GetSeasonShow()
            {
                return season;
            }

            public override void SetEpisodes(int episodes)
            {
                this.episodes = episodes;
            }
            public override int GetEpisodes()
            {
                return episodes;
            }

            public override void SetExpiration(string date)
            {
                throw new NotImplementedException();
            }
            public override string GetExpiration()
            {
                throw new NotImplementedException();
            }

            public override void SetTypeCont(string type)
            {
                throw new NotImplementedException();
            }
            public override string GetTypeCont()
            {
                throw new NotImplementedException();
            }

            public string PrintShow()
            {
                return (PrintContent() + "\n\tSEASON: " + this.GetSeasonShow());
            }

            public string PrintShowTxt()
            {
                return ("SHOW;" + PrintContentTxt() + ";" + this.GetSeasonShow());
            }

        }

        public class Podcast : Contents
        {
            public override void SetExpiration(string date)
            {
                this.date = date;
            }
            public override string GetExpiration()
            {
                return date;
            }

            public override void SetTypeCont(string type)
            {
                this.type = type;
            }
            public override string GetTypeCont()
            {
                return type;
            }

            public override void SetEpisodes(int episodes)
            {
                this.episodes = episodes;
            }
            public override int GetEpisodes()
            {
                return episodes;
            }


            public string PrintPodcast()
            {
                return (PrintContent() + "\n\tTYPE: " + this.GetTypeCont() + "\n\tEXPIRATION DATE: " + this.GetExpiration() );
            }

            public string PrintPodcastTxt()
            {
                return ("PODCAST;" + PrintContentTxt() + ";" + this.GetTypeCont() + ";" + this.GetExpiration());
            }
        }

    }
}
