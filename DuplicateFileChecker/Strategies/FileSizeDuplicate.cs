using System;
using System.IO;
using DuplicateStrategyAddin;

namespace DuplicateFileChecker.Strategies
{
	public class FileSizeDuplicate : IStrategy
	{
		public bool check (FileInfo a, FileInfo b)
		{
			return a.Length == b.Length;
		}
	}
}

