using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    float deathTimer = 0f;
    float maxDeathTimer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("health: " + gameObject.GetComponent<PlayerController>().health);
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<PlayerController>().health <= 0){
            gameObject.layer = 20;
            deathTimer += Time.deltaTime;
            gameObject.GetComponent<PlayerController>().isDead = true;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,0f,0f, 0.7f);
            //gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
            gameObject.GetComponent<Animator>().Play("Player_Death");

            if(deathTimer > maxDeathTimer)
            {
                Destroy(gameObject);

                LevelManager.instance.Respawn();
            }
        }
    }
}
