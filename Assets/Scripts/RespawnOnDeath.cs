using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LifeSystem))]
public class RespawnOnDeath : MonoBehaviour
{
    public float deathY = -10;

    private LifeSystem lifeSystem;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        lifeSystem = GetComponent<LifeSystem>();
        startPosition = gameObject.transform.position;
    }

    private void Update()
    {
        if (gameObject.transform.position.y > deathY)
            return;
    }

    public void Respawn()
    {
        gameObject.transform.position = startPosition;
        lifeSystem.Die();
    }
}
