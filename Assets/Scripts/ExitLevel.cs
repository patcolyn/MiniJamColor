using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitLevel : MonoBehaviour
{
    private GameObject[] objs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objs = GameObject.FindGameObjectsWithTag("EndTriggers");
        foreach (GameObject endTrigger in objs)
        {
            if (!endTrigger.GetComponent<EndLevelTrigger>().getIsActivated()) {
                return;
            }
        }
        Debug.Log("ALL ACTIVE");
        SceneManager.LoadScene("EndLevelScreen"); //Load end level screen
    }
}
