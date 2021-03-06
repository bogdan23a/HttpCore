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
using Org.Apache.Http.Params;
using Org.Apache.Http.Protocol;
using Org.Apache.Http.Util;
using Sharpen;

namespace Org.Apache.Http.Protocol
{
	/// <summary>RequestUserAgent is responsible for adding <code>User-Agent</code> header.
	/// 	</summary>
	/// <remarks>
	/// RequestUserAgent is responsible for adding <code>User-Agent</code> header.
	/// This interceptor is recommended for client side protocol processors.
	/// </remarks>
	/// <since>4.0</since>
	public class RequestUserAgent : IHttpRequestInterceptor
	{
		private readonly string userAgent;

		public RequestUserAgent(string userAgent) : base()
		{
			this.userAgent = userAgent;
		}

		public RequestUserAgent() : this(null)
		{
		}

		/// <exception cref="Org.Apache.Http.HttpException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual void Process(IHttpRequest request, HttpContext context)
		{
			Args.NotNull(request, "HTTP request");
			if (!request.ContainsHeader(HTTP.UserAgent))
			{
				string s = null;
				HttpParams @params = request.GetParams();
				if (@params != null)
				{
					s = (string)@params.GetParameter(CoreProtocolPNames.UserAgent);
				}
				if (s == null)
				{
					s = this.userAgent;
				}
				if (s != null)
				{
					request.AddHeader(HTTP.UserAgent, s);
				}
			}
		}
	}
}
