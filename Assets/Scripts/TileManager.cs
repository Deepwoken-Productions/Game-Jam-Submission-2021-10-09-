using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    // Start is called before the first frame update
    private ITile[,] tiles = new ITile[8,8];

    public Material CoinTileMat;
    public Material DefTileMat;
    public Material ConveyorMat;

    void Start()
    {
        tiles[0, 0] = new NullTile(false); // may be completely redundant, depends on how you do the snake.
        tiles[1, 0] = new CoinTile(CoinTileMat);
        if (tiles[0, 0] != null)
        {
            Debug.Log("exists");
        }
        tiles[0, 0].Create(new Vector3(0f, 20f, 0f));
        tiles[1, 0].Create(new Vector3(0f, 25f, 0f));

        Debug.Log("Tiles Spawned");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
