using System.Collections.Generic;


namespace DesafioJazzIrrigacao
{
    class Horta
    {
        public TamanhoHorta TamanhoHorta { get; private set; }

        public Horta(TamanhoHorta tamanhoHorta)
        {
            TamanhoHorta = tamanhoHorta;
        }

        public string GerarMovimentosRobo(IRobo robo, List<PosicaoRobo> canteiros)
        {
            var sequenciaMovimentos = "";

            foreach (var canteiro in canteiros)
            {
                sequenciaMovimentos += MoverNoEixoX(robo, canteiro);

                sequenciaMovimentos += MoverNoEixoY(robo, canteiro);

                sequenciaMovimentos += robo.Irrigar(canteiro);

            }
            return sequenciaMovimentos;
        }

        private string MoverNoEixoY(IRobo robo, PosicaoRobo canteiro)
        {
            var sequenciaMovimentos = "";

            while (robo.posicaoRobo.Y != canteiro.Y)
            {
                // Mover para o Leste
                if(robo.posicaoRobo.Y < canteiro.Y)
                {
                    sequenciaMovimentos += robo.Girar_Norte();
                    sequenciaMovimentos += robo.Mover();
                }
                else // Mover robo para Oeste
                {
                    sequenciaMovimentos += robo.Girar_Sul();
                    sequenciaMovimentos += robo.Mover();
                }
            }
            return sequenciaMovimentos;
        }

        private string MoverNoEixoX(IRobo robo, PosicaoRobo canteiro)
        {
            var sequenciaMovimentos = "";
            while (robo.posicaoRobo.X != canteiro.X)
            {
                //Mover robo para Leste >>
                if (robo.posicaoRobo.X < canteiro.X)
                {
                    sequenciaMovimentos += robo.Girar_Leste();
                    sequenciaMovimentos += robo.Mover();
                }
                else // Mover robo para Oeste <<
                {
                    sequenciaMovimentos += robo.Girar_Oeste();
                    sequenciaMovimentos += robo.Mover();
                }
            }

            return sequenciaMovimentos;
        }
    }
}
