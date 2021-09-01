using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigate : MonoBehaviour
{
    public void navgation(string scene) {
        SceneManager.LoadScene(scene);
    }

    public static void navigateInScript(string scene) {
        SceneManager.LoadScene(scene);
    }
}
