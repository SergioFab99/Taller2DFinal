using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BossAI
{
    public interface iBossAttack
    {
        int Cooldown();
        void Attack();
    }
}
