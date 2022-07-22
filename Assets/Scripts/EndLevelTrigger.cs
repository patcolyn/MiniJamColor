using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    [SerializeField]private Color requiredColor;
    private SpriteRenderer spriteRenderer;
    private bool isActivated = false;
    public int numberOfPlayersRequired = 1;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = requiredColor;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(numberOfPlayersRequired > 0) {
            var playerColor = new Color(0, 0, 0);
            if (collision && collision.GetComponentInChildren<SpriteRenderer>())
            {
                playerColor = collision.GetComponentInChildren<SpriteRenderer>().color;
            }

            if (playerColor == requiredColor)
            {
                numberOfPlayersRequired--;
                collision.transform.position = transform.position;
                collision.GetComponent<PlayerController>().EnteredFinish();
                collision.GetComponent<Animator>().SetBool("enteredTrigger",true);
                isActivated = true;
            }
        }
    }

    public bool getIsActivated()
    {
        return isActivated;
    }
}
