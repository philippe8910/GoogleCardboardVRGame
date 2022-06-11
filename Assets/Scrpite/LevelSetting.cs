using System;
using UnityEngine;

namespace Scrpite{
	public class LevelSetting : MonoBehaviour{
		[SerializeField] private int totalEnemyCount;
		[SerializeField] private EnemySpawner enemySpawner;
		[SerializeField] private int CurrentEnemyCount => enemySpawner.enemyReferenceList.Count;

		private void Update(){
			if(CurrentEnemyCount <= totalEnemyCount) return;
			enemySpawner.enabled = false;
			Debug.Log($"123");
		}
	}
}