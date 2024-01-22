using ChumaConsole.ChumaClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;

namespace ChumaUnitTest.ChumaClasses_Test
{
    [TestClass]
    public class Doctor_Test
    {
        [TestMethod]
        public void TryHealTest()
        {
            // arrange 
            Doctor doctor = new Doctor(1,1,3, Guid.NewGuid());
            Person person = new Person(2,3,4, isInfected: true, Guid.NewGuid());
            // act
            doctor.TryHeal(person);
            // assert            
            Assert.IsFalse(person.IsInfected);
        }

        [TestMethod]
        public void UpdatePositionTest()
        {
            // arrange 
            Doctor doctor = new Doctor(1, 1, 3, Guid.NewGuid());
            // act
            doctor.UpdatePosition(0.5);
            // assert            
            Assert.AreEqual(2, doctor.X);
            Assert.AreEqual(2, doctor.Y);
        }

        [TestMethod]
        public void SerializeToJsonTest()
        {
            // arrange 
            Doctor doctor = new Doctor(1, 1, 3, Guid.NewGuid());
            // act
            var json = doctor.SerializeToJson();
            var deserializedDoctor = JsonConvert.DeserializeObject<Doctor>(json);
            // assert            
            Assert.IsTrue(deserializedDoctor is Doctor);
        }
    }
}