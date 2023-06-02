using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B23_Ex04_Ronen_319047718_Ido_315942193
{
    public abstract class MenuItem: IMenuObserver
    {
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
        }

        public void PrintTitle()
        {
            Console.WriteLine($"---- {r_Title} ----");
        }

        public abstract void Execute();

        public void PrintPath()
        {
            Console.WriteLine(getPath());
            Console.WriteLine();
        }

        private string getPath()
        {
            string path = "";
            if(IsMainMenu())
            {
                path += Title;
            }
            else
            {
                path += String.Format("{0}->{1}", Parent.getPath(), Title);
            }

            return path;
        }

        public bool IsMainMenu()
        {
            return m_Parent == null;
        }

    }
}
