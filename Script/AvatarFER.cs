/*
This program can estimate avatar's facial expression by pressing "s" key .
At first , this program takes a screen shot , then , this sends a request to "server.py" .
"server.py" estimates avatar's emotion from a screenshot and resend to this .
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public sealed class AvatarFER : MonoBehaviour
{
    //<summary>server's address for avatar's facial expression recognition</summary>
    string url = "http://localhost:5000/AvatarFER";

    //<summary>path for saving a screen shot</summary>
    string SSpath = "./Assets/Picture/SS.jpg";

    //<summary>this variable stores estimated emotion of avatar</summary>
    private string emotionText;

    //<summary>UI that displays avatar's estimated emotion</summary>
    [SerializeField]private DisplayFEText _emoText;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            FER(SSpath);
        }
    }

    //<summary>
    //by pressing "s" key , take a screen shot , then , send a request to server
    //</summary>
    private void FER(string path){
        ScreenCapture.CaptureScreenshot(path);
        Debug.Log("screenshot");
        StartCoroutine(SendSS(path));
    }

    //<summary>
    //send a request to the server and receive a result that emotion is estimated .
    //For ease , This sends a no meaning data "filepath + 0" to the server , but server responses a request.
    //</summary>
    private IEnumerator SendSS(string filePath)
    {
        Debug.Log(filePath);
        WWWForm form = new WWWForm();
        form.AddField(filePath, 0);
        UnityWebRequest webRequest = UnityWebRequest.Post(url, form);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError)
        {
            Debug.Log(webRequest.error);
        }else{
            emotionText = webRequest.downloadHandler.text;
            Debug.Log("post:"+emotionText);
            if(CommunicateServer.EmotionStatus == "happy")emotionText = "happy";
            _emoText.ShowFE(emotionText);
        }
    }
}
