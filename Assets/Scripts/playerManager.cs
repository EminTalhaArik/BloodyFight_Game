using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{

    bool player1;
    [SerializeField]
    GameObject player1Prefab;
    [SerializeField]
    GameObject player2Prefab;

    [SerializeField]
    Transform spawnTransform;


    void Start()
    {

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
                destroyPlayer(collision.gameObject,true);
            }
            else if(!collision.gameObject.GetComponent<PlayerMovement>().player1)
            {
                destroyPlayer(collision.gameObject,false);
            }
        }
    }

    public void destroyPlayer(GameObject player, bool playerNum)
    {

        if (playerNum)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Player2PointUpper();
            StartCoroutine(player1Spawn(true));
        }
        else
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Player1PointUpper();
            StartCoroutine(player2Spawn(false));
        }
        Destroy(player.gameObject);
    }

    IEnumerator player1Spawn(bool playerNumber)
    {
        yield return new WaitForSeconds(3);
        GameObject player = Instantiate(player1Prefab, spawnTransform.position, Quaternion.identity);
        player.GetComponent<PlayerMovement>().player1 = playerNumber;
        player.GetComponent<Rigidbody2D>().gravityScale = 0.3f;

    }

    IEnumerator player2Spawn(bool playerNumber)
    {
        yield return new WaitForSeconds(3);
        GameObject player = Instantiate(player2Prefab, spawnTransform.position, Quaternion.identity);
        player.GetComponent<PlayerMovement>().player1 = playerNumber;
        player.GetComponent<Rigidbody2D>().gravityScale = 0.3f;
       
    }
}
   