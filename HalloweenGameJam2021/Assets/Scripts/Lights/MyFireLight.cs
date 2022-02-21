using UnityEngine;
using Random = UnityEngine.Random;
using CodeMonkey.Utils;

public class MyFireLight : MonoBehaviour
{
    public float positionScrollSpeed = 2f;
    public float intensityScrollSpeed = 1f;
    public float intensityBase = 1f;
    public float positionJumpScale = 1f;
    public float intensityJumpScale = 0.1f;
    public float fadeInTime = 5f;
    public float fadeOutTime = 5f;
    public Vector2 delayFromTo = new Vector2(0f, 10f);

    private float fadeIn, fadeOut;
    private bool burning = false;
    private Light myLight;
    private Vector3 lightPos;
    private LightMyFire setParticleSystem;

    private void Start()
    {
        setParticleSystem = GetComponentInParent<LightMyFire>();
        myLight = GetComponent<Light>();
        lightPos = myLight.transform.localPosition;
        fadeIn = 0;
        fadeOut = 0;

        if (TimeTickSystem.AreFiresLit) TimeTickSystem_OnLightFires(this, null);
            else TimeTickSystem_OnExtinguishFires(this, null);
        TimeTickSystem.OnLightFires += TimeTickSystem_OnLightFires;
        TimeTickSystem.OnExtinguishFires += TimeTickSystem_OnExtinguishFires;
    }

    private void TimeTickSystem_OnLightFires(object sender, TimeTickSystem.OnTimeEventArgs e)
    {
        FunctionTimer.Create(() =>
            {
                burning = true;
                if (setParticleSystem != null)
                {
                    if (setParticleSystem.delegateEvents) setParticleSystem.TimeTickSystem_OnLightFires(null, null);
                }
            }, Random.Range(delayFromTo.x, delayFromTo.y));
    }

    private void TimeTickSystem_OnExtinguishFires(object sender, TimeTickSystem.OnTimeEventArgs e)
    {
        FunctionTimer.Create(() =>
        {
            burning = false;
            if (setParticleSystem != null)
            {
                if (setParticleSystem.delegateEvents) FunctionTimer.Create(() => { if (setParticleSystem != null) setParticleSystem.TimeTickSystem_OnExtinguishFires(null, null); }, 0.5f * fadeOutTime / TimeTickSystem.SecondsPerSecond);
            }
        }, Random.Range(delayFromTo.x, delayFromTo.y));
    }

    private Vector3 PositionDelta(float positionScrollSpeed, float scale)
    {
        float x = Mathf.PerlinNoise(     Time.time * positionScrollSpeed, 1f + Time.time * positionScrollSpeed) - 0.5f;
        float y = Mathf.PerlinNoise(2f + Time.time * positionScrollSpeed, 3f + Time.time * positionScrollSpeed) - 0.5f;
        float z = Mathf.PerlinNoise(4f + Time.time * positionScrollSpeed, 5f + Time.time * positionScrollSpeed) - 0.5f;
        return new Vector3(x, y, z) * scale;
    }

    private float NewIntensity(float intensityBase, float intensityJumpScale, float intensityScrollSpeed)
    {
        return (intensityBase + (intensityJumpScale * Mathf.PerlinNoise(Time.time * intensityScrollSpeed, 1f + Time.time * intensityScrollSpeed)));
    }

    private void Update()
    {
        if (burning)
        {
            if (fadeIn < 1f) fadeIn += TimeTickSystem.SecondsPerSecond * Time.deltaTime / fadeInTime;
            if (fadeIn >= 1f) { fadeIn = 1f; fadeOut = 1f; }
            myLight.intensity = fadeIn * NewIntensity(intensityBase, intensityJumpScale, intensityScrollSpeed);
            transform.localPosition = lightPos + PositionDelta(positionScrollSpeed, positionJumpScale) * fadeIn;
        } else if (fadeOut > 0f)
        {
            fadeOut -= TimeTickSystem.SecondsPerSecond * Time.deltaTime / fadeOutTime;
            if (fadeOut <= 0f) { fadeOut = 0f; fadeIn = 0f; }
            myLight.intensity = fadeOut * NewIntensity(intensityBase, intensityJumpScale, intensityScrollSpeed);
            transform.localPosition = lightPos + PositionDelta(positionScrollSpeed, positionJumpScale) * fadeOut;
        }
    }

    private void OnDestroy()
    {
        TimeTickSystem.OnLightFires -= TimeTickSystem_OnLightFires;
        TimeTickSystem.OnExtinguishFires -= TimeTickSystem_OnExtinguishFires;
    }
}