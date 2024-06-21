using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformed : MonoBehaviour
{
    private bool _canControl = true;
    private AnimationClip _transformClip;

    //use for initialization purposes
    private void Awake()
    {
        //this is where you apply animation events

        //you want to set up an animation event that calls the function TransformationComplete() when the animation finishes
        var ae = new AnimationEvent();
        ae.time = _transformClip.length; //the time in which it takes to complete
        ae.functionName = "TransformationComplete"; //we will call the function named this when the animation completes
        _transformClip.AddEvent(ae);
    }

    //called when our transformation animation completes
    private void TransformationComplete()
    {
        //here we swap the model, please refer to the post on UnityAnswers to figure out how to do this

        //restore controls
        _canControl = true;
    }

    public void TransformCharacter()
    {
        //strip controls
        _canControl = false;

        //tell the animation to play
        GetComponent<Animation>().clip = _transformClip;
        GetComponent<Animation>().Play();//note, this won't blend the animations together, to use that you'll want to use animation.CrossFade()
    }

    //where your controls are implemented.

    private void FixedUpdate()
    {
        if (!_canControl) return; //early out if the user cannot control
    }
}
