using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PauseScreen : MonoBehaviour

{
    bool paused;
    bool canPause ;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] List<GameObject> boxes;
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
        
    }
}
