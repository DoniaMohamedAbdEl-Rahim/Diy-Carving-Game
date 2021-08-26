using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class DragSticker : MonoBehaviour
{
    [SerializeField]
    Sprite[] stickersSprites;
    [SerializeField]
    GameObject[] stickers;
    [SerializeField]
    intSO stickerIndex;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if ((touch.phase == TouchPhase.Began))
            {
                Ray raycast = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit raycastHit;
                if (Physics.Raycast(raycast, out raycastHit))
                {
                    // Debug.Log("Something Hit");

                    if (raycastHit.collider.CompareTag("Banana"))
                    {
                        for (int i = 0; i < stickers.Length; i++)
                        {
                            if (stickers[i].tag == raycastHit.collider.gameObject.tag)
                            {
                                stickerIndex.value = i;
                                Debug.Log($"Selected sticker indx = {i}");
                                break;
                            }
                        }
                        SceneManager.LoadScene(2);
                    }
                }
            }
        }
    }

}
