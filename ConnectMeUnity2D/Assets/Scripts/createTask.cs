using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createTask : MonoBehaviour
{
    [SerializeField] GameObject gameControllerObject;
    [SerializeField] GameObject taskPrefab;

    bool started = false;
    [SerializeField] float taskDelay = 5f;

    GameObject gameManagerObject;
    gameController GCscript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
        GCscript = gameManagerObject.GetComponent<gameController>();
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
        yield return new WaitForSeconds(3);
        while (GCscript.countdownValue >=0) { 
            for(int j = 0; j < 5; j++)
            {
                if (gameControllerObject.GetComponent<gameController>().tempTasks[j] == null)
                {
                    GameObject newTask = Instantiate(taskPrefab, gameControllerObject.GetComponent<gameController>().taskLocations[j].transform.position, gameControllerObject.GetComponent<gameController>().taskLocations[j].transform.rotation);
                    gameControllerObject.GetComponent<gameController>().tempTasks[j] = newTask;
                    break;
                  
                }
            }
            yield return new WaitForSeconds(taskDelay);
        }
    }
}
