using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Stone : Item
{
    GameObject _stoneSpawnPosition;
    float _armLength = 1.0f;
    // ������

    // �ӵ� ?

    // 

    private void Awake()
    {
        _stoneSpawnPosition = new GameObject("StoneSpawnPosition");
        _stoneSpawnPosition.transform.parent = this.transform;
        _stoneSpawnPosition.transform.localPosition = Vector2.up * _armLength;
    }

    private void Start()
    {
        SpawnStone();
    }

    private void Update()
    {
        // PlayerInput ������.

    }

    public override void Upgrade()
    {
        
    }

    private void SpawnStone()
    {
        var go_Stone = Instantiate(Resources.Load<GameObject>("Item/Stone"), _stoneSpawnPosition.transform.position, Quaternion.identity);
    }
}
