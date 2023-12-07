using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BossAI
{
    public class SprayAttack : MonoBehaviour, iBossAttack
    {
        int cooldownTime = 0;
        public void Attack()
        {

        }
        public int Cooldown()
        {
            return cooldownTime;
        }
    }

}
