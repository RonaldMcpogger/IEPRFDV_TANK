using UnityEngine;

public class Scorekeeper : MonoBehaviour
{
    int p1Point;
    int p2Point;

    [SerializeField] int initialPoints = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p1Point = initialPoints;
        p2Point = initialPoints;
    }

    public void p1Killed()
    {
        p1Point--;
        Debug.Log("p1 lives: " + p1Point);
    }

    public void p2Killed()
    {
        p2Point--;
        Debug.Log("p2 lives: " + p1Point);
    }
}
