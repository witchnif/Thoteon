using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


class Program_interactive_ia_with_testholl {
    static void Main(string[] args) {

// LECTURA DE ARCHIVOS
//----------------------------------------------------------------------------------------------------------//

        // Leer el archivo de pares de preguntas y respuestas y construir la lista de pares
        List<Tuple<List<string>, List<string>>> pairs = new List<Tuple<List<string>, List<string>>>();
        string[] lines_p = File.ReadAllLines("answers.txt");
        // Parsea el contenido del archivo en una lista de C#
        foreach (string line in lines_p) {
            // Elimina los espacios en blanco al inicio y al final de la linea
            string[] parts = line.Trim().Split(":");
            List<string> questions = parts[0].Split(",").Select(x => x.Trim()).ToList();
            List<string> answers = parts[1].Split(",").Select(x => x.Trim()).ToList();
            pairs.Add(new Tuple<List<string>, List<string>>(questions, answers));
        }

        // Lee el archivo de la lista que contiene coincidencias con entradas y preguntas
        List<List<string>> data_list = new List<List<string>>();
        string[] lines_L = File.ReadAllLines("lists.txt");
        // Parsea el contenido del archivo en una lista de C#
        foreach (string line in lines_L) {
            // Elimina los espacios en blanco al inicio y al final de la linea
            string[] key_values = line.Trim().Split(":");
            string[] key = key_values[0].Trim().Split(",").Select(x => x.Trim()).ToArray();
            string[] values = key_values[1].Trim().Split(",").Select(x => x.Trim()).ToArray();
            data_list.Add(new List<string> { string.Join(",", key), string.Join(",", values) });
        }

//DECLARACION DE VARIABLES
//----------------------------------------------------------------------------------------------------------//
        // Crea una lista vacía para guardar los resultados
        int[] result_ia = new int[data_list.Count];

//----------------------------------------------------------------------------------------------------------//
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n\n\n\n\n\n");
        Console.WriteLine("//------------------------------GAMEPLAY_IA_START------------------------------//");
        Console.WriteLine("\n\n");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("KYO_> Holiiiii, Soy Kyo y sere tu guia hoy");
        Console.WriteLine("KYO_>> Hablemos un rato, y cuando quieras vamos a clases");
        Console.ForegroundColor = ConsoleColor.Cyan;

//----------------------------------------------------------------------------------------------------------//

        while (true) {
            // Solicita una entrada al usuario
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("TU_>");
            string input_text = Console.ReadLine().ToLower();
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Verifica si el usuario quiere ir a clase para terminar la ejecucion del prpograma
            if (input_text == "vamos a clases" || input_text == "vamos a clase"){
                break;
            }

            // Divide la entrada en palabras utilizando el método "Split" de las cadenas de texto
           string[] words = input_text.Split();


            // Recorre cada sublista del diccionario
            for (int i = 0; i < data_list.Count; i++) {
                // Recupera la palabra clave y los valores de la sublista
                string[] key = data_list[i][0].Split(",");
                string[] values = data_list[i][1].Split(",");
                // Inicializa un contador para la clave actual
                int count = 0;
                // Recorre cada valor de la clave
                foreach (string value in values) {
                    // Verifica si la palabra ingresada por el usuario coincide con el valor
                    if (words.Contains(value)) {
                        // Si coincide, incrementa el contador para la clave actual
                        count++;
                    }
                }
                // Guarda el contador en la lista de resultados
                result_ia[i] = count;
            }

            // Ordena la lista de resultados en orden descendente y selecciona el primer elemento
            string top_one = (from i in Enumerable.Range(0, result_ia.Length)
                orderby result_ia[i] descending
                select data_list[i][0]).FirstOrDefault();


            // Imprime la lista de resultados y el vector con el top de la palabra clave que tienen más coincidencias
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Join(",", result_ia));
            Console.WriteLine(string.Join(",", top_one));
            Console.ForegroundColor = ConsoleColor.Cyan;
    
//----------------------------------------------------------------------------------------------------------//

            string one = top_one;
            // Buscar la lista de respuestas correspondiente a la pregunta dada
            Tuple<List<string>, List<string>> matchingPair = pairs.FirstOrDefault(pair => pair.Item1.Contains(one));
            if (matchingPair != null) {
                // Seleccionar una respuesta aleatoria de la lista de respuestas
                Random rand = new Random();
                string randomAnswer = matchingPair.Item2[rand.Next(matchingPair.Item2.Count)];
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("KYO_>> ");
                Console.WriteLine(randomAnswer);
                Console.ForegroundColor = ConsoleColor.Cyan;
            } else {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("KYO_>> ¿Qué, ¡Qué!?, no te entendi perdon, oye quieres seguir hablando o vamos a clases");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
        }

//----------------------------------------------------------------------------------------------------------//
//----------------------------------------------------------------------------------------------------------//
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("KYO_>> Si, Si, mira la hora, vamos super tarde");
        Console.WriteLine("KYO_>> ¡Corre!, ven vamos rapido a clases");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n\n\n\n");
        Console.WriteLine("//------------------------------END_OF_GAMEPLAY_IA------------------------------//");
        Console.WriteLine("\n\n");
        // Restaura los colores predeterminados de la consola
        Console.ResetColor();


//----------------------------------------------------------------------------------------------------------//
//----------------------------------------------------------------------------------------------------------//
//----------------------------------------------------------------------------------------------------------//
//----------------------------------------------------------------------------------------------------------//
//----------------------------------------------------------------------------------------------------------//
//----------------------------------------------------------------------------------------------------------//
//----------------------------------------------------------------------------------------------------------//
//----------------------------------------------------------------------------------------------------------//



//LISTAS DE TUPLAS
//----------------------------------------------------------------------------------------------------------//

        List<(string, List<int>)> part_a = new List<(string, List<int>)>()
        {
            ("REALISTA", new List<int>(){3, 11, 18, 21, 24, 27, 35, 44}),
            ("INVESTIGADOR", new List<int>(){8, 19, 29, 31, 33, 36, 37, 43}),
            ("SOCIAL", new List<int>(){4, 14, 15, 16, 17, 22}),
            ("CONVENCIONAL", new List<int>(){5, 6, 7, 9, 10, 26, 28, 42}),
            ("EMPRENDEDOR", new List<int>(){2, 12, 23, 32, 38, 39, 40, 41}),
            ("ARTÍSTICO", new List<int>(){1, 13, 20, 25, 30, 34, 45})
        };

        List<(string, List<int>)> part_b = new List<(string, List<int>)>()
        {
            ("REALISTA", new List<int>(){1, 10, 16}),
            ("INVESTIGADOR", new List<int>(){9, 13, 14}),
            ("SOCIAL", new List<int>(){5, 8, 17}),
            ("CONVENCIONAL", new List<int>(){3, 4, 18}),
            ("EMPRENDEDOR", new List<int>(){7, 12, 15}),
            ("ARTÍSTICO", new List<int>(){2, 6, 11}),
        };

        List<(string, List<int>)> part_c = new List<(string, List<int>)>()
        {
            ("REALISTA", new List<int>(){2, 5, 12}),
            ("INVESTIGADOR", new List<int>(){4, 9, 10}),
            ("SOCIAL", new List<int>(){3, 14, 18}),
            ("CONVENCIONAL", new List<int>(){1, 8, 13}),
            ("EMPRENDEDOR", new List<int>(){6, 7, 17}),
            ("ARTÍSTICO", new List<int>(){11, 15, 16}),
        };

        List<(string, List<int>)> part_d = new List<(string, List<int>)>()
        {
            ("REALISTA", new List<int>(){5, 12, 15, 20, 28}),
            ("INVESTIGADOR", new List<int>(){1, 9, 17, 24, 27}),
            ("SOCIAL", new List<int>(){4, 11, 13, 23, 30}),
            ("CONVENCIONAL", new List<int>(){2, 7, 18, 22, 26}),
            ("EMPRENDEDOR", new List<int>(){3, 10, 14, 19, 29}),
            ("ARTÍSTICO", new List<int>(){6, 8, 16, 21, 25})
        };

        List<(string, List<int>)> results = new List<(string, List<int>)>()
        {
            ("REALISTA", new List<int>(){0}),
            ("INVESTIGADOR", new List<int>(){0}),
            ("SOCIAL", new List<int>(){0}),
            ("CONVENCIONAL", new List<int>(){0}),
            ("EMPRENDEDOR", new List<int>(){0}),
            ("ARTÍSTICO", new List<int>(){0})
        };

        List<(string, List<string>)> occupations = new List<(string, List<string>)>()
        {
            ("REALISTA", new List<string>(){"\n\t\t→Mecánico\n\t\t→Especialista en Piscicultura (crianza de especies marinas) o agricultura\n\t\t→Operador en un fábrica o industria\n\t\t→Maestro gásfiter\n\t\t→Operador de máquinas\n\t\t→Investigador privado\n\t\t→Inspector de construcciones\n\t\t→Radiooperador\n\t\t→Empleado en una gasolinera\n\t\t→Diseñador de herramientas\n\t\t→Fotograbador\n\t\t→Electricista\n\t\t→Ingeniero mecánico"}),
            ("INVESTIGADOR", new List<string>(){"\n\t\t→Meteorólogo\n\t\t→Biólogo\n\t\t→Astrónomo\n\t\t→Ingeniero Civil\n\t\t→Antropólogo\n\t\t→Zoólogo\n\t\t→Químico\n\t\t→Investigador Científico\n\t\t→Escritor de artículos científicos\n\t\t→Geólogo\n\t\t→Botánico\n\t\t→Físico"}),
            ("SOCIAL", new List<string>(){"\n\t\t→Misionero Religioso\n\t\t→Profesor de Educación Básica\n\t\t→Orientador en asuntos de delincuencia juvenil\n\t\t→Psicopedagogo\n\t\t→Orientador matrimonial\n\t\t→Profesor de Educación Física\n\t\t→Director de organizaciones sociales\n\t\t→Psicólogo\n\t\t→Consejero\n\t\t→Especialista en organizaciones sociales\n\t\t→Trabajador en un hospital psiquiátrico\n\t\t→Profesor de educación media\n\t\t→Asesor en un municipio"}),
            ("CONVENCIONAL", new List<string>(){"\n\t\t→Contador\n\t\t→Experto en control de calidad\n\t\t→Director de tráfico\n\t\t→Estadístico\n\t\t→Secretario de un tribunal\n\t\t→Tramitador aduanero\n\t\t→Contralor de inventarios\n\t\t→Analista de finanzas\n\t\t→Evaluador\n\t\t→Inspector de empresas\n\t\t→Cajero\n\t\t→Cobrador de un banco\n\t\t→Especialista en impuestos"}),
            ("EMPRENDEDOR", new List<string>(){"\n\t\t→Ingeniero comercial   \n\t\t→Especulador en la bolsa\n\t\t→Vendedor de acciones y títulos\n\t\t→Agente de ventas\n\t\t→Administrador de un hotel\n\t\t→Representante de una empresa\n\t\t→Ejecutivo de negocios\n\t\t→Agente viajero\n\t\t→Promotor\n\t\t→Director de empresas\n\t\t→Político\n\t\t→Relacionador público\n\t\t→Productor de televisión"}),
            ("ARTÍSTICO", new List<string>(){"\n\t\t→Poeta\n\t\t→Director de un conjunto u orquesta\n\t\t→Músico\n\t\t→Escritor\n\t\t→Actor\n\t\t→Dibujante\n\t\t→Encargado de sonido\n\t\t→Cantante\n\t\t→Dramaturgo\n\t\t→Director de cine o teatro\n\t\t→Caricaturista\n\t\t→Experto en obras de arte\n\t\t→Compositor"})
        };

//DECLARACION DE VARIABLES
//----------------------------------------------------------------------------------------------------------//

        int[] adjetivos = new int[45];
        int[] caracteristicas = new int[0];
        int[] aspirations = new int[0];
        int[] personal_selections = new int[0];
        int contadorAdjetivos = 0;
        string respuesta_a;
        int w = 1;
        int resp_b = 1;
        int resp_c = 1;
        int resp_d = 1;
        int[] coincidencias = new int[part_a.Count];
        int[] coincidencias_b = new int[part_b.Count];
        int[] coincidencias_c = new int[part_c.Count];
        int[] coincidencias_d = new int[part_d.Count];
        string top = "";
        int maxNumber = 0;


        
//PART_A
//----------------------------------------------------------------------------------------------------------//

        // Preguntar al usuario por cada adjetivo y guardar la respuesta
        Console.ForegroundColor = ConsoleColor.Red;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("\n\n\n\n");
        Console.WriteLine("//------------------------------GAMEPLAY_TEST_START------------------------------//");
        Console.WriteLine("\n\n");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("GM_>> \n1.Huraño\t\t\t2.Discutidor (A)\t\t\t3.Arrogante\n4.Capaz\t\t\t\t5.Común Y Corriente\t\t\t6.Conformista\n7.Concienzudo (A)\t\t8.Curioso\t\t\t\t9.Dependiente\n10.Eficiente\t\t\t11.Paciente\t\t\t\t12.Dinámico\n13.Femenino (A)\t\t\t14.Amistoso (A)\t\t\t\t15.Generoso (A)\n16. Dispuesto A Ayudar\t\t17. Inflexible\t\t\t\t18. Insensible\n19. Introvertido (A)\t\t20. Intuitivo\t\t\t\t21. Irritable\n22. Amable\t\t\t23. De Buenos Modales\t\t\t24. Varonil\n25. Inconforme\t\t\t26. Poco Realista\t\t\t27. Poco Culto (A)\n28. Poco Idealista\t\t29. Impopular\t\t\t\t30. Original\n31. Pesimista\t\t\t32. Hedonista\t\t\t\t33. Práctico\n34. Rebelde\t\t\t35. Reservado\t\t\t\t36. Culto\n37. Lento De Movimientos\t38. Sociable\t\t\t\t39. Estable\n40. Esforzado\t\t\t41. Fuerte\t\t\t\t42. Suspicaz\n43. Cumplido\t\t\t44. Modesto\t\t\t\t45. Poco Convencional\n");
        Console.WriteLine("GM_>>Digite los números de los adjetivos que describan su personalidad. Señale tantos como desee. Trate de definirse tal como es, no como le gustaría ser.\n");
        Console.WriteLine("KYO_>> Cuando termines me avisas");

        
        // Verifica si el dato ingresado es un numero valido, y si es una cadena termina el algoritmo
        while(true) {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("TU_>");
            respuesta_a = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            
            if (int.TryParse(respuesta_a, out w)) {
                if (w > 45){
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("KYO_>> no hay mas de 45 opciones");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else{
                    if (w == 0){
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("KYO_>> ¿Cero? ¿en serio? espero que sea una equivocacion");
                        Console.ForegroundColor = ConsoleColor.Cyan;                        
                    }
                    else{
                        if (w < 0){
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("KYO_>> ¡Nooo!, ¿en serio? ¿Porque numeros negativos?");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else{
                            adjetivos[contadorAdjetivos] = w;
                            contadorAdjetivos++;
                        }
                    }
                }
            }
            else{
                break;
            }
        }
        
        // Imprime los numeros digitados por el usuario
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n\n");
        for (int i = 0; i < contadorAdjetivos; i++) {
            Console.Write("<{0}>", adjetivos[i]);
        }

//----------------------------------------------------------------------------------------------------------//

        // Calcular coincidencias y top seis
        for (int i = 0; i < part_a.Count; i++) {
            foreach (int adjetivo in adjetivos) {
                if (part_a[i].Item2.Contains(adjetivo)) {
                    coincidencias[i]++;
                }
            }
        }

        // Imprimir resultados y agregar coincidencias a la variable results
        Console.WriteLine("\nCoincidencias:");
        for (int i = 0; i < part_a.Count; i++) {
            Console.WriteLine("{0}: {1}", part_a[i].Item1, coincidencias[i]);
        }

        Console.WriteLine("\nTop seis:");

        var top_a = part_a.Zip(coincidencias, (part, coinc) => (part.Item1, coinc))
                            .OrderByDescending(p => p.Item2).Take(6);

        foreach (var item in top_a) {
            Console.WriteLine("{0}: {1}", item.Item1, item.Item2);
        }

        for (int i = 0; i < results.Count; i++) {
            // Sumar el valor de coincidencias a cada vector en results
            results[i] = (results[i].Item1, results[i].Item2.Select(x => x + coincidencias[i]).ToList());
        }

        // Imprimir los nuevos valores de results
        Console.WriteLine("\n\n");
        foreach (var result in results) {
            Console.WriteLine("Total de {0}: {1}", result.Item1, string.Join(", ", result.Item2));
        }
        Console.WriteLine("\n\n");
        Console.ForegroundColor = ConsoleColor.Cyan;

//declaración de métodos estáticos
//----------------------------------------------------------------------------------------------------------//
static int realizar_pregunta_b_2(string pregunta, int respuestaEsperada)
{
    Console.WriteLine($"GM_>> {pregunta}\n\nDigita el numero de tu respuesta\n\t1. Mas que los demas\n\t2. Igual que los demas\n\t3. Menos que los demas\n");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("TU_>");

    while (true)
    {
        Console.ForegroundColor = ConsoleColor.White;
        string respuestaStr = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Cyan;

        if (int.TryParse(respuestaStr, out int respuestaNum))
        {
            if (respuestaNum > 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("KYO_>> no hay mas de 3 opciones, intenta de nuevo: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("TU_>");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else if (respuestaNum == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("KYO_>> ¿Cero? ¿en serio? espero que sea una equivocacion, intenta de nuevo: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("TU_>");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else if (respuestaNum < 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("KYO_>> ¡Nooo!, ¿en serio? ¿Porque numeros negativos?, intenta de nuevo: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("TU_>");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                if (respuestaNum == 2 || respuestaNum == 3)
                {
                    respuestaNum = respuestaEsperada;
                    return respuestaNum;
                }
                else
                {
                    return 0;
                }
                
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("KYO_>>Solo escribe el numero de tu respuesta, intenta de nuevo: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("TU_>");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}

static int realizar_pregunta_b_1(string pregunta, int respuestaEsperada)
{
    Console.WriteLine($"GM_>> {pregunta}\n\nDigita el numero de tu respuesta\n\t1. Mas que los demas\n\t2. Igual que los demas\n\t3. Menos que los demas\n");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("TU_>");

    while (true)
    {
        Console.ForegroundColor = ConsoleColor.White;
        string respuestaStr = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Cyan;

        if (int.TryParse(respuestaStr, out int respuestaNum))
        {
            if (respuestaNum > 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("KYO_>> no hay mas de 3 opciones, intenta de nuevo: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("TU_>");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else if (respuestaNum == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("KYO_>> ¿Cero? ¿en serio? espero que sea una equivocacion, intenta de nuevo: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("TU_>");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else if (respuestaNum < 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("KYO_>> ¡Nooo!, ¿en serio? ¿Porque numeros negativos?, intenta de nuevo: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("TU_>");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                if (respuestaNum == 1)
                 {
                    respuestaNum = respuestaEsperada;
                    return respuestaNum;
                }
                else
                {
                    return 0;
                };
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("KYO_>> Solo escribe el numero de tu respuesta, intenta de nuevo: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("TU_>");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}

static int realizar_pregunta_c_2(string pregunta, int respuestaEsperada)
{
    Console.WriteLine($"GM_>> {pregunta}\n\nDigita el numero de tu respuesta\n\t1. Muy importante\n\t2. Me da igual\n\t3. Poco importante\n");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("TU_>");

    while (true)
    {
        Console.ForegroundColor = ConsoleColor.White;
        string respuestaStr = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Cyan;

        if (int.TryParse(respuestaStr, out int respuestaNum))
        {
            if (respuestaNum > 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("KYO_>> no hay mas de 3 opciones, intenta de nuevo: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("TU_>");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else if (respuestaNum == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("KYO_>> ¿Cero? ¿en serio? espero que sea una equivocacion, intenta de nuevo: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("TU_>");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else if (respuestaNum < 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("KYO_>> ¡Nooo!, ¿en serio? ¿Porque numeros negativos?, intenta de nuevo: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("TU_>");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                if (respuestaNum == 2 || respuestaNum == 3)
                {
                    respuestaNum = respuestaEsperada;
                    return respuestaNum;
                }
                else
                {
                    return 0;
                }
                
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("KYO_>>Solo escribe el numero de tu respuesta, intenta de nuevo: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("TU_>");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}

static int realizar_pregunta_c_1(string pregunta, int respuestaEsperada)
{
    Console.WriteLine($"GM_>> {pregunta}\n\nDigita el numero de tu respuesta\n\t1. Muy importante\n\t2. Me da igual\n\t3. Poco importante\n");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("TU_>");

    while (true)
    {
        Console.ForegroundColor = ConsoleColor.White;
        string respuestaStr = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Cyan;

        if (int.TryParse(respuestaStr, out int respuestaNum))
        {
            if (respuestaNum > 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("KYO_>> no hay mas de 3 opciones, intenta de nuevo: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("TU_>");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else if (respuestaNum == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("KYO_>> ¿Cero? ¿en serio? espero que sea una equivocacion, intenta de nuevo: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("TU_>");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else if (respuestaNum < 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("KYO_>> ¡Nooo!, ¿en serio? ¿Porque numeros negativos?, intenta de nuevo: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("TU_>");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                if (respuestaNum == 1)
                {
                    respuestaNum = respuestaEsperada;
                    return respuestaNum;
                }
                else
                {
                    return 0;
                };
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("KYO_>> Solo escribe el numero de tu respuesta, intenta de nuevo: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("TU_>");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}

static int realizar_pregunta_d_1(int first_num, int end_num)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("TU_>");

    while (true)
    {
        Console.ForegroundColor = ConsoleColor.White;
        string respuestaStr = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Cyan;

        if (int.TryParse(respuestaStr, out int respuestaNum))
            if (respuestaNum > end_num || respuestaNum < first_num)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("KYO_>> !Oye¡ mira los numeros de las respuestas, diste un numero que no aparece: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("TU_>");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                respuestaNum = int.Parse(respuestaStr);
                return respuestaNum;
            }

        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("KYO_>> Solo escribe el numero de tu respuesta, intenta de nuevo: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("TU_>");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}

//PART_B
//----------------------------------------------------------------------------------------------------------//

        resp_b = realizar_pregunta_b_2("1. ¿En comparacion con las personas de tu edad te consideras con mas o menos Distraído?", 1);
        Array.Resize(ref caracteristicas, caracteristicas.Length + 1);
        caracteristicas[caracteristicas.Length - 1] = resp_b;
        Console.WriteLine("\n\n");

        resp_b = realizar_pregunta_b_1("2. ¿En comparacion con las personas de tu edad te consideras con mas o menos Capacidad artística?", 2);
        Array.Resize(ref caracteristicas, caracteristicas.Length + 1);
        caracteristicas[caracteristicas.Length - 1] = resp_b;
        Console.WriteLine("\n\n");

        resp_b = realizar_pregunta_b_1("3. ¿En comparacion con las personas de tu edad te consideras con mas o menos Capacidad Burocrática?", 3);
        Array.Resize(ref caracteristicas, caracteristicas.Length + 1);
        caracteristicas[caracteristicas.Length - 1] = resp_b;
        Console.WriteLine("\n\n");

        resp_b = realizar_pregunta_b_1("4. ¿En comparacion con las personas de tu edad te consideras mas o menos Conservadurismo?", 4);
        Array.Resize(ref caracteristicas, caracteristicas.Length + 1);
        caracteristicas[caracteristicas.Length - 1] = resp_b;
        Console.WriteLine("\n\n");

        resp_b = realizar_pregunta_b_1("5. ¿En comparacion con las personas de tu edad te consideras con mas o menos Cooperas?", 5);
        Array.Resize(ref caracteristicas, caracteristicas.Length + 1);
        caracteristicas[caracteristicas.Length - 1] = resp_b;
        Console.WriteLine("\n\n");

        resp_b = realizar_pregunta_b_1("6. ¿En comparacion con las personas de tu edad te consideras con mas o menos Expresividad?", 6);
        Array.Resize(ref caracteristicas, caracteristicas.Length + 1);
        caracteristicas[caracteristicas.Length - 1] = resp_b;
        Console.WriteLine("\n\n");

        resp_b = realizar_pregunta_b_1("7. ¿En comparacion con las personas de tu edad te consideras con mas o menos Liderazgo?", 7);
        Array.Resize(ref caracteristicas, caracteristicas.Length + 1);
        caracteristicas[caracteristicas.Length - 1] = resp_b;
        Console.WriteLine("\n\n");

        resp_b = realizar_pregunta_b_1("8. ¿En comparacion con las personas de tu edad te consideras con mas o menos Gusto en ayudar a los demás?", 8);
        Array.Resize(ref caracteristicas, caracteristicas.Length + 1);
        caracteristicas[caracteristicas.Length - 1] = resp_b;
        Console.WriteLine("\n\n");

        resp_b = realizar_pregunta_b_1("9. ¿En comparacion con las personas de tu edad te consideras con mas o menos Capacidad matemática?", 9);
        Array.Resize(ref caracteristicas, caracteristicas.Length + 1);
        caracteristicas[caracteristicas.Length - 1] = resp_b;
        Console.WriteLine("\n\n");

        resp_b = realizar_pregunta_b_1("10. ¿En comparacion con las personas de tu edad te consideras con mas o menos Capacidad mecánica?", 10);
        Array.Resize(ref caracteristicas, caracteristicas.Length + 1);
        caracteristicas[caracteristicas.Length - 1] = resp_b;
        Console.WriteLine("\n\n");

        resp_b = realizar_pregunta_b_1("11. ¿En comparacion con las personas de tu edad te consideras con mas o menos Originalidad?", 11);
        Array.Resize(ref caracteristicas, caracteristicas.Length + 1);
        caracteristicas[caracteristicas.Length - 1] = resp_b;
        Console.WriteLine("\n\n");

        resp_b = realizar_pregunta_b_1("12. ¿En comparacion con las personas de tu edad te consideras con mas o menos Popularidad con el sexo opuesto?", 12);
        Array.Resize(ref caracteristicas, caracteristicas.Length + 1);
        caracteristicas[caracteristicas.Length - 1] = resp_b;
        Console.WriteLine("\n\n");

        resp_b = realizar_pregunta_b_1("13. ¿En comparacion con las personas de tu edad te consideras con mas o menos Capacidad para investigar?", 13);
        Array.Resize(ref caracteristicas, caracteristicas.Length + 1);
        caracteristicas[caracteristicas.Length - 1] = resp_b;
        Console.WriteLine("\n\n");

        resp_b = realizar_pregunta_b_1("14. ¿En comparacion con las personas de tu edad te consideras con mas o menos Capacidad científica?", 14);
        Array.Resize(ref caracteristicas, caracteristicas.Length + 1);
        caracteristicas[caracteristicas.Length - 1] = resp_b;
        Console.WriteLine("\n\n");

        resp_b = realizar_pregunta_b_1("15. ¿En comparacion con las personas de tu edad te consideras con mas o menos Seguridad en sí mismo?", 15);
        Array.Resize(ref caracteristicas, caracteristicas.Length + 1);
        caracteristicas[caracteristicas.Length - 1] = resp_b;
        Console.WriteLine("\n\n");

        resp_b = realizar_pregunta_b_2("16. ¿En comparacion con las personas de tu edad te consideras con mas o menos con Comprensión de sí mismo?", 16);
        Array.Resize(ref caracteristicas, caracteristicas.Length + 1);
        caracteristicas[caracteristicas.Length - 1] = resp_b;
        Console.WriteLine("\n\n");

        resp_b = realizar_pregunta_b_1("17. ¿En comparacion con las personas de tu edad te consideras con mas o menos con Comprensión de los demás?", 17);
        Array.Resize(ref caracteristicas, caracteristicas.Length + 1);
        caracteristicas[caracteristicas.Length - 1] = resp_b;
        Console.WriteLine("\n\n");

        resp_b = realizar_pregunta_b_1("18. ¿En comparacion con las personas de tu edad te consideras con mas o menos Pulcritud?", 18);
        Array.Resize(ref caracteristicas, caracteristicas.Length + 1);
        caracteristicas[caracteristicas.Length - 1] = resp_b;
        Console.WriteLine("\n\n");


//----------------------------------------------------------------------------------------------------------//
        Console.ForegroundColor = ConsoleColor.Red;
        // Calcular coincidencias y top seis
        for (int i = 0; i < part_b.Count; i++) {
            foreach (int caracteristica in caracteristicas) {
                if (part_b[i].Item2.Contains(caracteristica)) {
                    coincidencias_b[i]++;
                }
            }
        }

        // Imprimir resultados y agregar coincidencias a la variable results
        Console.WriteLine("\nCoincidencias:");
        for (int i = 0; i < part_b.Count; i++) {
            Console.WriteLine("{0}: {1}", part_b[i].Item1, coincidencias_b[i]);
        }

        Console.WriteLine("\nTop seis:");

        var top_b = part_b.Zip(coincidencias_b, (part_b, coinc_b) => (part_b.Item1, coinc_b))
                            .OrderByDescending(p => p.Item2).Take(6);

        foreach (var item in top_b) {
            Console.WriteLine("{0}: {1}", item.Item1, item.Item2);
        }

//----------------------------------------------------------------------------------------------------------//

        for (int i = 0; i < results.Count; i++) {
            // Sumar el valor de coincidencias a cada vector en results
            results[i] = (results[i].Item1, results[i].Item2.Select(x => x + coincidencias_b[i]).ToList());
        }

        // Imprimir los nuevos valores de results
        Console.WriteLine("\n\n");
        foreach (var result in results) {
            Console.WriteLine("Total de {0}: {1}", result.Item1, string.Join(", ", result.Item2));
        }
        Console.WriteLine("\n\n");
        Console.ForegroundColor = ConsoleColor.Cyan;

//PART_C
//----------------------------------------------------------------------------------------------------------//
        resp_c = realizar_pregunta_c_1("1. ¿Que importancia tiene para ti Estar feliz y satisfecho?", 1);
        Array.Resize(ref aspirations, aspirations.Length + 1);
        aspirations[aspirations.Length - 1] = resp_c;
        Console.WriteLine("\n\n");

        resp_c = realizar_pregunta_c_1("2. ¿Que importancia tiene para ti Descubrir o elaborar un producto útil?", 2);
        Array.Resize(ref aspirations, aspirations.Length + 1);
        aspirations[aspirations.Length - 1] = resp_c;
        Console.WriteLine("\n\n");

        resp_c = realizar_pregunta_c_1("3. ¿Que importancia tiene para ti Ayudar a quiénes están en apuros?", 3);
        Array.Resize(ref aspirations, aspirations.Length + 1);
        aspirations[aspirations.Length - 1] = resp_c;
        Console.WriteLine("\n\n");

        resp_c = realizar_pregunta_c_1("4. ¿Que importancia tiene para ti Llegar a ser una autoridad en algún tema?", 4);
        Array.Resize(ref aspirations, aspirations.Length + 1);
        aspirations[aspirations.Length - 1] = resp_c;
        Console.WriteLine("\n\n");

        resp_c = realizar_pregunta_c_1("5. ¿Que importancia tiene para ti Llegar a ser un deportista destacado?", 5);
        Array.Resize(ref aspirations, aspirations.Length + 1);
        aspirations[aspirations.Length - 1] = resp_c;
        Console.WriteLine("\n\n");

        resp_c = realizar_pregunta_c_1("6. ¿Que importancia tiene para ti Llegar a ser un líder en la comunidad?", 6);
        Array.Resize(ref aspirations, aspirations.Length + 1);
        aspirations[aspirations.Length - 1] = resp_c;
        Console.WriteLine("\n\n");

        resp_c = realizar_pregunta_c_1("7. ¿Que importancia tiene para ti Ser influyente en asuntos públicos?", 7);
        Array.Resize(ref aspirations, aspirations.Length + 1);
        aspirations[aspirations.Length - 1] = resp_c;
        Console.WriteLine("\n\n");

        resp_c = realizar_pregunta_c_1("8. ¿Que importancia tiene para ti Observar una conducta religiosa formal?", 8);
        Array.Resize(ref aspirations, aspirations.Length + 1);
        aspirations[aspirations.Length - 1] = resp_c;
        Console.WriteLine("\n\n");

        resp_c = realizar_pregunta_c_1("9. ¿Que importancia tiene para ti Contribuir a la ciencia en forma teórica?", 9);
        Array.Resize(ref aspirations, aspirations.Length + 1);
        aspirations[aspirations.Length - 1] = resp_c;
        Console.WriteLine("\n\n");

        resp_c = realizar_pregunta_c_1("10. ¿Que importancia tiene para ti Contribuir a la ciencia en forma técnica?", 10);
        Array.Resize(ref aspirations, aspirations.Length + 1);
        aspirations[aspirations.Length - 1] = resp_c;
        Console.WriteLine("\n\n");

        resp_c = realizar_pregunta_c_1("11. ¿Que importancia tiene para ti Escribir bien (novelas, poemas)?", 11);
        Array.Resize(ref aspirations, aspirations.Length + 1);
        aspirations[aspirations.Length - 1] = resp_c;
        Console.WriteLine("\n\n");

        resp_c = realizar_pregunta_c_2("12. ¿Que importancia tiene para ti Haber leído mucho?", 12);
        Array.Resize(ref aspirations, aspirations.Length + 1);
        aspirations[aspirations.Length - 1] = resp_c;
        Console.WriteLine("\n\n");

        resp_c = realizar_pregunta_c_1("13. ¿Que importancia tiene para ti Trabajar mucho?", 13);
        Array.Resize(ref aspirations, aspirations.Length + 1);
        aspirations[aspirations.Length - 1] = resp_c;
        Console.WriteLine("\n\n");

        resp_c = realizar_pregunta_c_1("14. ¿Que importancia tiene para ti Contribuir al bienestar humano?", 14);
        Array.Resize(ref aspirations, aspirations.Length + 1);
        aspirations[aspirations.Length - 1] = resp_c;
        Console.WriteLine("\n\n");

        resp_c = realizar_pregunta_c_1("15. ¿Que importancia tiene para ti Crear buenas obras artísticas (teatro, pintura)?", 15);
        Array.Resize(ref aspirations, aspirations.Length + 1);
        aspirations[aspirations.Length - 1] = resp_c;
        Console.WriteLine("\n\n");

        resp_c = realizar_pregunta_c_1("16. ¿Que importancia tiene para ti Llegar a ser un buen músico?", 16);
        Array.Resize(ref aspirations, aspirations.Length + 1);
        aspirations[aspirations.Length - 1] = resp_c;
        Console.WriteLine("\n\n");

        resp_c = realizar_pregunta_c_1("17. ¿Que importancia tiene para ti Llegar a ser un experto en finanzas y negocios?", 17);
        Array.Resize(ref aspirations, aspirations.Length + 1);
        aspirations[aspirations.Length - 1] = resp_c;
        Console.WriteLine("\n\n");

        resp_c = realizar_pregunta_c_1("18. ¿Que importancia tiene para ti Hallar un propósito real en la vida?", 18);
        Array.Resize(ref aspirations, aspirations.Length + 1);
        aspirations[aspirations.Length - 1] = resp_c;
        Console.WriteLine("\n\n");

//----------------------------------------------------------------------------------------------------------//
        Console.ForegroundColor = ConsoleColor.Red;
        // Calcular coincidencias y top seis
        for (int i = 0; i < part_c.Count; i++) {
            foreach (int aspiration in aspirations) {
                if (part_c[i].Item2.Contains(aspiration)) {
                    coincidencias_c[i]++;
                }
            }
        }

        // Imprimir resultados y agregar coincidencias a la variable results
        Console.WriteLine("\nCoincidencias:");
        for (int i = 0; i < part_c.Count; i++) {
            Console.WriteLine("{0}: {1}", part_c[i].Item1, coincidencias_c[i]);
        }

        Console.WriteLine("\nTop seis:");

        var top_c = part_c.Zip(coincidencias_c, (part_c, coinc_c) => (part_c.Item1, coinc_c))
                            .OrderByDescending(p => p.Item2).Take(6);

        foreach (var item in top_c) {
            Console.WriteLine("{0}: {1}", item.Item1, item.Item2);
        }

//----------------------------------------------------------------------------------------------------------//

        for (int i = 0; i < results.Count; i++) {
            // Sumar el valor de coincidencias a cada vector en results
            results[i] = (results[i].Item1, results[i].Item2.Select(x => x + coincidencias_c[i]).ToList());
        }

        // Imprimir los nuevos valores de results
        Console.WriteLine("\n\n");
        foreach (var result in results) {
            Console.WriteLine("Total de {0}: {1}", result.Item1, string.Join(", ", result.Item2));
        }
        Console.WriteLine("\n\n");
        Console.ForegroundColor = ConsoleColor.Cyan;

//PART_D
//----------------------------------------------------------------------------------------------------------//

        Console.WriteLine("GM_>> Para las siguientes preguntas escoje lo que más se ajuste a ti.\n");

        Console.WriteLine("GM_>> Me gusta...\n\t1. Leer y meditar sobre los problemas\n\t2. Anotar datos y hacer cómputos\n\t3. Tener una posición poderosa\n\t4. Enseñar o ayudar a los demás\n\t5. Trabajar manualmente, usar equipos, herramientas\n\t6. Usar mi talento artístico\n");
        resp_d = realizar_pregunta_d_1(1, 6);
        Array.Resize(ref personal_selections, personal_selections.Length + 1);
        personal_selections[personal_selections.Length - 1] = resp_d;
        Console.WriteLine("\n\n");

        Console.WriteLine("GM_>> Mi mayor habilidad se manifiesta en…\n\t7. Negocios\n\t8. Artes\n\t9. Ciencias\n\t10. Liderazgo\n\t11. Relaciones Humanas\n\t12. Mecánica\n");
        resp_d = realizar_pregunta_d_1(7, 12);
        Array.Resize(ref personal_selections, personal_selections.Length + 1);
        personal_selections[personal_selections.Length - 1] = resp_d;
        Console.WriteLine("\n\n");

        Console.WriteLine("GM_>> Soy muy incompetente en…\n\t13. Mecánica\n\t14. Ciencia\n\t15. Relaciones Humanas\n\t16. Negocios\n\t17. Liderazgo\n\t18. Artes\n");
        resp_d = realizar_pregunta_d_1(13, 18);
        Array.Resize(ref personal_selections, personal_selections.Length + 1);
        personal_selections[personal_selections.Length - 1] = resp_d;
        Console.WriteLine("\n\n");

        Console.WriteLine("GM_>> Si tuviera que realizar alguna de estas actividades, la que menos me agradaría es…\n\t19. Tener una posición de responsabilidad\n\t20. Llevar pacientes mentales a actividades recreativas\n\t21. Llevar registros exactos y complejos\n\t22. Escribir un poema\n\t23. Hacer algo que exija paciencia y precisión\n\t24. Participar en actividades sociales muy formales\n");
        resp_d = realizar_pregunta_d_1(19, 24);
        Array.Resize(ref personal_selections, personal_selections.Length + 1);
        personal_selections[personal_selections.Length - 1] = resp_d;
        Console.WriteLine("\n\n");

        Console.WriteLine("GM_>> Las materias que más me gustan son (recuerda escoger solo una opcion)…\n\t25. Arte\n\t26. Administración, contabilidad\n\t27. Química, Física\n\t28. Educación tecnológica, Mecánica\n\t29. Historia\n\t30. Ciencias sociales, Filosofía\n");
        resp_d = realizar_pregunta_d_1(25, 30);
        Array.Resize(ref personal_selections, personal_selections.Length + 1);
        personal_selections[personal_selections.Length - 1] = resp_d;
        Console.WriteLine("\n\n");


//----------------------------------------------------------------------------------------------------------//
        Console.ForegroundColor = ConsoleColor.Red;
        // Calcular coincidencias y top seis
        for (int i = 0; i < part_d.Count; i++) {
            foreach (int personal_selection in personal_selections) {
                if (part_d[i].Item2.Contains(personal_selection)) {
                    coincidencias_d[i]++;
                }
            }
        }

        // Imprimir resultados y agregar coincidencias a la variable results
        Console.WriteLine("\nCoincidencias:");
        for (int i = 0; i < part_d.Count; i++) {
            Console.WriteLine("{0}: {1}", part_d[i].Item1, coincidencias_d[i]);
        }

        Console.WriteLine("\nTop seis:");

        var top_d = part_d.Zip(coincidencias_d, (part_d, coinc_d) => (part_d.Item1, coinc_d))
                            .OrderByDescending(p => p.Item2).Take(6);

        foreach (var item in top_c) {
            Console.WriteLine("{0}: {1}", item.Item1, item.Item2);
        }

        for (int i = 0; i < results.Count; i++) {
            // Sumar el valor de coincidencias a cada vector en results
            results[i] = (results[i].Item1, results[i].Item2.Select(x => x + coincidencias_d[i]).ToList());
        }

//----------------------------------------------------------------------------------------------------------//

        // Imprimir los nuevos valores de results
        Console.WriteLine("\n\n");
        foreach (var result in results) {
            Console.WriteLine("Total de {0}: {1}", result.Item1, string.Join(", ", result.Item2));
        }
        Console.WriteLine("\n\n");
        Console.ForegroundColor = ConsoleColor.Cyan;


//RESULTS
//----------------------------------------------------------------------------------------------------------//
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("KYO_>> !VEN¡ miramos como te fue a ti...");
        Console.WriteLine("KYO_>> Mira, asi quedaron tus aptitudes laborales en estos 6 grandes grupos");
        // Imprimir los resultados finales de results
        Console.WriteLine("\n");

        foreach (var result in results) {
            Console.WriteLine("\t\t{0}: {1}", result.Item1, string.Join(", ", result.Item2));
        }

        Console.WriteLine("\n");
        Console.WriteLine("KYO_>> ¡MIRA! podriamos trabajar juntos que alegria");
        Console.WriteLine("KYO_>> estos son las ocupaciones sugeridas que nos arrojan");

        // busca el valor con mas coincidencias totales en la matriz results
        foreach (var result in results) {
            foreach (int number in result.Item2) {
                if (number > maxNumber) {
                    top = result.Item1;
                    maxNumber = number;
                }
            }
        }

        // Buscar el vector con el mismo nombre en la lista occupations
        var matching_occupation = occupations.Find(occ => occ.Item1 == top);

        // Imprimir el vector
        Console.Write("\n\t");
        Console.WriteLine(top);
        Console.WriteLine(matching_occupation.Item2[0]);

        Console.ForegroundColor = ConsoleColor.Cyan;



//----------------------------------------------------------------------------------------------------------//
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n\n\n\n");
        Console.WriteLine("//------------------------------END_OF_GAMEPLAY------------------------------//");
        Console.WriteLine("\n\n");
        Console.ResetColor();




    }
   
}


