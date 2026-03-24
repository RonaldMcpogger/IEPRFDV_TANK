using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class DeathChecker : MonoBehaviour

{
    float deathTimer = 0;
    public Vector2 spawnLoc;
    public Vector2 spawnPos;
    public SpriteRenderer TankBod;
    public SpriteRenderer Turret;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnLoc = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        deathTimer -= Time.deltaTime;
        if ((deathTimer <0))
        {
            TankBod.color = new Color(1, 1, 1, 1);
            Turret.color = new Color(1, 1, 1, 1);
            //Debug.Log("cooldown gone");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("Bullet") && deathTimer< 0)
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

                col.gameObject.GetComponent<Bullet>().resetHit();

                //set respawn code here, maybe send a signal to a manager that instantiates at a position
                if (GameObject.Find("Scorekeeper").TryGetComponent<Scorekeeper>(out Scorekeeper keeper))
                { 
                    if(keeper.p1Point == 0 || keeper.p2Point == 0)
                    {
                        // insert UI code that shows Game Over
                        Debug.Log("Game Over!!");
                        gameObject.transform.root.gameObject.SetActive(false);
                    }
                        
                    
                    else
                    {
                        // var g = GameObject.Instantiate(this.transform.root.gameObject);
                        deathTimer = 4f;
                        GlobalScreenShake.Instance.TriggerShake(1, 1f);

                        this.transform.root.position = spawnLoc; //temporary
                        TankBod.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
                        Turret.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
                        Debug.Log(this.transform.root.gameObject + " hit!");
                    }
                }
              
              
            }
        }
    }
}
