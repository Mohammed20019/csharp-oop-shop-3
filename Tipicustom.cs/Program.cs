namespace TipiCustom
{
    public readonly struct Litri
    {
        private readonly double v;

        public Litri(double v)
        {
            if (v is < 0) { throw new ArgumentOutOfRangeException(nameof(v)); }
            this.v = v;
        }

        public static implicit operator Litri(double v) { return new Litri(v); }
        public static implicit operator double(Litri litri) { return litri.v; }
        public override string ToString()
        {
            return v.ToString();
        }
    }

    public readonly struct PH
    {
        private readonly double v;

        public PH(double v)
        {
            if (v is < 0 or > 14) { throw new ArgumentOutOfRangeException(nameof(v)); }
            this.v = v;
        }

        public static implicit operator PH(double v) { return new PH(v); }
        public static implicit operator double(PH litri) { return litri.v; }
        public override string ToString()
        {
            return v.ToString();
        }
    }
}