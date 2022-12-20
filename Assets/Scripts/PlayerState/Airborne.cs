using UnityEngine;

namespace PlayerState
{
    public class Airborne : IPlayerState
    {
        private PlayerStateful _player;
        private float _defaultGravity;
        public bool _dashed;

        public Airborne()
        {
            _dashed = false;
        }
        
        public void Init(PlayerStateful go)
        {
            _player = go;
            _defaultGravity = _player.gravity;
            _dashed = false;
        }

        public void Update()
        { }

        public void Ground(bool isGrounded)
        {
            if (!isGrounded) return;
            Debug.Log("Grounded");
            _player.gravity = _defaultGravity;
            var gr = new Grounded();
            gr.Init(_player);
            _player.PlayerState = gr;
        }

        public void Up()
        {
            if (_dashed) return;
            _player.velocity.y = Mathf.Sqrt(_player.jumpHeight * -2f * _player.gravity);
            _dashed = true;
        }

        public void Down()
        {
            // Debug.Log("Down airborne");
            _player.gravity *= 4;
        }

        public void Sprint()
        {
        }

        public void NonSprint()
        {
            
        }
    }
}