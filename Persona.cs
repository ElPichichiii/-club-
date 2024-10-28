/*
 * Created by SharpDevelop.
 * User: lauta
 * Date: 1/10/2024
 * Time: 00:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ClubDeportivo
{
	/// <summary>
	/// Description of Persona.
	/// </summary>
	public class Persona
	{
		protected string nombrePersona,dni;
		
		public Persona(string nombrePersona,string dni)
		{
			this.nombrePersona=nombrePersona;
			this.dni=dni;
		
		}
		
		public string NombrePersona
		{
			set{this.nombrePersona=value;}
			get{return this.nombrePersona;}
		}
		
		public string Dni
		{
			set{this.dni=value;}
			get{return this.dni;}
		}
		
		public void Imprimir()
		{
			Console.WriteLine(nombrePersona+dni);
		}
			
	}
}
