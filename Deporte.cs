/*
 * Created by SharpDevelop.
 * User: lauta
 * Date: 2/10/2024
 * Time: 17:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;

namespace ClubDeportivo
{
	/// <summary>
	/// Description of Deporte.
	/// </summary>
	

	public class Deporte
	{
		private string nombreDeporte,dia,hora,entrenadorDni;
		private int categoria,cupo,cupoLibre;
		private ArrayList socios;
		private double cuota;
		private float descuentoSocio;
		
		public Deporte(string nombreDeporte,string dia,string hora,string entrenadorDni,int categoria,int cupo,
		               int cupoLibre,double cuota,float descuento)
		{
			this.nombreDeporte=nombreDeporte;
			this.dia=dia;
			this.hora=hora;
			this.entrenadorDni=entrenadorDni;
			this.categoria=categoria;
			this.cupo=cupo;
			this.cupoLibre=cupoLibre;
			this.socios=new ArrayList();
			this.cuota=cuota;
			this.descuentoSocio=descuento;
		}
		
		public string NombreDeporte
		{
			set{this.nombreDeporte=value;}
			get{return this.nombreDeporte;}
		}
		
		public string Dia
		{
			set{this.dia=value;}
			get{return this.dia;}
		}
		
		public string Hora
		{
			set{this.hora=value;}
			get{return this.hora;}
		}
		
		public string EntrenadorDni
		{
			set{this.entrenadorDni=value;}
			get{return this.entrenadorDni;}
		}
		
		public int Categoria
		{
			set{this.categoria=value;}
			get{return this.categoria;}
		}
		
		public int Cupo
		{
			set{this.cupo=value;}
			get{return this.cupo;}
		}
		
		public int CupoLibre
		{
			set{this.cupoLibre=value;}
			get{return this.cupoLibre;}
		}
		
		public ArrayList Socios
		{
			set{this.socios=value;}
			get{return this.socios;}
		}
		
		public double Cuota
		{
			set{this.cuota=value;}
			get{return this.cuota;}
		}
		
		public float DescuentoSocio
		{
			set{this.descuentoSocio=value;}
			get{return this.descuentoSocio;}
		}
		
		
		
		public void  ExisteDeportista(string dniSocio)//int
		{
			Console.WriteLine("ingrese el el numero de DNI:");
			dniSocio=Console.ReadLine();
			foreach(Socio s in socios)
			{
				if(s.Dni == dniSocio)
				{
					Console.WriteLine("ya existe socio con ese numero.");
					return	;
				}
			}
			Console.WriteLine("no existe ningun socio con ese numero.");
		}
		
		public void AgregarDeportista()
		{
			if(cupoLibre>0)
			{
				Console.WriteLine("Ingrese el dni del socio:");
				string dni=Console.ReadLine();
				foreach(Socio s in socios)
				{
					if(s.Dni == dni)
					{
						Console.WriteLine("ya existe socio.");
						return;
					}
				}
				Console.WriteLine("ingrese el nombre del socio:");
				string nombrePersona=Console.ReadLine();

       			Console.WriteLine("Ingrese la categoría del socio:");
       			int categoria = int.Parse(Console.ReadLine());

        		Console.WriteLine("Ingrese la edad del socio:");
        		int edad = int.Parse(Console.ReadLine());

        		Console.WriteLine("Ingrese el número de socio:");
        		int numero = int.Parse(Console.ReadLine());
        		
        		Console.WriteLine("¿el socio pago la cuota??");
        		bool cuotaPagada=bool.Parse(Console.ReadLine());

        		// Crear un nuevo objeto Socio con los datos ingresados
       			Socio nuevoSocio = new Socio(nombrePersona	, dni, categoria, edad, numero, cuotaPagada);

        		// Agregar el nuevo socio a la lista
        		socios.Add(nuevoSocio);
				cupoLibre--;
				Console.WriteLine("socio agregado con exito.");
			}
			else
			{
				Console.WriteLine("no hay cupo disponible");
			}
		}
		
		
		
		public void EliminarDeportistas()
		{
			Console.WriteLine("ingrese el dni del socio que desea eliminar :");
			string dni=Console.ReadLine();
			Socio socioEliminar=null;
			
			foreach(Socio s in socios)
			{
				if(s.Dni == dni)
				{
					socioEliminar=s;
					break;
				}
			}
			if(socioEliminar !=null)
			{
				socios.Remove(socioEliminar);
				cupoLibre++;
				Console.WriteLine("Socio eliminado con exito.");
			}
			else
			{
				Console.WriteLine("No se encontro socio.");
			}
			
		}
		
		public void AsignarEntrenador(ArrayList entrenadores)
		{
			Console.WriteLine("ingrese dni del entrenador:");
			string dni=Console.ReadLine();
			
			Entrenador entrenadorEncontrado=null;
			foreach(Entrenador e in entrenadores)
			{
				if(e.Dni == dni)
				{
					entrenadorEncontrado=e;
					break;
				}
			}
			
			//si no encuentra entrenador
			if(entrenadorEncontrado== null)
			{
				Console.WriteLine("no se ha encontrado entrenador");
				return;
			}
			
			//asignar el dni del entrenador encontrado al deporte
			this.EntrenadorDni=dni;
			Console.WriteLine("entrenador con dni{0} encontrado",dni);
		}
		
		public void RemoverEntrenador()
		{
	    if (!string.IsNullOrEmpty(this.EntrenadorDni))
	    {
	        this.EntrenadorDni = null; // O vaciar el DNI para que no haya entrenador asignado
	        Console.WriteLine("El entrenador ha sido removido.");
	    }
	    else
	    {
	        Console.WriteLine("No hay entrenador asignado.");
	    }
	}
		
		public void ListaDeportitas()//arraylist
		{
			if(socios.Count==0)
			{
				Console.WriteLine("No hay deportistas");
				return;
			}
			
			Console.WriteLine("Lista de deportistas");
			foreach(Socio s in socios)
			{
				Console.WriteLine("Número: {0}, Nombre: {1}, DNI: {2}, Categoria: {3}, Edad: {4}",s.NumeroSocio,s.NombrePersona,s.Dni,s.Categoria,s.Edad);
			}
			
		}
		
		
		
		public bool PagoCuota(string dni)//bool
		{
			foreach (Socio s in socios)
			{
				if(s.Dni == dni)
				{
					if(s.CuotaPagada)
					{
						Console.WriteLine("cuota paga");
						return true;//no se paga ,porque ya esta pagada
					}
					else
					{
						s.CuotaPagada=true;
						Console.WriteLine("se ha pagado la cuota con exito");
						return true;
					}
				}
			}
			Console.WriteLine("no se encontro ningun socio.");
			return false;
		}
	}
}
