using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wireNode : MonoBehaviour
{
    public static Vector3 cursorPos;
    public bool wireGrabbed = false;
    //public bool hold = false; 

    public bool inSocket = false;

    [SerializeField] Vector2 homeLocation;
    Vector2 socketTarget;

    // Start is called before the first frame update
    void Start()
    {
        homeLocation = transform.position;
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
        else
        {
            transform.position = socketTarget;
        }


        if (wireGrabbed == true)
        {
            //Debug.Log(Input.mousePosition);
            //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursorPos.z = 0f;
            transform.position = cursorPos;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        socketTarget = collision.gameObject.transform.position;
        inSocket = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inSocket = false;
    }

    public void toggleWireGrabbed()
    {
        wireGrabbed = !wireGrabbed;

 
    }
}
