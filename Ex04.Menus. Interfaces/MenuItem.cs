using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B23_Ex04_Ronen_319047718_Ido_315942193
{
    public abstract class MenuItem: IMenuItem
    {
        private readonly string m_Path;
        public string Path { get; }

        private readonly string m_Title;

        public string Title { get; }

        private MenuItem m_Parent;
        public MenuItem Parent
        { get; }

        public MenuItem(string i_Title, MenuItem i_Parent)
        {
            m_Title = i_Title;
            m_Parent = i_Parent;
            m_Path += string.Format("{0}->{1}", i_Parent.Path, i_Parent.Title );
        }

        public void PrintTitle()
        {
            Console.Write(m_Title);
        }

        public abstract void Execute();

        public void PrintPath()
        {
            Console.WriteLine(m_Path);
        }
    }
}
