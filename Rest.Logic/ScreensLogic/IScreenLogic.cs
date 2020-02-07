using System;
using System.Collections.Generic;
using System.Text;
using Rest.DataLayer.Screens.Repositories;
using Rest.Models;

namespace Rest.Logic.ScreensLogic
{
    public interface IScreenLogic
    {
        Screen GetScreen(int id);

        void AddScreen(Screen screen);

        void DeleteScreen(int id);

        void UpdateScreen(Screen screen);

        IEnumerable<Screen> GetScreens();
    }
}
