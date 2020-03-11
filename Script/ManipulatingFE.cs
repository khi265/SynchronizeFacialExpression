/*
This program manipulates avatar's facial expression by using blendshape .
by pressing "z" key , you can send a request to the server through the method of "AvatarFER.cs".
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ManipulatingFE : MonoBehaviour
{ 
    
    private enum blendshapeParameters : int{
        Jaw_Forward = 0,
        Jaw_Right,
        Jaw_Left,
        Jaw_Open,
        Mouth_Ape_Shape,
        Mouth_O_Shape,
        Mouth_Pout,
        Mouth_Lower_Right,
        Mouth_Lower_Left,
        Mouth_Smile_Right,
        Mouth_Smile_Left,
        Mouth_Sad_Right,
        Mouth_Sad_Left,
        Cheek_Puff_Right,
        Cheek_Puff_Left,
        Mouth_Lower_Inside,
        Mouth_Upper_Inside,
        Mouth_Lower_Overlay,
        Mouth_Upper_Overlay,
        Cheek_Suck,
        Mouth_LowerRight_Down,
        Mouth_LowerLeft_Down,
        Mouth_UpperRight_Up,
        Mouth_UpperLeft_Up,
        Mouth_Philtrum_Right,
        Mouth_Philtrum_Left,
        Eye_Left_Blink,
        Eye_Left_Wide,
        Eye_Left_Right,
        Eye_Left_Left,
        Eye_Left_Up,
        Eye_Left_Down,
        Eye_Right_Blink,
        Eye_Right_Wide,
        Eye_Right_Right,
        Eye_Right_Left,
        Eye_Right_Up,
        Eye_Right_Down,
        Eye_Frown
    }

    //<summary>it's for using blendshape</summary>
    private SkinnedMeshRenderer blendshape;
    
    //<summary>for communicating server.py</summary>
    [SerializeField]private CommunicateServer _cs;

    void Start()
    {
        blendshape = this.GetComponent<SkinnedMeshRenderer>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Z)){
            _cs.StartCommunicate(changeFE);
        }
        //For Debug
        //You can check avatar's face by pressing "D" , and you can change an argument
        if(Input.GetKeyDown(KeyCode.D)){
            changeFE("surprise");
        }
    }

    private void changeFE(string fe){
        for(int i = 0; i < 39; i++){
            blendshape.SetBlendShapeWeight(i, 0);
        }
        switch(fe){
            case "angry" :
                blendshape.SetBlendShapeWeight((int)blendshapeParameters.Mouth_Sad_Right, 100);
                blendshape.SetBlendShapeWeight((int)blendshapeParameters.Mouth_Sad_Left, 100);
                blendshape.SetBlendShapeWeight((int)blendshapeParameters.Mouth_UpperRight_Up, 35);
                blendshape.SetBlendShapeWeight((int)blendshapeParameters.Mouth_UpperLeft_Up, 35);
                blendshape.SetBlendShapeWeight((int)blendshapeParameters.Eye_Frown, 100);
                break;
            case "contempt" :
                break;
            case "disgust" :
                blendshape.SetBlendShapeWeight((int)blendshapeParameters.Mouth_LowerRight_Down, 100);
                blendshape.SetBlendShapeWeight((int)blendshapeParameters.Mouth_LowerLeft_Down, 100);
                blendshape.SetBlendShapeWeight((int)blendshapeParameters.Eye_Frown, 100);
                break;
            case "fear" :
                break;
            case "happy" :
                blendshape.SetBlendShapeWeight((int)blendshapeParameters.Mouth_Smile_Right, 100);
                blendshape.SetBlendShapeWeight((int)blendshapeParameters.Mouth_Smile_Left, 100);
                break;
            case "neutral" :
                break;
            case "sadness" :
                blendshape.SetBlendShapeWeight((int)blendshapeParameters.Mouth_Sad_Left, 100);
                blendshape.SetBlendShapeWeight((int)blendshapeParameters.Mouth_Sad_Right, 100);
                blendshape.SetBlendShapeWeight((int)blendshapeParameters.Eye_Left_Blink, 80);
                blendshape.SetBlendShapeWeight((int)blendshapeParameters.Eye_Right_Blink, 80);
                break;
            case "surprise" :
                blendshape.SetBlendShapeWeight((int)blendshapeParameters.Jaw_Open, 40); //(ブレンドシェイプの番号,セットする値)
                blendshape.SetBlendShapeWeight((int)blendshapeParameters.Mouth_Ape_Shape, 100); //(ブレンドシェイプの番号,セットする値)
                blendshape.SetBlendShapeWeight((int)blendshapeParameters.Mouth_O_Shape, 100); //(ブレンドシェイプの番号,セットする値)
                blendshape.SetBlendShapeWeight((int)blendshapeParameters.Eye_Left_Up, 100); //(ブレンドシェイプの番号,セットする値)
                blendshape.SetBlendShapeWeight((int)blendshapeParameters.Eye_Right_Up, 100); //(ブレンドシェイプの番号,セットする値)
                break;
        }
    }
}
