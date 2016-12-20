using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace thecardsgame
{
    public class BiddingState : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public List<Bid> Bids { get; set; }
        public PlayerPosition CurrentTurn { get; set; }
        public bool IsClosed { get; set; }
        public PlayerPosition? Winner { get; set; }
        public Bid WinnerBid { get; set; }
    }
}
