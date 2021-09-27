using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire_Controller : MonoBehaviour
{

    public static Vector3 cursorPos;
    public bool wireGrabbed = false;
    //public bool hold = false; 

    public bool inSocket = false; 

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (inSocket == false)
        {
            
        }


        if (Input.GetButtonDown("Fire1"))
        {
            wireGrabbed = !wireGrabbed;
        }

        if(wireGrabbed == true)
        {
            //Debug.Log(Input.mousePosition);
            //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursorPos.z = -1f;

            transform.position = cursorPos;
        }

    }
}
