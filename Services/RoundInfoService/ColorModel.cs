namespace OwnedGame.Services.RoundInfoService
{
    public class ColorModel
    {
        public int R { get; private set; }
        public int G { get; private set; }
        public int B { get; private set; }

        public ColorModel(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}
