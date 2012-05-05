using System;
using DuplicateFileChecker;
using System.IO;
using System.Collections.Generic;

namespace DuplicateFileChecker.Printers
{
	public class ConsoleTreePrinter : ReportPrinter
	{
		public ConsoleTreePrinter(List<List<FileInfo>> fNames):  base(fNames){}
		public override void Print ()
		{
			for (int i=0; i<FileNames.Count; i++) {
				if(FileNames[i].Count<2)
					continue;
				
				for (int j=0; j<FileNames[i].Count; j++) {
					string format = j==0? "{0}" : (j==(FileNames[i].Count-1)? "└───{0}" : "├───{0}");
					Console.WriteLine (format, FileNames [i] [j].FullName);
				}
				Console.Error.WriteLine("");
			}
		}
	}
}


