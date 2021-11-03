// Interface Robo
namespace DesafioJazzIrrigacao
{
    public interface IRobo
    {
        Orientacao Orientacao { get; }
        PosicaoRobo posicaoRobo { get; }

        string Irrigar(PosicaoRobo canteiro);
        string Mover();
        string Girar_Norte();
        string Girar_Sul();
        string Girar_Leste();
        string Girar_Oeste();
    }

    public class AcoesRobo: IRobo
    {
        public AcoesRobo(Orientacao orientacao, PosicaoRobo PosicaoRobo)
        {
            Orientacao = orientacao;
            posicaoRobo = PosicaoRobo;
        }

        public Orientacao Orientacao { get; private set; }
        public PosicaoRobo posicaoRobo { get; private set; }

        //Método para mover o robo
        public string Mover()
        {
            var direcao = new Vetor(0, 0);

            switch (Orientacao)
            {
                case Orientacao.Norte:
                    direcao = new Vetor(0, 1);
                    break;

                case Orientacao.Sul:
                    direcao = new Vetor(0, -1);
                    break;

                case Orientacao.Oeste:
                    direcao = new Vetor(-1, 0);
                    break;

                case Orientacao.Leste:
                    direcao = new Vetor(1, 0);
                    break;
            }

            if (direcao.X == 0 && direcao.Y == 0)
                return "";

            posicaoRobo.AtualizarPosicao(direcao);

            return "M";
        }
        //Compara as posição atual com as da classe orientação, e retorna 
        public string Girar_Norte()
        {
            if (Orientacao == Orientacao.Norte) return "";

            string sequencia;
            if (Orientacao == Orientacao.Leste)
                sequencia = "E";
            else if (Orientacao == Orientacao.Oeste)
                sequencia = "D";
            else
                sequencia = "EE";

            Orientacao = Orientacao.Norte;
            return sequencia;
        }

        public string Girar_Sul()
        {
            if (Orientacao == Orientacao.Sul) return "";

            string sequencia;
            if (Orientacao == Orientacao.Leste)
                sequencia = "D";
            else if (Orientacao == Orientacao.Oeste)
                sequencia = "E";
            else
                sequencia = "EE";

            Orientacao = Orientacao.Sul;
            return sequencia;
        }

        public string Girar_Leste()
        {
            if (Orientacao == Orientacao.Leste) return "";

            string sequencia;
            if (Orientacao == Orientacao.Sul)
                sequencia = "E";
            else if (Orientacao == Orientacao.Norte)
                sequencia = "D";
            else
                sequencia = "EE";

            Orientacao = Orientacao.Leste;

            return sequencia;
        }

        public string Girar_Oeste()
        {
            if (Orientacao == Orientacao.Oeste) return "";

            string sequencia;
            if (Orientacao == Orientacao.Sul)
                sequencia = "D";
            else if (Orientacao == Orientacao.Norte)
                sequencia = "E";
            else
                sequencia = "EE";

            Orientacao = Orientacao.Oeste;
            return sequencia;
        }

        public string Irrigar(PosicaoRobo canteiro)
        {
            if (posicaoRobo.X == canteiro.X && posicaoRobo.Y == canteiro.Y)
            {
                return "I";
            }

            return "";
        }
    }
    
}
