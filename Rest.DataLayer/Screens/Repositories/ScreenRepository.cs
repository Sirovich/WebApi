using System;
using System.Collections.Generic;
using System.Linq;
using Rest.Models;
using Rest.DataLayer.Screens.Contexts;

namespace Rest.DataLayer.Screens.Repositories
{
    public class ScreenRepository : IScreenRepository
    {
        private ScreenContext screenContext;

        public ScreenRepository(ScreenContext screenContext)
        {
            this.screenContext = screenContext ?? throw new ArgumentNullException(nameof(screenContext));
        }

        public void Add(Screen screen)
        {
            screenContext.Add(screen);
            screenContext.SaveChanges();
        }

        public void Delete(Screen screen)
        {
            screenContext.Remove(screen);
            screenContext.SaveChanges();
        }

        public IEnumerable<Screen> GetAll()
        {
            return screenContext.Screens;
        }

        public Screen GetById(int id)
        {
            return screenContext.Screens.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Screen screen)
        {
            screenContext.Update(screen);
            screenContext.SaveChanges();
        }
    }
}
