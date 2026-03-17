using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour

{
    bool paused;
    bool canPause ;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] List<GameObject> boxes;
    [SerializeField] InputActionAsset controls1;
    [SerializeField] InputActionAsset controls2;


    bool pressed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        paused = false;
        canPause = true;
        pauseMenu.SetActive(false);
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (controls1.FindActionMap("Player1TankControl").FindAction("Start").WasPressedThisFrame() && canPause)
        {
            paused = !paused;
            
        }
        else if (controls2.FindActionMap("Player2TankControl").FindAction("Start").WasPressedThisFrame() && canPause)
        {
            paused = !paused;
           
        }

        if (paused)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);

        }
        else
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
    }
    public void Resume()
    {
        paused = false;
    }
    public void Quit()
    {
       SceneManager.LoadScene("TitleScreen");
    }
}
