using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{

    public int lifes = 5;

    public void Die()
    {
        lifes--;
    }

    public void AddLife()
    {
        lifes++;
    }
}
