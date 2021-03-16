using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    public float xSpeed;
    public float maxForce;
    public float minForce;

    float quarterMaxForce;
    Rigidbody rb;
    Vector3 mov;
    public float zForce;
    bool increaseForce = false;
    Vector3 force;
    bool disableInput = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mov = new Vector3(xSpeed, 0, 0);
        quarterMaxForce = maxForce / 2;
        zForce = minForce;
    }

    // Update is called once per frame
    void Update()
    {
        //INPUT
        //=======================================================================
        if (!disableInput)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                increaseForce = true;
                disableInput = true;
            }

            if (Input.GetKey(KeyCode.A))
                transform.position -= mov * Time.deltaTime;
            if (Input.GetKey(KeyCode.D))
                transform.position += mov * Time.deltaTime;
        }
        else
        {
            //FORCE
            //=======================================================================
            if (minForce == maxForce)
            {
                zForce = maxForce;
            }
            else
            {
                if (increaseForce)
                {
                    zForce += quarterMaxForce * Time.deltaTime;

                    if (zForce >= maxForce)
                        increaseForce = false;
                }
                else
                {
                    zForce -= quarterMaxForce * Time.deltaTime;

                    if (zForce <= minForce)
                        increaseForce = true;

                }
            }
            //=======================================================================

            if (Input.GetKeyDown(KeyCode.Space))
            {
                force = new Vector3(0, 0, zForce);
                rb.AddForce(force, ForceMode.Impulse);
            }
        }
        //=======================================================================
    }
}
