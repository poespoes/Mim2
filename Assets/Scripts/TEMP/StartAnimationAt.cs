using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationAt : MonoBehaviour
{
    private Animator anim;
    private bool gameStarted;

    [Range(0, 1)]
    public float StartingAt;
    public string AnimationName;


    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        if (gameStarted == false) {
            anim.Play(AnimationName, 0, StartingAt);
            gameStarted = true;
        }
    }
}