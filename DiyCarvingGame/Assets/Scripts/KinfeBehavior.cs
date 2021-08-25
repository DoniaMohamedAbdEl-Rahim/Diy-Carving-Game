using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinfeBehavior : MonoBehaviour
{
    Vector3 screenPoint;
    Vector3 offset;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            Touch touch = Input.GetTouch(0);
            Vector3 toutchPosition = touch.position;
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(toutchPosition.x, toutchPosition.y, screenPoint.z));
        }
    }
}
