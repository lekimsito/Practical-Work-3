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
        private int score;
        private int episodes;
        private int date;
        private string type;
        public Contents()
        {

        }

        public void SetAge(int age)
        {
            this.age = age;
        }

        public int GetAge()
        {
            return age;
        }

        public void SetScore(int score)
        {
            this.score = score;
        }

        public int GetScore()
        {
            return score;
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

        public abstract void SetExpiration(int date);
        public abstract void SetTypeCont(string type);
        public abstract void SetEpisodes(int episodes);

        public abstract int GetExpiration();
        public abstract string GetTypeCont();
        public abstract int GetEpisodes();

        public class Movie : Contents
        {
            public override void SetExpiration(int date)
            {
                this.date = date;
            }
            public override int GetExpiration()
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
        }

        public class Shows : Contents
        {
            private int season;

            public Shows()
            {

            }

            public void SetSeason(int season)
            {
                this.season = season;
            }
            public int GetSeason()
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

            public override void SetExpiration(int date)
            {
                throw new NotImplementedException();
            }
            public override int GetExpiration()
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

        }

        public class Podcast : Contents
        {
            public override void SetExpiration(int date)
            {
                this.date = date;
            }
            public override int GetExpiration()
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
        }

    }
}
