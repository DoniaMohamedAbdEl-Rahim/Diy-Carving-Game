using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastCanvasManager : MonoBehaviour
{
    
    [SerializeField]
    Image originalSticker_img;
    [SerializeField]
    Sprite[] stickersSprites;
    [SerializeField]
    intSO stickerIndex;
    void Start()
    {
        originalSticker_img.sprite = stickersSprites[stickerIndex.value];
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
