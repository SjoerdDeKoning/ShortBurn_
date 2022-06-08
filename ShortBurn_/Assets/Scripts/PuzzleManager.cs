using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle
{
    public class PuzzleManager : MonoBehaviour
    {
        public bool cushion1, cushion2, cushion3, cushion4;

        public GameObject basementKey;

        void Update()
        {
            if (cushion1 && cushion2 && cushion3 && cushion4)
            {
                basementKey.gameObject.SetActive(true);
            }
        }

        public void CushionActivation(int number)
        {
            if (number == 1)
            {
                cushion1 = true;
            }

            if (number == 2 && cushion1 ) 
            {
                cushion2 = true;
            }

            if (number == 3 && cushion2 == true) 
            {
                cushion3 = true;
            }

            if (number == 4 && cushion3 == true) 
            {
                cushion4 = true;
            }
        }
    }
}