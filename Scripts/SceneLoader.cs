using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  public static void LoadScene(int sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
