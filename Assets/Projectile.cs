using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed;
    public float LifeTime;
    // Add movement component later : the component defines the projectile's path

    void Update()
    {
        UpdateLifeTime();
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        transform.position += transform.forward * (Speed * Time.deltaTime);
    }

    private void UpdateLifeTime()
    {
        LifeTime -= Time.deltaTime;
        CheckLifeTime();
    }

    private void CheckLifeTime()
    {
        if(LifeTime < 0)
        {
            GameObject.Destroy(gameObject); // use pooling system
        }
    }
}
