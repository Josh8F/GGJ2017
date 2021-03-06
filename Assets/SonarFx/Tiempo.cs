﻿using UnityEngine;
using System.Collections;

public class Tiempo : MonoBehaviour {
    public float tiempo = 0f,tiempo1 = 0f;
    public Vector3 posicion;
    SonarFx sonar;
    bool cuenta = false;
    float tiempores = 0f;
	public GameObject sound2;
	public GameObject sound1;
	public Camera camara;
	public float clicks = 100f;
	float movVert;
	float movHor;

	// Use this for initialization
	void Awake() {
        sonar = GetComponent<SonarFx>();
        sonar.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (clicks > 100f)
			clicks = 100f;
			

		if (cuenta == true) {
			if (tiempores > 0) {
				if (clicks < 100f) {
					movHor = Input.GetAxis ("Horizontal");
					movVert = Input.GetAxis ("Vertical");
					if (movVert == 1 || movVert == -1 || movHor == 1 || movHor == -1) {
						clicks += 0.17f;

					}

				}	
				tiempores -= Time.deltaTime;
			} else {
				

				sonar.enabled = false;
				cuenta = false;
			}
		} else {
			if (Application.loadedLevel == 0) {
				tiempores = tiempo1;
				if (tiempores > 0) {
					tiempores -= Time.deltaTime;

				} else {
					ComprobarMouse ();
				}        
			}
			ComprobarMouse ();
		}}
     
	     void ComprobarMouse(){
			if (Input.GetMouseButtonUp (0)) {

				if (clicks >= 20f) {
					clicks = clicks - 20f;
					GetComponent<SonarFx> ().waveColor = new Color32 (0xEF, 0xBA, 0x3E, 0x00);
					cuenta = true;
					tiempores = tiempo;
					sonar.enabled = true;
					Vector3 mousePos = Input.mousePosition;
					mousePos.z += 110;
					Vector3 mousePosWorld = camara.ScreenToWorldPoint (mousePos);
					posicion = new Vector3 (mousePosWorld.x, 0, mousePosWorld.z);
					Destroy(Instantiate (sound1, posicion, Quaternion.identity),3);

					sonar.posicion = posicion;
				} 

			} else if (Input.GetMouseButtonUp (1)) {

				if (clicks >= 40f) {

					clicks = clicks - 40f;
					GetComponent<SonarFx> ().waveColor = new Color32 (0x43, 0xBE, 0xE4, 0x00);
					cuenta = true;
					tiempores = tiempo;
					sonar.enabled = true;
					Vector3 mousePos = Input.mousePosition;
					mousePos.z += 110;
					Vector3 mousePosWorld = camara.ScreenToWorldPoint (mousePos);
					posicion = new Vector3 (mousePosWorld.x, 0, mousePosWorld.z);
					Destroy(Instantiate (sound2, posicion, Quaternion.identity),3);
					sonar.posicion = posicion;
				} 
			}
		}

	}

