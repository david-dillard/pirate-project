using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRaycast : MonoBehaviour
{
    public float interactDistance = 5f;
    public RaycastHit lookingAt;
    public Transform myCam;
    public bool inRange = false; //y/n if raycast is intersecting something



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(myCam.transform.position, myCam.transform.forward * interactDistance, Color.red);
        if (Physics.Raycast(myCam.transform.position, myCam.transform.forward, out lookingAt, interactDistance))
        {
            Debug.Log(lookingAt.transform.name);
            inRange = true;
        }
        else { inRange = false; }
    }
}
