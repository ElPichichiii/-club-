/*
 * Created by SharpDevelop.
 * User: lauta
 * Date: 21/10/2024
 * Time: 00:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.Serialization;

namespace ClubDeportivo
{
	/// <summary>
	/// Desctiption of Excepcion_cupoExcedido.
	/// </summary>
	public class Excepcion_cupoExcedido : Exception
{
    public Excepcion_cupoExcedido(string message, string nombreDeporte)
        : base(string.Format(message, nombreDeporte)) // Se formatea el mensaje
    {
    }
}
}


		
		