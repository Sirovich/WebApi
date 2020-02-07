using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Rest.Logic.ScreensLogic;
using Rest.Models;

namespace Rest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScreensController : ControllerBase
    {
        private IScreenLogic screenLogic;
        private IMemoryCache cache;

        public ScreensController(IScreenLogic screenLogic, IMemoryCache cache)
        {
            this.screenLogic = screenLogic;
            this.cache = cache;
        }

        [HttpGet]
        public IEnumerable<Screen> GetScreens()
        {
            IEnumerable<Screen> result;
            if (!cache.TryGetValue("screens", out result))
            {
                result = screenLogic.GetScreens();
                cache.Set("screens", result, new TimeSpan(0, 2, 0));
            }
            return result;
        }

        [HttpGet("{id}")]
        public Screen GetScreen([FromRoute]int id)
        {
            return screenLogic.GetScreen(id);
        }

        [HttpDelete("{id}")]
        public void DeleteScreen([FromRoute]int id)
        {
            screenLogic.DeleteScreen(id);
            if (cache.TryGetValue("screens", out _))
            {
                cache.Remove("screens");
            }
        }

        [HttpPut]
        public void UpdateScreen([FromForm]Screen screen)
        {
            screenLogic.UpdateScreen(screen);
            if (cache.TryGetValue("screens", out _))
            {
                cache.Remove("screens");
            }
        }

        [HttpPost]
        public void AddScreen([FromForm]Screen screen)
        {
            screenLogic.AddScreen(screen);
            if (cache.TryGetValue("screens", out _))
            {
                cache.Remove("screens");
            }
        }
    }
}
