/*
 * Created by SharpDevelop.
 * User: lauta
 * Date: 30/9/2024
 * Time: 23:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Globalization;
using System.Linq;

namespace ClubDeportivo
{
	class Program
	{
		public static void Main(string[] args)
		{
			Club club = new Club();
			char opcion;
			
			
			do
			{
				
			    Menu();
			    
			    opcion = char.ToLower(Console.ReadKey().KeyChar);  // Corregido: `.KeyChar` para obtener el carácter
			    Console.WriteLine();
			
			    switch (opcion)
			    {
			        case 'a':
			            // Lógica para dar de alta un entrenador
			            Console.WriteLine("Ingrese los datos del nuevo entrenador:");
			            AgregarEntrenador(club);
			            // Aquí solicitas nombre, dni, deporte, categoría, etc.
			            // club.AgregarEntrenador(...);
			            break;
			
			        case 'b':
			            // Lógica para dar de baja un entrenador
			            Console.WriteLine("Ingrese el DNI del entrenador que desea dar de baja:");
			            EliminarEntrenador(club);
			            break;

			        case 'c':
			            // Lógica para dar de alta a un niño/socio
			            Console.WriteLine("Ingrese los datos del niño/socio:");
			            NuevoInscripto(club);
			            // club.InscribirNiño(...);
			            break;
			
			        case 'd':
			            // Lógica para dar de baja a un niño/socio
			            Console.WriteLine("Ingrese el DNI del niño que desea dar de baja:");
			            BorrarInscripto(club);
			            // club.DarDeBajaNiño(...);
			            break;

			        case 'e':
			            // Lógica para simular el pago de una cuota
			            Console.WriteLine("Ingrese el DNI del socio/niño que realiza el pago:");
			            // club.SimularPago(...);
			            PagoCuota(club);
			            break;
			
			        case 'f':
			            // Submenú para inscripciones
			            SubMenuInscriptos(club);
			            break;
			
			        case 'g':
			            // Listado de deudores
			            club.ListaDeudores();
			            break;

			        case 'h':
			            // Agregar un deporte
			            Console.WriteLine("Ingrese los datos del nuevo deporte:");
			            AgregarDeporte(club);
			            // club.AgregarDeporte(...);
			            
			            break;
			
			        case 'i':
			            // Eliminar un deporte
			            Console.WriteLine("Ingrese el nombre del deporte que desea eliminar:");
			            EliminarDeporte(club);
			            // club.EliminarDeporte(...);
			            break;
			
			        case 's':
			            Console.WriteLine("Saliendo del programa...");
			            break;
	
			        default:
			            Console.WriteLine("Opción no válida, intente de nuevo.");
			            break;
			    }
			}
			while (opcion != 's');
		}	
	
				
		public static void Menu()
		{
			Console.Clear();
			Console.WriteLine("****************************************************************************************************");
			Console.WriteLine("****                                     Club Deportivo AYP                                     ****");
			Console.WriteLine("****************************************************************************************************");
			Console.WriteLine("");
		    Console.WriteLine("--------------------------------------------Menú del Club ------------------------");
		    Console.WriteLine("a - Dar de alta a un entrenador");
		    Console.WriteLine("b - Dar de baja a un entrenador");
		    Console.WriteLine("c - Dar de alta a un niño/socio en un deporte");
		    Console.WriteLine("d - Dar de baja a un niño/socio en un deporte");
		    Console.WriteLine("e - Simular el pago de una cuota");
		    Console.WriteLine("f - Submenú de inscripción:");
		    Console.WriteLine("    1. Listado por deporte");
		    Console.WriteLine("    2. Listado por deporte y categoría");
		    Console.WriteLine("    3. Total de inscriptos");
		    Console.WriteLine("g - Listado de deudores");
		    Console.WriteLine("h - Agregar un deporte");
		    Console.WriteLine("i - Eliminar un deporte");
		    Console.WriteLine("s - Salir");
		    Console.WriteLine("");
		    Console.WriteLine("Seleccione  una opcion:");
		}
	
		public static void SubMenuInscriptos(Club club)
    {
        char subOpcion;
        do
        {
            Console.Clear();
            Console.WriteLine("****************************************************************************************************");
            Console.WriteLine("****                                     Club Deportivo AYP                                     ****");
            Console.WriteLine("****************************************************************************************************");
            Console.WriteLine("");
            Console.WriteLine("------------------------------- Menú de Inscriptos y Deudores --------------------------------------");
            Console.WriteLine("1 - Listado por deporte");
            Console.WriteLine("2 - Listado por deporte y categoría");
            Console.WriteLine("3 - Listado total de inscriptos");
            Console.WriteLine("4 - Volver al menú principal");
            Console.Write("Seleccione una opción: ");
            subOpcion = char.ToLower(Console.ReadKey().KeyChar);  // Captura la opción en minúscula
            Console.WriteLine();

            switch (subOpcion)
            {
                case '1':
                    // Lógica para listar inscriptos por deporte
                    Console.WriteLine("Listado por deporte:");
                    club.ListaInscriptosPordDeporte();
                    break;

                case '2':
                    // Lógica para listar inscriptos por deporte y categoría
                    Console.WriteLine("Listado por deporte y categoría:");
                    club.ListaPorDeporteYCategoria();
                    break;

                case '3':
                    // Lógica para listar el total de inscriptos
                    Console.WriteLine("Listado total de inscriptos:");
                    club.ListaInscriptosTotal();
                    break;

                case '4':
                    Console.WriteLine("Volviendo al menú principal...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Presione cualquier tecla para intentarlo de nuevo.");
                    break;
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();

        } while (subOpcion != '4');  // Repite el submenú hasta que el usuario elija volver al menú principal
    }
			
		public static void AgregarEntrenador(Club club)
		{
			string nombrePersona,dni;
			float sueldoEntrenador;
			
			do
			{	
				Console.Clear();
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine("****                                     Club Deportivo AYP                                     ****");
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------- Ingresar Entrenador ---------------------------------------");
                Console.WriteLine("");

                Console.WriteLine("Ingrese el nombre del Entrenador.");
                nombrePersona=Console.ReadLine();
                if (!string.IsNullOrEmpty(nombrePersona))
		        {
		            nombrePersona = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombrePersona.ToLower());
		        }
		        else
		        {
		            Console.WriteLine("El nombre no puede estar vacío. Presione cualquier tecla para intentarlo de nuevo...");
		            Console.ReadKey();
		            continue; 
		        }
		
		        // Solicita el DNI del entrenador
		        Console.WriteLine("Ingrese el número de DNI (8 dígitos):");
		        dni = Console.ReadLine().Trim();
		
		        // Verifica que el DNI tenga exactamente 8 dígitos y sean numéricos
		        if (dni.Length != 8 || !dni.All(char.IsDigit))
		        {
		            Console.WriteLine("El DNI debe ser un número de 8 dígitos. Presione cualquier tecla para intentarlo de nuevo...");
		            Console.ReadKey();
		            continue;
		        }
		
		        // Solicita el sueldo del entrenador
		        Console.WriteLine("Ingrese el sueldo del entrenador:");
		        if (!float.TryParse(Console.ReadLine(), out sueldoEntrenador) || sueldoEntrenador <= 0)
		        {
		            Console.WriteLine("El sueldo debe ser un número positivo. Presione cualquier tecla para intentarlo de nuevo...");
		            Console.ReadKey();
		            continue;
		        }
		
		        // Verifica si ya existe un entrenador con el mismo DNI
		        if (!club.BuscarEntrenador(dni)) // Solo pasa el DNI
		        {
		            // Agrega el entrenador
		            if (club.AgregarEntrenador(nombrePersona, dni, sueldoEntrenador))
		            {
		                Console.WriteLine("El entrenador {0} ha sido agregado exitosamente.", nombrePersona);
		            }
		            else
		            {
		                Console.WriteLine("No se pudo agregar el entrenador.");
		            }
		        }
		        else
		        {
		            Console.WriteLine("El entrenador con DNI {0} ya está registrado.", dni);
		        }
		
		        // Pregunta si se desea agregar otro entrenador
		        Console.WriteLine("¿Desea agregar otro entrenador? SI/NO");
		
		    } while (Console.ReadLine().Trim().ToUpper() == "SI");
		
		    Console.WriteLine("Presione cualquier tecla para regresar al menú principal...");
		    Console.ReadKey();
		}
		
		
		public static void EliminarEntrenador(Club club)
		{
			string entrenadorDni;
			
			do
            {
                Console.Clear();
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine("****                                     Club Deportivo AYP                                     ****");
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------- Eliminar Entrenador ---------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("ingrese el DNI del entrenador que desea eliminar:");
                entrenadorDni=Console.ReadLine();
                bool eliminado=club.EliminarEntrenador(entrenadorDni);
                if(eliminado)
                {
                	Console.WriteLine("El entrenador con DNI {0} ha sido eliminado exitosamente.",entrenadorDni);
                }
                else
                {
                	Console.WriteLine("No se encontró un entrenador con el DNI {0}.",entrenadorDni);
       
                }
                 
                Console.WriteLine("¿Desea eliminar otro entrenador? (SI/NO)");
    		}
    		 while (Console.ReadLine().Trim().ToUpper() == "SI"); // Permite repetir el proceso si el usuario lo desea
    		
    		Console.WriteLine("Presione cualquier tecla para regresar al menú principal...");
    		Console.ReadKey();
		}
                	
		public static void NuevoInscripto(Club club)
		{
		    string nombreApellido = "", dni;
		    int edad, categoria, nroSocio, selDeporte;
		    bool esSocio;
		
		    do
		    {
		        Console.Clear();
		        Console.WriteLine("****************************************************************************************************");
		        Console.WriteLine("****                                     Club Deportivo AYP                                     ****");
		        Console.WriteLine("****************************************************************************************************");
		        Console.WriteLine("");
		        Console.WriteLine("-------------------------------------------- Inscripción -------------------------------------------");
		        Console.WriteLine("");
		        Console.WriteLine("Ingrese Nombre y Apellido:");
		        nombreApellido = Console.ReadLine().Trim();
		        nombreApellido = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombreApellido); // Formato correcto: Juan Perez
		
		        Console.WriteLine("Ingrese DNI (8 DIGITOS):");
		        dni = Console.ReadLine();
		
		        Console.WriteLine("Ingrese edad:");
		        edad = int.Parse(Console.ReadLine());
		
		        Console.WriteLine("Ingrese categoría:");
		        categoria = int.Parse(Console.ReadLine());
		
		        Console.WriteLine("¿Es socio? (SI/NO):");
		        esSocio = Console.ReadLine().Trim().ToUpper() == "SI";
		
		        if (esSocio)
		        {
		            Console.WriteLine("Ingrese el número de socio:");
		            nroSocio = int.Parse(Console.ReadLine());
		        }
		        else
		        {
		            nroSocio = 0;
		        }
		
		        // Mostrar la lista de deportes
		       	Console.WriteLine("Seleccione el deporte de la siguiente lista:");
				Console.WriteLine("");
				
				for (int i = 0; i < club.Deportes.Count; i++)
				{
				    Deporte deporte = (Deporte)club.Deportes[i];
				    Console.WriteLine((i + 1) + " - " + deporte.NombreDeporte); // Usar concatenación de cadenas
				}
				
				// Seleccionar deporte
				Console.WriteLine("Ingrese el número del deporte:");
				selDeporte = int.Parse(Console.ReadLine()) - 1;
				
				if (club.Deportes.Count == 0)
				{
				    Console.WriteLine("No hay deportes disponibles.");
				    return; // O maneja el caso como prefieras
				}

				
				string nombreDeporte = ((Deporte)club.Deportes[selDeporte]).NombreDeporte;

		        // Manejo de excepciones durante la inscripción
		        try
		        {
		            // Registrar nuevo inscripto
		            club.NuevoInscripto(nombreDeporte, dni, nombreApellido, categoria, edad, nroSocio, true);
		            Console.WriteLine("Inscripción realizada con éxito.");
		        }
		        catch (Excepcion_cupoExcedido ex)
		        {
		            // Mostrar mensaje de cupo excedido
		            Console.WriteLine(ex.Message);
		        }
		
		        // Preguntar si se desea continuar
		        Console.WriteLine("\n¿Desea inscribir a otra persona? (SI/NO):");
		
		    } while (Console.ReadLine().Trim().ToUpper() == "SI"); // Repetir si el usuario elige continuar
		
		    Console.WriteLine("Inscripción finalizada. Presione cualquier tecla para volver al menú principal...");
		    Console.ReadKey();
		}

			
		
		public static void BorrarInscripto(Club club)
		{
			string nombreSocio,dni;
			
			
			do{
				Console.Clear();
				Console.WriteLine("****************************************************************************************************");
				Console.WriteLine("****                                     Club Deportivo AYP                                     ****");
				Console.WriteLine("****************************************************************************************************");
				Console.WriteLine("");
				Console.WriteLine("---------------------------------------- Borrar Inscripción ----------------------------------------");
				Console.WriteLine("");
				
				Console.WriteLine("ingrese el nombre del socio:");
				nombreSocio=Console.ReadLine().Trim();
				if (string.IsNullOrEmpty(nombreSocio))
		        {
		            Console.WriteLine("El nombre del socio no puede estar vacío. Presione cualquier tecla para continuar...");
		            Console.ReadKey();
		            continue; // Volver a empezar el ciclo
		        }	
				
				Console.WriteLine("Ingrese el número de DNI.");
				dni = Console.ReadLine();
				if (dni.Length != 8 || !dni.All(char.IsDigit))
		        {
		            Console.WriteLine("El DNI debe ser un número de 8 dígitos. Presione cualquier tecla para continuar...");
		            Console.ReadKey();
		            continue; // Volver a empezar el ciclo
		        }	
				
				
				int sociosRestantes=club.BorrarInscripto(nombreSocio,dni);
				Console.WriteLine("Cantidad de socios restantes en el deporte {0}: {1}", nombreSocio, sociosRestantes);
        
				
				Console.WriteLine("");
				Console.WriteLine("¿Desea borrar a alguien mas? SI/NO");
				
			}
			while (Console.ReadLine().Trim().ToUpper() == "SI");
		}
		
		public static void PagoCuota(Club club)
		{
		    string dniSocio;
		
		    do
		    {
		        Console.Clear();
		        Console.WriteLine("****************************************************************************************************");
		        Console.WriteLine("****                                     Club Deportivo AYP                                     ****");
		        Console.WriteLine("****************************************************************************************************");
		        Console.WriteLine("");
		        Console.WriteLine("-------------------------------------------- Pagar Cuota -------------------------------------------");
		        Console.WriteLine("");
		
		        Console.Write("Ingrese el número de DNI: ");
		        dniSocio = Console.ReadLine().Trim();
		
		        // Validamos que el DNI tenga 8 dígitos y sea numérico
		        if (dniSocio.Length != 8 || !dniSocio.All(char.IsDigit))
		        {
		            Console.WriteLine("El DNI debe ser un número de 8 dígitos. Presione cualquier tecla para continuar...");
		            Console.ReadKey();
		            continue; // Vuelve a empezar el ciclo
		        }
		
		        // Verificamos si el inscripto existe
		        if (club.ExisteInscripto(dniSocio) != null) 
		        {
		            Console.WriteLine("¿Se procede a registrar el pago? (SI/NO)");
		            if (Console.ReadLine().Trim().ToUpper() == "SI")
		            {
		                // Intentamos realizar el pago
		                if (club.ValorCuota(dniSocio))
		                {
		                    Console.WriteLine("Pago realizado correctamente.");
		                }
		                else
		                {
		                    Console.WriteLine("No se pudo realizar el pago. Es posible que el socio ya haya pagado.");
		                }
		            }
		        }
		        else
		        {
		            Console.WriteLine("El DNI ingresado no existe. Presione cualquier tecla para continuar...");
		            Console.ReadKey();
		        }
		
		        Console.WriteLine("");
		        Console.WriteLine("¿Desea ingresar otro pago? (SI/NO)");
		    } while (Console.ReadLine().Trim().ToUpper() == "SI");
		
		    Console.WriteLine("Presione cualquier tecla para regresar al menú principal...");
		    Console.ReadKey();
		}
		
		
		public static void ListaDeudores(Club club)
		{
			string continuar;
			do
			{
				Console.Clear();
        		Console.WriteLine("****************************************************************************************************");
        		Console.WriteLine("****                                     Club Deportivo AYP                                     ****");
        		Console.WriteLine("****************************************************************************************************");
        		Console.WriteLine("");
        		Console.WriteLine("------------------------------------------- Lista Deudores -------------------------------------------");
        		Console.WriteLine("");

        		// Llamamos al método que ya tienes en la clase Club
        		bool hayDeudores = club.ListaDeudores();

       			if (!hayDeudores)
        		{
            		Console.WriteLine("No hay deudores registrados.");
        		}
        		else
        		{
            		Console.WriteLine("Se han listado todos los deudores.");
        		}

		        // Preguntar si desea ver la lista de deudores nuevamente
		        Console.WriteLine("¿Desea ver la lista de deudores nuevamente? (S/N):");
		        continuar = Console.ReadLine().Trim().ToUpper();
		        Console.WriteLine();

    		}while (continuar == "SI" ); // Repetir si el usuario elige continuar

    		Console.WriteLine("Presione cualquier tecla para continuar...");
    		Console.ReadKey();
		}
			
		
		public static void AgregarDeporte(Club club)
		{
			string continuar;
			do
			{
				Console.Clear();
				Console.WriteLine("****************************************************************************************************");
				Console.WriteLine("****                                     Club Deportivo AYP                                     ****");
				Console.WriteLine("****************************************************************************************************");
				Console.WriteLine("");
				Console.WriteLine("-------------------------------------------Agregar Deporte -------------------------------------------");
				Console.WriteLine("");
			
				Console.WriteLine("Ingrese el nombre del deporte:");
				string nombreDeporte = Console.ReadLine();
				
			    Console.WriteLine("Ingrese el día del deporte:");
			    string dia = Console.ReadLine();
				
			    Console.WriteLine("Ingrese la hora del deporte:");
			    string hora = Console.ReadLine();
				
			    Console.WriteLine("Ingrese el DNI del entrenador:");
			    string entrenadorDni = Console.ReadLine();
			
			    Console.WriteLine("Ingrese la categoría del deporte:");
			    int categoria = int.Parse(Console.ReadLine());
				
			    Console.WriteLine("Ingrese el cupo total de deportes:");
			    int cupo = int.Parse(Console.ReadLine());
				
			    Console.WriteLine("Ingrese el cupo libre:");
			    int cupoLibre = int.Parse(Console.ReadLine());
				
			    Console.WriteLine("Ingrese el costo de la cuota:");
			    double cuota = double.Parse(Console.ReadLine());
				
		
			    Console.WriteLine("Ingrese el descuento:");
			    float descuento = float.Parse(Console.ReadLine());
				
				// Llamar al método para agregar el deporte
				club.AgregarDeporte(nombreDeporte, dia, hora, entrenadorDni, categoria, cupo, cupoLibre, cuota, descuento);
				
				Console.WriteLine("¿Desea agregar otro deporte? (SI/NO):");
	        	continuar = Console.ReadLine().Trim().ToUpper();;
	        	Console.WriteLine();
	        
			} while (continuar == "SI");
			Console.WriteLine("Presione cualquier tecla para continuar...");
	    	Console.ReadKey();
		}
		
	
		public static void EliminarDeporte(Club club)
		{
			string nombreDeporte;
			bool deporteEliminado;
			do
			{
				Console.Clear();
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine("****                                     Club Deportivo AYP                                     ****");
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine("");
                Console.WriteLine("------------------------------------------- Eliminar Deporte -------------------------------------------");
                Console.WriteLine("");
			
		
				Console.WriteLine("Ingrese el deporte que desea eliminar:");
				nombreDeporte=Console.ReadLine();

				deporteEliminado = club.EliminarDeporte(nombreDeporte); // Asegúrate de que el método en Club acepte el nombre como parámetro

		        if (!deporteEliminado)
		        {
		            Console.WriteLine("No se encontró ningún deporte con ese nombre. Intente de nuevo.");
		        }
		
		        Console.WriteLine("¿Desea eliminar otro deporte? (SI/NO): ");
		    } while (Console.ReadLine().Trim().ToUpper() == "SI");
		}
	}
}
			
			
			
	
		
					
			
		

	  