using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Vector2 dir;
    public float speed = 5f;
    public float maxSpeed = 15f;
    public InputActionReference moveAction;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool slide = false;

    private int countdown = 0;
    [SerializeField] private int maxCountdown = 2; //in seconds

    void Start()
    {
        
        this.rb = this.transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = moveAction.action.ReadValue<Vector2>();
        Debug.Log(dir);
        rb.AddForce(dir * speed);

        if(rb.linearVelocity.sqrMagnitude > maxSpeed) //limits the tanks speed
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }

        if(dir == Vector2.zero && slide == false) //slows down tank after player stops their inputs
        {
            rb.linearVelocity = rb.linearVelocity.normalized;
        }

        if (rb.linearVelocity.sqrMagnitude == 1) //stops the tank after "maxCountdown" seconds have passed
        {
            countdown++;
            if (countdown >= maxCountdown * 60)
            {
                rb.linearVelocity *= 0;
            }
        }
        else
            countdown = 0;
    }
   
}
