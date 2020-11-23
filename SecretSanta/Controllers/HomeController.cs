using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecretSanta.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SecretSanta.Services;
using SecretSanta.ViewModels;

namespace SecretSanta.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IDictionary<string, SecretSantaRoom> Rooms { get; }

        public HomeController(ILogger<HomeController> logger, Dictionary<string, SecretSantaRoom> rooms)
        {
            _logger = logger;
            Rooms = rooms;
        }



        public IActionResult Index()
        {
            return View();
        }



        public IActionResult CreateRoom()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRoom(CreateRoomViewModel vm)
        {
            if (Rooms.ContainsKey(vm.RoomCode))
            {
                return View();
            }

            SecretSantaRoom newRoom = new SecretSantaRoom();

            Rooms.Add(vm.RoomCode, newRoom);

            return View(nameof(EnterName), new EnterNameViewModel(vm.RoomCode));
        }




        public IActionResult EnterName(EnterNameViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            Gifter newGifter = new Gifter(vm.GifterName);
            Rooms[vm.RoomCode].Gifters.Add(newGifter);

            return View(nameof(Room), Rooms[vm.RoomCode]);
        }



        public IActionResult JoinRoom()
        {
            return View();
        }

        public IActionResult JoinRoom(string roomCode)
        {
            return View(nameof(Room), roomCode);
        }


        public IActionResult Room()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
