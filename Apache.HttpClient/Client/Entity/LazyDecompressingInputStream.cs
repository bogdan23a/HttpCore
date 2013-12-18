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

using System.IO;
using Apache.Http.Client.Entity;
using Sharpen;

namespace Apache.Http.Client.Entity
{
	/// <summary>Lazy init InputStream wrapper.</summary>
	/// <remarks>Lazy init InputStream wrapper.</remarks>
	internal class LazyDecompressingInputStream : InputStream
	{
		private readonly InputStream wrappedStream;

		private readonly DecompressingEntity decompressingEntity;

		private InputStream wrapperStream;

		public LazyDecompressingInputStream(InputStream wrappedStream, DecompressingEntity
			 decompressingEntity)
		{
			this.wrappedStream = wrappedStream;
			this.decompressingEntity = decompressingEntity;
		}

		/// <exception cref="System.IO.IOException"></exception>
		public override int Read()
		{
			InitWrapper();
			return wrapperStream.Read();
		}

		/// <exception cref="System.IO.IOException"></exception>
		public override int Available()
		{
			InitWrapper();
			return wrapperStream.Available();
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void InitWrapper()
		{
			if (wrapperStream == null)
			{
				wrapperStream = decompressingEntity.Decorate(wrappedStream);
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		public override void Close()
		{
			if (wrapperStream != null)
			{
				wrapperStream.Close();
			}
			wrappedStream.Close();
		}
	}
}