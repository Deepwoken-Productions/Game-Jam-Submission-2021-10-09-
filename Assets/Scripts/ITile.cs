using UnityEngine;

public interface ITile
{
    GameObject GetTile();
    void OnStep();
    void Push();
}
