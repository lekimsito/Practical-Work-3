using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Practical_work_3
{
    public class Episode
    {
        protected int minutes;
        protected string title;
        protected string nameofcontent;
        protected int season;

        public Episode()
        {

        }

        public void SetMinutes(int minutes)
        {
            this.minutes = minutes;
        }

        public int GetMinutes()
        {
            return minutes;
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public string GetTitle()
        {
            return title;
        }

        public void SetContentName(string nameofcontent)
        {
            this.nameofcontent = nameofcontent;
        }

        public string GetContentName()
        {
            return nameofcontent;
        }

        public void SetSeason(int season)
        {
            this.season = season;
        }

        public int GetSeason()
        {
            return season;
        }

        public string PrintEpisodes()
        {
            return ("\n\t\tTITLE: " + this.GetTitle() + "\n\t\tDURATION: " + this.GetMinutes());
        }

        public string PrintEpisodesShowTxt()
        {
            return ("EPISODES;" + this.GetContentName() + ";" + this.GetSeason() + ";" + this.GetTitle() + ";" + this.GetMinutes());
        }

        public string PrintEpisodesPodcastTxt()
        {
            return ("EPISODES;" + this.GetContentName() + ";" + this.GetTitle() + ";" + this.GetMinutes());
        }
    }
}
