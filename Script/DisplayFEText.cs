using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayFEText : MonoBehaviour
{
    public void ShowFE(string res){
        this.GetComponent<Text>().text = res;
    }
}
