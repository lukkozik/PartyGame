﻿using PartyGame.App.Abstract;
using PartyGame.Domain.Entity;
using System.Collections.Generic;

namespace PartyGame.App.Concrete
{
    public class MenuActionService : IMenuActionService
    {
        private List<MenuAction> menuActions;

        public MenuActionService()
        {
            menuActions = new List<MenuAction>();
        }

        public void AddNewAction(int id, string name, string menuName)
        {
            var menuAction = new MenuAction() { Id = id, Name = name, MenuName = menuName };
            menuActions.Add(menuAction);
        }

        public List<MenuAction> GetMenuActionByMenuName(string menuName)
        {
            var resault = new List<MenuAction>();

            foreach (var menuAction in menuActions)
            {
                if (menuAction.MenuName == menuName)
                {
                    resault.Add(menuAction);
                }
            }

            return resault;
        }
    }
}
