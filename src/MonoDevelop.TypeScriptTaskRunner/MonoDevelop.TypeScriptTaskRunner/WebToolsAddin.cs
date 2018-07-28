//
// WebToolsAddin.cs
//
// Author:
//       Matt Ward <matt.ward@microsoft.com>
//
// Copyright (c) 2018 Microsoft
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.IO;
using MonoDevelop.Ide;

namespace MonoDevelop.TypeScriptTaskRunner
{
	/// <summary>
	/// The web tools addin includes node and the TypeScript compiler (tsc.js).
	/// Visual Studio 7.5 is the first version that includes these files so they
	/// may not exist.
	/// </summary>
	static class WebToolsAddin
	{
		static readonly string rootDirectory;
		static readonly string nodePath;
		static readonly string typeScriptCompilerPath;
		static readonly bool exists;

		static WebToolsAddin ()
		{
			rootDirectory = GetWebToolsDirectory ();
			nodePath = Path.Combine (rootDirectory, "Node", "mac", "node");
			typeScriptCompilerPath = Path.Combine (RootDirectory, "TSServer", "tsc.js");

			exists = File.Exists (nodePath) && File.Exists (typeScriptCompilerPath);
		}

		public static bool Exists => exists;
		public static string RootDirectory => rootDirectory;
		public static string NodePath => nodePath;
		public static string TypeScriptCompilerPath => typeScriptCompilerPath;

		static string GetWebToolsDirectory ()
		{
			Type type = typeof (DesktopService);
			string binDirectory = Path.GetDirectoryName (type.Assembly.Location);
			string directory = Path.Combine (binDirectory, "..", "AddIns", "webtools", "Microsoft.VisualStudio.WebTools.WebToolingAddin");
			return Path.GetFullPath (directory);
		}
	}
}
