using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

	public Transform tilePrefab;
	public Transform backgroundPrefab;
	public float xOffSet;
	public float yOffSet;
	public Vector2 mapSize;

	[Range(0,1)]
	public float outlinePercent;

	void Start() {
		GenerateMap ();
	}

	public void GenerateMap() {

		string holderName = "Generated Map";
		if (transform.Find (holderName)) {
			DestroyImmediate(transform.Find(holderName).gameObject);
		}

		Transform mapHolder = new GameObject (holderName).transform;
		mapHolder.parent = transform;
		Vector3 origin = new Vector3(xOffSet,yOffSet, 0.502f );
		Transform backGround = Instantiate(backgroundPrefab, origin, Quaternion.identity) as Transform;
		backGround.parent=mapHolder;
		backGround.localScale= new Vector3(mapSize.x,mapSize.y,1);
		for (int x = 0; x < mapSize.x; x ++) {
			for (int y = 0; y < mapSize.y; y ++) {
				Vector3 tilePosition = new Vector3(-mapSize.x/2 +0.5f + x+xOffSet,-mapSize.y/2 + 0.5f + y+yOffSet, 0.501f );
				Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.identity) as Transform;
				newTile.localScale = Vector3.one * (1-outlinePercent);
				newTile.parent = mapHolder;
			}
		}

	}

}
