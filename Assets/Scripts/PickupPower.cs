using UnityEngine;

public class PickupPower : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] powerType powerup;

    void Start()
    {
        // change once we have idea of other powerups  make it upon generation random powerup type
        powerup = powerType.BULLETSPLIT;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            other.GetComponent<PlayerMovement>().setPower(this.powerup);

        }
    }
}
