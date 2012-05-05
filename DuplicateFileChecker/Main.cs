using System;
using System.IO;
using System.Collections.Generic;
using DuplicateFileChecker.Printers;

namespace DuplicateFileChecker
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			
			if (args.Length < 1) {
				Console.Error.WriteLine ("Not enought argument specified. Run with --help to see the available options");
				Environment.Exit ((int)ExitCodes.NotEnoughArguments);
			}
			foreach (string arg in args) {
				switch (arg) {
				case "--help":
					Console.Error.WriteLine ("DuplicateFileChecker\tDIRECTORY");
					Console.Error.WriteLine ("\tDIRECTORY\tFinds the duplicate files inside this directory recursively");
					Environment.Exit ((int)ExitCodes.Success);
					break;
				}
				
			}
			
			// checking if this current file is a directory
			FileAttributes fattr = File.GetAttributes (args [0]);
			if ((fattr & FileAttributes.Directory) != FileAttributes.Directory) {
				Console.Error.WriteLine ("'{0}' is not a directory!", args [0]);
				Environment.Exit ((int)ExitCodes.InvalidArgument);
			}
			
			DuplicateDetector dd = new DuplicateDetector ();
			List<List<FileInfo>> filenames = dd.FindDuplicateFiles (args [0]);
			
			ConsoleTreePrinter rp = new ConsoleTreePrinter(filenames);
			rp.Print ();
			
		}
	}
}