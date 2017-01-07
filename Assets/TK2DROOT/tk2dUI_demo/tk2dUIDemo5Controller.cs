using UnityEngine;
using System.Collections;

public class tk2dUIDemo5Controller : tk2dUIBaseDemoController {

	public tk2dUILayout prefabItem;

	// Manually set up a scrollable area by working out offsets manually
	public tk2dUIScrollableArea manualScrollableArea;

	void CustomizeListObject( Transform contentRoot ) {
		string[] firstPart = { "Ba", "Po", "Re", "Zu", "Meh", "Ra'", "B'k", "Adam", "Ben", "George" };
		string[] secondPart = { "Hoopler", "Hysleria", "Yeinydd", "Nekmit", "Novanoid", "Toog1t", "Yboiveth", "Resaix", "Voquev", "Yimello", "Oleald", "Digikiki", "Nocobot", "Morath", "Toximble", "Rodrup", "Chillaid", "Brewtine", "Surogou", "Winooze", "Hendassa", "Ekcle", "Noelind", "Animepolis", "Tupress", "Jeren", "Yoffa", "Acaer" };
		string name = firstPart[Random.Range(0, firstPart.Length)] + " " + secondPart[Random.Range(0, secondPart.Length)];
 		Color color = new Color32((byte)Random.Range(192, 255), (byte)Random.Range(192, 255), (byte)Random.Range(192, 255), 255);
		contentRoot.Find("Name").GetComponent<tk2dTextMesh>().text = name;
		contentRoot.Find("HP").GetComponent<tk2dTextMesh>().text = "HP: " + Random.Range(100, 512).ToString();
		contentRoot.Find("MP").GetComponent<tk2dTextMesh>().text = "MP: " + (Random.Range(2, 40) * 10).ToString();
		contentRoot.Find("Portrait").GetComponent<tk2dBaseSprite>().color = color;
	}

	void Start () {
		// Disable the prefab item
		// don't want it visible when the game is running, as it is in the scene
		prefabItem.transform.parent = null;
		DoSetActive( prefabItem.transform, false );

		// Add a bunch of items to the manual list
		// You will need to parent the object manually and then calculate the step
		float x = 0;
		float w = (prefabItem.GetMaxBounds() - prefabItem.GetMinBounds()).x;
		for (int i = 0; i < 10; ++i) {
			tk2dUILayout layout = Instantiate(prefabItem) as tk2dUILayout;
			layout.transform.parent = manualScrollableArea.contentContainer.transform;
			layout.transform.localPosition = new Vector3(x, 0, 0);
			DoSetActive( layout.transform, true );
			CustomizeListObject( layout.transform );
			x += w;
		}

		manualScrollableArea.ContentLength = x;
	}
}
