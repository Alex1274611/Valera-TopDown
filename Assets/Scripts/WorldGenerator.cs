using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [Header("Границы")]
    public Transform leftTop;
    public Transform rightTop;
    public Transform leftDown;
    public Transform rightDown;
    public GameObject tree;
    public GameObject stump2;
    public GameObject bush;
    public int treechance = 15;
    public int bushchance = 20;
    public int stump = 30;
    [Header("Блок")]
    public List<GameObject> sand;
    public List<GameObject> grass;
    public List<GameObject> water;
    public float step = 5;
    public float scale = 0.1f;

    public void Generate()
    {
        float width = rightTop.position.x - leftTop.position.x;
        float height = rightTop.position.y - rightDown.position.y;

        int CountX = Mathf.FloorToInt(width / step);
        int CountY = Mathf.FloorToInt(height / step);
        for(int x = 0; x < CountX; x++)
        {
            for(int y = 0; y < CountY; y++)
            {
                float CoordX = x * scale;
                float CoordY = y * scale;
                Vector2 spawnLocation = new Vector3(step/2, step/2) + leftDown.position + new Vector3(x * step, y * step, 0);

                float noise = Mathf.PerlinNoise(CoordX, CoordY);
                if(noise <= 0.3)
                {
                    int randN = Random.Range(0, water.Count - 1);
                    GameObject spawnBlock = Instantiate(water[randN],spawnLocation,Quaternion.identity);
                }
                else if (noise <= 0.4 && noise > 0.3)
                {
                    int randN = Random.Range(0, sand.Count - 1);
                    GameObject spawnBlock = Instantiate(sand[randN],spawnLocation,Quaternion.identity);
                }
                else
                {
                    int randN = Random.Range(0, grass.Count - 1);
                    GameObject spawnBlock = Instantiate(grass[randN],spawnLocation,Quaternion.identity);
                    int n = Random.Range(0,100);
                    if(n < treechance)
                    {
                        Instantiate(tree,spawnLocation,Quaternion.identity);
                    }
                    else if(n < bushchance)
                    {
                        Instantiate(bush,spawnLocation,Quaternion.identity);
                    }
                    else if(n < stump)
                    {
                        Instantiate(stump2,spawnLocation,Quaternion.identity);
                    }
                }
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
