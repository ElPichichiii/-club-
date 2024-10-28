/*
 * Created by SharpDevelop.
 * User: lauta
 * Date: 1/10/2024
 * Time: 00:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ClubDeportivo
{
	/// <summary>
	/// Description of socioDescuento.
	/// </summary>
	public class Socio:Inscripto
	{
		private int numeroSocio;
		private bool cuotaPagada;
		
		public Socio(string nombrePersona,string dni,int categoria,int edad,int numeroSocio,bool cuotaPagada):base (nombrePersona,dni,categoria,edad)
		{
			this.numeroSocio=numeroSocio;
			this.cuotaPagada=cuotaPagada;
		}
		
		public int NumeroSocio
		{
			set{this.numeroSocio=value;}
			get{return this.numeroSocio;}
		}
		
		public bool CuotaPagada
		{
			set{this.cuotaPagada=value;}
			get{return this.cuotaPagada;}
		}
	}
}
			