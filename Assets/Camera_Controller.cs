using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{

    public GameObject follow;
    public float maxX;
    public float minX;
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xVal = follow.transform.position.x;

        xVal = Mathf.Min(maxX, xVal);
        xVal = Mathf.Max(minX, xVal);
        transform.position = new Vector3(xVal, transform.position.y, transform.position.z);
    }
}
