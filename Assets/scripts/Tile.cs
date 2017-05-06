using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	private int type;
	public bool lockedForMatching = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	bool Match (Tile tile) {
		return this.type === tile.type;
	}
}
