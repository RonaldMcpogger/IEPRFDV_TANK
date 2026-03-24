using UnityEngine;
using TMPro;
public class WinScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] TMP_Text WinText;
    [SerializeField] Scorekeeper scorekeeper;
    void Start()
    {
        if (scorekeeper.p1Point <= 0)
        {
            WinText.text = "Player 1 Wins!";
        }
        else if (scorekeeper.p2Point <= 0)
        {
            WinText.text = "Player 2 Wins!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0;

    }
}
