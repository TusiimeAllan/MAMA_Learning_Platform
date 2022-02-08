using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Repeat : MonoBehaviour
{

    private Button btn;
    /*public GameObject ButtonRef;
    private FallingNumAndImg BtnRef;*/

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        //BtnRef = ButtonRef.GetComponent<FallingNumAndImg>();
        btn.onClick.AddListener(repeat);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void repeat()
    {
        /*GameObject[] obj;
        for (int i = 1; i < BtnRef.count +1 ; i++)
        {
            obj = GameObject.FindGameObjectsWithTag(i.ToString());
            for (int x=0; x<obj.Length; x++)
            {
                Destroy(obj[x]);
            }
            
        }
        BtnRef.count = 0;*/
        SceneManager.LoadSceneAsync("Numbers");
    }
}
