using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;



public class Spawner : MonoBehaviour
{
    

    public Animator anim;
    public Transform spawnPoint;
    public float spawnRate = 2f;
    string[] colour = new string[]{"RedButton","GreenButton","BlueButton","OrangeButton","PinkButton"};
    int whatToSpawn;
    List<string> list = new List<string>();
    int[] pattern1 = {1,2,1,4};
    int[] pattern2 = {3,1,2,0};
    string ans;
    public List<GameObject> p = new List<GameObject>();
    
    public GameObject Con;
    public GameObject GPan;
    public GameObject LogicPan;
    public GameObject InvalidPan;
    public GameObject SuccessPan;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Ace");
        
    }


    public void CheckAns()
    {
        if(ans == colour[pattern1[3]] )
        {
            Debug.Log("Success!");
            SuccessPan.SetActive(true);
        }
        else if(ans != colour[pattern1[3]])
        {
            Debug.Log("WRONG!");
            InvalidPan.SetActive(true);
        } 
    }

    IEnumerator Ace()
    {
        // int ran = Random.Range (1,3); 
     //    switch(ran)
     //     {
        //case 1:
            StartCoroutine("MakeP1");
     //                 break;

     //         case 2:StartCoroutine(MakeP(pattern2));
     //                 break;
     //     }

         yield return new WaitForSeconds(4f);
        //  int k=0;
        // for(int i=0;i<3;i++)
        // {
            
        //     MakeBox(pattern1[0]);
        //       yield return new WaitForSeconds(spawnRate);
        //     MakeBox(pattern1[1]);
        //       yield return new WaitForSeconds(spawnRate);
        //     MakeBox(pattern1[2]);
        //       yield return new WaitForSeconds(spawnRate);
        //     k++;
        //     if(k==3)
        //     {
        //         break;//**This should be where the door closes**
        //     }
        //     else
        //     {
        //         MakeBox(pattern1[3]);
        //           yield return new WaitForSeconds(spawnRate);

        //     }
        // }
        foreach(string s in list) 
        {
            Debug.Log(s);
        }//List of boxes generated             
    }
    

     IEnumerator MakeP1()
     {
        int k=0;
        for(int i=0;i<3;i++)
        {        
            MakeBox(pattern1[0]);
            yield return new WaitForSeconds(spawnRate);
            MakeBox(pattern1[1]);
            yield return new WaitForSeconds(spawnRate);
            MakeBox(pattern1[2]);
            yield return new WaitForSeconds(spawnRate);
            k++;
            if(k==3)
            {
                break;
            }
            else
            {
                MakeBox(pattern1[3]);
                yield return new WaitForSeconds(spawnRate);
            }
        }
     }

   //  IEnumerator MakeP2()
   //  {
        // int k=0;
   //   for(int i=0;i<3;i++)
   //       {
   //          MakeBox(pattern2[0]);
   //            yield return new WaitForSeconds(spawnRate);
   //          MakeBox(pattern2[1]);
   //            yield return new WaitForSeconds(spawnRate);
   //          MakeBox(pattern2[2]);
   //            yield return new WaitForSeconds(spawnRate);
   //          k++;
   //          if(k==3)
   //          {
   //              break;
   //          }
   //          else
   //          {
   //              MakeBox(pattern2[3]);
   //                yield return new WaitForSeconds(spawnRate);

   //          }
   //      }
   //   }



    // IEnumerator MakeP(int[] px)
    // {
    //  int k=0;
    //  for(int i=0;i<3;i++)
    //      {
    //         MakeBox(px[0]);
    //           yield return new WaitForSeconds(spawnRate);
    //         MakeBox(px[1]);
    //           yield return new WaitForSeconds(spawnRate);
    //         MakeBox(px[2]);
    //           yield return new WaitForSeconds(spawnRate);
    //         k++;
    //         if(k==3)
    //         {
    //             break;
    //         }
    //         else
    //         {
    //             MakeBox(px[3]);
    //               yield return new WaitForSeconds(spawnRate);

    //         }
    //     }
    // }
    /*Logic Function
    Should make a series of numbers with {1,2,3,4,5} only(Or atleast the result should be these 5 no.s)
    Let's make it simple
    List = {1,2,3,4,5};
    pattern 1 = {(1214)(1214)....}
    pattern 2 = {(3124)(3124)....}
    pattern 3 = {(232)(232)....}
    pattern 4 = {(131)(131)....}
    pattern 5 = {(3212)(3212)....}
    pattern 6 = {(1231)(1231)....}
    pattern 7 = {(3121)(3121)....}
    pattern 8 = {()()....}
    pattern 9 = {()()....}
    pattern10 = {()()....}
    pattern11 = {()()....}
    */



    
    public void MakeBox(int x)
    {
        Instantiate (p[x] , spawnPoint.position , Quaternion.identity); 
        list.Add(colour[x]);
    }



    int count=0;
    void OnTriggerEnter(Collider other)
    {
        count++;
        Destroy(other.gameObject);
        if(count==11)
        {
            anim.SetBool("closeNow",true);
            Con.SetActive(true);
            LogicPan.SetActive(true);
            GPan.SetActive(true);
            
        }
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void ToNxt()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Relod()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void BtnTest()
    {
        
            ans = EventSystem.current.currentSelectedGameObject.name;
            Con.SetActive(false);
            Debug.Log(ans);
            CheckAns();
    }
}



//     Update is called once per frame
//     void Update()
//     {
//         if(Time.time > nextSpawn)
//         {
            
//          whatToSpawn = Random.Range (1,6);//Need to change as i dont want random. Probably a function call(Logic Function)
//          Debug.Log(whatToSpawn);
//          switch(whatToSpawn)
//          {
//              case 1:
//                  Instantiate (p1 , spawnPoint.position , Quaternion.identity);
//                  list.Add("red");
//                  break;
//              case 2:
//                  Instantiate (p2 , spawnPoint.position , Quaternion.identity);
//                  list.Add("green");
//                  break;
//              case 3:
//                  Instantiate (p3 , spawnPoint.position , Quaternion.identity);
//                  list.Add("blue");
//                  break;
//                 case 4:
//                     Instantiate (p4 , spawnPoint.position , Quaternion.identity);
//                     list.Add("orange");
//                     break;
//                 case 5:
//                     Instantiate (p5 , spawnPoint.position , Quaternion.identity);
//                     list.Add("pink");
//                     break;
//          }
//          nextSpawn = Time.time + spawnRate;
//          foreach(string s in list) 
//          {
//              Debug.Log(s);
//          }
//         }
//     }