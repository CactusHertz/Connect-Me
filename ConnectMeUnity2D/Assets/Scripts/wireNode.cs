using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wireNode : MonoBehaviour
{
    public static Vector3 cursorPos;
    [SerializeField] bool wireGrabbed = false;
    [SerializeField] bool overSocket = false;
    [SerializeField] private bool inSocket = false;

    [SerializeField] Vector2 homeLocation;
    GameObject socketTarget;

    // Start is called before the first frame update
    void Start()
    {
        homeLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (inSocket == true)
        {
            transform.position = socketTarget.transform.position;
        }
        else
        {
            transform.position = homeLocation;
        }
        if (wireGrabbed == true)
        {
            inSocket = false;
            cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursorPos.z = -1f;
            if (cursorPos.x < -9)
            {
                cursorPos.x = -9;
            }
            if (cursorPos.x > 9)
            {
                cursorPos.x = 9;
            }
            if (cursorPos.y < -5)
            {
                cursorPos.y = -5;
            }
            if (cursorPos.y > 5)
            {
                cursorPos.y = 5;
            }
            transform.position = cursorPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.GetComponent<socketNode>() != null)
        {
            socketTarget = collision.gameObject;
            overSocket = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        overSocket = false;
    }

    public void toggleWireGrabbed()
    {
        wireGrabbed = !wireGrabbed;
        if(overSocket == true)
        {
            inSocket = true;
        }
        else
        {
            inSocket = false;
        }
    }

    public GameObject getSocket()
    {
        return socketTarget;
    }

    public bool getInSocket()
    {
        return inSocket;
    }
    public void goHome()
    {
        inSocket = false;
        transform.position = homeLocation;
    }

}
