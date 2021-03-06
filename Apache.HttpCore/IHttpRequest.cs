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

using Org.Apache.Http;
using Sharpen;

namespace Org.Apache.Http
{
	/// <summary>
	/// A request message from a client to a server includes, within the
	/// first line of that message, the method to be applied to the resource,
	/// the identifier of the resource, and the protocol version in use.
	/// </summary>
	/// <remarks>
	/// A request message from a client to a server includes, within the
	/// first line of that message, the method to be applied to the resource,
	/// the identifier of the resource, and the protocol version in use.
	/// <pre>
	/// Request       = Request-Line
	/// *(( general-header
	/// | request-header
	/// | entity-header ) CRLF)
	/// CRLF
	/// [ message-body ]
	/// </pre>
	/// </remarks>
	/// <since>4.0</since>
	public interface IHttpRequest : HttpMessage
	{
		/// <summary>Returns the request line of this request.</summary>
		/// <remarks>Returns the request line of this request.</remarks>
		/// <returns>the request line.</returns>
		RequestLine GetRequestLine();
	}
}
