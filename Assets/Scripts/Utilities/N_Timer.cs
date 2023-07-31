using System.Collections.Generic;
using UnityEngine;

public class N_Timer : MonoBehaviour
{
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(time + Time.deltaTime);
    }
}
