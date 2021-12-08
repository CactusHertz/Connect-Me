using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class taskInfo : MonoBehaviour
{

    [SerializeField] int[] tags = { -1, -1 };
    int callTime = 3;
    int pointValue = 20;
    bool callFinished = false;
    [SerializeField] GameObject textObject;
    [SerializeField] GameObject callTimeText;
    [SerializeField] GameObject square;
    [SerializeField] GameObject timeSquare;
    public bool completedTask = false;

    GameObject gameManagerObject;
    gameController GCscript;

    private bool hasLimit = false;
    private float xScaleFactor = 0.0f;
    private bool startingBoolTask = false;

    // Might change this naming convention for the sockets, it is a hassle to update.
    string[] socketNameList = { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "A9", "A10", "A11", "A12",  "A13", "A14", "A15", "A16", "B9", "B10", "B11", "B12", "B13", "B14", "B15", "B16"};
    bool[] hasLimitList = {false, true, true };
    float[] xScaleFactorList = {0.0f, 0.001f, 0.0018f};


    // Start is called before the first frame update
    void Start()
    {
        callTime = Random.Range(2, 4);
        gameManagerObject = GameObject.Find("GameManager");
        GCscript = gameManagerObject.GetComponent<gameController>();
        callTimeText.GetComponent<TextMesh>().text = ("call time: " + callTime + " sec");

        // can only be overidden by an emergency call
        int ran1 = -1;
        bool validRan1 = false;
        while (!validRan1)
        {
            validRan1 = true;
            ran1 = Random.Range(0, 32);
            for (int t = 0; t < GCscript.tempTasks.Length; t++)
            {
                if (GCscript.tempTasks[t] != null)
                {
                    if (GCscript.tempTasks[t].GetComponent<taskInfo>().tags[0] == ran1 || GCscript.tempTasks[t].GetComponent<taskInfo>().tags[1] == ran1)
                    {
                        validRan1 = false;
                    }
                }
            }
        }
        tags[0] = ran1;

        int ran2 = -1;
        bool validRan2 = false;
        while (!validRan2)
        {
            validRan2 = true;
            ran2 = Random.Range(0, 32);
            for (int t = 0; t < GCscript.tempTasks.Length; t++)
            {
                if (GCscript.tempTasks[t] != null)
                {
                    if (GCscript.tempTasks[t].GetComponent<taskInfo>().tags[0] == ran2 && GCscript.tempTasks[t].GetComponent<taskInfo>().tags[1] != ran2 && ran1 != ran2)
                    {
                        validRan2 = false;
                    }
                }
                if (tags[0] == ran2)
                {
                    validRan2 = false;
                }
            }
        }
        tags[1] = ran2;

        // labels the task object with the correct ends 
        textObject.GetComponent<TextMesh>().text = (socketNameList[tags[0]] + " -> " + socketNameList[tags[1]]);
        xScaleFactor = xScaleFactorList[SceneManager.GetActiveScene().buildIndex-1];
        hasLimit = hasLimitList[SceneManager.GetActiveScene().buildIndex-1];
    }

    // Update is called once per frame
    void Update()
    {
        callTimeText.GetComponent<TextMesh>().text = ("call time: " + callTime + " sec");
        if (callTime == 0)
        {
                square.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (callTime < 0)
        {
            gameManagerObject.GetComponent<gameController>().IncrementScore(pointValue);
            Destroy(gameObject);
        }
        if (hasLimit == true)
        {
            timeSquare.SetActive(true);
            if (startingBoolTask == false)
            {
                if (gameManagerObject.GetComponent<gameController>().startingBool)
                {
                    StartCoroutine(TaskTimeLimit());
                    startingBoolTask = true;
                }
            }
        }
    }

    public int[] getTags()
    {
        return tags;
    }

    public void decrementTime()
    {
        callTime--;
    }
    IEnumerator TaskTimeLimit()
    {
        while (timeSquare.transform.localScale.x >= 0)
        {

            if (timeSquare.transform.localScale.x < 0.5)
            {
                timeSquare.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if (timeSquare.transform.localScale.x < 1.5)
            {
                timeSquare.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            

            Vector3 scaleChange = new Vector3(-xScaleFactor, 0.0f, 0.0f);
            timeSquare.transform.localScale += scaleChange;
            
            yield return new WaitForSeconds(0.01f);

        }
        if (GCscript.countdownValue >= 0)
        {
            gameManagerObject.GetComponent<gameController>().IncrementScore(pointValue / 4);
        }
        Destroy(gameObject);
    }
}
