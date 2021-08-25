using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class DragAndDropStickers : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject placeHolder;
    [SerializeField]
    Canvas stickers_Canvas;
    Vector3 _touchPosition;
    Vector3 _direction;
    Rigidbody _rb;
    [SerializeField]
    float _moveSpeed = 0.01f;
    bool selected = false;
    Vector3 screenPoint;
    Vector3 offset;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
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
                        stickers_Canvas.enabled = false;
                        placeHolder.SetActive(true);
                        //transform.position = Input.mousePosition;
                        Debug.Log("Banana clicked");
                        selected = true;
                    }
                    else
                    {
                        selected = false;
                    }
                }
                screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

                offset =gameObject.transform.position- Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, screenPoint.z));

            }
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 cursorScreenPoint = new Vector3(touch.position.x, touch.position.y, screenPoint.z);
                Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + offset;
                transform.position = cursorPosition;
            }
            if (transform.position.magnitude - placeHolder.transform.position.magnitude < 300.0f)
            {

                this.transform.position = placeHolder.transform.position;
                placeHolder.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       // gameObject.SetActive(false);
    }
}
