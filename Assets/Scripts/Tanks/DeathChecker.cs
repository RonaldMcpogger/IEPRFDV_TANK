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
                if (GameObject.Find("Scorekeeper").TryGetComponent<Scorekeeper>(out Scorekeeper keeper))
                { 
                    if(keeper.p1Point == 0 || keeper.p2Point == 0)
                        Debug.Log("Game Over!!");
                    else
                    {
                        var g = GameObject.Instantiate(this.transform.root.gameObject);
                        g.transform.position = Vector3.zero; //temporary
                    }
                }
                Debug.Log(this.transform.root.gameObject + " hit!");
                Destroy(this.transform.root.gameObject);
            }
        }
    }
}
