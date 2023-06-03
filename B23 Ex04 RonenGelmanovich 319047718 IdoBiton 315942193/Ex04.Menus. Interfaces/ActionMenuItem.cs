using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B23_Ex04_Ronen_319047718_Ido_315942193
{
    public class ActionMenuItem : MenuItem
    {
        private readonly IMenuObserver r_Observer;
        public ActionMenuItem(string i_Title, IMenuObserver i_MenuObserver)
            : base(i_Title)
        {
            r_Observer = i_MenuObserver;
        }

        // Executes the action and returns to parent menu
        public override void Execute()
        {
            Console.Clear();
            PrintPath();
            r_Observer.Execute();
        }
    }
}
