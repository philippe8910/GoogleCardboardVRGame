using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePeople
{
    public class AnimationController : MonoBehaviour
    {

        Animator anim;
        public bool run;

        void Start()
        {
            anim = GetComponent<Animator>();
            anim.Play("Idle");
        }
    }
}
