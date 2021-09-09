using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBoost : MonoBehaviour
{
    public float radius = 1f;
    private void Start()
    {
        SphereCollider collider = gameObject.AddComponent<SphereCollider>();
        collider.center = Vector3.zero;
        collider.radius = radius;
        collider.isTrigger = true;
    }
}
