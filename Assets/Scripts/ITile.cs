using UnityEngine;

interface ITile
{
    void OnStep();
    void Push();

    void Create(Vector3 Location);
}
