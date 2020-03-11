/*
This program can change UI text 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public sealed class DisplayFEText : MonoBehaviour
{
    public void ShowFE(string res){
        this.GetComponent<Text>().text = res;
    }
}
