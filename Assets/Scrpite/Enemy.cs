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
		private Rigidbody _rigidbody;
		private Transform _target;

		[SerializeField] private Pistal pistal;

		private void Start(){
			_hp = startHp;
			_moveSpeed = startMoveSpeed;
			_rigidbody = GetComponent<Rigidbody>();

			pistal = GameObject.FindObjectOfType<Pistal>().GetComponent<Pistal>();
		}

		private void Update(){
			var distance = Vector3.Distance(transform.position, _target.position);
			if(distance < 0.3){
				_moveSpeed = 0;
			}

			var forward = transform.forward;
			var forwardDirection = forward * _moveSpeed;
			_rigidbody.velocity = forwardDirection;
		}

		public void GetFire()
		{
			pistal.Shooting();
		}

		public void SetTarget(Transform target){
			_target = target;
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

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				GameObject.FindObjectOfType<PlayerHpBar>().Hurt(0.1f);
				Destroy(gameObject);
			}
		}
	}
}