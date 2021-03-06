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
using Apache.Http;
using Apache.Http.Client.Methods;
using Apache.Http.Impl.Execchain;
using Org.Apache.Http;
using Sharpen;
using Sharpen.Reflect;

namespace Apache.Http.Impl.Execchain
{
	/// <summary>Execution proxies for HTTP message objects.</summary>
	/// <remarks>Execution proxies for HTTP message objects.</remarks>
	/// <since>4.3</since>
	internal class Proxies
	{
		internal static void EnhanceEntity(HttpEntityEnclosingRequest request)
		{
			HttpEntity entity = request.GetEntity();
			if (entity != null && !entity.IsRepeatable() && !IsEnhanced(entity))
			{
				HttpEntity proxy = (HttpEntity)Proxy.NewProxyInstance(typeof(HttpEntity).GetClassLoader
					(), new Type[] { typeof(HttpEntity) }, new RequestEntityExecHandler(entity));
				request.SetEntity(proxy);
			}
		}

		internal static bool IsEnhanced(HttpEntity entity)
		{
			if (entity != null && Proxy.IsProxyClass(entity.GetType()))
			{
				InvocationHandler handler = Proxy.GetInvocationHandler(entity);
				return handler is RequestEntityExecHandler;
			}
			else
			{
				return false;
			}
		}

		internal static bool IsRepeatable(IHttpRequest request)
		{
			if (request is HttpEntityEnclosingRequest)
			{
				HttpEntity entity = ((HttpEntityEnclosingRequest)request).GetEntity();
				if (entity != null)
				{
					if (IsEnhanced(entity))
					{
						RequestEntityExecHandler handler = (RequestEntityExecHandler)Proxy.GetInvocationHandler
							(entity);
						if (!handler.IsConsumed())
						{
							return true;
						}
					}
					return entity.IsRepeatable();
				}
			}
			return true;
		}

		public static CloseableHttpResponse EnhanceResponse(HttpResponse original, ConnectionHolder
			 connHolder)
		{
			return (CloseableHttpResponse)Proxy.NewProxyInstance(typeof(ResponseProxyHandler)
				.GetClassLoader(), new Type[] { typeof(CloseableHttpResponse) }, new ResponseProxyHandler
				(original, connHolder));
		}
	}
}
