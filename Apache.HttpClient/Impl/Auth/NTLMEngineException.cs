/**
 * Couchbase Lite for .NET
 *
 * Original iOS version by Jens Alfke
 * Android Port by Marty Schoch, Traun Leyden
 * C# Port by Zack Gramana
 *
 * Copyright (c) 2012, 2013 Couchbase, Inc. All rights reserved.
 * Portions (c) 2013 Xamarin, Inc. All rights reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software distributed under the
 * License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 */

using System;
using Apache.Http.Auth;
using Sharpen;

namespace Apache.Http.Impl.Auth
{
	/// <summary>Signals NTLM protocol failure.</summary>
	/// <remarks>Signals NTLM protocol failure.</remarks>
	/// <since>4.0</since>
	[System.Serializable]
	public class NTLMEngineException : AuthenticationException
	{
		private const long serialVersionUID = 6027981323731768824L;

		public NTLMEngineException() : base()
		{
		}

		/// <summary>Creates a new NTLMEngineException with the specified message.</summary>
		/// <remarks>Creates a new NTLMEngineException with the specified message.</remarks>
		/// <param name="message">the exception detail message</param>
		public NTLMEngineException(string message) : base(message)
		{
		}

		/// <summary>Creates a new NTLMEngineException with the specified detail message and cause.
		/// 	</summary>
		/// <remarks>Creates a new NTLMEngineException with the specified detail message and cause.
		/// 	</remarks>
		/// <param name="message">the exception detail message</param>
		/// <param name="cause">
		/// the <tt>Throwable</tt> that caused this exception, or <tt>null</tt>
		/// if the cause is unavailable, unknown, or not a <tt>Throwable</tt>
		/// </param>
		public NTLMEngineException(string message, Exception cause) : base(message, cause
			)
		{
		}
	}
}
