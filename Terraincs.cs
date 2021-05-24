using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Terraincs : MonoBehaviour {

	public Vector3 Spawn;

	void OnTriggerExit (Collider col){
		if(col.gameObject.tag == "Player"){
			col.transform.position = Spawn;
		}
	}
}


