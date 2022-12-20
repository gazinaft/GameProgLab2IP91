using UnityEngine;

namespace PlayerState
{
    public class Grounded : IPlayerState
    {
        private PlayerStateful _player;
        public void Init(PlayerStateful go)
        {
            _player = go;
        }

        public void Update()
        {
            if (_player.velocity.y < 0)
            {
                _player.velocity.y = -2f;
            }
            
        }

        public void Ground(bool isGrounded)
        {
            if (isGrounded) return;
            Debug.Log("Jumped");
            var air = new Airborne();
            air.Init(_player);
            _player.PlayerState = air;
        }

        public void Up()
        {
            _player.velocity.y = Mathf.Sqrt(_player.jumpHeight * -2f * _player.gravity);
        }

        public void Down()
        { }

        public void Sprint()
        {
        }

        public void NonSprint()
        {
        }
    }
}