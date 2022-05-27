using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public FMODUnity.EventReference CheckpointRef;
    private FMOD.Studio.EventInstance CheckpointInst;

    public FMODUnity.EventReference DashRef;
    private FMOD.Studio.EventInstance DashInst;

    public FMODUnity.EventReference DeathRef;
    private FMOD.Studio.EventInstance DeathInst;

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
        DashInst = FMODUnity.RuntimeManager.CreateInstance(DashRef);
        DashInst.start();
        DashInst.release();

    }
    public void DeathAudio()
    {
        DeathInst = FMODUnity.RuntimeManager.CreateInstance(DeathRef);
        DeathInst.start();
        DeathInst.release();

    }
}
