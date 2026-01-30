using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Vector2 dir;
    public float speed = 5f;
    public InputActionReference moveAction;
    [SerializeField] private Rigidbody2D rb;

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
    }
   
}
