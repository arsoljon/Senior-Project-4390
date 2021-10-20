using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAirBar : MonoBehaviour
{
    //Use this in case we create a method to increase air. 
    public static UIAirBar instance {get; private set;}

    [SerializeField] Image mask;
    float originalSize;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
    }

    // Update is called once per frame
    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
