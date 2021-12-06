using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taskInfo : MonoBehaviour
{

    [SerializeField] int[] tags = { -1, -1 };
    int callTime = 3;
    [SerializeField] bool callFinished = false;
    [SerializeField] GameObject textObject;
    [SerializeField] GameObject callTimeText;
    [SerializeField] GameObject square;
    public bool completedTask = false;
    bool started = false;
    GameObject gameManagerObject;

    // Might change this naming convention for the socket, it is such a hassle to update.
    string[] socketNameList = { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "A9", "A10", "A11", "A12",  "A13", "A14", "A15", "A16", "B9", "B10", "B11", "B12", "B13", "B14", "B15", "B16"};

    
    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
        callTimeText.GetComponent<TextMesh>().text = ("call time: " + callTime + " sec");
        // add check for if a slot is already taken by another task.
        // can only be overidden by an emergency call
        tags[0] = Random.Range(0, 32);
        bool invalidRan = true;
        while (invalidRan == true)
        {
            int ran2 = Random.Range(0, 32);
            if (tags[0] != ran2)
            {
                tags[1] = ran2;
                invalidRan = false;
            }
        }
        textObject.GetComponent<TextMesh>().text = (socketNameList[tags[0]] + " -> " + socketNameList[tags[1]]);
    }

    // Update is called once per frame
    void Update()
    {
        if (started == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine("TaskTimer");
                started = true;
            }
        }
        if (callTime == 0)
        {
            
                square.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (callTime < 0)
        {
            gameManagerObject.GetComponent<gameController>().IncrementScore(20);
            Destroy(gameObject);
        }
        
    }

    public int[] getTags()
    {
        return tags;
    }

    IEnumerator TaskTimer()
    {
        while (true)
        {
            if (completedTask == true)
            {
                callTime -= 1;
                callTimeText.GetComponent<TextMesh>().text = ("call time: " + callTime + " sec");
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
