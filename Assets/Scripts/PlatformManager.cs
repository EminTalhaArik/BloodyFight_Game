using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    Animator myAnimator;
    bool tekrar;

    void Start()
    {
        tekrar = true;
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (tekrar)
        {
            StartCoroutine(ulti());
            tekrar = false;
        }
    }

    IEnumerator ulti()
    {
        yield return new WaitForSeconds(15);
        myAnimator.SetBool("ultiyeGec", true);
        StartCoroutine(tekrarTrue());
    }

    IEnumerator tekrarTrue()
    {
        yield return new WaitForSeconds(5);
        tekrar = true;
    }
    
}
