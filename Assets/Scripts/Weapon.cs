using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected CircleCollider2D WeaponCollider
    {
        get;
        private set;
    }

    protected float Damage
    {
        get;
        set;
    }


    private void Awake()
    {
        WeaponCollider = gameObject.AddComponent<CircleCollider2D>();
        WeaponCollider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if( collision.gameObject.tag.Compare() )

    }
}
