using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Spawner2 : MonoBehaviour
{
	public Animator anim;
    public Transform spawnPoint;
    public float spawnRate = 2f;
    string[] colour = new string[]{"RedButton","GreenButton","BlueButton","OrangeButton","PinkButton"};
    int whatToSpawn;
    List<string> list = new List<string>();
    // int[] pattern1 = {1,2,1,4};
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
    	StartCoroutine("Ace1");  
    }

    public void CheckAns()
    {
        if(ans == colour[pattern2[3]])
        {
            Debug.Log("Success!");
            SuccessPan.SetActive(true);
        }
        else if(ans != colour[pattern2[3]])
        {
            Debug.Log("WRONG!");
            InvalidPan.SetActive(true);
        } 
    }

    IEnumerator Ace1()
    {
    	 StartCoroutine("MakeP2");
    	// yield return new WaitForSeconds(1f);
    	 yield return new WaitForSeconds(spawnRate);
         yield return new WaitForSeconds(spawnRate);
         yield return new WaitForSeconds(spawnRate);
    	 foreach(string s in list) 
        {
            Debug.Log(s);
        }
    }


    IEnumerator MakeP2()
    {
        int k=0;
     for(int i=0;i<3;i++)
         {
            MakeBox(pattern2[0]);
              yield return new WaitForSeconds(spawnRate);
            MakeBox(pattern2[1]);
              yield return new WaitForSeconds(spawnRate);
            MakeBox(pattern2[2]);
              yield return new WaitForSeconds(spawnRate);
            k++;
            if(k==3)
            {
                break;
            }
            else
            {
                MakeBox(pattern2[3]);
                  yield return new WaitForSeconds(spawnRate);

            }
        }
     }

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
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


    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
