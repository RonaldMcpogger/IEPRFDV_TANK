using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionAsset controls;
    [SerializeField] private string mapName;
    Vector2 dir;
    public float speed = 5f;
    private InputAction moveAction;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float rotationSpeed = 0f;
    public float tankSpeed = 0.0f;

    private float targetAngle;
    [SerializeField] private int teamCode;

    void Start()
    {
        moveAction = controls.FindActionMap(mapName).FindAction("Move");
        this.rb = this.transform.GetComponent<Rigidbody2D>();

        if (Gamepad.current != null)
            Debug.Log("Connected");
        else Debug.Log("Error: No Gamepad");

        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        dir = moveAction.ReadValue<Vector2>();
        //  Debug.Log(this.gameObject.name + dir);
        dir.Normalize();
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

    private void OnEnable()
    {
      //  moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    public int getTeamCode()
    {
        return teamCode;
    }
}
