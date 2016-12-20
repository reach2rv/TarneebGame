using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace thecardsgame
{
    public class GamePlayState : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public PlayerPosition CurrentTurn { get; set; }
        public Dictionary<TeamPosition, int> TricksWon { get; set; }
        public List<Cards> CurrentCards { get; set; }
        public Dictionary<PlayerPosition, Cards> CurrentTrick { get; set; }
        public Suit CurrentTrickBaseSuit { get; set; }
    }
}