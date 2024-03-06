using UnityEngine;

namespace Reward
{
    internal class RewardSpawner
    {
        private SpawnData _spawnData;
        private Transform _spawnCenter;
        private float _sqrR1, _sqrR2;
        private RewardPool _pool;

        public RewardSpawner(RewardView prefab, SpawnData spawnData, int maxRewardsCount,
            Transform spawnCenter, Vector3 rouletteCenter)
        {
            _spawnData = spawnData;
            _pool = new RewardPool(prefab, maxRewardsCount, spawnCenter, rouletteCenter);
            _spawnCenter = spawnCenter;
            _sqrR1 = Mathf.Pow(_spawnData.R1, 2);
            _sqrR2 = Mathf.Pow(_spawnData.R2, 2);
        }

        public float Spawn(Sprite sprite)
        {
            var obj = _pool.Get();
            Vector3 position = CalculatePosition();
            var lifeTime = Random.Range(_spawnData.HideMinDelay, _spawnData.HideMaxDelay);
            obj.Show(sprite, position, _spawnData.ShowDuration, lifeTime, _spawnData.HideDuration);

            lifeTime += _spawnData.ShowDuration + _spawnData.HideDuration;
            return lifeTime;
        }

        private Vector3 CalculatePosition()
        {
            Vector3 position = Vector3.zero;
            position.x = Random.Range(-_spawnData.R2, _spawnData.R2);
            var sqrX = Mathf.Pow(position.x, 2);
            var minYSqr = _sqrR1 - sqrX;
            var maxYSqr = _sqrR2 - sqrX;

            if (minYSqr < 0)
            {
                var maxY = Mathf.Sqrt(maxYSqr);
                position.y = Random.Range(-maxY, maxY);
            }
            else
            {
                var maxY = Mathf.Sqrt(maxYSqr);
                var minY = Mathf.Sqrt(minYSqr);
                position.y = Random.Range(minY, maxY) * Mathf.Sign(Random.Range(-1, 1));
            }

            position += _spawnCenter.position;
            return position;
        }
    }
}