using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Rest.DataLayer.Screens.Repositories;
using Rest.Models;

namespace Rest.Logic.ScreensLogic
{
    public class ScreenLogic : IScreenLogic
    {
        private readonly IScreenRepository screenRepository;
        private readonly ILogger<ScreenLogic> logger;

        public ScreenLogic(IScreenRepository screenRepository, ILogger<ScreenLogic> logger)
        {
            this.screenRepository = screenRepository;
            this.logger = logger;
        }

        public IEnumerable<Screen> GetScreens()
        {
            return screenRepository.GetAll();
        }

        public void AddScreen(Screen screen)
        {
            try
            {
                logger.LogInformation("AddScreen: Screen.Manufacturer = {0}", screen.Manufacturer);
                screenRepository.Add(screen);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "AddScreen: exception was thrown");
                throw;
            }
        }

        public void DeleteScreen(int id)
        {
            try
            {
                var screen = screenRepository.GetById(id);
                screenRepository.Delete(screen);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "DeleteScreen");
                throw;
            }
        }

        public Screen GetScreen(int id)
        {
            return screenRepository.GetById(id);
        }

        public void UpdateScreen(Screen screen)
        {
            try
            {
                screenRepository.Update(screen);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "UpdateScreen");
                throw;
            }
        }
    }
}
