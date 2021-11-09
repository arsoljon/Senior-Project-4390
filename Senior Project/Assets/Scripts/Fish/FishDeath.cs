using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDeath : MonoBehaviour
{
    float deathTimer = 0f;
    float maxDeathTimer = 3f;
    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Awake() 
    {
        deathTimer = 0f;
    }
    void Start()
    {
        deathTimer = 0f;
        Debug.Log("health: " + gameObject.GetComponent<FishHealth>().health);
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<FishHealth>().health <= 0){
            gameObject.layer = 20;
            gameObject.GetComponent<FishHealth>().isDead = true;
            renderer.color = new Color(1f,0f,0f, 0.7f);
            //gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            //gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
            //gameObject.GetComponent<Animator>().Play("Fish_Death");
            //Destroy(gameObject);
            deathTimer += Time.deltaTime;
            if(deathTimer >= maxDeathTimer)
            {
                gameObject.SetActive(false);
            }
        }
    }
}

