using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    GameObject objectPrefab;
    [SerializeField]
    float minX;
    [SerializeField]
    float minY;
    [SerializeField]
    float maxX;
    [SerializeField]
    float maxY;
    Vector2 position;

    bool spawn;

    void Start()
    {
        spawn = true;
    }

    void Update()
    {
        if (spawn)
        {
            StartCoroutine(olustur());
            spawn = false;
        }
    }

    IEnumerator olustur()
    {
        position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Instantiate(objectPrefab,position,Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(1, 5));
        spawn = true;
    }
}
