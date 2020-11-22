using System;
using NUnit.Framework;
using SecretSanta.Services;
using SecretSanta.Models;

namespace SecretSanta.Test
{
    public class SecretSantaSessionTests
    {
        private SecretSantaSession session;

        [SetUp]
        public void Setup()
        {
            session = new SecretSantaSession();
        }


        [Test]
        public void AssignSecretSantasAssignsUniqueGifters()
        {
            for (int i = 0; i < 5; ++i)
            {
                session.Gifters.Add(new Gifter(""));
            }

            session.AssignSecretSantas();

            foreach(Gifter gifter in session.Gifters)
            {
                //This doesn't necessarily prove that a gifter can't be assigned themselves, but it doesn't hurt to add it in
                Assert.That(gifter.AssignedGifteeID != Guid.Empty && gifter.AssignedGifteeID != gifter.ID);
            }
        }
    }
}