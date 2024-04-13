using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unchord
{
    public class TestPlayer : MonoBehaviour
    {
        public float speed = 3.0f;
        public float force = 20.0f;

        public float ix;
        public float jf;

        public TestGround steppedGround;
        public SoundLooper footstepSFX;

        private void Start()
        {
            footstepSFX = new SoundLooper("event:/SFX/Footstep/Stone", 1.22f, true);
        }

        private void FixedUpdate()
        {
            if (jf > 0.0f)
                jf -= Time.fixedDeltaTime * 49.5f;

            transform.position += Vector3.right * ix * speed * Time.fixedDeltaTime;
            transform.position += Vector3.up * jf * Time.fixedDeltaTime;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.55f, 1 << 7);

            if (hit)
            {
                steppedGround = hit.collider.GetComponent<TestGround>();

                if(!footstepSFX.EventPath.Equals(steppedGround.footstepSFX))
                    footstepSFX.EventPath = steppedGround.footstepSFX;
            }
            else
                steppedGround = null;

            footstepSFX.Paused = (steppedGround == null) || (ix == 0.0f);
        }

        void Update()
        {
            ix = Input.GetAxisRaw("Horizontal");

            if (Input.GetKeyDown(KeyCode.Space))
                jf = force;

            footstepSFX.UpdateAndPlay();
        }
    }
}