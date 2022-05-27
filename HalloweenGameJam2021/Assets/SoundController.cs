using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public FMODUnity.EventReference CheckpointRef;
    private FMOD.Studio.EventInstance CheckpointInst;

    public FMODUnity.EventReference Dashref;
    private FMOD.Studio.EventInstance DashInst;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ChekpointAudio()
    {
        CheckpointInst = FMODUnity.RuntimeManager.CreateInstance(CheckpointRef);
        CheckpointInst.start();
        CheckpointInst.release();
    }
    public void DashAudio()
    {
        DashInst = FMODUnity.RuntimeManager.CreateInstance(Dashref);
        DashInst.start();
        DashInst.release();

    }
}
