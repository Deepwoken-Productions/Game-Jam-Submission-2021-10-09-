using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    //This is a singleton class uwu
    public static TileManager instance { get; private set; }

    public int mapLength;
    public int mapWidth;

    public Transform origin;

    public GameObject[,] tileArray;
    public List<GameObject> tilePrefabs;

    public int maxCoins;
    private int currentCoins = 0;

    private Vector2Int snakeCurrentPosition;
    private Vector2Int snakeNextPosition;
    bool loop = true;

    ITile prvTile = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        tileArray = new GameObject[mapLength, mapWidth];

        //PopulateMap();

        StartCoroutine("GenerateMap");
        //GenerateMap();
    }

    void PopulateMap()
    {
        for (int i = -mapLength / 2; i < mapLength / 2; i++)
        {
            for (int j = -mapWidth / 2; j < mapWidth / 2; j++)
            {
                ITile tilePrefab;

                ITile coinTile = new CoinTile(false);
                ITile defaultTile = new DefaultTile(false);

                int randomNumber = Random.Range(0, 2);

                if (randomNumber == 0)
                {
                    if (currentCoins >= maxCoins)
                    {
                        tilePrefab = defaultTile;
                    }
                    else
                    {
                        tilePrefab = coinTile;
                        currentCoins++;
                    }
                }
                else
                {
                    tilePrefab = defaultTile;
                }

                GameObject newTile = GameObject.Instantiate(tilePrefab.GetTile());
                newTile.transform.position = origin.position + new Vector3(origin.position.x, 0, origin.position.z) + new Vector3(i * newTile.transform.GetChild(0).localScale.x * 2, 0, j * newTile.transform.GetChild(0).localScale.z * 2);
                newTile.transform.parent = transform;

                tileArray[i + mapLength / 2, j + mapWidth / 2] = newTile;
            }
        }
    }

    GameObject tiles() 
    {
        ITile tile = null;
        if (prvTile == null || !prvTile.GetType().Equals(typeof(DefaultTile)))
        {
            tile = new DefaultTile(false);
        }
        else
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    Debug.Log("Def Made");
                    tile = new DefaultTile(false);
                    break;
                case 1:
                    Debug.Log("Coin Made");
                    tile = new CoinTile(false);
                    break;
                case 2:
                    Debug.Log("NullTile Made");
                    break;
            }
        }
        prvTile = tile;
        //if(!prvTile.GetType().Equals(typeof(NullTile)))
        GameObject newTile = GameObject.Instantiate(tile.GetTile());
        Debug.Log(snakeCurrentPosition);
        newTile.transform.position = origin.position + new Vector3(snakeCurrentPosition.y * 8, 0, snakeCurrentPosition.x * 8);
        Debug.Log(newTile.transform.position);
        newTile.transform.parent = transform;
        return newTile;
    }

    void GenerateMap()
    {
        snakeCurrentPosition = new Vector2Int(Random.Range(0, tileArray.GetLength(0)), 0);
        tileArray[snakeCurrentPosition.x, snakeCurrentPosition.y] = tiles();
        tileArray[snakeCurrentPosition.x, snakeCurrentPosition.y].layer = 6;
        Debug.Log("Beginning Map Gen");


        do
        {
            int direction = Random.Range(0, 3);
            snakeNextPosition = Vector2Int.zero;

            if (direction == 0)
            {
                snakeNextPosition = snakeCurrentPosition + new Vector2Int(1, 0);
            }
            else if (direction == 1)
            {
                snakeNextPosition = snakeCurrentPosition + new Vector2Int(0, 1);
            }
            else if (direction == 2)
            {
                snakeNextPosition = snakeCurrentPosition + new Vector2Int(-1, 0);
            }

            if (MoveIfPositionValid())
            {
                tileArray[snakeCurrentPosition.x, snakeCurrentPosition.y] = tiles();
                tileArray[snakeCurrentPosition.x, snakeCurrentPosition.y].layer = 6;
            }


            if (snakeCurrentPosition.y == tileArray.GetLength(1) -1)
            {
                Debug.Log("Snake has reached the end");
                loop = false;
            }
        }
        while (loop);
    }

    bool MoveIfPositionValid()
    {
        if (snakeNextPosition.x <= tileArray.GetLength(0) - 1 && snakeNextPosition.x >= 0)
        {
            if (tileArray[snakeNextPosition.x, snakeCurrentPosition.y] == null)
            {
                
                snakeCurrentPosition.x = snakeNextPosition.x;

                Debug.Log("Moved on x");
                return true;
            }
        }

        if (snakeNextPosition.y <= tileArray.GetLength(1) - 1 && snakeNextPosition.y >= 0)
        {
            if (tileArray[snakeCurrentPosition.x, snakeNextPosition.y] == null)
            {
                snakeCurrentPosition.y = snakeNextPosition.y;
                Debug.Log("Moved on y");
                return true;
            }
        }
        return false;
    }
}
