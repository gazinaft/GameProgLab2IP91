using UnityEngine;

namespace PlayerState
{
    public interface IPlayerState
    {
        void Init(PlayerStateful go);
        void Update();
        void Ground(bool isGrounded);
        void Up();
        void Down();
        void Sprint();
        void NonSprint();
    }
}