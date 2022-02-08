using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeNDate : MonoBehaviour
{
    private string theTime, theDate;

    [SerializeField]
    private TextMeshProUGUI timeText, dateText;
    

    // Update is called once per frame
    void Update()
    {
        timeText.text = System.DateTime.Now.ToString("hh:mm:ss tt");
        dateText.text = System.DateTime.Now.ToString("dddd, dd MMMM yyyy");
    }
}
