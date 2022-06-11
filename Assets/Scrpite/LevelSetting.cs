using UnityEngine;

namespace Scrpite{
	public class LevelSetting : MonoBehaviour{
		[SerializeField] private int totalEnemyCount;
		[SerializeField] private EnemySpawner enemySpawner;
		private int CurrentEnemyCount => enemySpawner.enemyReferenceList.Count;
	}
}