using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCannonController : MonoBehaviour
{
    public float CannonSpeed;

    // Start is called before the first frame update
    void Start()
    {
        CannonSpeed = 5f;
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.RightArrow));
        transform.root.position += Vector3.right * CannonSpeed;


    }
}
