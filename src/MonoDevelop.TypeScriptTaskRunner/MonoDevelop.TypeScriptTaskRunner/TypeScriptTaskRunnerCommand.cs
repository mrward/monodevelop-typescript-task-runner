//
// TypeScriptTaskRunnerCommand.cs
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

using Microsoft.VisualStudio.TaskRunnerExplorer;

namespace MonoDevelop.TypeScriptTaskRunner
{
	class TypeScriptTaskRunnerCommand : ITaskRunnerCommand
	{
		TypeScriptCompilerCommandLine commandLine;

		public TypeScriptTaskRunnerCommand (string workingDirectory, bool isWatch = false)
		{
			if (isWatch) {
				commandLine = TypeScriptCompilerCommandLine.CreateWatchCommandLine (workingDirectory);
			} else {
				commandLine = TypeScriptCompilerCommandLine.CreateBuildCommandLine (workingDirectory);
			}
		}

		public string Args {
			get => commandLine.Arguments;
			set => commandLine.Arguments = value;
		}

		public string Options { get; set; }

		public string Executable => commandLine.Command;
		public string WorkingDirectory => commandLine.WorkingDirectory;
	}
}
