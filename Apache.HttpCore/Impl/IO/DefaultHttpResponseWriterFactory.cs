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
using Org.Apache.Http.IO;
using Org.Apache.Http.Impl.IO;
using Org.Apache.Http.Message;
using Sharpen;

namespace Org.Apache.Http.Impl.IO
{
	/// <summary>Default factory for response message writers.</summary>
	/// <remarks>Default factory for response message writers.</remarks>
	/// <since>4.3</since>
	public class DefaultHttpResponseWriterFactory : HttpMessageWriterFactory<HttpResponse
		>
	{
		public static readonly Org.Apache.Http.Impl.IO.DefaultHttpResponseWriterFactory Instance
			 = new Org.Apache.Http.Impl.IO.DefaultHttpResponseWriterFactory();

		private readonly LineFormatter lineFormatter;

		public DefaultHttpResponseWriterFactory(LineFormatter lineFormatter) : base()
		{
			this.lineFormatter = lineFormatter != null ? lineFormatter : BasicLineFormatter.Instance;
		}

		public DefaultHttpResponseWriterFactory() : this(null)
		{
		}

		public virtual HttpMessageWriter<HttpResponse> Create(SessionOutputBuffer buffer)
		{
			return new DefaultHttpResponseWriter(buffer, lineFormatter);
		}
	}
}
