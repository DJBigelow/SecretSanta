using System;
using NUnit.Framework;
using SecretSanta.Services;
using SecretSanta.Models;
using System.Collections.Generic;

namespace SecretSanta.Test
{
    public class SecretSantaRoomTests
    {
        private SecretSantaRoom session;

        [SetUp]
        public void Setup()
        {
            session = new SecretSantaRoom();
        }


        [Test]
        public void AssignSecretSantasAssignsUniqueGifters()
        {
            for (int i = 0; i < 5; ++i)
            {
                session.Gifters.Add(new Gifter(i.ToString(), i.ToString()));
            }

            session.AssignSecretSantas();

            foreach(Gifter gifter in session.Gifters)
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
                session.Gifters.Add(new Gifter(i.ToString(), ""));
            }

            session.AssignSecretSantas();


            var originalGiftersList = new List<Gifter>();

            foreach(Gifter gifter in session.Gifters)
            {
                originalGiftersList.Add(gifter);
            }


            session.AssignSecretSantas();

            for (int i = 0; i < session.Gifters.Count; ++i)
            {
                Assert.AreEqual(originalGiftersList[i].ID, session.Gifters[i].ID);
            }

        }
    }
}