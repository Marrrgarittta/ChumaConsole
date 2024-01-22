using ChumaConsole.ChumaClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChumaClasses_Test.ChumaUnitTest
{
    [TestClass]
    public class ChumaModel_Test
    {
        [TestMethod]
        public void AddAgentTest()
        {
            // arrange 
            var model = new ChumaModel();
            var person1 = new Person(x: 1, y: 1, speed: 5, isInfected: true, id: Guid.NewGuid());
            // act
            model.AddAgent(person1);
            // assert            
            Assert.IsTrue(model.agents.Contains(person1));
        }

        [TestMethod]
        public void RemoveAgentTest()
        {
            // arrange 
            var model = new ChumaModel();
            var person1 = new Person(x: 1, y: 1, speed: 5, isInfected: true, id: Guid.NewGuid());
            // act
            model.AddAgent(person1);
            model.RemoveAgent(person1);
            // assert            
            Assert.IsFalse(model.agents.Contains(person1));
            Assert.AreEqual(model.agents.Count, 0);
        }

        [TestMethod]
        public void IsCriticalDistanceTest()
        {
            // arrange 
            var model = new ChumaModel();
            var person1 = new Person(x: 1, y: 1, speed: 5, isInfected: true, id: Guid.NewGuid());
            var person2 = new Person(x: 5, y: 5, speed: 3, isInfected: false, id: Guid.NewGuid());
            // act
            var result = model.IsCriticalDistance(person1, person2);
            // assert            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdateAgentsTest()
        {
            // arrange 
            var model = new ChumaModel();
            var person1 = new Person(x: 1, y: 1, speed: 5, isInfected: true, id: Guid.NewGuid());
            var person2 = new Person(x: 5, y: 5, speed: 3, isInfected: false, id: Guid.NewGuid());
            var doctor = new Doctor(x: 10, y: 10, speed: 2, id: Guid.NewGuid());

            model.AddAgent(person1);
            model.AddAgent(person2);
            model.AddAgent(doctor);

            // act
            model.UpdateAgents(3); // обновляем модель каждые 3 секунды

            // assert
            Assert.AreEqual(16, person1.X);
            Assert.AreEqual(16, person1.Y);

            Assert.AreEqual(14, person2.X);
            Assert.AreEqual(14, person2.Y);

            Assert.AreEqual(16, doctor.X);
            Assert.AreEqual(16, doctor.Y);

            // доктор должен был вылечить всех
            Assert.IsFalse(person1.IsInfected);
            Assert.IsFalse(person2.IsInfected);
        }
    }
}