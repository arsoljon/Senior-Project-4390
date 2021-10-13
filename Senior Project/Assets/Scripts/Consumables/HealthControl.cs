using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour
{
    //This class will control if the item will be seen. 
    public float timeToggle = 2;
    public float currentTime = 0;
    public bool enabled;
    HealthCollectible controller;

    void Start()
    {
        enabled = true;
    }

    void Update()
    {
        //while the image is being shown, check if it has been touched by the player. 
        if(enabled)
        {
            foreach(Transform child in gameObject.transform)
            {
                if(child.tag == "Food")
                {
                    HealthCollectible controller = child.GetComponent<HealthCollectible>();
                    if(controller.isGone){
                        enabled = !enabled;
                        child.gameObject.SetActive(enabled);
                    }
                }
            }
        }
        //If it is not being shown, make a countdown for the time gone.  
        else
        {
            currentTime += Time.deltaTime;
            if(currentTime >= timeToggle)
            {
                foreach(Transform child in gameObject.transform)
                {
                    if(child.tag == "Food")
                    {
                        HealthCollectible controller = child.GetComponent<HealthCollectible>();
                        enabled = !enabled;
                        child.gameObject.SetActive(enabled);
                        controller.ResetGone();
                        currentTime = 0;                    
                    }
                }
            }
        }
    }
}
