using UnityEngine;

public class TurretHitbox : MonoBehaviour
{
    [SerializeField] private GameObject PMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("entered turret hitbox");
        if (other.CompareTag("Bullet"))
        {
            //Debug.Log(other.gameObject.name);
            float speed = GetComponentInParent<PlayerAimController>().getSpeed() + PMovement.GetComponent<PlayerMovement>().tankSpeed;


            other.gameObject.GetComponent<Bullet>().addForceToBullet(transform.right + transform.up, speed, this.transform.root.gameObject);


            Debug.Log(this.transform.root.name+" "+speed);
        }
    }
}
