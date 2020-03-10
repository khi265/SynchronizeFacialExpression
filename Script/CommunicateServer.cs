using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class CommunicateServer : MonoBehaviour {
    
    private enum photoKind : int{
        photo,
        SS
    }

    public static string EmotionStatus;

    private string result;
    
    string url = "http://localhost:5000/hello";


    public delegate void CallBack(string fe);

    public void StartCommunicate(CallBack call){
        StartCoroutine(getText(call));
    }

    private IEnumerator getText(CallBack call) {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }else {
            string dev_res = www.downloadHandler.text;
            // 結果をテキストとして表示します
            Debug.Log(dev_res);
            result = dev_res;
            EmotionStatus = result;
            call(result);
        }
    }
}
