using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Again : MonoBehaviour
{
    FallingNumAndImg fall;
    private Button btn;
    int count;
    bool begin = true;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(again);
        fall = GameObject.Find("Next").GetComponent<FallingNumAndImg>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void again()
    {
        if(fall.begin && fall.count > 0)
            fall.Invoke("again",0);
    }

 
}
