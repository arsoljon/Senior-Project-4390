using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    public PlayerController player;
    [SerializeField]PolygonCollider2D fishSpawnArea; 
    float distanceAway;
    float _origin;


    // Start is called before the first frame update
    void Start()
    {
        if (fishSpawnArea == null) GetComponent<PolygonCollider2D>();
        if (fishSpawnArea == null) Debug.Log("Please assign PolygonCollider2D component.");
        foreach(Transform child in gameObject.transform)
        {
            if(child.tag == "Fish")
            {
                //child.transform.position = ChangePosition(child.transform.position, child.GetComponent<FishController>().freq, child.GetComponent<FishController>().amps, child.GetComponent<FishController>().speed);
                randomizeStartPosition(child);
            }
        }
        distanceAway = 10.0f;

        Debug.Log("fishSpawnArea: " + fishSpawnArea.points); 
 
    }


    // Update is called once per frame
    void Update()
    {
        foreach(Transform child in gameObject.transform)
            {
                if(child.tag == "Fish")
                {
                    if(child.transform.position.x > (player.transform.position.x + distanceAway))
                    {
                        child.GetComponent<FishController>()._speed = -child.GetComponent<FishController>()._speed; 
                        //child.transform.position = ChangePosition(child.transform.position, child.GetComponent<FishController>().freq, child.GetComponent<FishController>().amps, child.GetComponent<FishController>().speed);
                    }
                }
            }
    }

    Vector2 ChangePosition(Vector2 position, float _frequency, float _amplitude, float speed)
    {
        position.x = position.x + speed * Time.deltaTime;
        //Make the sin wave inconsistently go up and down. 
        position.y = Mathf.Sin(Time.time * _frequency) * _amplitude;
        return position;
    }
 

    void randomizeStartPosition(Transform child)
    {
        Vector3 rndPoint3D = RandomPointInBounds(fishSpawnArea.bounds, 1f);
        Vector2 rndPoint2D = new Vector2(rndPoint3D.x, rndPoint3D.y);
        Vector2 rndPointInside = fishSpawnArea.ClosestPoint(new Vector2(rndPoint2D.x, rndPoint2D.y));
        if (rndPointInside.x == rndPoint2D.x && rndPointInside.y == rndPoint2D.y)
        {
            GameObject rndCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            rndCube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            rndCube.transform.position = rndPoint2D;
            child.transform.position = rndPoint2D;
        }
    }

    private Vector3 RandomPointInBounds(Bounds bounds, float scale)
    {
        return new Vector3(
            Random.Range(bounds.min.x * scale, bounds.max.x * scale),
            Random.Range(bounds.min.y * scale, bounds.max.y * scale),
            Random.Range(bounds.min.z * scale, bounds.max.z * scale)
        );
    }
    
}
