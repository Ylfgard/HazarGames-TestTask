using System;
using System.Collections;
using UnityEngine;

namespace GameStateController
{
    public class GameStateController : MonoBehaviour
    {
        public Action<int> CooldownTicked;

        private const int COOLDOWN = 10;

        public BaseGameState CooldownState;

        private void Awake()
        {
            CooldownState = new CooldownState(this);
        }

        public void SetCooldownState()
        {
            StartCoroutine(Cooldown());
        }

        private IEnumerator Cooldown()
        {
            for (int t = COOLDOWN; t > 0; t--)
            {
                CooldownTicked?.Invoke(t);
                yield return new WaitForSeconds(1);
            }
        }

        private void Start()
        {
            SetCooldownState();
        }
    }
}