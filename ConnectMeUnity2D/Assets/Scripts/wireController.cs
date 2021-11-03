using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wireController : MonoBehaviour
{
    private LineRenderer lineRend;

    [SerializeField] int[] tags = {-1,-1};
    [SerializeField] private GameObject WireStart;
    [SerializeField] private GameObject WireEnd;

    private bool bothSocketsFilled = false;

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


        if(WireStart.GetComponent<wireNode>().getInSocket() == true && WireEnd.GetComponent<wireNode>().getInSocket() == true)
        {
            tags[0] = WireStart.GetComponent<wireNode>().getSocket().GetComponent<socketNode>().getTag();
            tags[1] = WireEnd.GetComponent<wireNode>().getSocket().GetComponent<socketNode>().getTag();
            bothSocketsFilled = true;
        }
        else
        {
            bothSocketsFilled = false;
        }

    }
   

    public int[] getTags()
    {
        return tags;
    }

    public bool getBothSocketsFilled()
    {
        return bothSocketsFilled;
    }

}
