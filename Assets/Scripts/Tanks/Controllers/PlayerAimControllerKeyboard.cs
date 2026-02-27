using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour, PlayerAimController
{
    [SerializeField] private GameObject Turret;
    [SerializeField] private float angleOffset; // New serialized field for angle offset
    private float speed;
    float lastAngle;

    public void Update()
    {
        // Early exit if Camera.main or Turret is not assigned
        if (Camera.main == null || Turret == null) return;

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 aimDir = (worldPos - (Vector2)Turret.transform.position).normalized;


        Vector2 dir = (worldPos - (Vector2)Turret.transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg;
        angle += 180;
        //Debug.Log(angle);
        Turret.transform.up = aimDir; // Set the turret's up direction to the aim direction
        speed = (angle - lastAngle) / Time.deltaTime;
        lastAngle = angle;
    }

    public float getSpeed()
    {
        return speed;
    }
}
