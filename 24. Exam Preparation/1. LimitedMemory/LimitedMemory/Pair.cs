namespace LimitedMemory
{
    public class Pair<TK, TV>
    {

        public TK Key { get; set; }

        public TV Value { get; set; }

        public Pair(TK key, TV value)
        {
            Key = key;
            Value = value;
        }
    }
}
