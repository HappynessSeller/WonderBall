namespace Wonderseat
{
    public enum PlayerSide
    {
        Left,
        Right
    }

    public static class PlayerSideExtensions
    {
        public static PlayerSide GetOpponentSide(this PlayerSide side)
        {
            switch (side)
            {
                case PlayerSide.Left:
                    return PlayerSide.Right;
                case PlayerSide.Right:
                    return PlayerSide.Left;
                default:
                    throw new System.NotSupportedException($"Player side {side} is not supported");
            }
        }
    } 
}
