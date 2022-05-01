
[System.Serializable]
public class WaveData
{
    public int wave;
    public bool isFirst;

    public WaveData(EnemySpawner spawner)
    {
        wave = spawner.wave;
        isFirst = spawner.isFirstSpawn;
    }
}
