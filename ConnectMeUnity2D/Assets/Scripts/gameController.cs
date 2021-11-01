using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public GameObject[] wires;
    public GameObject wireHolder;
    int wireCount;


    public GameObject[] sockets;
    public GameObject socketHolder;
    int socketCount;

    public GameObject[] tempTasks;
    public GameObject tempTaskHolder;
    int tempTaskCount;


    // Start is called before the first frame update
    void Start()
    {
        wireCount = wireHolder.transform.childCount;
        wires = new GameObject[wireCount];
        //auto populates the array with all the wires. 
        for (int i = 0; i < wireCount; i++)
        {
            wires[i] = wireHolder.transform.GetChild(i).gameObject;
        }

        socketCount = socketHolder.transform.childCount;
        sockets = new GameObject[socketCount];
        //auto populates the array with all the sockets. 
        for (int i = 0; i < socketCount; i++)
        {
            sockets[i] = socketHolder.transform.GetChild(i).gameObject;
            sockets[i].GetComponent<socketNode>().setTag(i);
        }

        tempTaskCount = tempTaskHolder.transform.childCount;
        tempTasks = new GameObject[tempTaskCount];
        //auto populates the array with all the tempTasks. 
        for (int i = 0; i < tempTaskCount; i++)
        {
            tempTasks[i] = tempTaskHolder.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < wireCount; i++)
        {
            if(wires[i].GetComponent<wireController>().getBothSocketsFilled() == true)
            {
                int[] tags = wires[i].GetComponent<wireController>().getTags();
                for (int j = 0; j < tempTaskCount; j++)
                {
                    int[] taskTags = tempTasks[i].GetComponent<taskInfo>().getTags();
                    if (tags[0] == taskTags[0] && tags[1] == taskTags[1])
                    {
                        //Debug.Log("Finished Task");
                    }
                    else if ( tags[1] == taskTags[0] && tags[0] == taskTags[1])
                    {
                        //Debug.Log("Finished Task");
                    }
                    else
                    {
                        //Debug.Log("Wrong Task");
                    }
                }
            }
        }
    }
}
