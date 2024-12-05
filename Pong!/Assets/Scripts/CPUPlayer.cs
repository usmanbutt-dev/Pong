using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUPlayer : MonoBehaviour {
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform ball; 
    private float upperLimit = 3.5f; 
    private float lowerLimit = -3.5f; 

    void Update() {
        if (ball != null) {
            float targetY = ball.position.y;
            targetY = Mathf.Clamp(targetY, lowerLimit, upperLimit);
            float newY = Mathf.MoveTowards(transform.position.y, targetY, moveSpeed * Time.deltaTime);
            transform.position = new Vector2(transform.position.x, newY);
        }
    }
}