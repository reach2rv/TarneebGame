using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace thecardsgame
{
    public class Bidding : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private GameSession gameSession;

        /// <summary>
        /// List of bids
        /// </summary>
        public List<Bid> Bids { get; private set; }

        /// <summary>
        /// The current turn in the bidding
        /// </summary>
        public PlayerPosition CurrentTurn { get; private set; }

        /// <summary>
        /// The starting player of the current bidding process
        /// </summary>
        private PlayerPosition startPosition;

        /// <summary>
        /// Indicates whether the current bidding process is complete or not
        /// </summary>
        public bool IsClosed { get; private set; }

        /// <summary>
        /// The winner of the bidding in case of the bids are closed, else returns null
        /// </summary>
        public Bid Winner
        {
            get
            {
                if (IsClosed)
                {
                    Bid winner = GetLastNonPassBid();

                    return winner;
                }
                else
                {
                    return null;
                }
            }
        }

        public Bidding(GameSession gameSession, PlayerPosition startPosition)
        {
            this.gameSession = gameSession;

            Bids = new List<Bid>();

            this.startPosition = startPosition;
            CurrentTurn = startPosition;
        }

        /// <summary>
        /// Evaluate and place the specified bid. Checks if the last 3 bids are Pass
        /// or a Pass and Double or Re-double is placed, the last bid is the winner and
        /// the bidding is closed.
        /// </summary>
        public void PlaceBid(Bid bid)
        {
            if (!IsClosed)
            {
                if (gameSession.GetPlayer(CurrentTurn) == bid.Player)
                {
                    //TODO: handle pass&double and re-double bids

                    Bid lastBid = GetLastNonPassBid();
                    // Check if user bid is 13 tricks or more if yes then close bid and start game
                    if (lastBid == null && Convert.ToInt32(bid) == 7)
                    {
                        Bids.Add(bid);
                        IsClosed = true;
                        gameSession.BiddingComplete();

                    }
                    if (lastBid != null && bid.CompareTo(lastBid) == 7)
                    {
                        Bids.Add(bid);
                        IsClosed = true;
                        gameSession.BiddingComplete();
                    }
                    if (bid.IsPass || lastBid == null || (lastBid != null && bid.CompareTo(lastBid) > 0))
                    {
                        Bids.Add(bid);
                        if (bid.IsPass && GetNumberOfPassBids() >= 3)
                        {
                            IsClosed = true;
                            gameSession.BiddingComplete();
                        }
                        else
                        {
                            NextTurn();
                        }
                    }
                    else
                    {
                        throw new ArgumentException("The placed bid is less than the last bid");
                    }
                }
                else
                {
                    throw new InvalidOperationException("The player placed a bit not in the right turn");
                }
            }
            else
            {
                throw new InvalidOperationException("Cannot place bids when the bidding is closed");
            }
        }

        private void NextTurn()
        {
            if (!IsClosed)
            {
                if (CurrentTurn == PlayerPosition.West)
                {
                    CurrentTurn = PlayerPosition.South;
                }
                else
                {
                    CurrentTurn++;
                }
            }
        }

        private Bid GetLastNonPassBid()
        {
            for (int i = Bids.Count - 1; i >= 0; i--)
            {
                Bid tempBid = Bids[i];
                if (!tempBid.IsPass)
                {
                    return tempBid;
                }
            }

            return null;
        }
        private int GetNumberOfPassBids()
        {
            int numberOfPassBids = 0;

            for (int i = Bids.Count - 1; i >= 0; i--)
            {
                Bid tempBid = Bids[i];
                if (tempBid.IsPass)
                {
                    numberOfPassBids++;
                }
                else
                {
                    break;
                }
            }
            return numberOfPassBids;
        }
    }
}
