using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS07_3_Shadow : MonoBehaviour
{
    float posX;
    float posY;
    float T = 5;
    float f;
    Vector2 defaultPosition;
    [SerializeField] Transform character;
    public UnityEvent OnCharacter;
    bool onCharacter;
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
        // posX = Mathf.Lerp(transform.position.x, character.position.x, Stage07_3Params.Instance.ShadowSpeed * Time.deltaTime);
        posY = Mathf.Sin(2 * Mathf.PI * f * posX) + defaultPosition.y;
        this.transform.position = new Vector3(posX, posY, 0);
        // this.transform.position = new Vector3(posX, 0, 0) ;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Character>())
        {
            OnCharacter?.Invoke();
            onCharacter = true;
        }
    }
}
