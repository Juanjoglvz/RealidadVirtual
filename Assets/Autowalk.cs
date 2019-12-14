using UnityEngine;
using System.Collections;




public class Autowalk : MonoBehaviour
{
    private const int RIGHT_ANGLE = 120;

    // This variable determinates if the player will move or not 
    private bool isWalking = false;

    Transform mainCamera = null;

    //This is the variable for the player speed
    public float speed;
    
    
    public bool walkWhenLookDown;
    
    public double thresholdAngle;
    
    public bool freezeYPosition;
    
    public float yOffset;

    void Start()
    {
        mainCamera = Camera.main.transform;
    }

    void Update()
    {
        // Walk when player looks below the threshold angle 
        if (walkWhenLookDown && !isWalking &&
            mainCamera.transform.eulerAngles.x >= thresholdAngle &&
            mainCamera.transform.eulerAngles.x <= RIGHT_ANGLE)
        {
            isWalking = true;
        }
        else if (walkWhenLookDown && isWalking &&
            (mainCamera.transform.eulerAngles.x <= thresholdAngle ||
                mainCamera.transform.eulerAngles.x >= RIGHT_ANGLE))
        {
            isWalking = false;
        }
        

        if (isWalking)
        {
            Vector3 direction = new Vector3(mainCamera.transform.forward.x, 0, mainCamera.transform.forward.z).normalized * speed * Time.deltaTime;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
            transform.Translate(rotation * direction);
        }

        if (freezeYPosition)
        {
            transform.position = new Vector3(transform.position.x, yOffset, transform.position.z);
        }
    }

}
