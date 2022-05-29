using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject helpPanel;
    public GameObject creditsPanel;
    public GameObject quitPanel;

    private void Start()
    {
        menuPanel.SetActive(true);
        helpPanel.SetActive(false);
        creditsPanel.SetActive(false);
        quitPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuPanel.activeSelf == true)
                quitMenu();
            else
                mainMenu();
        }
    }

    public void quitMenu()
    {
        menuPanel.SetActive(false);
        helpPanel.SetActive(false);
        creditsPanel.SetActive(false);
        quitPanel.SetActive(true);
    }  
    
    public void creditMenu()
    {
        menuPanel.SetActive(false);
        helpPanel.SetActive(false);
        creditsPanel.SetActive(true);
        quitPanel.SetActive(false);
    }    
    
    public void helpMenu()
    {
        menuPanel.SetActive(false);
        helpPanel.SetActive(true);
        creditsPanel.SetActive(false);
        quitPanel.SetActive(false);
    }    

    public void mainMenu()
    {
        menuPanel.SetActive(true);
        helpPanel.SetActive(false);
        creditsPanel.SetActive(false);
        quitPanel.SetActive(false);
    }

    public void ApplicationQuit()
    {
        Application.Quit();
    }

    public void LoadLvl_1()
    {
        SceneManager.LoadScene(1);
    }    

    public void LoadLvl_2()
    {
        SceneManager.LoadScene(2);
    }

}
