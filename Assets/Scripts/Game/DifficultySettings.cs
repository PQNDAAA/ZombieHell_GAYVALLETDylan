using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySettings : MonoBehaviour
{
    [SerializeField]
    private SO_DifficultySettings m_DifficultySettings;
    [SerializeField]
    private SO_Spawner m_Spawner;
    [SerializeField]
    private SO_Base m_Base;

    //Function that will launch when the button will be pressed
    //To change different values to increase the game "DifficultySettings"
    public void OnButtonClick()
    {
        m_Spawner.spawnRate = m_DifficultySettings.SpawnRateMonster;

        m_Spawner.e_EnemyChanceToSpawn = m_DifficultySettings.ChanceToSpawn;

        m_Base.removeScore = m_DifficultySettings.removeScoreBase;
        m_Base.health = m_DifficultySettings.healthBase;

    }


}
