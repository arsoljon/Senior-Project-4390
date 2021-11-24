using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHud : MonoBehaviour
{

    [SerializeField] private UnityEvent OnExitKey;

    [SerializeField] private KeyCode exitMenuKey = KeyCode.Escape;
    
    private void Update()
    {
        if (Input.GetKeyDown(exitMenuKey))
        {   
            OnExitKey?.Invoke();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
