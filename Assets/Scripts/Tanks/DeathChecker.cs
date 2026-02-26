using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class DeathChecker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("Bullet"))
        {
            Debug.Log("last hit was" + col.gameObject.GetComponent<Bullet>().getLastHit());
            if (col.gameObject.GetComponent<Bullet>().getLastHit() != this.transform.root.gameObject &&
                col.gameObject.GetComponent<Bullet>().getLastHit() != null)
            {
                Debug.Log(this.transform.root.gameObject + " hit!");
                Destroy(this.transform.root.gameObject);

                //set score code here

                switch (GetComponentInParent<PlayerMovement>().getTeamCode())
                {
                    case 0:
                    FindAnyObjectByType<Scorekeeper>().p1Killed();
                        break;
                    case 1:
                    FindAnyObjectByType<Scorekeeper>().p2Killed();
                        break;
            }
                
                //set respawn code here, maybe send a signal to a manager that instantiates at a position
            }
        }
    }
}
