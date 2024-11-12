using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float duration = 0.2f;
    [SerializeField] private float magnitude = 0.4f;

    public void Start()
    {
        ScoreManager.Instance.onScore1Change += StartShake;
        ScoreManager.Instance.onScore2Change += StartShake;
    }

    private void StartShake()
    {
        StartCoroutine(Shake());
    }

    public IEnumerator Shake()
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
