﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BloodMgr : MonoBehaviour {

	public int bones;
	private int currentBones;
	public GameObject myCanvas;

	private Image[] bloods;

	public GameManager gameMgr;

	public Image BloodBlur;

	public void bloodGain(int damage){
		if (damage > 0) {
			if (currentBones < 7) {
				currentBones++;
			}
		} else {
			Debug.Log ("ben yeh sai, who call this is too over");
		}
	}

	public void bloodLoss(int damage){
		if (damage > 0) {
			if (currentBones > 0) {
				currentBones--;
			}
		} else {
			Debug.Log ("ben yeh sai, who call this is too over");
		}
	}

	void Start () {
		bloods = myCanvas.GetComponentsInChildren<Image>();
		for ( int i = this.bones; i < 7; i++ ) {
			bloods[i].enabled = false;
		}
		currentBones = this.bones;
	}	

	Tweener tweenAnimation;
	public void PlayHitAnimation()
	{
		if (tweenAnimation != null)
			tweenAnimation.Kill ();

		BloodBlur.color = Color.white;
		tweenAnimation = DOTween.To (() => BloodBlur.color, (x) => BloodBlur.color = x, new Color (1, 1, 1, 0), 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if ( currentBones > bones ) {
			for ( int i = bones; i < currentBones; i++ ) {
				bloods[i].enabled = true;
			}
		} else if ( currentBones < bones ) {
			for ( int i = currentBones; i < bones; i++ ) {
				bloods[i].enabled = false;
			}
		}

		bones = currentBones;

		if (bones <= 0) {
			gameMgr.GameOver ();
		}
	}

	public void Reset(){
		for ( int i = this.bones; i < 7; i++ ) {
			bloods[i].enabled = true;
		}
		bones = 3;
		currentBones = bones;
		for ( int i = this.bones; i < 7; i++ ) {
			bloods[i].enabled = false;
		}
	}
}
