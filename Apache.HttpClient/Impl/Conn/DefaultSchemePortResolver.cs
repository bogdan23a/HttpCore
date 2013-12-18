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

using Apache.Http;
using Apache.Http.Conn;
using Apache.Http.Impl.Conn;
using Apache.Http.Util;
using Sharpen;

namespace Apache.Http.Impl.Conn
{
	/// <summary>
	/// Default
	/// <see cref="Apache.Http.Conn.SchemePortResolver">Apache.Http.Conn.SchemePortResolver
	/// 	</see>
	/// .
	/// </summary>
	/// <since>4.3</since>
	public class DefaultSchemePortResolver : SchemePortResolver
	{
		public static readonly DefaultSchemePortResolver Instance = new DefaultSchemePortResolver
			();

		/// <exception cref="Apache.Http.Conn.UnsupportedSchemeException"></exception>
		public virtual int Resolve(HttpHost host)
		{
			Args.NotNull(host, "HTTP host");
			int port = host.GetPort();
			if (port > 0)
			{
				return port;
			}
			else
			{
				string name = host.GetSchemeName();
				if (Sharpen.Runtime.EqualsIgnoreCase(name, "http"))
				{
					return 80;
				}
				else
				{
					if (Sharpen.Runtime.EqualsIgnoreCase(name, "https"))
					{
						return 443;
					}
					else
					{
						throw new UnsupportedSchemeException(name + " protocol is not supported");
					}
				}
			}
		}
	}
}
