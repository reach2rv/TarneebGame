using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour {

    public Sprite[] card_faces;
    public GameObject[] cards;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void PopulateCards()
    {
        

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                GameObject prefab = Resources.Load("Card") as GameObject;
                GameObject card = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
                card.transform.parent = this.gameObject.transform;
                card.transform.localPosition = Vector3.zero;

                //card.GetComponent<SpriteRenderer>().sprite = card_faces;
                    //= card_sprite[(i * 13) + j];
               // card.GetComponent<Card>().mySuit = (Card.Suit)i;
                //card.GetComponent<Card>().myValue = (Card.Value)j;
                //card.gameObject.name = ((Card.Suit)i).ToString() + "_" + ((Card.Value)j).ToString();

            }
        }
    }
}
