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
    int taskCount;

    public GameObject[] taskLocations;
    public GameObject taskLocationHolder;
    int taskLocationCount;
    




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
        taskCount = 5;
        tempTasks = new GameObject[5];
        //auto populates the array with all the tempTasks. 
        for (int i = 0; i < tempTaskCount; i++)
        {

           // Debug.Log("Test");
            //if (tempTaskHolder.transform.GetChild(i).gameObject != null)
           // {
                tempTasks[i] = tempTaskHolder.transform.GetChild(i).gameObject;
           // }
        }

        //taskLocationCount = taskLocationHolder.transform.childCount;
        taskLocationCount = 5;
        taskLocations = new GameObject[taskLocationCount];
        //auto populates the array with all the tempTasks. 
        for (int i = 0; i < taskLocationCount; i++)
        {
            taskLocations[i] = taskLocationHolder.transform.GetChild(i).gameObject;
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
                for (int j = 0; j < taskCount; j++)
                {
                    if (tempTasks[j] != null) {
                        int[] taskTags = tempTasks[j].GetComponent<taskInfo>().getTags();

                        if (tags[0] == taskTags[0] && tags[1] == taskTags[1])
                        {
                            Debug.Log("Finished Task");
                            tempTasks[j].GetComponent<taskInfo>().completedTask = true;
                        }

                        else if (tags[1] == taskTags[0] && tags[0] == taskTags[1])
                        {
                            Debug.Log("Finished Task");
                            tempTasks[j].GetComponent<taskInfo>().completedTask = true;
                        }
                        else
                        {
                            tempTasks[j].GetComponent<taskInfo>().completedTask = false;
                            //Debug.Log("not a Task");
                        }
                    }
                }
            }
        }


    }


   
}
