using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerAimController2 : MonoBehaviour, PlayerAimController
{
    [SerializeField] private GameObject Turret;
    [SerializeField] private float angleOffset; // New serialized field for angle offset
    private float speed;
    float lastAngle;

    [SerializeField] private InputActionAsset controls;
    private InputAction turretAction;
    [SerializeField] private string mapName;
    private void Start()
    {
        turretAction = controls.FindActionMap(mapName).FindAction("Aim");
        turretAction.Enable();
    }

    public void Update()
    {
        //Debug.Log(turretAction.ReadValue<Vector2>());
        // Early exit if Camera.main or Turret is not assigned
        if (Camera.main == null || Turret == null) return;

        if (turretAction.ReadValue<Vector2>() == Vector2.zero)
            return;
        // Do not rotate when moving backwards (negative Y)

       Vector2 dir = turretAction.ReadValue<Vector2>();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Debug.Log(angle);

        angle += 180;
        Turret.transform.up = dir;
        speed = (angle- lastAngle)/Time.deltaTime;
        lastAngle = angle;
    }

    public float getSpeed()
    {
               return speed;
    }
}
