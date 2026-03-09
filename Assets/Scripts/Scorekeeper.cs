using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scorekeeper : MonoBehaviour
{
    
    public int p1Point;
    public int p2Point;

    [SerializeField] GameObject anchor;
    [SerializeField] GameObject anchorParent;
    [SerializeField] List<GameObject> lives;
    [SerializeField] GameObject anchor2;
    [SerializeField] GameObject anchorParent2;
    [SerializeField] List<GameObject> lives2;


    [SerializeField] bool debug = true;

    [SerializeField] int initialPoints = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p1Point = initialPoints;
        p2Point = initialPoints;

        for (int i = 0; i < initialPoints; i++)
        {
            GameObject g = GameObject.Instantiate(anchor, anchorParent.transform);
            g.name = "One's Heart " + i;
            if (g.TryGetComponent<RectTransform>(out RectTransform transform))
            {
                transform.anchoredPosition += new UnityEngine.Vector2((53 * i), 0);
            }
            lives.Add(g);
        }

        anchor.SetActive(false);

        for (int i = 0; i < initialPoints; i++)
        {
            GameObject g = GameObject.Instantiate(anchor2, anchorParent2.transform);
            g.name = "Two's Heart " + i;
            if (g.TryGetComponent<RectTransform>(out RectTransform transform))
                transform.anchoredPosition += new UnityEngine.Vector2(-(53 * i), 0);
            lives2.Add(g);
        }
        anchor2.SetActive(false);
    }

    public void p1Killed()
    {
        if (debug)
            Debug.Log("p1 lives: " + p1Point);
        else
        {
            if(p1Point > 0 && lives.Last().TryGetComponent<RawImage>(out RawImage img))
            {
                img.color = new Color(0,0,0,0);
                lives.Remove(lives.Last());
            }
        }

        p1Point--;
    }

    public void p2Killed()
    {

        if (debug)
            Debug.Log("p2 lives: " + p2Point);
        else 
        {
            if (p2Point > 0 && lives2.Last().TryGetComponent<RawImage>(out RawImage img))
            {
                img.color = new Color(0, 0, 0, 0);
                lives2.Remove(lives2.Last());
            }
        }

        p2Point--;
    }
}
