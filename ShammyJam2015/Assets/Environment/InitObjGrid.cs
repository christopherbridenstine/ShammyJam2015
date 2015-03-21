using UnityEngine;
using System.Collections;

public class InitObjGrid : MonoBehaviour {

	public GameObject[,] ObjGrid = new GameObject[10,10];
	public int GridWidth;
	public int GridHeight;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < GridHeight; i++){
			for(int j = 0; j < GridWidth; j++){
				// GameObject objType = Resources.Load("square") as GameObject;
				GameObject obj = Instantiate(Resources.Load("square") as GameObject);
				obj.transform.localPosition = new Vector3((1.0f * j) + 0.5f, (1.0f * i) + 0.5f, 0.0f);
				obj.transform.localScale = new Vector3(2f, 2f, 2f);
				ObjGrid[i,j] = obj;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
