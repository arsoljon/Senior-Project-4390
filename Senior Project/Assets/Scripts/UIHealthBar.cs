using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    //Next line makes a static variable of the current health class so it can be accessed with something like:
    // UIHealthBar.SetValue(currentHealth / (float)maxHealth) from anywhere in the project. However, it is only needed in the main character script. 
    //Similar to Debug.Log() and Time.deltaTime. 
    public static UIHealthBar instance {get; private set;}
    public Image mask;
    float originalSize;

    void Awake() 
    {
        //Initialize the static instance of this class. 
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //Save the current width of the health bar. 
        originalSize = mask.rectTransform.rect.width;
    }

    // Update is called once per frame
    public void SetValue(float value)
    {
        //change the size of the health with the given 'value'.
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
