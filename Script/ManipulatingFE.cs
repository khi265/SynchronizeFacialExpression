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
    }

    private void changeFE(string fe){
        switch(fe){
            case "angry" :
                break;
            case "contempt" :
                break;
            case "disgust" :
                break;
            case "fear" :
                break;
            case "happy" :
                blendshape.SetBlendShapeWeight(9, 100); //(ブレンドシェイプの番号,セットする値)
                blendshape.SetBlendShapeWeight(10, 100); //(ブレンドシェイプの番号,セットする値)
                break;
            case "neutral" :
                for(int i = 0; i < 39; i++){
                    blendshape.SetBlendShapeWeight(i, 0); //(ブレンドシェイプの番号,セットする値)
                }
                break;
            case "sadness" :
                break;
            case "surprise" :
                break;
        }
    }
}
