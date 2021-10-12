using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    //These variables will keep track if the item should be shown. 
    public bool isGone {get{return gone;}}
    bool gone;
    // Start is called before the first frame update
    void Start()
    {
        gone = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(gone == false)
        {
            PlayerController controller = other.GetComponent<PlayerController>();
            if (controller != null)
            {
                Debug.Log("Symbolic health increase!");
                /*
                //Make these inside of the PlayerController script. 
                if(controller.health  < controller.maxHealth)
                {
                    //Make this too. ChangeHealth function. 
                    controller.ChangeHealth(1);
                    gone = true;
                }
                */
            } 
        }
    }

    public void ResetGone()
    {
        gone = false;
    }
}
