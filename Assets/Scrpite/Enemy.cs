using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scrpite{
	[RequireComponent(typeof(EventTrigger))]
	public class Enemy : MonoBehaviour{
		[SerializeField] private int startHp;
		[SerializeField] private float startMoveSpeed;

		private int _hp;
		private float _moveSpeed;

		private void Start(){
			_hp = startHp;
			_moveSpeed = startMoveSpeed;
		}

		public void TakeShoot(){
			_hp -= 1;
			_moveSpeed -= 0.1f;
			CheckState();
		}

		private void CheckState(){
			_moveSpeed = Mathf.Clamp(_moveSpeed, 0.3f, startMoveSpeed);
			if(_hp < 1){
				Die();
			}
		}

		private void Die(){
			gameObject.SetActive(false);
		}
	}
}