using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAudio : MonoBehaviour
{
    public FMODUnity.EventReference FireRef;
    private FMOD.Studio.EventInstance FireInst;



    private void Start()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        FireInst = FMODUnity.RuntimeManager.CreateInstance(FireRef);
        FireInst.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        Debug.Log("TriggerFireAudio");
        FireInst.start();
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("ReleaseFireAudio");
        FireInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        FireInst.release();
    }


}
