using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusOnObject : MonoBehaviour
{
    public GameObject objectToFocus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = objectToFocus.transform.position;
        gameObject.transform.position = new Vector3(newPos.x, newPos.y, gameObject.transform.position.z);
    }
}
