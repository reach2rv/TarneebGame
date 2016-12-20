using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace thecardsgame
{
    public class GameSessionState : MonoBehaviour
    {
        

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public Guid Id { get; set; }
        public Dictionary<PlayerPosition, Player> Players { get; set; }
        public GameSessionStatus Status { get; set; }
        public DateTime CreationTime { get; set; }




    }
}
