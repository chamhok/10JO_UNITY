using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Item : MonoBehaviour
{
    public int Lv
    {
        get;
        protected set;
    }

    public abstract void Upgrade();
}
