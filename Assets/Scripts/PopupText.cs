﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopupText : MonoBehaviour {
    public Animator animator;
    private Text damageText;

	void OnEnable() {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);
        damageText = animator.GetComponent<Text>();
	}

    public void SetText(string text)
    {
        damageText.text = text;
    }
	
}
