using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B23_Ex04_Ronen_319047718_Ido_315942193
{
    public abstract class MenuItem: IMenuObserver
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

        private MenuItem m_Parent = null;
        public MenuItem Parent
        {
            get
            {
                return m_Parent;
            }
            set
            {
                m_Parent = value;
            }
        }

        public MenuItem(string i_Title)
        {
            r_Title = i_Title;
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
            if (!IsMainMenu())
            {
                menuPath += $"{m_Parent.Path} -> ";
            }
            menuPath += r_Title;
            return menuPath;
        }

        public bool IsMainMenu()
        {
            return m_Parent == null;
        }

    }
}
