using UnityEngine;
using UnityEngine.LowLevelPhysics2D;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    float minSpeed;
    Rigidbody2D rb;
    float cooldown;
    [SerializeField]
    float maxSpeed = 20f;

    [SerializeField] private SpriteRenderer bulletImage;
    [SerializeField] private TrailRenderer bulletTrail;

    [Tooltip("If true, this is the main bullet and will not die")]
    [SerializeField] private bool isCore =true;

    GameObject lastHit;

    int lifeTime = 10;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

    }

    private void FixedUpdate()
    {
        if (rb.linearVelocity.magnitude < minSpeed && rb.linearVelocity.magnitude > 0.1)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * minSpeed;
        }

        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);
        cooldown -= Time.fixedDeltaTime;
    }

    public void addSpeed( Vector3 angle, float speed)
    {
       this.rb.AddForce(angle * speed * 1);
        //Debug.Log("adding speed to bullet: " + angle + ", speed:" +  speed);
    }
    public void addForceToBullet(Vector3 angle, float speed, GameObject hitter)
    {
        if (cooldown < 0 )
        {
            this.addSpeed(angle, speed);
            lastHit = hitter;
            
            /// NOTE FIX THIS POWEREUP SPLITTER
                if (hitter.gameObject.GetComponent<PlayerMovement>().getPower()==powerType.BULLETSPLIT)
                {
                    for(int i =0; i<3; i++)
                    {
                        var newBullet = Instantiate(this.transform.root.gameObject); // spawn clone of bullet
                        newBullet.GetComponent<Bullet>().isCore = false;
                        newBullet.GetComponent<Bullet>().addSpeed(angle, speed);


                    }
                }
            

            if (lastHit.name == "Player")
            {
                bulletImage.color = Color.blue;

                bulletTrail.startColor = Color.blue;
            }
            else if(lastHit.name == "Player (2)")
            {
                
                bulletImage.color = Color.red;
                bulletTrail.startColor = Color.red;
            }
        }
        cooldown = .05f;
        //Debug.Log("adding force to bullet: " + angle + ", speed:" +  speed);


    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
     if(collision.gameObject.CompareTag("Wall") && !isCore)
        {
            Destroy(this.gameObject);
        }
        GlobalScreenShake.Instance.TriggerShake(0.01f, 0.01f);
    }

    public GameObject getLastHit() { return lastHit; }
}

