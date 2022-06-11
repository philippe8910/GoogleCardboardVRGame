using System.Collections.Generic;
using UnityEngine;

namespace Scrpite{
	public class EnemySpawner : MonoBehaviour{
		[SerializeField] private Transform target;
		[SerializeField] private List<GameObject> enemyTypes;
		[SerializeField] private List<Transform> spawnPoints;

		public List<GameObject> enemyReferenceList = new List<GameObject>();


		private ColdDownTimer _timer;

		private void Start(){
			_timer = new ColdDownTimer(3f);
		}

		private void Update(){
			var canInvoke = _timer.CanInvoke();
			if(!canInvoke) return;
			RandomSpawn();
			var randomNumber = Random.Range(2, 5);
			_timer.ModifyDuring(randomNumber);
			_timer.Reset();
		}

		private void RandomSpawn(){
			var randomEnemyNumber = Random.Range(0, enemyTypes.Count);
			var enemyPrefab = enemyTypes[randomEnemyNumber];
			var randomSpawnNumber = Random.Range(0, spawnPoints.Count);
			var randomPosition =
					spawnPoints[randomSpawnNumber].position + Vector3.up * enemyPrefab.transform.position.y;
			var enemyPre = Instantiate(enemyPrefab, randomPosition, spawnPoints[randomSpawnNumber].rotation);
			var enemy = enemyPre.GetComponent<Enemy>();
			enemy?.SetTarget(target);
			enemyReferenceList.Add(enemyPre);
		}
	}
}