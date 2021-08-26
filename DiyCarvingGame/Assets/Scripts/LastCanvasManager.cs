using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LastCanvasManager : MonoBehaviour
{

    [SerializeField]
    Image originalSticker_img;
    [SerializeField]
    Sprite[] stickersSprites;
    [SerializeField]
    intSO stickerIndex;
    [SerializeField]
    intSO carvingTimes;
    [SerializeField]
    TMP_Text resultTxt;
    [SerializeField]
    Image[] stars;
    [SerializeField]
    Sprite star;
    [SerializeField]
    Slider slider;
    void Start()
    {
        originalSticker_img.sprite = stickersSprites[stickerIndex.value];
        slider.value = (carvingTimes.value);
        //Matching Text
        if (carvingTimes.value >= 100)
        {
            resultTxt.text = "Mateches 100 %";
            //  Debug.Log($"Carving > 100 = {carvingTimes.value}");
        }
        else if (carvingTimes.value < 100)
        {
            resultTxt.text = $"Mateches {carvingTimes.value} %";
            // Debug.Log($"Carving < 100 = {carvingTimes.value}");
        }


        //Stars 
        if (carvingTimes.value >= 80)
        {
            stars[0].sprite = star;
            stars[1].sprite = star;
            stars[2].sprite = star;
        }
        else if (carvingTimes.value >= 50)
        {
            stars[0].sprite = star;
            stars[1].sprite = star;
        }
        else if (carvingTimes.value >= 10)
        {
            stars[0].sprite = star;
        }
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
