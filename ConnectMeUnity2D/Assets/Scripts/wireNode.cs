using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wireNode : MonoBehaviour
{
    public static Vector3 cursorPos;
    public bool wireGrabbed = false;
    //public bool hold = false; 

    public bool inSocket = false;

    public Vector2 homeLocation = new Vector2(0f, 0f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (inSocket == false)
        {
            if (wireGrabbed == false)
            {
                transform.position = homeLocation;
            }
        }


        if (wireGrabbed == true)
        {
            //Debug.Log(Input.mousePosition);
            //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursorPos.z = -1f;

            transform.position = cursorPos;
        }

    }

    public void toggleWireGrabbed()
    {
        wireGrabbed = !wireGrabbed;
    }
}
