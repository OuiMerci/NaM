using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class TESTCanon : MonoBehaviour
{
    public bool keepSpawning = true;
    public float shootDelay;
    public int normalCountBeforeSpecial;
    public GameObject projectile;
    public GameObject specialProjectile;

    [ShowInInspector] [ReadOnly]
    private int currentCountBeforeSpecial;

    // Start is called before the first frame update
    void Start()
    {
        currentCountBeforeSpecial = normalCountBeforeSpecial;
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while(keepSpawning)
        {
            if(currentCountBeforeSpecial > 0)
            {
                SpawnProjectile(projectile);
                currentCountBeforeSpecial--;

                yield return new WaitForSeconds(shootDelay);
            }
            else
            {
                SpawnProjectile(specialProjectile);
                currentCountBeforeSpecial = normalCountBeforeSpecial; ;

                yield return new WaitForSeconds(shootDelay);
            }
        }
    }

    private void SpawnProjectile(GameObject prefab)
    {
        var projectile = GameObject.Instantiate(prefab, transform.position, Quaternion.identity, transform);
        projectile.transform.forward = transform.forward;
    }
}
