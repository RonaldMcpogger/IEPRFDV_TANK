using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerAimController : MonoBehaviour
{
    [SerializeField] private GameObject Turret;
    [SerializeField] private float angleOffset; // New serialized field for angle offset
 

    void Update()
    {
        // Early exit if Camera.main or Turret is not assigned
        if (Camera.main == null || Turret == null) return;

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 aimDir = (worldPos - (Vector2)Turret.transform.position).normalized;

        Turret.transform.up = aimDir; // Set the turret's up direction to the aim direction

    }
}
