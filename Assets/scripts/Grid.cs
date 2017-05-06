using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {

	public int width;
	public int height;
	private Tile[,] tiles;

	//▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
	// Use this for initialization
	void Start () {
		tiles = new Tile[width, height];
	}
	
	//▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
	// Update is called once per frame
	void Update () {
	
	}

	//▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
	public Tile[] GetCombinations() {
		Tile tile;
		List<Tile> combinations = new List<Tile>();

		// Checking columns, in O(n)
		for (int i = 0; i < width; i++) {
			int j0 = height - 1;
			while (j0 >= 2) {
				tile = tiles[i][j0];
				if (tile.lockedForMatching) {
					j0 -= 1;
					continue;
				}

				int j1 = j0 - 1;
				while (j1 >= 0 && !tiles[i][j1].lockedForMatching && tile.Match(tiles[i][j1])) {
					j1 -= 1;
				}

				if (j0 - j1 >= 3) {
					while (j0 > j1) {
						combinations.Add(tiles[i][j0]);
						j0 -= 1;
					}
				} else {
					j0 = j1;
				}
			}
		}

		// Checking rows, in O(n)
		for (int j = 0; j < height; j++) {
			int i0 = height - 1;
			while (i0 >= 2) {
				tile = tiles[i0][j];
				if (tile.lockedForMatching) {
					i0 -= 1;
					continue;
				}
				int i1 = i0 - 1;
				while (i1 >= 0 && !tiles[i1][j].lockedForMatching && tile.Match(tiles[i1][j])) {
					i1 -= 1;
				}

				if (i0 - i1 >= 3) {
					while (i0 > i1) {
						combinations.Add(tiles[i0][j]);
						i0 -= 1;
					}
				} else {
					i0 = i1;
				}
			}
		}

		return combinations.ToArray();
	}
}
