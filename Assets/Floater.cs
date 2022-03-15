using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public GameObject FloaterObj;

    Vector3 velocity;
    public float ypos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update(){

        ypos = FloaterObj.GetComponent<Transform>().position.y;

       
        velocity = (997f * -9.81f * ypos * transform.up);
        //force = 997f * -9.81f * ypos * transform.up;
        

        FloaterObj.GetComponent<Rigidbody>().AddForce(velocity, ForceMode.Force);
    }
}