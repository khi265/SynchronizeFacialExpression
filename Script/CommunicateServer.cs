/*
This program can communicate with "server.py" .
This sends a GET request to the server and receive a latest facial expression recognition result data of "video_emotion_color_demo.py" for real-user .
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public sealed class CommunicateServer : MonoBehaviour {

    //<summary>real-user's emotion status variable like a singleton</summary>
    public static string EmotionStatus;

    //<summary>tmp variable for receiving a latest facial expression recognition result data</summary>
    private string result;
    
    //<summary>server's address</summary>
    string url = "http://localhost:5000/hello";


    //<summary>this callback valriable calls "changeFE" of "ManipulatingFE.cs" </summary>
    public delegate void CallBack(string fe);

    //<summary>
    // This method starts coroutine "getText"
    //</summary>
    public void StartCommunicate(CallBack call){
        StartCoroutine(getText(call));
    }

    //<summary>
    // This method is for getting facial expression recognition result data from "server.py"
    // communicating server , this program can receive the data .
    //</summary>
    private IEnumerator getText(CallBack call) {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }else {
            string dev_res = www.downloadHandler.text;
            Debug.Log(dev_res);
            result = dev_res;
            EmotionStatus = result;
            call(result);
        }
    }
}
