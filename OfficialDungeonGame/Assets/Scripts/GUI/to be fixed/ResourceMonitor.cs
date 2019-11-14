using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceMonitor : MonoBehaviour
{
    public TextMeshProUGUI Resources;
    public int number = 0;

    private void Start()
    {
        
    }

    private void Update()
    {
        Resources.text = number.ToString();
    }


}
