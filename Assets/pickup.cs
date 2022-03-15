using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public cameraRaycast raycastScript;
    //public pickupable pickupableScript;
    public RaycastHit lookingAt2;
    public Transform holdingPosition;
    public bool holdingAnItem = false;
    public GameObject heldItem; 



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookingAt2 = raycastScript.lookingAt;
        if (raycastScript.inRange)
        {
            if(Input.GetKey(KeyCode.F) && !holdingAnItem)
            {
                
                lookingAt2.collider.GetComponent<Rigidbody>().isKinematic = true;
                lookingAt2.collider.GetComponent<Rigidbody>().freezeRotation = true;
                lookingAt2.collider.GetComponent<Rigidbody>().useGravity = false;
                lookingAt2.transform.position = holdingPosition.position;
                lookingAt2.transform.parent = GameObject.Find("holdingPosition").transform;

                heldItem = lookingAt2.collider.gameObject;
                holdingAnItem = true;
            }
            Debug.Log("Can pick up " + lookingAt2.transform.name);
        }
        if(holdingAnItem && Input.GetKey(KeyCode.X))
        {
            heldItem.GetComponent<Rigidbody>().isKinematic = false;
            heldItem.GetComponent<Rigidbody>().freezeRotation = false;
            heldItem.GetComponent<Rigidbody>().useGravity = true;
            heldItem.transform.parent = null;
            heldItem = null;

            holdingAnItem = false;
        }

    }

    /*
     lookingAt2.collider.GetComponent<Rigidbody>().isKinematic = false;
            lookingAt2.collider.GetComponent<Rigidbody>().freezeRotation = false;
            lookingAt2.collider.GetComponent<Rigidbody>().useGravity = true;
            lookingAt2.transform.parent = null;
     */
}
