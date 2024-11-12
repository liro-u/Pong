using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadMovement : MonoBehaviour
{
    [Header("KeyBind")]
    [SerializeField] private KeyCode upKey = KeyCode.UpArrow;
    [SerializeField] private KeyCode downKey = KeyCode.DownArrow;

    [Header("Movement")]
    [SerializeField] private float speed = 0.2f;

    private Vector3 moveDirection = new Vector3(0, 0, 0);

    private void Update()
    {
        if (Input.GetKeyDown(upKey) || Input.GetKeyUp(downKey))
        {
            moveDirection += new Vector3(0, 1, 0);
        }
        if (Input.GetKeyDown(downKey) || Input.GetKeyUp(upKey))
        {
            moveDirection += new Vector3(0, -1, 0);
        }
    }

    private void FixedUpdate()
    {
        Vector3 position = transform.position + moveDirection * speed;
        position.y = Mathf.Clamp(position.y, ArenaManager.Instance.bottomYPosition, ArenaManager.Instance.topYPosition);
        transform.position = position;
    }
}
