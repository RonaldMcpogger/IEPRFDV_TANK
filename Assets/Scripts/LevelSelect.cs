using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    
    [SerializeField] private GameObject MainMenu;
    
        void Start()
        {
            //levelSelectMenu.SetActive(false);
        }

    void Update()
    {

    }
    public void backtoTitle()
    {
        this.gameObject.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void loadlevel(int lv)
    {
        switch (lv)
        {
            case 1:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
                break;
            case 2:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level3");
                break;
            case 4:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level4");
                break;
            default:
                Debug.LogError("Invalid level selected: " + lv);
                break;
        }
    }
}
