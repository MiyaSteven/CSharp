using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;

namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            // All Women Leagues
            ViewBag.WomensLeagues = _context.Leagues
                .Where(w => w.Name.Contains("Women"))
                .ToList();

            // All Hockey Leagues
            ViewBag.HockeyLeagues = _context.Leagues
                .Where(h => h.Sport.Contains("Hockey"))
                .ToList();

            // All Not Football Leagues
            ViewBag.NotFootballLeagues = _context.Leagues
                .Where(a => !a.Name.Contains("Football"))
                .ToList();

            // All Conference Leagues
            ViewBag.ConferenceLeagues = _context.Leagues
                .Where(c => c.Name.Contains("Conference"))
                .ToList();

            // All Atlantic Leagues
            ViewBag.AtlanticLeagues = _context.Leagues
                .Where(c => c.Name.Contains("Atlantic"))
                .ToList();

            // All Dallas Teams
            ViewBag.DallasTeams = _context.Teams
                .Where(c => c.Location.Contains("Dallas"))
                .ToList();

            // All Raptors Teams
            ViewBag.RaptorsTeams = _context.Teams
                .Where(r => r.TeamName.Contains("Raptors"))
                .ToList();

            // All Teams from City
            ViewBag.CityTeams = _context.Teams
                .Where(r => r.Location.Contains("City"))
                .ToList();

            // All Teams that start with 'T'
            ViewBag.TStartTeams = _context.Teams
                .Where(t => t.TeamName.StartsWith("T"))
                .ToList();

            // Teams Ascending Alphabetically by Location
            ViewBag.AscendingTeamsByLocation = _context.Teams
                .Where(abc => abc.Location.Contains(abc.Location))
                .OrderBy(abc => abc.Location)
                .ToList();

            // Teams Descending by TeamName
            ViewBag.descendingTeamOrder = _context.Teams
                .Where(de => de.TeamName.Contains(de.TeamName))
                .OrderByDescending(de => de.TeamName)
                .ToList();

            // Players with last name of "Cooper"
            ViewBag.LastNameCooperPlayers = _context.Players
                .Where(p => p.LastName.Contains("Cooper"))
                .ToList();

            // Players with first name of "Joshua"
            ViewBag.FirstNameJoshuaPlayers = _context.Players
                .Where(p => p.FirstName.Contains("Joshua"))
                .ToList();

            // Players with last name of "Cooper" minus Joshua first name
            ViewBag.CooperMinusJoshuaPlayers = _context.Players
                .Where(cmj => cmj.LastName.Contains("Cooper") && !cmj.FirstName.Contains("Joshua"))
                .ToList();

            // Players with last name of "Cooper" minus Joshua first name
            ViewBag.FirstNames = _context.Players
                .Where(aow => aow.FirstName.Contains("Alexander") || aow.FirstName.Contains("Wyatt"))
                .ToList();

            return View("Level1");
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View("Level2");
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }
    }
}