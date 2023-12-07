using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BossAI
{
    public class AttackSelector : MonoBehaviour
    {
        public int attacksDoneCounter = 0;
        private iBossAttack CurrentAttack;
        public AttackSelector(iBossAttack attack)
        {
            CurrentAttack = attack;
        }
        public void changeAttack(iBossAttack attack)
        {
            CurrentAttack = attack;
        }
        public iBossAttack Ataque
        {get => CurrentAttack;}
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
