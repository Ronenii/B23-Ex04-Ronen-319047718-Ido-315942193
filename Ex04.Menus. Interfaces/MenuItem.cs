using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B23_Ex04_Ronen_319047718_Ido_315942193
{
    public abstract class MenuItem : IMenuItem
    {
        private readonly string r_Path;
        public string Path
        {
            get
            {
                return r_Path;
            }
        }

        private readonly string r_Title;

        public string Title
        {
            get
            {
                return r_Title;
            }
        }

        private readonly MenuItem r_Parent;
        public MenuItem Parent
        {
            get
            {
                return r_Parent;
            }
        }

        public MenuItem(string i_Title, MenuItem i_Parent)
        {
            r_Title = i_Title;
            r_Parent = i_Parent;

            // If the parent is nul lthis means we are in the main menu and it still doesn't have a relative path
            if (i_Parent != null)
            {
                r_Path = string.Format("{0}->{1}", i_Parent.Path, i_Parent.Title);
            }
            else
            {
                r_Path = string.Empty;
            }
        }

        public void PrintTitle()
        {
            Console.WriteLine(r_Title);
        }

        public abstract void Execute();

        public void PrintPath()
        {
            Console.WriteLine(r_Path);
        }
    }
}
