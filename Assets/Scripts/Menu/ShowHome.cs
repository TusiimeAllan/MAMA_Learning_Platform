using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHome : MonoBehaviour
{
    [SerializeField]
    public GameObject Home;

    // Start is called before the first frame update
    void Start()
    {
        Home.SetActive(true);
    }

}
