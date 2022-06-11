using System;
using UnityEngine;

namespace Scrpite{
	public class LevelSetting : MonoBehaviour{
		[SerializeField] private int totalEnemyCount;
		[SerializeField] private EnemySpawner enemySpawner;
		[SerializeField] private int CurrentEnemyCount => enemySpawner.enemyReferenceList.Count;

		private void Update(){
			if(CurrentEnemyCount <= totalEnemyCount) return;

			totalEnemyCount += 10;
			enemySpawner._timeMax -= 0.4f;
			enemySpawner._timeMax = Mathf.Clamp(enemySpawner._timeMax, 0.5f, 3);

		}
	}
}