using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyBallon : MonoBehaviour
{
    spawner sp;

    // Start is called before the first frame update
    void Start()
    {
        sp = GameObject.Find("Canvas").GetComponent<spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sp.stopBallon)
        {
            Destroy(this.gameObject);
        }
    }
}
