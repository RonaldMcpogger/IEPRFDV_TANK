using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerAimController : MonoBehaviour
{
    Vector2 aimDir;
    Vector2 worldPos;
    [SerializeField] private GameObject Turret;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 
    // Update is called once per frame
    void Update()
    {
        this.worldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Debug.Log(this.worldPos);
        this.aimDir = (this.worldPos - (Vector2)Turret.transform.position).normalized;
        Turret.transform.up = this.aimDir;
    }
}
