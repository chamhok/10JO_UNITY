using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Moon : Item
{
    Vector2[] _offsets = { Vector2.up, Vector2.down, Vector2.right, Vector2.left };
    float _armLength = 1.0f;
    GameObject[] _satelite = new GameObject[4];
    int _index = 0;
    public float speed = 10.0f;

    private void Awake()
    {
        // �ڽ��� �� �� �� �� ��ġ�� �ν��Ͻ� ���� �� ����
        for (int i = 0; i < 4; ++i)
        {
            GameObject go_Moon = Instantiate(Resources.Load<GameObject>("Item/Moon"));
            go_Moon.transform.parent = this.transform;
            go_Moon.transform.localPosition = (Vector3)_offsets[i] * _armLength;
            _satelite[i] = go_Moon;
        }
                
        // ��� ��Ȱ��ȭ
        foreach(var go in _satelite)
        {
            go.SetActive(false);
        }
    }

    private void Update()
    {
        // ȸ�� 
        if (0 == _index) return;
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }

    public override void Upgrade()
    {
        _satelite[_index++].SetActive(true);
    }
}
