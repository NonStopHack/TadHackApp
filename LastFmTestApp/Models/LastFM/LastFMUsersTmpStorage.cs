using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LastFmTestApp.Models.LastFM
{
    public class LastFmUsersTmpStorage
    {
        private static List<LastFmProfile> _profiles;

        static LastFmUsersTmpStorage()
        {
            _profiles = new List<LastFmProfile>();
        }

        public static LastFmProfile GetProfileByEmail(string email)
        {
            var user = _profiles?.FirstOrDefault(u => u.SystemUserEmail == email);
            return user;
        }

        public static bool AddProfile(LastFmProfile newProfile)
        {
            if (GetProfileByEmail(newProfile.Email) != null)
            {
                return false;
            }
            else
            {
                _profiles.Add(newProfile);
                return true;
            }
        }

        public static void CreateOrUpdateUser(LastFmProfile newProfile)
        {
            if (GetProfileByEmail(newProfile.SystemUserEmail) == null)
            {
                _profiles.Add(newProfile);
            }
            else
            {
                var user = _profiles?.FirstOrDefault(u => u.SystemUserEmail == newProfile.SystemUserEmail);
                user.Email = newProfile.Email;
                user.Password = newProfile.Password;
            }
        }
    }
}