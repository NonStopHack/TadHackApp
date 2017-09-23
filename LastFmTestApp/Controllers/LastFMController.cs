using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IF.Lastfm.Core.Objects;
using LastFmTestApp.App_Start;
using LastFmTestApp.Models.LastFM;

namespace LastFmTestApp.Controllers
{
    public class LastFmController : Controller
    {
        [HttpGet]
        public ActionResult LastFmProfile()
        {
            LastFmProfile lastFmProfile = new LastFmProfile();
            return View(lastFmProfile);
        }

        [HttpPost]
        public ActionResult CreateOrUpdateLastFmProfile(LastFmProfile lastFmProfile)
        {
            if (ModelState.IsValid)
            {
                LastFmUsersTmpStorage.CreateOrUpdateUser(lastFmProfile);
                return RedirectToAction("Playlists");
            }

            return View(lastFmProfile);
        }

        [Authorize]
        public ActionResult Playlists(string playlistId)
        {
            return View();
        }
        
        [Authorize]
        public ActionResult Album(string playlistId)
        {
            var response = LastFm.Client.Album.GetInfoAsync("Grimes", "Visions");
            LastAlbum album = response.Result.Content;
            return View(album);
        }
    }
}