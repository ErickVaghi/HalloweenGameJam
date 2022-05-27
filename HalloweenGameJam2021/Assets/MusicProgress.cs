using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicProgress : MonoBehaviour
{
    public MusicController mc;
    public int ProgressLvl = 1;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        mc.changeMusicProgress(ProgressLvl);
    }

}
