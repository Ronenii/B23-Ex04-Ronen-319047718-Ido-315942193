using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B23_Ex04_Ronen_319047718_Ido_315942193
{
    public class SubMenu : MenuItem, ISubMenuItem
    {
        private List<MenuItem> m_MenuItems;

        public SubMenu(string i_Prompt, int i_ItemNum, string i_ParentMenuItem) : base(i_Prompt, i_ItemNum, i_ParentMenuItem)
        {
        }

        public void ListSubMenu()
        {
            PrintPath();
            foreach (MenuItem item in m_MenuItems)
            {
                item.PrintItem();
            }
        }

        public void AddSubMenuItemToSubMenu(string i_Prompt)
        {
            m_MenuItems.Add(new SubMenu(i_Prompt, m_MenuItems.Count + 1, Prompt));
        }

        // TODO: Maybe add refrence to action I don't really know
        public void AddFinalItemToSubMenu(string i_Prompt)
        {

        }
    }
}
