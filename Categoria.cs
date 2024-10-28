/*
 * Created by SharpDevelop.
 * User: lauta
 * Date: 2/10/2024
 * Time: 16:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ClubDeportivo
{
	/// <summary>
	/// Description of Categoria.
	/// </summary>
	public class Categoria
	{
		private string nombreEntrenador,dni,dias,horarios;
		private int cupo,cantidadInscriptos;
		private double costoCuota;
	
		
		public Categoria(string nombreEntrenador,string dni,string dias,string horarios,int cupo,int cantidadInscriptos,double costoCuota)
		{
			this.nombreEntrenador=nombreEntrenador;
			this.dni=dni;
			this.dias=dias;
			this.horarios=horarios;
			this.cupo=cupo;
			this.cantidadInscriptos =0;
			this.costoCuota=costoCuota;
			
		}
		
		public string NombreEntrenador
		{
			set{this.nombreEntrenador=value;}
			get{return this.nombreEntrenador;}
		}
		
		public string Dni
		{
			set{this.dni=value;}
			get{return this.dni;}
		}
		
		
		public string Dias
		{
			set{this.dias=value;}
			get{return this.dias;}
		}
		
		public string Horarios
		{
			set{this.horarios=value;}
			get{return this.horarios;}
		}
		
		public int Cupo
		{
			set{this.cupo=value;}
			get{return this.cupo;}
		}
		
		public int CantidadInscriptos
		{
			set{this.cantidadInscriptos=value;}
			get{return this.cantidadInscriptos;}
		}
		
		public double CostoCuota
		{
			set{this.costoCuota=value;}
			get{return this.costoCuota;}
		}
		
	}
}
