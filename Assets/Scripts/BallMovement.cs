using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField, Range(0f, 90f)] private float quarterDirectionMin = 15f;
    [SerializeField, Range(0f, 90f)] private float quarterDirectionMax = 45f;
    [SerializeField] private float startForce = 100f;
    [SerializeField] private float waitTime = 3f;
    [ColorUsageAttribute(true, true)]
    [SerializeField] private List<Color> waitColors = new List<Color>();
    [ColorUsageAttribute(true, true)]
    [SerializeField] private Color activeColor;
    [SerializeField] private MeshRenderer meshRenderer;

    private void Start()
    {
        StartCoroutine(WaitThenLaunch());
    }

    public IEnumerator WaitThenLaunch()
    {
        int numberOfMaterials = waitColors.Count;
        for (int i = 0; i < numberOfMaterials; i++)
        {
            meshRenderer.material.color = waitColors[i];
            yield return new WaitForSeconds(waitTime / (numberOfMaterials * 1f));
        }
        meshRenderer.material.color = activeColor;
        LaunchBall();
    }

    public void LaunchBall()
    {
        float angle = Random.Range(quarterDirectionMin, quarterDirectionMax);
        bool isUpperCorner = Random.Range(0, 2) == 0 ? true : false;
        bool isRightPlayer = Random.Range(0, 2) == 0 ? true : false;

        Vector3 direction;

        if (isRightPlayer)
        {
            direction = new Vector3(1, 0, 0);
        }
        else
        {
            direction = new Vector3(-1, 0, 0);
        }

        Quaternion rotation = Quaternion.Euler(0, 0, isUpperCorner ? angle : -angle);

        direction = rotation * direction;

        Rigidbody rb = GetComponent<Rigidbody>();

        rb.AddForce(direction * startForce, ForceMode.Impulse);
    }
}
