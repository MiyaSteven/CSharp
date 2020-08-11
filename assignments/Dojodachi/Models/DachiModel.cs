using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Models
{
    public class DachiModel
    {
        public const string SessionKeyName = "_Name";
        public const string SessionFullness = "_Fullness";
        public const string SessionHappiness = "_Happiness";
        public const string SessionMeals = "_Meals";
        public const string SessionEnergy = "_Energy";
        const string SessionKeyTime = "_Time";

        public string SessionInfo_Name { get; set; }
        public string SessionInfo_Fullness { get; set; }
        public string SessionInfo_Happiness { get; set; }
        public string SessionInfo_Meals { get; set; }
        public string SessionInfo_Energy { get; set; }
        public string SessionInfo_CurrentTime { get; private set; }
        public string SessionInfo_SessionTime { get; private set; }
        public string SessionInfo_MiddlewareValue { get; private set; }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                HttpContext.Session.SetString(SessionKeyName, "DachiObject");
                HttpContext.Session.SetInt32(SessionKeyAge, 773);
            }

            var name = HttpContext.Session.GetString(SessionKeyName);
            var age = HttpContext.Session.GetInt32(SessionKeyAge);
        }
    }
}