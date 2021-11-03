using System;
using System.Collections.Generic;

namespace DesafioJazzIrrigacao
{
    public class EntradaDados
    {
        public TamanhoHorta TamanhoHorta { get; private set; }
        public PosicaoRobo PosicaoRobo { get; private set; }
        public Orientacao Orientacao { get; private set; }
        public List<PosicaoRobo> Canteiros { get; private set; }

        public bool Valido { get; private set; }

        public void LerEntradas()
        {
            Console.WriteLine("Digite o tamanho da Horta no eixo X: ");
            var hortaX = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o tamanho da Horta no eixo Y: ");
            var hortaY = int.Parse(Console.ReadLine());

            ParseTamanhoHorta(hortaX, hortaY);
            if (!Valido) return;

            Console.WriteLine("Digite a posição do Robo no eixo X: ");
            var roboX = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a posição do Robo no eixo Y: ");
            var roboY = int.Parse(Console.ReadLine());            

            Console.WriteLine("Digite a orientação do Robo(N, S, L, O): ");
            var orientacao = Console.ReadLine();

            ParseRobo(roboX, roboY, orientacao);
            if (!Valido) return;


            Console.WriteLine("Digite a quatidade de canteiros a serem irrigada:");
            var qtdCanteiros = int.Parse(Console.ReadLine());

            var posicoes = new List<Vetor>();
            for(var i = 0; i<qtdCanteiros; i++)
            {
                Console.WriteLine($"Digite a posição X do canteiro {i+1}: ");
                var posicaoX = int.Parse(Console.ReadLine());

                Console.WriteLine($"Digite a posição Y do canteiro {i + 1}: ");
                var posicaoY = int.Parse(Console.ReadLine());

                posicoes.Add(new Vetor(posicaoX, posicaoY));
            }
           
            ParseCanteiros(qtdCanteiros, posicoes);
            if (!Valido) return;

            Valido = true;
        }

        private void ParseTamanhoHorta(int hortaX, int hortaY)
        {
            try
            {

                if(hortaX <= 0 || hortaX <= 0)
                {
                    Console.WriteLine("O tamanho da horta não pode ser negativo, ou igual a zero.");
                    Valido = false;
                    return;
                }
                TamanhoHorta = new TamanhoHorta(hortaX, hortaX);
            }
            catch (FormatException)
            {
                Console.WriteLine("O tamanho da horta tem que ser informado em números.");
                Valido = false;
                return;
            }
            Valido = true;
        }

        private void ParseRobo(int roboX, int roboY, string EntradaOrientacao)
        {
            try
            {
                if((roboX > TamanhoHorta.X || roboX < 0) || (roboY > TamanhoHorta.Y || roboY < 0))
                {
                    Console.WriteLine("Posição do robo inválida, digite uma posição dentro dos limites da Horta.");
                    Valido = false;
                    return;
                }
                PosicaoRobo = new PosicaoRobo(roboX, roboY);
            }
            catch (FormatException)
            {
                Console.WriteLine("A posição do robo deve ser informada em números.");
                Valido = false;
                return;
            }

            if (EntradaOrientacao == "N")
            {
                Orientacao = Orientacao.Norte;
            }
            else if (EntradaOrientacao == "S")
            {
                Orientacao = Orientacao.Sul;
            }
            else if (EntradaOrientacao == "L")
            {
                Orientacao = Orientacao.Leste;
            }
            else if (EntradaOrientacao == "O")
            {
                Orientacao = Orientacao.Oeste;
            }
            else
            {
                Orientacao = Orientacao.Indefinida;
            }

            if (Orientacao == Orientacao.Indefinida)
            {
                Console.WriteLine("Digite uma orientação válida para o robo: \"N S L O\"");
                Valido = false;
                return;
            }
            Valido = true;
        }

        public void ParseCanteiros(int qtdCanteiros, List<Vetor> posicoes)
        {

            if(qtdCanteiros != posicoes.Count)
            {
                Console.WriteLine("O numero de canteiros não coincide com as posições informadas.");
                Valido = false;
                return;
            }
            Canteiros = new List<PosicaoRobo>(qtdCanteiros);

            for (var i = 0; i< posicoes.Count; i++)
            {
                var canteiro = new PosicaoRobo(posicoes[i].X, posicoes[i].Y);
                Canteiros.Add(canteiro);
            }
            Valido = true;
        }
    }
    
}
