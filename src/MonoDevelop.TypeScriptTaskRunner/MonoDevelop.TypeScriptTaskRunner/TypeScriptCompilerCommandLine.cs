﻿//
// TypeScriptCompilerCommandLine.cs
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

namespace MonoDevelop.TypeScriptTaskRunner
{
	class TypeScriptCompilerCommandLine
	{
		public string Command { get; set; }
		public string Arguments { get; set; }
		public string WorkingDirectory { get; set; }

		public static TypeScriptCompilerCommandLine CreateBuildCommandLine (string workingDirectory)
		{
			string command = "tsc";
			string arguments = string.Empty;

			if (WebToolsAddin.Exists) {
				command = WebToolsAddin.NodePath;
				arguments = string.Format ("\"{0}\"", WebToolsAddin.TypeScriptCompilerPath);
			}

			return new TypeScriptCompilerCommandLine {
				Command = command,
				Arguments = arguments,
				WorkingDirectory = workingDirectory
			};
		}

		public static TypeScriptCompilerCommandLine CreateWatchCommandLine (string workingDirectory)
		{
			var commandLine = CreateBuildCommandLine (workingDirectory);
			commandLine.Arguments += " --watch";

			return commandLine;
		}
	}
}
