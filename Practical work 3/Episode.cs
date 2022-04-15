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
        private int minutes;
        private string title;

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
    }
}
