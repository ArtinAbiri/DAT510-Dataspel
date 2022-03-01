using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    Vector3 startPos;
    public bool doShake;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        startPos = transform.position;
    }

    private IEnumerator Shake(float duration, float magnitude)
    {
        

        float elapsedTime = 0f;
        
        while (elapsedTime < duration)
        {
            Vector3 origPos = transform.position;
            float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float yOffset = Random.Range(-0.0f, 0.0f) * magnitude;
            transform.localPosition = new Vector3(origPos.x + xOffset, origPos.y + yOffset, transform.position.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }

    public void ShakeMe()
    {
        StartCoroutine(Shake(2, 0.5f));
    }

}
