using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movedPlatformManager : MonoBehaviour
{

    public BoxCollider2D collider2D;

    [SerializeField]
    Transform firstPos;
    [SerializeField]
    Transform lastPos;
    Transform nextPos;

    public float hareketHizi;

    void Start()
    {
        nextPos = firstPos;
    }

    void Update()
    {
        if(transform.position == firstPos.position)
        {
            nextPos = lastPos;
        }
        else if(transform.position == lastPos.position)
        {
            nextPos = firstPos;
        }

        transform.position = Vector2.MoveTowards(transform.position, nextPos.position, hareketHizi);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collider2D.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collider2D.enabled = false;
        }
    }
}
