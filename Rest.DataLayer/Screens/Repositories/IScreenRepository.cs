using System;
using System.Collections.Generic;
using System.Text;
using Rest.Models;

namespace Rest.DataLayer.Screens.Repositories
{
    public interface IScreenRepository : IRepository<Screen>
    {
        Screen GetById(int id);
    }
}
