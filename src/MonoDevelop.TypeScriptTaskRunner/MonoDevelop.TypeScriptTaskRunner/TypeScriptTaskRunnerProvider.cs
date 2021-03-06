﻿//
// TypeScriptTaskRunnerProvider.cs
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
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TaskRunnerExplorer;
using System.IO;
using MonoDevelop.Core;

namespace MonoDevelop.TypeScriptTaskRunner
{
	[TaskRunnerExport ("tsconfig.json")]
	class TypeScriptTaskRunnerProvider : ITaskRunner
	{
		public List<ITaskRunnerOption> Options { get; set; }

		public async Task<ITaskRunnerConfig> ParseConfig (ITaskRunnerCommandContext context, string configPath)
		{
			return await Task.Run (() => {
				ITaskRunnerNode hierarchy = LoadHierarchy (configPath);
				return new TypeScriptTaskRunnerConfig (hierarchy);
			});
		}

		ITaskRunnerNode LoadHierarchy (string configPath)
		{
			string workingDirectory = Path.GetDirectoryName (configPath);

			var root = new TaskRunnerNode ("TypeScript Task Runner");

			root.Children.Add (new TaskRunnerNode ("tcs build", true) {
				Description = "Runs 'tsc build'",
				Command = new TypeScriptTaskRunnerCommand (workingDirectory)
			});

			root.Children.Add (new TaskRunnerNode ("tcs watch", true) {
				Description = "Runs 'tsc watch'",
				Command = new TypeScriptTaskRunnerCommand (workingDirectory, isWatch: true)
			});

			return root;
		}
	}
}
