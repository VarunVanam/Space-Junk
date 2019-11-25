using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject IP_panel;
	public GameObject Mainpanel;

    public void PlayGame()
    {
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
    	Application.Quit();
    	Debug.Log("QUIT!");
    }
    public void ShowIP()
    {
    	IP_panel.SetActive(true);
    	Mainpanel.SetActive(false);
    }
    public void ShowMain()
    {
    	IP_panel.SetActive(false);
    	Mainpanel.SetActive(true);
    }

}
