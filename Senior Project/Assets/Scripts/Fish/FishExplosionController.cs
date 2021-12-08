using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishExplosionController : MonoBehaviour
{
    float _destroyTimer; 
    float _maxTimer;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Parent = GameObject.Find("FishSpawnArea");
        transform.parent = Parent.transform;
        _destroyTimer = 0f; 
        _maxTimer = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        _destroyTimer += Time.deltaTime;
        if(_destroyTimer >= _maxTimer)
            Destroy(gameObject);
    }
}
