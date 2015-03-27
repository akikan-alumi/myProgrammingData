using UnityEngine;
using System.Collections;

public class SpawnerSpawnes : MonoBehaviour {
	[SerializeField]
	private GameObject prefab;

	public void Spawns () {
		Instantiate (prefab, this.transform.position, this.transform.rotation);
	}
}
