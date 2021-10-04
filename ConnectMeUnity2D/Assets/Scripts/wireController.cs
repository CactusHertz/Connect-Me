using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wireController : MonoBehaviour
{
    private LineRenderer lineRend;

    [SerializeField] private GameObject WireStart;
    [SerializeField] private GameObject WireEnd;

    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 2;
    }
    // Update is called once per frame
    void Update()
    {
        lineRend.SetPosition(0, new Vector3(WireStart.transform.position.x, WireStart.transform.position.y, 0f));
        lineRend.SetPosition(1, new Vector3(WireEnd.transform.position.x, WireEnd.transform.position.y, 0f));
    }



    /*
    private LineRenderer lineRend;
    private Vector2 mousePos;
    private Vector2 startMousePos;

    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRend.SetPosition(0, new Vector3(startMousePos.x, startMousePos.y, 0f));
            lineRend.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0f));
            distance = (mousePos - startMousePos).magnitude;
            Debug.Log("distance is " + distance);

        }
    }*/
}
