﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    public void SetText(string text) 
    {
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = text;
    
    }
}
