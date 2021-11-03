namespace DesafioJazzIrrigacao
{
    public class PosicaoRobo
    {
        public PosicaoRobo(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }


        public void AtualizarPosicao(Vetor input)
        {
            X += input.X;
            Y += input.Y;
        }
    }
}
