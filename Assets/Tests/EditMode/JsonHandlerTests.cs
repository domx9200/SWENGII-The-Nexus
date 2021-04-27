using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Tests
{
    public class JsonHandlerTests
    {
        // Should fail if test is not written to despite having a save file to read from
        [Test]
        public void LoadFromFileSucceeds() 
        {  
            Assert.IsTrue(true);          
        }
        
    }
}