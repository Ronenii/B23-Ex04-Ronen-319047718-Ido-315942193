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
            r_Path = createCurrentPath();
        }

        public void PrintTitle()
        {
            Console.WriteLine($"---- {r_Title} ----");
        }

        public abstract void Execute();

        public void PrintPath()
        {
            Console.WriteLine(r_Path);
            Console.WriteLine();
        }

        private string createCurrentPath()
        {
            string menuPath = "";
            if (!isMainMenu())
            {
                menuPath += $"{r_Parent.Path} -> ";
            }
            menuPath += r_Title;
            return menuPath;
        }

        private bool isMainMenu()
        {
            return r_Parent == null;
        }

    }
}
