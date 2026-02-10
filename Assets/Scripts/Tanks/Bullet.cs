using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    float minSpeed;
    Rigidbody2D rb;
    float cooldown;
    [SerializeField]
    float maxSpeed = 20f;

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

    public void addForceToBullet(Vector3 angle, float speed)
    {
        if (cooldown < 0)
            rb.AddForce(angle * speed * 100);

        cooldown = .5f;
        //Debug.Log("adding force to bullet: " + angle + ", speed:" +  speed);
    }
}

