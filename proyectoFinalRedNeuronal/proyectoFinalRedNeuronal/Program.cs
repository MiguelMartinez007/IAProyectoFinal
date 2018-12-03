using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoFinalRedNeuronal
{
    class Program
    {
        static void Main(string[] args)
        {
            Neurona neurona = new Neurona();
            Random r = new Random();

            neurona.pesos = new float[2];
            neurona.umbral = 0f;

            // ERROR = LO QUE NESESITAMOS - LO QUE TENEMOS
            // TASA DE APRENDIZAJE = 0.3f
            // PESO = PESO ANTERIOR + TASA DE APRENDIZAJE * ERROR + ENTRADA

            float[] pesosAnteriores =  new float[0];
            float umbralAnterior = -10;

            float tasaAprendizaje = .3f;

            bool sw = false;
            while (!sw)
            {
                sw = true;

                if (pesosAnteriores.Length == 0)
                {
                    // se les aplica el random a los pesos y al umbral
                    neurona.pesos[0] = Convert.ToSingle(r.NextDouble() - r.NextDouble());
                    neurona.pesos[1] = Convert.ToSingle(r.NextDouble() - r.NextDouble());
                    neurona.umbral = Convert.ToSingle(r.NextDouble() - r.NextDouble());
                    // Agregamos los datos anteriores
                    pesosAnteriores = new float[2];
                    pesosAnteriores = neurona.pesos;
                    umbralAnterior = neurona.umbral;
                }

                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Peso1: " + neurona.pesos[0]);
                Console.WriteLine("Peso2: " + neurona.pesos[1]);
                Console.WriteLine("Umbral: " + neurona.umbral);
                Console.WriteLine("E1:1 E2:1 : " + neurona.salida(new float[] { 1f, 1f }));
                Console.WriteLine("E1:1 E2:0 : " + neurona.salida(new float[] { 1f, 0f }));
                Console.WriteLine("E1:0 E2:1 : " + neurona.salida(new float[] { 0f, 1f }));
                Console.WriteLine("E1:0 E2:0 : " + neurona.salida(new float[] { 0f, 0f }));

                if (neurona.salida(new float[2] { 1f, 1f }) != 1)
                {
                    calcularPesos(pesosAnteriores, neurona, tasaAprendizaje, umbralAnterior);
                    sw = false;
                }
                if (neurona.salida(new float[2] { 1f, 0f }) != 0)
                {
                    sw = false;
                }
                if (neurona.salida(new float[2] { 0f, 1f }) != 0)
                {
                    sw = false;
                }
                if (neurona.salida(new float[2] { 0f, 0f }) != 0)
                {
                    sw = false;
                }

                // Se le aplica la funcion sinmoide
            }

            Console.ReadKey();
        }

        private static void calcularPesos(float[] pesosAnteriores, Neurona neurona, float tasaAprendizaje, float umbralAnterior)
        {
            if (pesosAnteriores.Length != 0)
            {
                // ERROR = LO QUE NESESITAMOS - LO QUE TENEMOS
                // PESO = PESO ANTERIOR + TASA DE APRENDIZAJE * ERROR + ENTRADA
                neurona.pesos[0] = pesosAnteriores[0] + tasaAprendizaje * (1 - neurona.salida(new float[2] { 0f, 1f })) * 1;
                neurona.pesos[1] = pesosAnteriores[1] + tasaAprendizaje * (1 - neurona.salida(new float[2] { 0f, 1f })) * 1;
                neurona.umbral = umbralAnterior + tasaAprendizaje * (1 - neurona.salida(new float[2] { 0f, 1f })) * 1;
            }
        }

        float Neurona(float entrada1, float entrada2, float peso1, float peso2, float umbral)
        {
            // Se hace la sumatoria de las entradas con los pesos y el umbral
            return umbral + entrada1 * peso1 + entrada2 * peso2;
        }

        float funcion(float d)
        {
            return d > 0 ? 1 : 0;
        }
    }

    public class Neurona
    {
        public float[] pesos;
        public float umbral;
        public float salida(float[] entradas)
        {
            return Sigmoide(neurona(entradas));
        }



        float neurona(float[] entradas)
        {
            // Se hace la sumatoria de las entradas con los pesos y el umbral
            float sum = 0;

            for (int i = 0; i < pesos.Length; i++)
            {
                sum += entradas[i] * pesos[i];
            }
            sum += umbral;

            return sum;
        }

        float Sigmoide(float d)
        {
            return d > 0 ? 1 : 0;
        }
    }
}
