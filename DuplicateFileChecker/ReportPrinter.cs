using System;
using System.IO;
using System.Collections.Generic;

namespace DuplicateFileChecker
{
	abstract public class ReportPrinter
	{
		private List<List<FileInfo>> fileNames;

		public List<List<FileInfo>> FileNames {
			get {
				return this.fileNames;
			}
			set {
				fileNames = value;
			}
		}

		public ReportPrinter (List<List<FileInfo>> fNames)
		{
			this.FileNames = new List<List<FileInfo>> (fNames);
		}
		
		abstract public void Print ();
	}
}

