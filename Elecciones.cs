/*
 Práctica evaluable Tema 4
 Ejercicio 1
*/

using System;

class Elecciones
{
    // Estructura para almacenar la dirección de la sede
    struct sedePartido
    {
        public string calle;
        public ushort numero;
        public string codigoPostal;
        public string ciudad;
    }
    
    // Estructura para almacenar los datos de cada partido
    struct partido
    {
        public string siglas;
        public string nombre;
        public int votos;
        public float porcentajeVotos;
        public sedePartido sede;
    }
    
    // Programa principal
    static void Main()
    {
        // Array con tamaño para 20 partidos
        const ushort MAX_PARTIDOS = 20;
        partido[] partidos = new partido[MAX_PARTIDOS];
        
        // Variables auxiliares para las distintas opciones del menú
        int i, j, cantidad = 0, posicionABorrar, votosNulosBlancos, totalVotos;
        byte opcionMenu;
        string siglasABorrar, textoABuscar;
        bool encontrado;

        do
        {
            Console.Clear();
            Console.WriteLine("Menú de opciones");
            Console.WriteLine("1.- Añadir un partido a la lista");
            Console.WriteLine("2.- Borrar un partido de la lista");
            Console.WriteLine("3.- Ordenar por votos");
            Console.WriteLine("4.- Calcular porcentajes");
            Console.WriteLine("5.- Buscar partido");
            Console.WriteLine("0.- Salir");
            Console.WriteLine("Elige una opción del menú: ");
            opcionMenu = Convert.ToByte(Console.ReadLine());;

            switch (opcionMenu)
            {
                case 1: 
                
                    // Añadir nuevo partido al final de los existentes
                
                    Console.Clear();
                    Console.WriteLine("Introduce los datos del nuevo partido:");
                    Console.Write("Siglas: ");                    
                    partidos[cantidad].siglas = Console.ReadLine();
                    Console.Write("Nombre: ");                    
                    partidos[cantidad].nombre = Console.ReadLine();
                    // Pedimos el nº de votos hasta que sea correcto (entre 0 y 50 millones)
                    do
                    {
                        // Asignamos una cantidad negativa (inválida) al principio
                        partidos[cantidad].votos = -1;
                        try
                        {
                            Console.Write("Votos: ");
                            partidos[cantidad].votos = Convert.ToInt32(Console.ReadLine());
                        } catch (Exception) {}
                    }
                    while (partidos[cantidad].votos < 0 || partidos[cantidad].votos > 50000000);
                    // Asignamos el porcentaje a 0 inicialmente
                    partidos[cantidad].porcentajeVotos = 0;
                    
                    Console.WriteLine("Dirección de la sede:");
                    Console.Write("Calle: ");
                    partidos[cantidad].sede.calle = Console.ReadLine();
                    Console.Write("Número: ");
                    partidos[cantidad].sede.numero = Convert.ToUInt16(Console.ReadLine());
                    Console.Write("Cód. postal: ");
                    partidos[cantidad].sede.codigoPostal = Console.ReadLine();
                    Console.Write("Ciudad: ");
                    partidos[cantidad].sede.ciudad = Console.ReadLine();
                    
                    Console.WriteLine("Partido añadido correctamente.");
                    cantidad++;
                    
                    break;
                    
                case 2: 
                
                    // Borrar un partido a partir de sus siglas
                
                    for (i = 0; i < cantidad; i++)
                    {
                        Console.WriteLine("{0}: {1}", (i+1), partidos[i].siglas);
                    }
                    
                    Console.WriteLine("\nIndica las siglas del partido a borrar:");
                    siglasABorrar = Console.ReadLine();
                    
                    // Buscamos la posición del partido con esas siglas
                    posicionABorrar = -1;
                    i = 0;
                    while (i < cantidad && posicionABorrar == -1)
                    {
                        if (partidos[i].siglas == siglasABorrar)
                            posicionABorrar = i;
                        i++;
                    }
                    
                    if (posicionABorrar == -1)
                    {
                        Console.WriteLine("No se ha encontrado un partido con esas siglas");
                    }
                    else
                    {
                        // Borrado del partido
                        for (i = posicionABorrar; i < cantidad - 1; i++)
                            partidos[i] = partidos[i+1];
                        
                        Console.WriteLine("Partido borrado");
                        cantidad--;
                    }
                
                    break;
                    
                case 3: 
                
                    // Ordenar array por votos de mayor a menor
                    
                    // Algoritmo de burbuja
                    for (i = 0; i < cantidad - 1; i++)
                    {
                        for (j = i+1; j < cantidad; j++)
                        {
                            if (partidos[i].votos < partidos[j].votos)
                            {
                                partido auxiliar = partidos[i];
                                partidos[i] = partidos[j];
                                partidos[j] = auxiliar; 
                            }
                        }
                    }
                    
                    // Mostramos listado ordenado
                    Console.WriteLine("Listado ordenado de partidos:");
                    for (i = 0; i < cantidad; i++)
                    {
                        Console.WriteLine("{0}. {1}", i+1, partidos[i].siglas);
                        Console.WriteLine(partidos[i].nombre);
                        Console.WriteLine("{0} votos", partidos[i].votos);
                        Console.WriteLine("Sede: {0}, {1}, {2}, {3}", partidos[i].sede.calle,
                            partidos[i].sede.numero, partidos[i].sede.codigoPostal,
                            partidos[i].sede.ciudad);
                    }
                
                    break;
                    
                case 4: 
                
                    // Calcular porcentajes
                    
                    // Pedimos el total de votos nulos y en blanco
                    // Podemos hacerlo por separado o todo junto
                    do
                    {
                        Console.WriteLine("Introduce el total de votos nulos y en blanco");
                        votosNulosBlancos = Convert.ToInt32(Console.ReadLine());
                    }
                    while (votosNulosBlancos < 0);
                    
                    // Calculamos el total de votos
                    totalVotos = votosNulosBlancos;                    
                    for (i = 0; i < cantidad; i++)
                        totalVotos += partidos[i].votos;
                    
                    // Calculamos los porcentajes y mostramos información
                    for (i = 0; i < cantidad; i++)
                    {
                        partidos[i].porcentajeVotos = partidos[i].votos * 100 / (float)totalVotos;
                        Console.WriteLine("{0}. {1}: {2} votos, {3}%", i+1, partidos[i].siglas,
                            partidos[i].votos, partidos[i].porcentajeVotos.ToString("N1"));
                    }
                    
                    break;
                    
                case 5: 
                
                    // Buscar partido por siglas o nombre
                    
                    Console.WriteLine("Introduce el texto a buscar:");
                    textoABuscar = Console.ReadLine();
                    
                    encontrado = false;
                    
                    for (i = 0; i < cantidad; i++)
                    {
                        if (partidos[i].siglas.ToUpper().Contains(textoABuscar.ToUpper()) ||
                            partidos[i].nombre.ToUpper().Contains(textoABuscar.ToUpper()))
                        {
                            encontrado = true;
                            Console.WriteLine("{0}. {1}, {2}", i+1, partidos[i].siglas, partidos[i].nombre);
                            Console.WriteLine("Sede: {0}, {1}, {2}, {3}", partidos[i].sede.calle,
                                partidos[i].sede.numero, partidos[i].sede.codigoPostal,
                                partidos[i].sede.ciudad);
                            Console.WriteLine();
                        }
                    }
                    
                    if (!encontrado)
                        Console.WriteLine("No se han encontrado coincidencias");
                                                    
                    break;
                    
                case 0:
                    Console.WriteLine("Fin del programa.");
                    break;
                default:
                    Console.WriteLine("Opción no reconocida");
                    break;
            }
            
            if (opcionMenu != 0)
            {
                Console.WriteLine("Pulsa INTRO para continuar...");
                Console.ReadLine();
            }
        } 
        while (opcionMenu != 0);
    }
}
