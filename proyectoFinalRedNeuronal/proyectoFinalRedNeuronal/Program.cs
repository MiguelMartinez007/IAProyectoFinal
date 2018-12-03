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
            Neurona neurona = new Neurona(2, 0.4f);
            Random r = new Random();

            // ERROR = LO QUE NESESITAMOS - LO QUE TENEMOS
            // TASA DE APRENDIZAJE = 0.3f
            // PESO = PESO ANTERIOR + TASA DE APRENDIZAJE * ERROR + ENTRADA
            
            bool sw = false;
            while (!sw)
            {
                sw = true;

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
                    neurona.aprender(new float[2] { 1f, 1f }, 1);
                    sw = false;
                }
                if (neurona.salida(new float[2] { 1f, 0f }) != 0)
                {
                    neurona.aprender(new float[2] { 1f, 0f }, 0);
                    sw = false;
                }
                if (neurona.salida(new float[2] { 0f, 1f }) != 0)
                {
                    neurona.aprender(new float[2] { 0f, 1f }, 0);
                    sw = false;
                }
                if (neurona.salida(new float[2] { 0f, 0f }) != 0)
                {
                    neurona.aprender(new float[2] { 0f, 0f }, 0);
                    sw = false;
                }
            }

            Console.ReadKey();
        }
    }

    public class Neurona
    {
        float[] pesosAnteriores;
        float umbralAnterior;
        // PESO = PESO ANTERIOR + TASA DE APRENDIZAJE * ERROR + ENTRADA
        public float[] pesos;
        public float umbral;
        float tasaAprendizaje;



        public Neurona(int nEntradas, float tasaAprendizaje = 3.0f)
        {
            this.tasaAprendizaje = tasaAprendizaje;
            pesos = new float[nEntradas];
            pesosAnteriores = new float[nEntradas];
            aprender();
        }

        public void aprender()
        {
            
            Random r = new Random();
            for (int i = 0; i < pesosAnteriores.Length; i++)
            {
                pesosAnteriores[i] = Convert.ToSingle(r.NextDouble() - r.NextDouble());
            }
            umbralAnterior = Convert.ToSingle(r.NextDouble() - r.NextDouble());

            pesos = pesosAnteriores;
            umbral = umbralAnterior;
        }
        public void aprender(float[] entradas, float salidaEsperada)
        {
            if (pesosAnteriores != null)
            {
                float error = salidaEsperada - salida(entradas);
                for (int i = 0; i < pesos.Length; i++)
                {
                    pesos[i] = pesosAnteriores[i] + tasaAprendizaje * error * entradas[i];
                }
                umbral = umbralAnterior + tasaAprendizaje * error;
                pesosAnteriores = pesos;
                umbralAnterior = umbral;
            }
            else
            {
                Random r = new Random();
                for (int i = 0; i < pesosAnteriores.Length; i++)
                {
                    pesosAnteriores[i] = Convert.ToSingle(r.NextDouble() - r.NextDouble());
                }
                umbralAnterior = Convert.ToSingle(r.NextDouble() - r.NextDouble());

                pesos = pesosAnteriores;
                umbral = umbralAnterior;
            }
        }

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
