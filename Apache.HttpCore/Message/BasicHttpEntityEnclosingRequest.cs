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
using Org.Apache.Http.Message;
using Org.Apache.Http.Protocol;
using Sharpen;

namespace Org.Apache.Http.Message
{
	/// <summary>
	/// Basic implementation of
	/// <see cref="Org.Apache.Http.HttpEntityEnclosingRequest">Org.Apache.Http.HttpEntityEnclosingRequest
	/// 	</see>
	/// .
	/// </summary>
	/// <since>4.0</since>
	public class BasicHttpEntityEnclosingRequest : BasicHttpRequest, HttpEntityEnclosingRequest
	{
		private HttpEntity entity;

		public BasicHttpEntityEnclosingRequest(string method, string uri) : base(method, 
			uri)
		{
		}

		public BasicHttpEntityEnclosingRequest(string method, string uri, ProtocolVersion
			 ver) : base(method, uri, ver)
		{
		}

		public BasicHttpEntityEnclosingRequest(RequestLine requestline) : base(requestline
			)
		{
		}

		public virtual HttpEntity GetEntity()
		{
			return this.entity;
		}

		public virtual void SetEntity(HttpEntity entity)
		{
			this.entity = entity;
		}

		public virtual bool ExpectContinue()
		{
			Header expect = GetFirstHeader(HTTP.ExpectDirective);
			return expect != null && Sharpen.Runtime.EqualsIgnoreCase(HTTP.ExpectContinue, expect
				.GetValue());
		}
	}
}
