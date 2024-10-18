using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class binladenmovement : MonoBehaviour
{
   public  float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0;

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX = speed * Time.deltaTime;
        }

        transform.Translate(moveX, 0, 0);
    }
}
