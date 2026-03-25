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
            this.rb.AddForce(angle * speed * 1);
            lastHit = hitter;
            
            ///// POWERUP FUNCTION spawn bullet
            //    if (hitter.gameObject.GetComponent<PlayerMovement>().getPower()==powerType.BULLETSPLIT &&isCore)
            //    {
            //           hitter.gameObject.GetComponent<PlayerMovement>().setPower(powerType.none);
            //         for (int i =0; i<4; i++)
            //        {
            //               Vector3 bulletLoc = this.transform.position;
            //        var newBullet = Instantiate(this.transform.root.gameObject,new Vector3(bulletLoc.x +5.5f, bulletLoc.y, bulletLoc.z),new Quaternion(0,0,0,0)); // spawn clone of bullet
            //            newBullet.GetComponent<Bullet>().isCore = false;
            //            newBullet.GetComponent<Bullet>().addSpeed(angle*2 , speed+ 2);
            //            newBullet.GetComponent<Bullet>().lastHit = hitter;


    
            //         }
                
            //    }

            if (!isCore)
            {
                if (lastHit.name == "Player")
                {
                    bulletImage.color = Color.cyan;

                    bulletTrail.startColor = Color.cyan;
                }
                else if (lastHit.name == "Player (2)")
                {

                    bulletImage.color = Color.orange;
                    bulletTrail.startColor = Color.orange;
                }
            }
            else
            {
                if (lastHit.name == "Player")
                {
                    bulletImage.color = Color.blue;

                    bulletTrail.startColor = Color.blue;
                }
                else if (lastHit.name == "Player (2)")
                {

                    bulletImage.color = Color.red;
                    bulletTrail.startColor = Color.red;
                }
            }
        }
        cooldown = .5f;
        //Debug.Log("adding force to bullet: " + angle + ", speed:" +  speed);


    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
     if( !isCore)
        {
           lifeTime-=1;
              if(lifeTime <= 0)
                {
                 Destroy(this.gameObject);
            }
        }
        GlobalScreenShake.Instance.TriggerShake(0.01f, 0.01f);
    }

    public GameObject getLastHit() { return lastHit; }

    public void resetHit()
    {
        bulletImage.color = new Color(0.6901961f, 0.5215687f, 0.654902f,1);

        bulletTrail.startColor = new Color(0.6901961f, 0.5215687f, 0.654902f, 1);

        lastHit = null;
    }
}

