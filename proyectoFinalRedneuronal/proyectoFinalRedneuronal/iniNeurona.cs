using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoFinalRedneuronal
{
    class iniNeurona
    {
        // Valores de la tabla And
        public float[][] entradas = { new float[2] { 1f, 1f }, new float[2] { 1f, 0f }, new float[2] { 0f, 1f }, new float[2] { 0f, 0f } };
        public float[] salidas = { 1, 1, 1, 0 };

        public void config(ListBox l)
        {
            Neurona neurona = new Neurona(2, 0.4f);

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
                l.Items.Add("------------------------------------------");
                l.Items.Add("Peso1: " + neurona.pesos[0]);
                l.Items.Add("Peso2: " + neurona.pesos[1]);
                l.Items.Add("Umbral: " + neurona.umbral);

                for (int i = 0; i < entradas.Length; i++)
                {
                    Console.WriteLine("E1:" + entradas[i][0] + " E2:" + entradas[i][1] + "  = " + neurona.salida(entradas[i]));
                    l.Items.Add("E1:" + entradas[i][0] + " E2:" + entradas[i][1] + "  = " + neurona.salida(entradas[i]));
                    if (neurona.salida(entradas[i]) != salidas[i])
                    {
                        neurona.aprender(entradas[i], salidas[i]);
                        sw = false;
                    }
                }
            }
        }
        public void config()
        {
            Neurona neurona = new Neurona(2, 0.4f);

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

                for (int i = 0; i < entradas.Length; i++)
                {
                    Console.WriteLine("E1:" + entradas[i][0] + " E2:" + entradas[i][1] + " " + neurona.salida(entradas[i]));
                    
                    if (neurona.salida(entradas[i]) != salidas[i])
                    {
                        neurona.aprender(entradas[i], salidas[i]);
                        sw = false;
                    }
                }
            }
        }
    }
}
