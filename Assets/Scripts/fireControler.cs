using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireControler : MonoBehaviour
{

    AudioSource punchSound;

    void Start()
    {
        punchSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            if (collision.gameObject.GetComponent<PlayerMovement>().player1)
            {
                GameObject.Find("AltKatman").GetComponent<playerManager>().destroyPlayer(collision.gameObject,true);
                
            }
            else
            {
                GameObject.Find("AltKatman").GetComponent<playerManager>().destroyPlayer(collision.gameObject,false);
            }
            punchSound.Play();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
