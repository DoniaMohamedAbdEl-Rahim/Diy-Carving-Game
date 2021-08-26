using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField]
    Canvas gamePlayCanvas;
    [SerializeField]
    Canvas lastCanvas;
    [SerializeField]
    GameObject knife;
  
    public void Back_Clicked()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene(0);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Done()
    {
        Debug.Log("Done");
        gamePlayCanvas.gameObject.SetActive(false);
        lastCanvas.gameObject.SetActive(true);
    }
}
