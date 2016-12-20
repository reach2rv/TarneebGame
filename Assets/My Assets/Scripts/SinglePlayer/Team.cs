using UnityEngine;
using System.Collections;
using System;

namespace thecardsgame
{
    public class Team : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// First player of the team; NorthSouth
        /// </summary>
        public Player Player1;
        /// <summary>
        /// Second player of the team; NorthSouth
        /// </summary>
        public Player Player2;

        /// <summary>
        /// The position of the team either NorthSouth or EastWest
        /// </summary>
        public TeamPosition Position { get; set; }

        /// <summary>
        /// Indicates whether the team is ready and has two players or not
        /// </summary>
        /// 

        public Team()
        {
           Player1 = null;
           Player2 = null;
            //Player3 = null;
            //Player4 = null;
        }

        /// <summary>
        /// Checks if the specified player is member of the team
        /// </summary>
        public bool IsMember(Player player)
        {
            return (Player1 == player || Player2 == player);
        }

        /// <summary>
        /// Make the specified player join the team on the specified position
        /// </summary>
        public void Join(Player player, PlayerPosition position)
        {
            if (
                ((position == PlayerPosition.North || position == PlayerPosition.East) && Player1 != null) ||
                ((position == PlayerPosition.South || position == PlayerPosition.West) && Player2 != null))
            {

                throw new InvalidOperationException("Another player already holding this position");
            }

            switch (position)
            {
                case PlayerPosition.North:
                case PlayerPosition.East:
                    this.Player1 = player;
                    break;
                case PlayerPosition.South:
                case PlayerPosition.West:
                    this.Player2 = player;
                    break;
            }
        }

        /// <summary>
        /// Make the specified player leave the team
        /// </summary>
        /// <param name="player"></param>
        public void Leave(Player player)
        {
            if (player == Player1)
            {
                Player1 = null;
            }
            else
            {
                Player2 = null;
            }
        }

        public override string ToString()
        {
            return Position.ToString();
        }
    }

    public enum TeamPosition
    {
        NorthSouth,
        EastWest
    }
}