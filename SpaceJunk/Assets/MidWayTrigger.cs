using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MidWayTrigger : MonoBehaviour
{
   int count=0;
   public GameObject guessPan;


   void Start()
    {
       
    }


    void OnTriggerEnter(Collider other)
    {
        count++;
        if(count == 11)
        {
        	Debug.Log(count);
            guessPan.SetActive(true);
            Debug.Log("Hey1");
             StartCoroutine("Ace");
            Debug.Log("Hey3");
            guessPan.SetActive(false);
            Debug.Log("Hey4");
        }
    }
    IEnumerator Ace()
    {
    	Debug.Log("Hey2");
    	yield return new WaitForSeconds(5f);
    }
}
