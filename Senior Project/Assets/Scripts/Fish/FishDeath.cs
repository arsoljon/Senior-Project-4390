using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDeath : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    Animator animator; 

    void Start()
    {
        Debug.Log("health: " + gameObject.GetComponent<FishHealth>().health);
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<FishHealth>().health <= 0){
            Vector2 position = gameObject.transform.position;
            position.y += 1;
            Instantiate(explosion, position, Quaternion.identity);
            explosion.SetActive(true);
            animator.Play("ExplodingFish");
            Destroy(gameObject);
        }
    }
}

