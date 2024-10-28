/*
 * Created by SharpDevelop.
 * User: lauta
 * Date: 1/10/2024
 * Time: 00:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ClubDeportivo
{
	/// <summary>
	/// Description of Socio.
	/// </summary>
	public class Inscripto:Persona
	{
		
		protected int  categoria,edad;
		protected DateTime ultimomespago;
		public Inscripto(string nombrePersona,string dni,int categoria,int edad):base(nombrePersona,dni)
		{
			
			this.categoria=categoria;
			this.edad=edad;
			this.ultimomespago= DateTime.Now;
		}
		
		
		
		public int Categoria
		{
			set{this.categoria=value;}
			get {return this.categoria;}
		}
		
		public int Edad
		{
			set{this.edad=value;}
			get{return this.edad;}
		}
		
		public DateTime UltimoMesPago
		{
			set{this.ultimomespago=value;}
			get{return ultimomespago;}
		}
	}
}
