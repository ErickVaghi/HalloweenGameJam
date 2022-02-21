using UnityEngine;

public class LightMyFire : MonoBehaviour
{
    public bool delegateEvents = true;

    private void Start()
    {
        if (!delegateEvents)
        {
            if (TimeTickSystem.AreFiresLit) TimeTickSystem_OnLightFires(this, null);
            else TimeTickSystem_OnExtinguishFires(this, null);
            TimeTickSystem.OnLightFires += TimeTickSystem_OnLightFires;
            TimeTickSystem.OnExtinguishFires += TimeTickSystem_OnExtinguishFires;
        }
    }

    public void TimeTickSystem_OnLightFires(object sender, TimeTickSystem.OnTimeEventArgs e)
    {
        var systems = GetComponentsInChildren<ParticleSystem>();
        foreach (var system in systems)
        {
            var emission = system.emission;
            emission.enabled = true;
        }
    }

    public void TimeTickSystem_OnExtinguishFires(object sender, TimeTickSystem.OnTimeEventArgs e)
    {
        var systems = GetComponentsInChildren<ParticleSystem>();
        foreach (var system in systems)
        {
            var emission = system.emission;
            emission.enabled = false;
        }
    }

    private void OnDestroy()
    {
        if (!delegateEvents)
        {
            TimeTickSystem.OnLightFires -= TimeTickSystem_OnLightFires;
            TimeTickSystem.OnExtinguishFires -= TimeTickSystem_OnExtinguishFires;
        }
    }
}
