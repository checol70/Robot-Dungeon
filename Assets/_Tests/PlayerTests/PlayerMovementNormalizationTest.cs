using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerMovementNormalizationTests
    {
        [Test] 
        public void TestPlayerMovementScript()
        {
            Vector3 firstTest = PlayerMovementScript.GetInputDir(10, 0);
            Vector3 secondTest = PlayerMovementScript.GetInputDir(10, 10);
            Vector3 thirdTest = PlayerMovementScript.GetInputDir(4, 1);
            Vector3 fourthTest = PlayerMovementScript.GetInputDir(0, 10);
            Vector3 fifthTest = PlayerMovementScript.GetInputDir(1, 4);
            Vector3 sixthTest = PlayerMovementScript.GetInputDir(-10, 0);

            Vector3 seventhTest = PlayerMovementScript.GetInputDir(0, -10);
            Vector3 eighthTest = PlayerMovementScript.GetInputDir(-4, 1);
            Vector3 ninthTest = PlayerMovementScript.GetInputDir(1, -4);
            Vector3 tenthTest = PlayerMovementScript.GetInputDir(-1, -1);

            Assert.AreEqual(new Vector3(1,0, 0), firstTest);
            Assert.AreEqual(new Vector3(.5f, 0, .5f), secondTest);
            Assert.AreEqual(new Vector3(.8f, 0, .2f), thirdTest);
            Assert.AreEqual(new Vector3(0, 0, 1), fourthTest);
            Assert.AreEqual(new Vector3(.2f, 0, .8f), fifthTest);
            Assert.AreEqual(new Vector3(-1, 0, 0), sixthTest);
            Assert.AreEqual(new Vector3(0, 0, -1), seventhTest);
            Assert.AreEqual(new Vector3(-.8f, 0, .2f), eighthTest);
            Assert.AreEqual(new Vector3(.2f, 0, -.8f), ninthTest);
            Assert.AreEqual(new Vector3(-.5f, 0, -.5f), tenthTest);
        }

    }
}
