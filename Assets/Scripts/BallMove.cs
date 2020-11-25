using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform currentTarget;
    Rigidbody rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Solid.TTBall==true)
        {
            rb = GetComponent<Rigidbody>();
            Move(currentTarget);

            
              
            
        }
    }

    void Move(Transform tt)
    {

        Vector3 newPos = Vector3.MoveTowards(transform.position, tt.position,1.5f * Time.deltaTime);
        
        rb.MovePosition(newPos);
    }
}
