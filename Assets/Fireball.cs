using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Fireball : MonoBehaviour
{
    float speed = 5.0f;
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("COLLISION STAY");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLLISION : " + collision.gameObject);
        if (collision.gameObject.layer == 9)
        {
            Debug.Log("COLLISION");
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
