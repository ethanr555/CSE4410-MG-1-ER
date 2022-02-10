using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float x, y;
    public KeyCode upKey, downKey;
    public float speed;
    // Start is called before the first frame update

    Rigidbody2D myRigidbody;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        int direction = 0;
        if (Input.GetKey(upKey))
        {
            direction = direction + 1;
        }
        if (Input.GetKey(downKey))
        {
            direction = direction - 1;
        }
        myRigidbody.AddForce(new Vector2(0, 0.1f * direction * speed * Time.deltaTime));
        //transform.position += new Vector3(x * speed * Time.deltaTime, y * speed * Time.deltaTime, 0);
    }
}
