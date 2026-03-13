using UnityEngine;
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

    GameObject lastHit;



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

    public void addForceToBullet(Vector3 angle, float speed, GameObject hitter)
    {
        if (cooldown < 0 )
        {
            rb.AddForce(angle * speed * 1);
            lastHit = hitter;
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
     
        GlobalScreenShake.Instance.TriggerShake(0.01f, 0.01f);
    }

    public GameObject getLastHit() { return lastHit; }
}

