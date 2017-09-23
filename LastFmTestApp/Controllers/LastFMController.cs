using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IF.Lastfm.Core.Objects;

namespace LastFmTestApp.Controllers
{
    public class LastFMController : Controller
    {
        [Authorize]
        public ActionResult LastFmProfile()
        {
            return View();
        }

        [Authorize]
        public ActionResult Playlists()
        {
            return View();
        }

        [Authorize]
        public ActionResult Playlists(string playlistId)
        {
            return View();
        }
        
        [Authorize]
        public ActionResult Album(string playlistId)
        {
            var response = client.Album.GetInfoAsync("Grimes", "Visions");
            LastAlbum visions = response.Content;
            return View();
        }
    }
}