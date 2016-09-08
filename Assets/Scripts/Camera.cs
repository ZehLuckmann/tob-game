using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{

    public float interpVelocity;
    public float minDistance;
    public float maxDistance;
    public bool fixX;
    public bool fixY;
    public float followDistance;
    public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;
    // Use this for initialization
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
            targetPos = transform.position;

            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;
            Vector3 targetDirection = (target.transform.position - posNoZ);

            if (fixX)
                targetDirection.x = 0;
            if (fixY)
                targetDirection.y = 0;
            
            interpVelocity = targetDirection.magnitude * 5f;
            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);
            if ((targetPos.x >= minDistance && targetPos.x <= maxDistance) || (minDistance == 0 && maxDistance == 0))
                transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
        }
    }
}
