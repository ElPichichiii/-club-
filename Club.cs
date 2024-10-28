/*
 * Created by SharpDevelop.
 * User: lauta
 * Date: 2/10/2024
 * Time: 17:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace ClubDeportivo
{
	/// <summary>
	/// Description of Club.
	/// </summary>
	public class Club
	{
		private  ArrayList entrenadores;
		private ArrayList deportes;
		
		public Club()
		{
			entrenadores=new ArrayList();
			deportes=new ArrayList();
		}
		
		public ArrayList Entrenadores
		{
			set{this.entrenadores=value;}
			get{return this.entrenadores;}
		}
		
		public ArrayList Deportes
		{
			set{this.deportes=value;}
			get{return this.deportes;}
		}
		
		public bool  BuscarEntrenador(string dni)//int
		{
			
			Entrenador entrenadorEncontrado=null;
			foreach(Entrenador e in entrenadores)
			{
				if(e.Dni == dni)
				{
					entrenadorEncontrado=e;//encontramos entrenador
					return true;;//salimos del bucle	
				}
			}
			return false;
			
			
		}
		
	public bool AgregarEntrenador(string nombrePersona,string dni,float sueldoEntrenador)
{
	
   // Verifica si el entrenador ya existe
   
   foreach(Entrenador e in entrenadores)
   {
   	if(e.Dni == dni)
   	{
   		
   		return false;
   	}
   }

    // Crear el nuevo entrenador y agregarlo
    Entrenador nuevoEntrenador = new Entrenador(nombrePersona, dni,sueldoEntrenador);
    entrenadores.Add(nuevoEntrenador);
    
    return true;
}
	
	public bool EliminarEntrenador(string entrenadorDni)
{
   

    Entrenador entrenadorAEliminar = null;

    // Busca al entrenador con el DNI proporcionado
    foreach (Entrenador e in entrenadores)
    {
        if (e.Dni == entrenadorDni)
        {
            entrenadorAEliminar = e;
            break;  // Sale del bucle cuando se encuentra el entrenador
        }
    }

    // Verifica si se encontró al entrenador
    if (entrenadorAEliminar == null)
    {
        
        return false; // Sale del método si no se encuentra
    }

    // Verifica si el entrenador está asignado a algún deporte
    foreach (Deporte d in deportes)
    {
        if (d.EntrenadorDni == entrenadorAEliminar.Dni) // Se compara el DNI
        {
            
            return false; // Sale del método si el entrenador está asignado
        }
    }

    // Si no hay asignaciones, se procede a eliminar
    entrenadores.Remove(entrenadorAEliminar);
    return true;
}

	
			
		public void AsignarEntrenadorADeporte()
		{
			Console.WriteLine("ingrese el nombre del entrenador:");
			string nombreDeporte=Console.ReadLine();
			Deporte deporteEncontrado=null;
			foreach(Deporte d in deportes)
			{
				if(d.NombreDeporte == nombreDeporte)
				{
					deporteEncontrado=d;
					break;
				}
			}
			Console.WriteLine("Ingrese el dni del entrenador:");
			string entrenadorDni=Console.ReadLine();
			Entrenador entrenadorEncontrado=null;
			foreach(Entrenador e in entrenadores)
			{
				if(e.Dni == entrenadorDni)
				{
					entrenadorEncontrado=e;
					break;
				}
			}
			if(entrenadorEncontrado==null)
			{
				Console.WriteLine("no se ha encontrado ningun entrenador");
				return;//salimos del metodo
			}
			
			//asignamos
			deporteEncontrado.EntrenadorDni=entrenadorEncontrado.Dni;
			Console.WriteLine("entrenador:{0} asignado al deporte:{1}",entrenadorEncontrado.NombrePersona,deporteEncontrado.NombreDeporte);
		}
			
			
		
		public bool ExisteDeporteYCategoria(string nombreDeporte,int categoria)
		{
			foreach(Deporte d in deportes)
			{
				if(d.NombreDeporte == nombreDeporte && d.Categoria ==categoria)
				{
					return true;
				}
			}
			return false;
		}
		
		public bool EstaVacioDeporte(string nombreDeporte)//bool
		{
			foreach(Deporte d in deportes)
			{
				if(d.NombreDeporte == nombreDeporte)
				{
					return d.CupoLibre == d.Cupo;
				}
			}
			return true;
			
		}
		
		public void AgregarDeporte(string nombreDeporte, string dia, string hora, string entrenadorDni, int categoria, int cupo, int cupoLibre, double cuota, float descuento)
		{
			
			foreach(Deporte d in deportes)
			{
				if(d.NombreDeporte == nombreDeporte)
				{
					Console.WriteLine("ya existe un deporte con ese nombre.");
					return;
				}
			}
			
			bool entrenadorExiste=false;
			foreach(Entrenador e in entrenadores)
			{
				if(e.Dni == entrenadorDni)
				{
					entrenadorExiste=true;
					break;
				}
			}
			if(!entrenadorExiste)
			{
				Console.WriteLine("No existe entrenador.");
			}
			
			Deporte nuevoDeporte = new Deporte(nombreDeporte, dia, hora, entrenadorDni, categoria, cupo, cupoLibre, cuota, descuento);
    		deportes.Add(nuevoDeporte);
    		Console.WriteLine("Deporte agregado con éxito.");
			
		}
		
		public bool EliminarDeporte(string nombreDeporte)
		{
			Deporte deporteAEliminar=null;
			foreach (Deporte d in deportes)
			{
				if(d.NombreDeporte == nombreDeporte)
				{
					if(d.Socios.Count>0)
					{
						Console.WriteLine("No se puede eliminar el deporte,ya que tiene inscriptos.");
						return false;
					}
					deporteAEliminar=d;
					break;
				}
			}
			if(deporteAEliminar !=null)
			{
				deportes.Remove(deporteAEliminar);
				Console.WriteLine("deporte eliminado con exito.");
				return true;
			}
			else
			{
				Console.WriteLine("no se encontro ningun deporte con el nombre.");
				return false;
			}
			
		}
		
		public int TotalDeportes()//int
		{
			Console.WriteLine("el numero total de deportes es:{0}",deportes.Count);
			return deportes.Count;
		}
		
		public void ListaDeportes()//arraylist
		{
			if(deportes.Count ==0)
			{
				Console.WriteLine("No se encontraron deportes");
				return;
			}
			Console.WriteLine("deportes registrados:");
			foreach(Deporte d in deportes)
			{
				Console.WriteLine("Nombre: {0}, Día: {1}, Hora: {2}, Entrenador DNI: {3}, Categoría: {4}, Cupo: {5}, Cupo Libre: {6}," +
"				                  Cuota: {7}, Descuento: {8}",d.NombreDeporte,d.Dia,d.Hora,d.EntrenadorDni,d.Categoria,d.Cupo,d.CupoLibre,
									d.Cuota,d.DescuentoSocio);
			}
		}
		
		public void ListaCategoriaXDeporte()//arraylist
		{
			Console.WriteLine("ingrese el nombre del deporte:");
			string nombreDeporte=Console.ReadLine();
			
			ArrayList categorias=new ArrayList();
			foreach(Deporte d in deportes)
			{
				if(d.NombreDeporte == nombreDeporte)
				{
					categorias.Add(d.Categoria);
				}
			}
			if(categorias.Count ==0)
			{
				Console.WriteLine("no se encontraron categorias o deportes registrados");
				return;//salir si no se encuentra el deporte
			}
			Console.WriteLine("categorias para el deporte:{0}",nombreDeporte);
			foreach(Categoria c in categorias)
			{
				Console.WriteLine(c);
			}
		}
		
		public void ListaInscriptosPordDeporte()//arraylist
		{
			Console.WriteLine("ingrese  el nombre del deporte:");
			string nombreDeporte=Console.ReadLine();
			foreach(Deporte d in deportes)
			{
				if(d.NombreDeporte == nombreDeporte)
				{
					Console.WriteLine("ya hay inscriptos en el deporte");
					
					if(d.Socios.Count ==0)
					{
						Console.WriteLine("no hay inscriptos por deporte");
						return;
					}
					
					foreach(Socio s in d.Socios)
					{
						Console.WriteLine("nombre:{0} -dni{1}",s.NombrePersona,s.Dni);
					}
					return;
				}
			}
			Console.WriteLine("el deporte ingresado no existe");
		}
				
					
					
				
				
		public void ListaPorDeporteYCategoria()//arraylist
		{
			Console.WriteLine("ingrese el deporte:");
			string nombreDeporte=Console.ReadLine();
			
			Console.WriteLine("ingrese la categoria:");
			int categoria=int.Parse(Console.ReadLine());
			
			bool encontrado=false;
			
			foreach(Deporte d in deportes)
			{
				if(d.NombreDeporte == nombreDeporte && d.Categoria == categoria)
				{
					  Console.WriteLine("Deporte: {0}, Categoría: {1}, Entrenador: {2}, Cupo: {3}",d.NombreDeporte,d.Categoria,d.EntrenadorDni,d.Cupo);
					  encontrado=true;
				}
			}
			
			if(!encontrado)
			{
				Console.WriteLine("No se encontraron deportes con ese nombre y categoría.");
			}
		}
	
			
		
		
		public void ListaInscriptosTotal()//arraylist
		{
			if (deportes.Count == 0)
    {
        Console.WriteLine("No hay deportes registrados.");
        return; // Salir si no hay deportes
    }

    Console.WriteLine("Lista total de inscriptos en todos los deportes:");
    foreach (Deporte d in deportes)
    {
        Console.WriteLine("Deporte: {0}",d.NombreDeporte);
        
        // Verificar si hay inscriptos en el deporte
        if (d.Socios.Count == 0)
        {
            Console.WriteLine("No hay inscriptos en este deporte.");
        }
        else
        {
            foreach (Socio s in d.Socios)
            {
                Console.WriteLine("- Número: {0}, Nombre: {1}, DNI: {2}, Categoría: {3}, Edad: {4}",s.NumeroSocio,s.NombrePersona,s.Dni,s.Categoria,s.Edad);
            }
        }

        Console.WriteLine(); // Espacio entre deportes
    }
}
		
		
		public bool ListaDeudores() // Devuelve true si hay deudores, false de lo contrario
		{
		    bool hayDeudores = false; // Para verificar si hay deudores
		
		    Console.WriteLine("Lista de deudores (socios que no han pagado):");
		
		    foreach (Deporte d in deportes)
		    {																																													
		        // Verificar si hay inscriptos en el deporte
		        if (d.Socios.Count == 0)
		        {
		            continue; // Si no hay inscriptos, pasar al siguiente deporte
		        }
		
		        foreach (Socio s in d.Socios)
		        {
		            if (!s.CuotaPagada) // Verificar si la cuota no ha sido pagada
		            {
		                Console.WriteLine("Deporte: {0}, Número: {1}, Nombre: {2}, DNI: {3}, Categoría: {4}, Edad: {5}",
		                                  d.NombreDeporte, s.NumeroSocio, s.NombrePersona, s.Dni, s.Categoria, s.Edad);
		                hayDeudores = true; // Hay al menos un deudor
		            }
		        }
		    }
		
		    if (!hayDeudores)
		    {
		        Console.WriteLine("No hay deudores registrados.");
		    }
		
		    return hayDeudores; // Retornar true o false según si hay deudores
		}

		
		public void AgregarEntrenadorDeporte()//int
		{
			Console.WriteLine("ingrese el deporte");
			string nombreDeporte=Console.ReadLine();
			Deporte deporteEncontrado=null;
			foreach(Deporte d in deportes)
			{
				if(d.NombreDeporte == nombreDeporte)
				{
					deporteEncontrado=d;
					break;
				}
			}
			if(deporteEncontrado ==null)
			{
				Console.WriteLine("el deporte ingresado no existe");
				return ;
			}
			
			Console.WriteLine("ingrese el dni del entrenador");
			string dniEntrenador=Console.ReadLine();
			Entrenador entrenadorEncontrado=null;
			foreach(Entrenador e in entrenadores)
			{
				if(e.Dni == dniEntrenador)
				{
					entrenadorEncontrado=e;
					break;
				}
			}
			
			if(entrenadorEncontrado==null)
			{
				Console.WriteLine("No se encontro ningun entrenador con ese dni");
				return  ;
			}
			
			deporteEncontrado.EntrenadorDni=entrenadorEncontrado.Dni;
			Console.WriteLine("Entrenador {0} (DNI: {1}) asignado al deporte:{2}.",entrenadorEncontrado.NombrePersona,entrenadorEncontrado.Dni,
			                  entrenadorEncontrado.NombrePersona);
			
			

		}
		
		public void QuitarEntrenadorDeporte()
		{
			Console.WriteLine("ingrese el deporte");
			string nombreDeporte=Console.ReadLine();
			Deporte deporteEncontrado=null;
			foreach(Deporte d in deportes)
			{
				if(d.NombreDeporte == nombreDeporte)
				{
					deporteEncontrado=d;
					break;
				}
			}
			if(deporteEncontrado==null)
			{
				Console.WriteLine("no se ha encontrado ningun deporte.");
				return ;
			}
			Console.WriteLine("ingrese el dni del entrenador que desea quitar:");
			string dniEntrenador=Console.ReadLine();
			if(deporteEncontrado.EntrenadorDni == dniEntrenador)
			{
				deporteEncontrado.EntrenadorDni=null;
				Console.WriteLine("Entrenador con DNI {0} ha sido quitado del deporte {1}.",dniEntrenador,deporteEncontrado);
			}
			else
			{
				Console.WriteLine("El entrenador con ese DNI no está asignado a este deporte.");
			}
		}
			
		
		
		public void BuscarEntrenadorDeporte()//int
		{
			Console.WriteLine("ingrese el deporte");
			string nombreDeporte=Console.ReadLine();
			Deporte deporteEncontrado=null;
			foreach(Deporte d in deportes)
			{
				if(d.NombreDeporte == nombreDeporte)
				{
					deporteEncontrado=d;
					break;
				}
			}
			if(deporteEncontrado==null)
			{
				Console.WriteLine("el deporte ingresado no existe");
				return ;
			}
			
			if(deporteEncontrado.EntrenadorDni==null)
			{
				Console.WriteLine("no existe un entrenador asignado a ese deporte");
			}
			else
			{
				Entrenador entrenadorEncontrado=null;
				foreach(Entrenador e in entrenadores)
				{
					if(e.Dni == deporteEncontrado.EntrenadorDni)
					{
						entrenadorEncontrado=e;
						break;
					}
				}
				if(entrenadorEncontrado==null)
				{
					Console.WriteLine("Entrenador asignado: {0} (DNI: {1})",entrenadorEncontrado.NombrePersona,entrenadorEncontrado.Dni);
				}
				
				else
				{
					Console.WriteLine("No se encontró un entrenador con el DNI asignado.");
				
			}
			}
		}
		
		public int CupoInscripto()//int
		{
			Console.WriteLine("ingrese el deporte");
			string nombreDeporte=Console.ReadLine();
			Deporte deporteEncontrado=null;
			foreach(Deporte d in deportes)
			{
				if(d.NombreDeporte == nombreDeporte)
				{
					deporteEncontrado=d;
					break;
				}
			}
			
			if(deporteEncontrado==null)
			{
				Console.WriteLine("el deporte ingresado no existe");
				return 0;
			}
			
			int cupoLibre=deporteEncontrado.CupoLibre;
			Console.WriteLine("Cupo libre en el deporte '{0}': {cupoLibre}",deporteEncontrado.NombreDeporte,cupoLibre);
			
			return cupoLibre;

		}
		
		public Socio ExisteInscripto(string dni)
		{
		    Console.WriteLine("Ingrese el deporte:");
		    string nombreDeporte = Console.ReadLine();
		    Deporte deporteEncontrado = null;
		
		    foreach (Deporte d in deportes)
		    {
		        if (d.NombreDeporte.Equals(nombreDeporte, StringComparison.OrdinalIgnoreCase))
		        {
		            deporteEncontrado = d;
		            break;
		        }
		    }
		
		    if (deporteEncontrado == null)
		    {
		        Console.WriteLine("El deporte ingresado no existe.");
		        return null; // Retorna null si el deporte no existe
		    }
		
		    foreach (Socio s in deporteEncontrado.Socios)
		    {
		        if (s.Dni.Equals(dni, StringComparison.OrdinalIgnoreCase))
		        {
		            return s; // Retorna el socio si es encontrado
		        }
		    }
		
		    Console.WriteLine("No se encontró un inscripto con ese DNI en el deporte.");
		    return null; // Retorna null si no se encontró el socio
		}
				
		public int NuevoInscripto(string nombreDeporte, string dni, string nombrePersona, int categoria, int edad, int nroSocio, bool cuotaPaga)
		{
		    // Buscar el deporte solicitado
		    Deporte deporteEncontrado = null;
		    foreach (Deporte d in deportes)
		    {
		        if (d.NombreDeporte == nombreDeporte)
		        {
		            deporteEncontrado = d;
		            break;
		        }
		    }
		    
		    // Si no se encuentra el deporte
		    if (deporteEncontrado == null)
		    {
		        Console.WriteLine("El deporte ingresado no existe");
		        return 0; // Retornamos 0 si no se encontró el deporte
		    }
		    
		    // Verificar si el socio ya está registrado
		    foreach (Socio s in deporteEncontrado.Socios)
		    {
		        if (s.Dni == dni)
		        {
		            Console.WriteLine("El socio ya está registrado en este deporte.");
		            return deporteEncontrado.Socios.Count; // Retornamos el total actual si ya está inscrito
		        }
		    }
		    
		    // Verificar si hay cupo disponible
		    if (deporteEncontrado.CupoLibre <= 0)
		    {
		        // Si no hay cupo, lanzamos la excepción personalizada con formato
		        throw new Excepcion_cupoExcedido("No hay más cupos disponibles para el deporte {0}.",nombreDeporte);
		    }
		    
		    // Agregar nuevo socio
		    Socio socioNuevo = new Socio(nombrePersona, dni, categoria, edad, nroSocio, cuotaPaga);
		    deporteEncontrado.Socios.Add(socioNuevo);
		    deporteEncontrado.CupoLibre--; // Reducimos el cupo disponible
		    
		    Console.WriteLine("Socio agregado con éxito.");
		    return deporteEncontrado.Socios.Count; // Retornamos el total de socios luego de la inscripción
		}

		
		
		public int BorrarInscripto(string nombreDeporte,string dni )//int
		{
   			foreach (Deporte d in deportes)
    		{
       			if (d.NombreDeporte == nombreDeporte)
        		{
           			Socio socioEncontrado = null;
            		foreach (Socio s in d.Socios)
            		{
                		if (s.Dni == dni)
                		{
		                    socioEncontrado = s;
		                    break;
                		}
           			}
            		if (socioEncontrado != null)
		            {
		                d.Socios.Remove(socioEncontrado);
		                Console.WriteLine("Socio con DNI: {0} fue eliminado.", dni);
		            }
		            else
		            {
		                Console.WriteLine("No se ha encontrado ningún socio con ese DNI.");
		            }
		            return d.Socios.Count;
			        }
			    }
			    Console.WriteLine("El deporte que ingresó no existe.");
			    return 0; // Retornamos 0 si no se eliminó a nadie, ya que no encontró el deporte.
			}
		
		
		public bool ValorCuota(string dniSocio)
		{
	    // Verificamos si el socio está inscrito
	    Socio socio = ExisteInscripto(dniSocio);
	    
	    if (socio == null)
	    {
	        // No se encontró el socio
	        return false;
	    }
	
	    // Si el socio aún no ha pagado este mes
	    if (socio.UltimoMesPago.Month != DateTime.Now.Month)
	    {
	        // Registramos el pago y actualizamos la fecha
	        socio.CuotaPagada = true; // Asumiendo que CuotaPagada es una propiedad de tipo bool
	        socio.UltimoMesPago = DateTime.Now; // Actualizamos la fecha de pago
	        
	        Console.WriteLine("Pago registrado para el socio con DNI: {0}", socio.Dni);
	        return true; // Pago realizado correctamente
	    }
	    
	    // El socio ya ha pagado este mes
	    Console.WriteLine("El socio con DNI: {0} ya ha pagado este mes.", socio.Dni);
	    return false; // No se pudo realizar el pago
	}
}
}
							
		    	