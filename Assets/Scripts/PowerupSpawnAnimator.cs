using UnityEngine;

public class PowerupSpawnAnimator : MonoBehaviour
{
    bool isAnimatingScale = true;
    bool isAnimatingRot = true;
    Vector3 currentScale = new Vector3(0f,0f,0f);
    Vector3 finalScale = new Vector3(1f,1f,1f);
    float currentRotation = -180f;
    float finalRotation = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.transform.localScale = currentScale;
        this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
    }

    // Update is called once per frame
    void Update()
    {
        if(isAnimatingScale || isAnimatingRot)
        {
            currentScale = Vector3.Lerp(currentScale, finalScale, 3f * Time.deltaTime);
            this.gameObject.transform.localScale = currentScale;
            if (this.gameObject.transform.localScale.x >= 0.98f)
            {
                this.gameObject.transform.localScale = finalScale;
                isAnimatingScale = false;
               // Debug.Log("Done animating scale");
            }

            
            currentRotation = Mathf.LerpAngle(currentRotation,finalRotation, 3f * Time.deltaTime);
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);

            if(currentRotation >= -1f)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, finalRotation);
                isAnimatingRot = false;
               // Debug.Log("Done animating rot");
            }
        }
    }
}
