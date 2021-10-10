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

    private int upMovements;
    public int maxCoins;
    private int currentCoins = 0;

    private Vector2Int snakeCurrentPosition;
    private Vector2Int snakeNextPosition;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            GameObject.Destroy(gameObject);
        }

        tileArray = new GameObject[mapLength, mapWidth];

        PopulateMap();

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
                    if(currentCoins >= maxCoins)
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

                tileArray[i + mapLength/2, j + mapWidth/2] = newTile;
            }
        }
    }

    void GenerateMap()
    {
        upMovements = 0;

        snakeCurrentPosition = new Vector2Int(0, Mathf.RoundToInt(mapLength / 2));
        Destroy(tileArray[0, snakeCurrentPosition.y]);

        while (true)
        {
            int direction = Random.Range(0, 4);
            snakeNextPosition = Vector2Int.zero;

            if(direction == 0)
            {
                snakeNextPosition = snakeCurrentPosition + new Vector2Int(1, 0);
            }
            else if(direction == 1)
            {
                snakeNextPosition = snakeCurrentPosition + new Vector2Int(0, 1);
            }
            else if (direction == 2)
            {
                snakeNextPosition = snakeCurrentPosition + new Vector2Int(-1, 0);
            }
            else if (direction == 3)
            {
                snakeNextPosition = snakeCurrentPosition +  new Vector2Int(0, -1);
            }

            MoveIfPositionValid();

            if(upMovements >= 6)
            {
                break;
            }

             Destroy(tileArray[snakeCurrentPosition.x, snakeCurrentPosition.y]);

            if(tileArray[snakeCurrentPosition.x, snakeCurrentPosition.y])
            {
                tileArray[snakeCurrentPosition.x, snakeCurrentPosition.y].transform.name = "NullTile";
            }
        }
    }

    void MoveIfPositionValid()
    {
        if (snakeNextPosition.x <= tileArray.GetLength(0) - 1 && snakeNextPosition.x >= 0)
        {
            if (tileArray[snakeNextPosition.x, snakeCurrentPosition.y] != null && tileArray[snakeNextPosition.x, snakeCurrentPosition.y].transform.name != "NullTile")
            {
                if (snakeNextPosition.x > snakeCurrentPosition.x)
                {
                    upMovements++;
                }

                snakeCurrentPosition.x = snakeNextPosition.x;
            }
        }

        if (snakeNextPosition.y <= tileArray.GetLength(1) - 1 && snakeNextPosition.y >= 0)
        {
            if (tileArray[snakeCurrentPosition.x, snakeNextPosition.y] != null && tileArray[snakeCurrentPosition.x, snakeNextPosition.y].transform.name != "NullTile")
            {
                snakeCurrentPosition.y = snakeNextPosition.y;
            }
        }
    }
}
