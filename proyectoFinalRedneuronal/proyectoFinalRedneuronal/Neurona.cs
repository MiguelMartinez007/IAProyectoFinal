using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoFinalRedneuronal
{
    class Neurona
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