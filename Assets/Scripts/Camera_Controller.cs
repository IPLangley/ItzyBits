using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    float lerpSpeed;
    public Transform target;
    Vector3 tempPosition;
    void Start()
    {
        lerpSpeed = 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target == null) return;
        tempPosition = target.position;
        tempPosition.z = -10;
        transform.position = Vector3.Lerp(transform.position, tempPosition, lerpSpeed * Time.deltaTime);

    }
}
