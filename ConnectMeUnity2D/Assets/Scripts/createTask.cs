using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createTask : MonoBehaviour
{
    [SerializeField] GameObject gameControllerObject;
    [SerializeField] GameObject taskPrefab;

    bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (started == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine("makeTask");
                started = true;
            }
        }
    }

    
    IEnumerator makeTask()
    {
        for (int i = 0; i < 15; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                if (gameControllerObject.GetComponent<gameController>().tempTasks[j] == null)
                {
                    GameObject newTask = Instantiate(taskPrefab, gameControllerObject.GetComponent<gameController>().taskLocations[j].transform.position, gameControllerObject.GetComponent<gameController>().taskLocations[j].transform.rotation);
                    gameControllerObject.GetComponent<gameController>().tempTasks[j] = newTask;
                    break;
                }
            }
            yield return new WaitForSeconds(10f);
        }
    }
}