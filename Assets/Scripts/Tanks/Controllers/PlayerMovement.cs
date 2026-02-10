using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Vector2 dir;
    public float speed = 5f;
    public InputActionReference moveAction;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float rotationSpeed = 0f;
    public float tankSpeed = 0.0f;
    
    private float targetAngle;

    void Start()
    {

        this.rb = this.transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = moveAction.action.ReadValue<Vector2>();
     //   Debug.Log(dir);

        rb.AddForce(dir * speed);
        rotateBody();

        tankSpeed = rb.linearVelocity.magnitude;
    }

    private void rotateBody()
    {
        if (dir == Vector2.zero)
            return;
        // Do not rotate when moving backwards (negative Y)
      
        
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
           // Debug.Log(angle);
            float targetAngle = angle - 90f;
            float smoothedAngle = Mathf.LerpAngle(rb.rotation, targetAngle, rotationSpeed * Time.deltaTime);

            rb.rotation = smoothedAngle;
        
    }
}
