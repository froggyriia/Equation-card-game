using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButtonBehaviour : MonoBehaviour
{
    public void GoToMainScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
