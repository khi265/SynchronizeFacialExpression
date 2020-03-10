using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulatingFE : MonoBehaviour
{ 
    private SkinnedMeshRenderer blendshape;
    [SerializeField]private CommunicateServer _cs;

    void Start()
    {
        blendshape = this.GetComponent<SkinnedMeshRenderer>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Z)){
            _cs.StartCommunicate(changeFE);
            //string fe = _cs.StartCommunicate(changeFE);
            //changeFE(fe);
        }
        //For Debug
        if(Input.GetKeyDown(KeyCode.D)){
            changeFE("angry");
        }
    }

    private void changeFE(string fe){
        for(int i = 0; i < 39; i++){
            blendshape.SetBlendShapeWeight(i, 0); //(ブレンドシェイプの番号,セットする値)
        }
        //todo: enumに！
        switch(fe){
            case "angry" :
                blendshape.SetBlendShapeWeight(11, 100); //(ブレンドシェイプの番号,セットする値)
                blendshape.SetBlendShapeWeight(12, 100); //(ブレンドシェイプの番号,セットする値)
                blendshape.SetBlendShapeWeight(22, 35); //(ブレンドシェイプの番号,セットする値)
                blendshape.SetBlendShapeWeight(23, 35); //(ブレンドシェイプの番号,セットする値)
                blendshape.SetBlendShapeWeight(38, 100); //(ブレンドシェイプの番号,セットする値)
                break;
            case "contempt" :
                break;
            case "disgust" :
                blendshape.SetBlendShapeWeight(20, 100); //(ブレンドシェイプの番号,セットする値)
                blendshape.SetBlendShapeWeight(21, 100); //(ブレンドシェイプの番号,セットする値)
                blendshape.SetBlendShapeWeight(38, 100); //(ブレンドシェイプの番号,セットする値)
                break;
            case "fear" :
                break;
            case "happy" :
                blendshape.SetBlendShapeWeight(9, 100); //(ブレンドシェイプの番号,セットする値)
                blendshape.SetBlendShapeWeight(10, 100); //(ブレンドシェイプの番号,セットする値)
                break;
            case "neutral" :
                break;
            case "sadness" :
                blendshape.SetBlendShapeWeight(11, 100); //(ブレンドシェイプの番号,セットする値)
                blendshape.SetBlendShapeWeight(12, 100); //(ブレンドシェイプの番号,セットする値)
                blendshape.SetBlendShapeWeight(26, 80); //(ブレンドシェイプの番号,セットする値)
                blendshape.SetBlendShapeWeight(32, 80); //(ブレンドシェイプの番号,セットする値)
                break;
            case "surprise" :
                blendshape.SetBlendShapeWeight(3, 40); //(ブレンドシェイプの番号,セットする値)
                blendshape.SetBlendShapeWeight(4, 100); //(ブレンドシェイプの番号,セットする値)
                blendshape.SetBlendShapeWeight(5, 100); //(ブレンドシェイプの番号,セットする値)
                blendshape.SetBlendShapeWeight(30, 100); //(ブレンドシェイプの番号,セットする値)
                blendshape.SetBlendShapeWeight(36, 100); //(ブレンドシェイプの番号,セットする値)
                break;
        }
    }
}
