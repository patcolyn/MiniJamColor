using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ExitLevel : MonoBehaviour
{
    private GameObject[] endLevelTriggers;
    private GameObject[] menu;
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
        endLevelTriggers = GameObject.FindGameObjectsWithTag("EndTriggers");
        foreach (GameObject endTrigger in endLevelTriggers)
        {
            if (!endTrigger.GetComponent<EndLevelTrigger>().getIsActivated()) {
                return;
            }
        }
        Debug.Log("ALL ACTIVE");
        activateMenu();
    }

    private void activateMenu()
    {
        menu = GameObject.FindGameObjectsWithTag("Menu");
        foreach(GameObject menuElement in menu)
        {
            if(menuElement.name == "Canvas")
            {
                menuElement.transform.position = Vector3.zero;
                menuElement.GetComponent<Canvas>().enabled = true;
                menuElement.GetComponent<CanvasScaler>().enabled = true;
                menuElement.GetComponent<GraphicRaycaster>().enabled = true;
            } else
            {
                menuElement.GetComponent<EventSystem>().enabled = true;
                menuElement.GetComponent<StandaloneInputModule>().enabled = true;
            }
        }
    }
}
