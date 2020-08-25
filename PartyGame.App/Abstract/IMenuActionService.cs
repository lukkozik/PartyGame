using PartyGame.Domain.Entity;
using System.Collections.Generic;

namespace PartyGame.App.Abstract
{
    interface IMenuActionService
    {
        void AddNewAction(int id, string name, string menuName);
        List<MenuAction> GetMenuActionByMenuName(string menuName);
    }
}
