using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public sealed class AvatarFER : MonoBehaviour
{
    string url = "http://localhost:5000/AvatarFER";
    string SSpath = "./Assets/Picture/SS.jpg";

    private string emotionText;
    [SerializeField]private DisplayFEText _emoText;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            FER(SSpath);
        }
    }

    private void FER(string path){
        ScreenCapture.CaptureScreenshot(path);
        Debug.Log("screenshot");
        StartCoroutine(SendSS(path));
    }

    private IEnumerator SendSS(string filePath)
    {
        Debug.Log(filePath);
        WWWForm form = new WWWForm();
        form.AddField(filePath, 0);
        //URLをPOSTで用意
        UnityWebRequest webRequest = UnityWebRequest.Post(url, form);
        //UnityWebRequestにバッファをセット
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        //URLに接続して結果が戻ってくるまで待機
        yield return webRequest.SendWebRequest();

        //エラーが出ていないかチェック
        if (webRequest.isNetworkError)
        {
            //通信失敗
            Debug.Log(webRequest.error);
        }else{
            emotionText = webRequest.downloadHandler.text;
            Debug.Log("post:"+emotionText);
            _emoText.ShowFE(emotionText);
        }
    }
}
