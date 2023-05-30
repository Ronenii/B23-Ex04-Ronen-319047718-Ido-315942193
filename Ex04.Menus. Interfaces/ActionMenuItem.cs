using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B23_Ex04_Ronen_319047718_Ido_315942193
{
    public class ActionMenuItem: MenuItem
    {
        private IMenuObserver m_Observer;
        public ActionMenuItem(string i_Title, MenuItem i_Parent, IMenuObserver i_MenuObserver)
            : base(i_Title, i_Parent)
        {
            m_Observer = i_MenuObserver;
        }

        public override void Execute()
        {
           m_Observer.Execute();
        }
    }
}
