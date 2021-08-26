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
    [SerializeField]
    GameObjectSO finalGameObject;
    bool done = false;
    bool done2 = false;
    float speed =40f;
    private void Update()
    {
        if (done)
        {
            {
                if (!done2)
                    finalGameObject._gameObject.transform.position += new Vector3(0, 0, -20);
                done2 = true;
            }
            finalGameObject._gameObject.transform.Rotate(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
        }
    }
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
        done = true;
        StartCoroutine(Animate());
    }
    IEnumerator Animate()
    {
        yield return new WaitForSeconds(5.0f);
        finalGameObject._gameObject.transform.position = new Vector3(18, 9 , 10);
        gamePlayCanvas.gameObject.SetActive(false);
        lastCanvas.gameObject.SetActive(true);
    }
}
