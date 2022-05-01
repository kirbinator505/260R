using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public GameObject spawnManager;

    public void SaveGameState()
    {
        SaveSystem.SavePlayer(PlayerManager.instance.player.GetComponent<TMPPlayerController>(), PlayerManager.instance.player.GetComponent<PlayerStats>());
        SaveSystem.SaveWave(spawnManager.GetComponent<EnemySpawner>());
    }

    public void LoadGameState()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        PlayerManager.instance.player.GetComponent<TMPPlayerController>().agent.ResetPath();
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        PlayerManager.instance.player.transform.position = position;
        PlayerManager.instance.player.GetComponent<PlayerStats>().currentHealth = data.health;

        WaveData waveData = SaveSystem.LoadWave();
        spawnManager.GetComponent<EnemySpawner>().wave = waveData.wave;
        spawnManager.GetComponent<EnemySpawner>().isFirstSpawn = waveData.isFirst;
    }

    public void SaveBaseGameState()
    {
        Debug.Log("saving base state");
        SaveSystem.SaveBasePlayer(PlayerManager.instance.player.GetComponent<TMPPlayerController>(), PlayerManager.instance.player.GetComponent<PlayerStats>());
        SaveSystem.SaveBaseWave(spawnManager.GetComponent<EnemySpawner>());
    }

    public void LoadBaseGameState()
    {
        PlayerData data = SaveSystem.LoadBasePlayer();
        PlayerManager.instance.player.GetComponent<TMPPlayerController>().agent.ResetPath();
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        PlayerManager.instance.player.transform.position = position;
        PlayerManager.instance.player.GetComponent<PlayerStats>().currentHealth = data.health;
        
        WaveData waveData = SaveSystem.LoadBaseWave();
        spawnManager.GetComponent<EnemySpawner>().wave = waveData.wave;
        spawnManager.GetComponent<EnemySpawner>().isFirstSpawn = waveData.isFirst;
        spawnManager.GetComponent<EnemySpawner>().ResetEnemies();
    }
}
