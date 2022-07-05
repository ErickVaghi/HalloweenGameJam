using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovementAudio : MonoBehaviour
{
    public FMODUnity.EventReference GhostMovementRef;
    private FMOD.Studio.EventInstance GhostMovementInst;
    FMOD.Studio.PARAMETER_ID myParam_ID;
    public Rigidbody2D rb;
    private FMOD.Studio.PLAYBACK_STATE pbstate;
    void Start()
    {
        GhostMovementInst = FMODUnity.RuntimeManager.CreateInstance(GhostMovementRef);
        FMOD.Studio.EventDescription myParam_EventDescription;
        GhostMovementInst.getDescription(out myParam_EventDescription);
        FMOD.Studio.PARAMETER_DESCRIPTION myParam_ParameterDescription;
        myParam_EventDescription.getParameterDescriptionByName("MovementPitch", out myParam_ParameterDescription);
        myParam_ID = myParam_ParameterDescription.id;
        GhostMovementInst.start();
    }

    void Update()
    {
        GhostMovementInst.getPlaybackState(out pbstate);
        GhostMovementInst.setParameterByID(myParam_ID, rb.velocity.magnitude);
        
    }
}
