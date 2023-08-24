using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS07_3_Shadow : MonoBehaviour
{
    float posX;
    float posY;
    float T = 5;
    float f;
    Vector2 defaultPosition;

    private void Start()
    {
        defaultPosition = transform.position;
        f = 1 / T;
        posX = defaultPosition.x;

    }
    // Update is called once per frame
    void Update()
    {
        posX += Stage07_3Params.Instance.ShadowSpeed * Time.deltaTime;
        posY = Mathf.Sin(2 * Mathf.PI * f * posX) + defaultPosition.y;
        this.transform.position = new Vector3(posX, posY, 0);
        // this.transform.position = new Vector3(posX, 0, 0) ;
    }
}
