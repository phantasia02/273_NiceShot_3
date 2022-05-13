using UnityEngine;
using LanKuDot.UnityToolBox;
using System.Collections.Generic;

namespace MYgame.Scripts.Scenes.GameScenes.Data
{
    [CreateAssetMenu(
        menuName = "Data/Stage Data",
        fileName = "StageData")]
    public class StageData : ScriptableObject
    {
        [SerializeField]
        private bool _WinMoveWinPos = false;

        [SerializeField]
        private Vector3 _AddForce = Vector3.zero;

        [SerializeField]
        private float _PredictionTime = 2.0f;

        [SerializeField]
        private float _PredictionBallSize = 1.0f;


        public bool WinMoveWinPos => _WinMoveWinPos;
        public Vector3 AddForce => _AddForce;
        public float PredictionTime => _PredictionTime;
        public float PredictionBallSize => _PredictionBallSize;

    }
}
