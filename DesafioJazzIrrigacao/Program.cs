using System;

namespace DesafioJazzIrrigacao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite os dados para executar: ");  

            var entradas = new EntradaDados();
            entradas.LerEntradas();

            if(entradas.Valido == false)
            {
                Console.Read();
                return;
            }

            var horta = new Horta(entradas.TamanhoHorta);

            var robo = new AcoesRobo(entradas.Orientacao, entradas.PosicaoRobo);

            var sequenciaMovimentos = horta.GerarMovimentosRobo(robo, entradas.Canteiros);

            EscreverCaminho(sequenciaMovimentos);

            Console.WriteLine($"Orientação Final: {robo.Orientacao}");
            Console.ReadLine();
        }

        static void EscreverCaminho(string entrada)
        {
            Console.WriteLine("Caminho: ");
            for(var i = 0; i <entrada.Length; i++)
            {
                if(i == 0)
                {
                    Console.Write($"{entrada[i]}");
                }
                else
                {
                    Console.Write($" {entrada[i]}");
                }
            }

            Console.Write(Environment.NewLine);
        }
    }
}
