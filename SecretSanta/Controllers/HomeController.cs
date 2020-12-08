using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecretSanta.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SecretSanta.ViewModels;
using System.Collections.Concurrent;
using Microsoft.AspNetCore.Http;

namespace SecretSanta.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IDictionary<string, SecretSantaRoom> Rooms { get; }

        public HomeController(ILogger<HomeController> logger, IDictionary<string, SecretSantaRoom> rooms)
        {
            Rooms = rooms;
        }



        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult CreateRoom()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRoom(CreateRoomViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var newRoom = new SecretSantaRoom();

                if (Rooms.TryAdd(vm.RoomCode, newRoom))
                {
                    return View(nameof(EnterName), new EnterNameViewModel { RoomCode = vm.RoomCode });
                }

                ModelState.AddModelError("RoomExists", "Room already exists");
                return View();
            }


        }



        [HttpPost]
        public IActionResult EnterName(EnterNameViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }


            Gifter newGifter = new Gifter(Guid.NewGuid(), vm.GifterName);
            HttpContext.Session.SetString("UserID", newGifter.ID.ToString());

            Rooms[vm.RoomCode].Gifters.Add(newGifter);

            return RedirectToAction(nameof(Room),  new { roomCode = vm.RoomCode });
        }



        [HttpGet]
        public IActionResult JoinRoom()
        {
            return View();
        }

        [HttpPost]
        public IActionResult JoinRoom(JoinRoomViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            if (Rooms.ContainsKey(vm.RoomCode))
            {
                return View(nameof(EnterName), new EnterNameViewModel { RoomCode = vm.RoomCode });
            }
            else
            {
                ModelState.AddModelError("RoomDoesNotExist", "Room does not exist");
                return View(vm);
            }
        }

        [HttpGet]
        public IActionResult Room(string roomCode)
        {
            return View(new RoomViewModel(Rooms[roomCode], roomCode));
        }


        [HttpGet]
        public IActionResult Recipient(string roomID)
        { 
            var room = Rooms[roomID];
            room.AssignSecretSantas();

            var gifter = room.Gifters.FirstOrDefault(g => g.ID.ToString() == HttpContext.Session.GetString("UserID"));

            return View(new RecipientViewModel(gifter.RecipientName));
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
