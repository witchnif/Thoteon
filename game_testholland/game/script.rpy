
# Declara los personajes usados en el juego como en el ejemplo:

define IA = Character("Thoteon")
define humano = Character("Alicia", color = "F175DB")

# El juego comienza aquí.

label start:
    scene neon
    show bot at left
    with fade
    IA "Hola me llamo Thoteon"
    IA "yo soy la IA, que te va acompañar en una charla muy interesamte 
    para hacer un test de aptitudes laborales"
    IA "mi objetivo es ayudar a los estudiantes de bachillerato 
    a elegir una carrera profesional"
    IA "Quieres saber que quieres ser?"
    show persona at right
    humano "si"
    IA "comenzemos!"
    with fade
    scene tablero
    show bot at left
    IA "vamos hacer un test para saber como eres" 
    IA "¿Para las siguientes preguntas escoja una sola alternativa, según lo que más se ajuste a usted.?"

    menu :
        "a)	Leer  y meditar sobre los problemas":
            jump opc1
        "b)	Anotar datos y hacer cómputos":
            jump opc2
        "c)	Tener una posición poderosa":
            jump opc3
        "d)	Enseñar o ayudar a los demás" :
            jump opc4
        "e)	Trabajar manualmente, usar equipos, herramientas":
            jump opc5
        "f)	Usar mi talento artístico":
            jump opc6
    

     

    return
    label opc1:
        scene final
        show bot at right
        IA "Eres INVESTIGADOR"
        IA "como eres social debes hacer estas actividades para fortalezer tus habilidades:"
        IA "Leer libros o revista científicas,Trabajar en un laboratorio,Trabajar en un proyecto científico,
            Construir modelos de cohetes."
        IA "Una vez que ya sabes las habilidades deberias estudiar:"
        IA "Tomar un curso de química,Tomar un curso de física,Tomar un curso de geometría,Tomar un curso de biología."
        IA "Espero que te fuera ayudado, hasta la proxima y exitos en tu carrera"
        return

        label opc2:
            scene final
            show bot at right
            IA "Eres CONVENCIONAL"
            IA "como eres realizta debes hacer estas actividades para fortalezer tus habilidades:"
            IA "Mantener en orden mi escritorio y habitación,Mecanografiar documentos o cartas para mí o para otros"
            IA "Sumar, restar, multiplicar números en negocios o administración,Manejar máquinas de negocios de cualquier tipo."
            IA "Una vez que ya sabes las habilidades deberias estudiar:"
            IA "curso de mecanografía,curso de comercio,curso de contabilidad,curso de matemáticas comerciales."
            IA "Espero que te fuera ayudado, hasta la proxima y exitos en tu carrera"
            return
        label opc3: 
            scene final
            show bot at right
            IA "Eres EMPRENDEDOR"
            IA "como eres realizta debes hacer estas actividades para fortalezer tus habilidades:"
            IA  "Influir en los demás,Vender,Discutir sobre política,Administrar mi propio servicio o negocio,"
            IA "Asistir a conferencias,Ofrecer pláticas,"
            IA "Una vez que ya sabes las habilidades deberias estudiar:"
            IA "Curso de Emprendimiento,Curso de Desarrollo de Habilidades Gerenciales,Curso de Marketing Digital,"
            IA "Curso de Finanzas para Emprendedores,Curso de Gestión de Proyectos,Curso de Desarrollo de Productos o Servicios."
            IA "Espero que te fuera ayudado, hasta la proxima y exitos en tu carrera"
            return
        label opc4:
            scene final
            show bot at right
            IA "Eres SOCIAL"
            IA "como eres social debes hacer estas actividades para fortalezer tus habilidades:"
            IA "Escribir cartas a los amigos,Ir a la iglesia,Pertenecer a grupos sociales,Ayudar a otros en sus problemas personales,"    
            IA "Cuidar a niños,Asistir a fiestas,Bailar,Leer sobre psicología."
            IA "Una vez que ya sabes las habilidades deberias estudiar:"
            IA "Curso de Trabajo Social,Curso de Psicología Social,Curso de Derechos Humanos,Curso de Desarrollo Comunitario,"
            IA "Curso de Educación Social,Curso de Políticas Sociales."
            IA "Espero que te fuera ayudado, hasta la proxima y exitos en tu carrera"

            return
        label opc5:
            scene final
            show bot at right    
            IA "Eres realista" 
            IA "como eres realizta debes hacer estas actividades para fortalezer tus habilidades:"
            IA "Repara articulos electricos, Reparar automóviles,Reparar artículos mecánicos,Hacer artículos de madera
            Conducir camiones y tractores,"
            IA "Utilizar herramientas mecánicas o de herrería,Acondicionar un automóvil o bicicletas para carreras.
            Tomar un curso taller,"
            IA "Tomar un curso de dibujo mecánico,Tomar un curso de labrado de madera,Tomar un curso de mecánica automotriz"
            IA "Eres INVESTIGADOR"
            IA "Espero que te fuera ayudado, hasta la proxima y exitos en tu carrera"
            
            return
        label opc6:
            scene final
            show bot at right   
            IA "Eres ARTÍSTICO "
            IA "Como eres como eres artistico debes hacer estas actividades para fortalezer tus habilidades: "
            IA "Bosquejar, dibujar o pintarBosquejar, dibujar o pintar,Asistir a conciertos,Diseñar muebles o edificios,"
            IA "Tocar en una banda, conjunto u orquesta,Tocar un instrumento musical,Ir a recitales, conciertos o comedias musicales,"
            IA "Leer novelas y temas de actualidad ,Hacer retratos o fotografía creativa."
            IA "Una vez que ya sabes las habilidades deberias estudiar:"
            IA "Curso de Dibujo y pintura,Curso de Escultura,Curso de Fotografía,Curso de Diseño gráfico,Curso de Artes escénicas,"
            IA "Curso de Artes textiles,Curso de Ilustración,Curso de Artes digitales."
            IA "Espero que te fuera ayudado, hasta la proxima y exitos en tu carrera"
            return

    