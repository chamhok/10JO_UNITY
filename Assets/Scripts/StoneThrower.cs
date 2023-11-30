using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class StoneThrower : Item
{
    GameObject _stoneSpawnPosition;
    float _armLength = 1.0f;
    // ������
    Vector3 _shootingDirection;
    float _projectileSpeed = 1.0f;
    bool _bFire = false;
    float _fireDelay = 1.0f;

    private void Awake()
    {
        _stoneSpawnPosition = new GameObject("StoneSpawnPosition");
        _stoneSpawnPosition.transform.parent = this.transform;
        _stoneSpawnPosition.transform.localPosition = Vector2.right * _armLength;
    }

    private void Start()
    {
        StartCoroutine(IFire());
    }

    private void Update()
    {
        // PlayerInput ������.

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _shootingDirection = mousePosition - transform.position;
        _shootingDirection.z = 0;
        _shootingDirection.Normalize();
        transform.rotation = Quaternion.Euler(_shootingDirection);

        float rotZ = Mathf.Atan2(_shootingDirection.y, _shootingDirection.x) * Mathf.Rad2Deg;

        //armRenderer.flipY = Mathf.Abs(rotZ) > 90f;        
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    public override void Upgrade()
    {
        _bFire = true;
    }

    private void SpawnStone()
    {
        var go_Stone = Instantiate(Resources.Load<GameObject>("Item/Stone"), _stoneSpawnPosition.transform.position, transform.rotation);
        go_Stone.GetComponent<Projectile>().SetVelocity(_shootingDirection  * _projectileSpeed);
    }

    IEnumerator IFire()
    {
        while(_bFire)
        {
            yield return new WaitForSeconds(_fireDelay);
            SpawnStone();
        }
    }
}
