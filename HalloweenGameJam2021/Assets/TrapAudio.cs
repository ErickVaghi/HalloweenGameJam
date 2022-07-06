using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAudio : MonoBehaviour
{
    public FMODUnity.EventReference TrapRef;
    private FMOD.Studio.EventInstance TrapInst;
    FMOD.Studio.PLAYBACK_STATE pbState;

    void Start()
    {
        TrapInst = FMODUnity.RuntimeManager.CreateInstance(TrapRef);
        TrapInst.getPlaybackState(out pbState);
        if (pbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            TrapInst.start();
        }

    }

    // Update is called once per frame

    void Update()
    {
        TrapInst.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));

    }



}
