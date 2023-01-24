using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class WebSocketTests
{
    public GameObject gb;
// #if UNITY_WEBGL
//     [SetUp]
//     public void WebGLSetup()
//     {
//         Debug.Log("WEBGL BUILD");
//     }
// #endif
//
// #if UNITY_STANDALONE && !UNITY_EDITOR
//     [UnitySetUp]
//     public IEnumerator SASetup()
//     {
//         Debug.Log("STANDALONE BUILD");
//         // Load the main scene.
//         SceneManager.LoadScene(0, LoadSceneMode.Single);
//
//         // Wait until the Test Scene to be loaded.
//         yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Main");
//     }
// #endif

//#if UNITY_EDITOR
    [UnitySetUp]
        public IEnumerator Setup()
        {
            Debug.Log("EDITOR TESTING MESSAGE");
            // Load the main scene.
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
            
            // Wait until the Test Scene to be loaded.
            yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Main");
            //yield return new WaitForSeconds(5);
        }
//#endif


    [UnityTest]
    public IEnumerator SimpleLoadSceneTest()
    {
        // var element = GameObject.Find("Menu/Start/Testing");
        //
        // Assert.NotNull(element);
        //SceneManager.LoadScene(1, LoadSceneMode.Single);
        yield return new WaitForSeconds(5);
    }
    
}   
