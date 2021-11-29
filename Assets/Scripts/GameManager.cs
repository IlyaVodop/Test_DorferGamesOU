using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject] private UiManager _uiManager;
    public void Restart()
    {
        _uiManager. _uiObject.SetActive(false);
        SceneManager.LoadScene("Game");
    }
   
}
