using UnityEngine;
using TMPro;
public class WinScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] TMP_Text WinText;
    [SerializeField] Scorekeeper scorekeeper;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

       
        Time.timeScale = 0;

    }
    public void CallEnd( int flag)
    {
       switch(flag)
        {
            case 1:
                WinText.text = "Player 1 Wins!";
                break;
                case 2:
                WinText.text = "Player 2 Wins!";
                break;
        }
        
            
        
       
            
        
    }
}
