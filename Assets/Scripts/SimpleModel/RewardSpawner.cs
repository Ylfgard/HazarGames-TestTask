using System.Collections;
using UnityEngine;

public class RewardSpawner : MonoBehaviour
{
    private const float SHOW_DURATION = 1f;
    private const float HIDE_MIN_DELAY = 1;
    private const float HIDE_MAX_DELAY = 2.5f;
    private const float HIDE_DURATION = 1f;
    private const float SPAWN_DURATION = 5f;

    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private GameStateController.GameStateController _stateController;

    [SerializeField] private RewardView _prefab;
    [SerializeField] private Transform _spawnCenter;
    [SerializeField] private int _r1, _r2;

    private float _sqrR1, _sqrR2;
    private RewardPool _pool;

    private void Awake()
    {
        _pool = new RewardPool(_prefab, _spawnCenter, _scoreView.Position);
        _sqrR1 = Mathf.Pow(_r1, 2);
        _sqrR2 = Mathf.Pow(_r2, 2);
    }

    public void StartSpawn()
    {
        _scoreView.Show();
        StartCoroutine(EndSpawn());
    }

    public void Spawn(int value, Sprite sprite)
    {
        var obj = _pool.Get();
        Vector3 position = CalculatePosition();
        var lifeTime = Random.Range(HIDE_MIN_DELAY, HIDE_MAX_DELAY);
        obj.Show(sprite, position, SHOW_DURATION, lifeTime, HIDE_DURATION);
        StartCoroutine(ReleaseReward(SHOW_DURATION + lifeTime + HIDE_DURATION, obj, value));
    }

    private Vector3 CalculatePosition()
    {
        Vector3 position = Vector3.zero;
        position.x = Random.Range(-_r2, _r2);
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

    private IEnumerator ReleaseReward(float lifeTime, RewardView obj, int reward)
    {
        yield return new WaitForSeconds(lifeTime - 0.1f);
        _scoreView.IncreaseScore(reward);
        _pool.Release(obj);
    }

    private IEnumerator EndSpawn()
    {
        yield return new WaitForSeconds(SPAWN_DURATION);
        _scoreView.Hide();
        _stateController.SetCooldownState();
    }
}