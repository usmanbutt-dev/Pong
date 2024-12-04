using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {
    [SerializeField] private float moveSpeed = 5f;
    private float upperLimit = 3.5f;
    private float lowerLimit = -3.5f;

    void Update() {
        bool isPressingUp = Input.GetKey(KeyCode.W);
        bool isPressingDown = Input.GetKey(KeyCode.S);

        // Handle movement and clamp the position
        if (isPressingUp && transform.position.y < upperLimit) {
            float newY = Mathf.Min(transform.position.y + moveSpeed * Time.deltaTime, upperLimit);
            transform.position = new Vector2(transform.position.x, newY);
        }

        if (isPressingDown && transform.position.y > lowerLimit) {
            float newY = Mathf.Max(transform.position.y - moveSpeed * Time.deltaTime, lowerLimit);
            transform.position = new Vector2(transform.position.x, newY);
        }
    }
}
