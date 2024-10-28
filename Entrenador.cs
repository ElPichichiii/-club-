/*
 * Created by SharpDevelop.
 * User: lauta
 * Date: 1/10/2024
 * Time: 00:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ClubDeportivo
{
	/// <summary>
	/// Description of Entrenador.
	/// </summary>
	public class Entrenador:Persona
	{
		private float sueldoEntrenador;
		
		public Entrenador(string nombrePersona,string dni,float sueldoEntrenador):base(nombrePersona,dni)
		{
			this.sueldoEntrenador=sueldoEntrenador;
		}
		
		public float Sueldo
		{
			set{this.sueldoEntrenador=value;}
			get{return this.sueldoEntrenador;}
		}
	}
}
