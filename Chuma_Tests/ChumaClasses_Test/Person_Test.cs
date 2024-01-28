using ChumaConsole.ChumaClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;

namespace ChumaUnitTest.ChumaClasses_Test
{
    [TestClass]
    public class Person_Test
    {
        [TestMethod]
        public void TryInfectTest()
        {
            // arrange 
            Person person = new Person(1, 4, 3, isInfected: true, Guid.NewGuid());
            Person person2 = new Person(2, 3, 5, isInfected: false, Guid.NewGuid());
            // act
            person.TryInfect(person2);
            // assert            
            Assert.IsTrue(person2.IsInfected);
        }

        [TestMethod]
        public void UpdatePositionTest()
        {
            // arrange 
            Person person = new Person(1, 4, 3, isInfected: true, Guid.NewGuid());
            // act
            person.UpdatePosition(4);
            // assert            
            Assert.AreEqual(13, person.X);
            Assert.AreEqual(16, person.Y);
        }

        [TestMethod]
        public void SerializeToJsonTest()
        {
            // arrange 
            Person person = new Person(1, 4, 3, isInfected: true, Guid.NewGuid());
            // act
            var json = person.SerializeToJson();
            var deserializedPerson = JsonConvert.DeserializeObject<Person>(json);
            // assert            
            Assert.IsTrue(deserializedPerson is Person);
        }

        [TestMethod]
        public void SetTrueInfectedStateTest()
        {
            // arrange 
            Person person = new Person(1, 4, 3, isInfected: false, Guid.NewGuid());
            // act
            person.IsInfected = true;
            //   person.SetInfectedState(true);
            // assert            
            Assert.IsTrue(person.IsInfected);
        }

        [TestMethod]
        public void SetFalseInfectedStateTest()
        {
            // arrange 
            Person person = new Person(1, 4, 3, isInfected: true, Guid.NewGuid());
            // act
            person.IsInfected = false;
            // person.SetInfectedState(false);
            // assert            
            Assert.IsFalse(person.IsInfected);
        }
    }
}