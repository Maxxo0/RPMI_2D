using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject controlMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] TMP_Text pickUps;
    [SerializeField] GameObject ship;
    [SerializeField] GameObject menuManager;
    public int actuallyPoints;
    public int maxPoints;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        actuallyPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pickUps.text = actuallyPoints.ToString() + "/" + maxPoints.ToString();
        if (actuallyPoints >= maxPoints ) { actuallyPoints = maxPoints; }
        if (actuallyPoints == maxPoints) { CanExit(); }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Drop"))
        {
            actuallyPoints++;
            collision.gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Nave"))
        {

            SceneManager.LoadScene(5);
        }
    }

    public void ReturnMenu()
    {

        SceneManager.LoadScene(5); // Cargar escena 1
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

    



    public void QuitGame()
    {
        Application.Quit(); // Cerrar juego
    }

    public void Controls(InputAction.CallbackContext context)
    {
        if (context.started) 
        {
            controlMenu.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ExitControls()
    {
        controlMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void CanExit()
    {
        ship.gameObject.SetActive(true);
    }

    private void LvlUnlock()
    {
        
    }
} 


