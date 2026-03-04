using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject LevelMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LevelMenu.SetActive(false);
    }

    // Update is called once per frame
    public void StartGame()
    {
        mainMenu.SetActive(false);
        LevelMenu.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
