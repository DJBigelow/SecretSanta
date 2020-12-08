using System;
using NUnit.Framework;
using SecretSanta.Models;
using System.Collections.Generic;

namespace SecretSanta.Test
{
    public class SecretSantaRoomTests
    {
        private SecretSantaRoom room;

        [SetUp]
        public void Setup()
        {
            room = new SecretSantaRoom();
        }


        [Test]
        public void AssignSecretSantasAssignsUniqueGifters()
        {
            for (int i = 0; i < 5; ++i)
            {
                room.Gifters.Add(new Gifter(Guid.NewGuid(), i.ToString()));
            }

            room.AssignSecretSantas();

            foreach(Gifter gifter in room.Gifters)
            {
                //This doesn't necessarily prove that a gifter can't be assigned themselves, but it doesn't hurt to add it in
                Assert.That(gifter.RecipientName != null && gifter.RecipientName != gifter.Name);
            }
        }

        [Test]
        public void AssignSecretSantasDoesNothingIfAlreadyCalled()
        {
            for (int i = 0; i < 5; ++i)
            {
                room.Gifters.Add(new Gifter(Guid.NewGuid(), ""));
            }

            room.AssignSecretSantas();


            var originalGiftersList = new List<Gifter>();

            foreach(Gifter gifter in room.Gifters)
            {
                originalGiftersList.Add(gifter);
            }


            room.AssignSecretSantas();

            for (int i = 0; i < room.Gifters.Count; ++i)
            {
                Assert.AreEqual(originalGiftersList[i].ID, room.Gifters[i].ID);
            }

        }
    }
}