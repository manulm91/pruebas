/*
 Práctica evaluable Tema 4
 Ejercicio 2
*/

using System;

public class Temperaturas
{
    enum meses { ENERO = 1, FEBRERO, MARZO, ABRIL, MAYO, JUNIO, JULIO, AGOSTO,
                 SEPTIEMBRE, OCTUBRE, NOVIEMBRE, DICIEMBRE }

    public static void Main()
    {
        // Array de arrays para almacenar las 12 filas de temperaturas
        const int FILAS = 12;
        int[][] temperaturas = new int[FILAS][];
        
        // Variables auxiliares
        int tempMayor, tempMenor, mesMayor, mesMenor;
        int totalTemperaturas = 0, sumTemperaturas = 0;
        float media;
        // Variables para recoger las temperaturas de cada fila y trocearlas por espacios
        string lineaTemperaturas;
        string[] partesTemperaturas;
        
        for (int i = 0; i < FILAS; i++)
        {
            Console.WriteLine("Escribe las temperaturas, separadas por un espacio, para {0}", (meses)(i+1));
            lineaTemperaturas = Console.ReadLine();
            partesTemperaturas = lineaTemperaturas.Split();   // Por defecto separa por espacios
            
            // Reservamos espacio en la fila i para el total de temperaturas introducidas
            temperaturas[i] = new int[partesTemperaturas.Length];
            
            // Asignamos cada temperatura (convertida a entero) en su posición
            for (int j = 0; j < partesTemperaturas.Length; j++)
            {
                temperaturas[i][j] = Convert.ToInt32(partesTemperaturas[j]);
                // Vamos contando temperaturas para calcular luego la media
                totalTemperaturas++;
                sumTemperaturas += temperaturas[i][j];
            }
        }

        media = sumTemperaturas / (float)totalTemperaturas;

        // Buscamos mayor y menor temperatura
        // Comenzamos suponiendo que ambas están en ENERO, en la primera temperatura,
        // y buscamos a partir de ahí otra temperatura que las supere
        tempMayor = tempMenor = temperaturas[0][0];
        mesMayor = mesMenor = (int)(meses.ENERO);

        for (int i = 0; i < FILAS; i++)
        {
            for (int j = 0; j < temperaturas[i].Length; j++)
            {
                if (temperaturas[i][j] < tempMenor)
                {
                    tempMenor = temperaturas[i][j];
                    mesMenor = i+1;
                }
                else if (temperaturas[i][j] > tempMayor)
                {
                    tempMayor = temperaturas[i][j];
                    mesMayor = i+1;
                }
            }
        }
        Console.WriteLine();
        Console.WriteLine("La temperatura mínima ha sido de {0} grados, registrada en {1}", tempMenor, (meses)mesMenor);
        Console.WriteLine("La temperatura máxima ha sido de {0} grados, registrada en {1}", tempMayor, (meses)mesMayor);
        Console.WriteLine("La media total de temperaturas es de {0} grados", media.ToString("N2"));
    }
}
