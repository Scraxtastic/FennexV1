using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeLifeText : MonoBehaviour
{
    public GameObject player;
    public string lifeText = "Lifes: ";

    private int lifeCount = 5;
    private LifeSystem lifeSystem;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        lifeSystem = player.GetComponent<LifeSystem>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeSystem.lifes == lifeCount)
            return;
        lifeCount = lifeSystem.lifes;
        text.text = lifeText + lifeCount;
    }
}
