namespace AIRLab.CA.Groups
{
    /// <summary>
    /// The group F(2)
    /// </summary>
    public sealed class BooleanGroup
    {
        public static BooleanGroup operator |(BooleanGroup node1, BooleanGroup node2)
        {
            return new BooleanGroup();
        }

        public static BooleanGroup operator !(BooleanGroup node1)
        {
            return new BooleanGroup();
        }
    }
}
