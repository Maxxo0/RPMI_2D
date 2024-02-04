using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject controlMenu;
    [SerializeField] GameObject levelMenu;
    
    public int level = 0;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this);
    }
    

    public void PlayGame()
    {
        levelMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        Application.Quit(); // Cerrar juego
    }

    public void Controls()
    {
        controlMenu.SetActive(true);
        Time.timeScale = 0f;

    }

    public void ExitControls()
    {
        controlMenu.SetActive(false);
        Time.timeScale = 0f;
    }


    public void ExitMenu()
    {
        levelMenu.SetActive(false);
        Time.timeScale = 0f;
    }


    public void Level1()
    {
        if (level == 0)
        {
            level = 1;
            SceneManager.LoadScene(1); // Cargar escena 1
        }
    }

    public void Level2()
    {
        if(level == 1)
        {
            level = 2;
            SceneManager.LoadScene(2); // Cargar escena 2
        }
    }

    public void Level3()
    {
        if(level == 2)
        {
            level = 3;
            SceneManager.LoadScene(3); // Cargar escena 3
        }
    }

    public void Level4()
    {
        if(level==4)
        {
            level = 4;
            SceneManager.LoadScene(4); // Cargar escena 1
        }
    }
}
