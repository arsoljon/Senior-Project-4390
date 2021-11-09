using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    [SerializeField]PolygonCollider2D fishSpawnArea; 
    [SerializeField]GameObject[] listOfFish;
    [SerializeField]int FishCount; 
    int index; 

    //GameObject _container = GameObject.Find("FishSpawnArea");

    // Start is called before the first frame update
    void Start()
    {
        if (fishSpawnArea == null) GetComponent<PolygonCollider2D>();
        if (fishSpawnArea == null) Debug.Log("Please assign PolygonCollider2D component.");
        index = 0; 

        for(int i = 0; i < FishCount; i++)
        {
            randomizeStartPosition(listOfFish[index]);
            index += 1; 
            if(index > (listOfFish.Length - 1))
            {
                index = 0;
            }
        }
    }
 

    public void randomizeStartPosition(GameObject child)
    {
        Vector3 rndPoint3D = RandomPointInBounds(fishSpawnArea.bounds, 1f);
        Vector2 rndPoint2D = new Vector2(rndPoint3D.x, rndPoint3D.y);
        Vector2 rndPointInside = fishSpawnArea.ClosestPoint(new Vector2(rndPoint2D.x, rndPoint2D.y));
        if (rndPointInside.x == rndPoint2D.x && rndPointInside.y == rndPoint2D.y)
        {
            //GameObject rndCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //rndCube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            //rndCube.transform.position = rndPoint2D;
            Instantiate(child, rndPoint2D , Quaternion.identity);
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
