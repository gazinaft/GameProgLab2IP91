using PlayerState;

public interface IStatefull
{
    IPlayerState PlayerState { get; set; }
}