using UnityEngine;

public class OOBWalls : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private Vector2 p1SpawnLoc;
    [SerializeField] private Vector2 p2SpawnLoc;
    [SerializeField] private Vector2 bulletLoc;
    public GameObject p1;
    public GameObject p2;
    public GameObject origBullet;
    void Start()
    {
        p1SpawnLoc = p1.transform.position;
        p2SpawnLoc = p2.transform.position;
        bulletLoc = origBullet.transform.position;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<PlayerMovement>().getTeamCode() == 0)
            {
                other.gameObject.transform.position = p1SpawnLoc;
            }
            else
            {
                other.gameObject.transform.position = p2SpawnLoc;
            }
        }
        else if (other.CompareTag("Bullet"))
        {
            other.gameObject.transform.position = bulletLoc;
        }
    }
}
