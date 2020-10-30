//#define LAP
using System.Collections.Generic;
using UnityEngine;


namespace CheckPointSystem
{
    public class CheckPointManager : MonoBehaviour
    {

        [SerializeField] private List<CheckPointController> checkPoints = new List<CheckPointController>();
        private int _lastPassedCheckPoint;

        private void Start()
        {
            for (int i = 0; i < checkPoints.Count; i++) {
                checkPoints[i].checkPointManager = this;
                if (i == 0) checkPoints[i].isMyTurn = true;
            }
        }

        public void SetLastPassedCheckPoint(int id)
        {
            _lastPassedCheckPoint = id;

            if (checkPoints.Count - 1 > id) {
                checkPoints[id + 1].isMyTurn = true;
            } else {
                Debug.Log("yarış bitti");
                GameManager.Instance().RestartGame();
            }
        }

    }
}



