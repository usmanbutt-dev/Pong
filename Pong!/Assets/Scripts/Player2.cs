using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {
    [SerializeField] private float moveSpeed = 5f;
    void Update() {
        bool isPressingUp = Input.GetKey(KeyCode.UpArrow);
        bool isPressingDown = Input.GetKey(KeyCode.DownArrow);

        if (isPressingUp) {
            transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
        }
        if (isPressingDown) {
            transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
        }
    }
}