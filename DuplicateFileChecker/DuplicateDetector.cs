using System;
using System.Collections.Generic;
using System.IO;

namespace DuplicateFileChecker
{
	public class DuplicateDetector
	{
		private List<FileInfo> files;
		private int fileCount;
		
		public List<FileInfo> Files {
			get { return this.files;}
			set { files = value;}
		}
		
		private int FileCount {
			get { return this.fileCount;}
			set { fileCount = value;}
		}

		public DuplicateDetector ()
		{
			this.FileCount = 0;
			this.Files = new List<FileInfo> ();
		}
		
		/// <summary>
		/// Finds the duplicate files.
		/// </summary>
		/// <returns>
		/// The duplicate files in a list
		/// </returns>
		/// <param name='dirname'>
		/// Full path of the directory
		/// </param>
		public List<List<FileInfo>> FindDuplicateFiles (string dirname)
		{
			/// Populating the internal Files member by all the files in
			/// the directory `dirname'
			populateAllFilesRecursive (dirname);
			Strategies.StrategyProvider sp = new Strategies.StrategyProvider();	
			List<List<FileInfo>> fileNames = new List<List<FileInfo>> ();
			
			/// Iterating over all the files to check the duplicates
			for (int i=0; i< Files.Count; i++) {
				
				List<FileInfo> names = new List<FileInfo> ();
				FileInfo A = Files [i];
				names.Add (A);
				for (int j=i+1; j< Files.Count; j++) {
					FileInfo B = Files [j];
					
					/// Duplicate strategy calcualtes the probablity of
					/// duplicacy. 
					DuplicateStrategy ds = new DuplicateStrategy (A, B, sp);
					int probablity = ds.GetDuplicateProbablity ();
					
					/// If there is a small chance we just consider to 
					/// be a duplicate entry
					if (probablity > 0) {
						names.Add (B);
					}
				}
				
				/// if we get only a sigle copy of the current file then
				/// dont add it to the main output list
				if (names.Count > 1) {
					fileNames.Add (names);
					foreach(FileInfo name in names){
						Files.Remove(name);
					}
				}
			}
			return fileNames;
		}
		
		/// <summary>
		/// Hanldes the callbacke when a file is found during directory
		/// walking
		/// </summary>
		/// <param name='fi'>
		/// FileInfo structure that is recieved from DirectoryWalker
		/// </param>
		private void handleFile (FileInfo fi)
		{
			this.Files.Add (fi);
			this.FileCount++;
#if DEBUG
			Console.Error.Write ("{0}\r", FileCount);
#endif
		}
		
		/// <summary>
		/// Populates all files recursivly in the given directory.
		/// </summary>
		/// <param name='dirname'>
		/// Full path of the directory
		/// </param>
		private void populateAllFilesRecursive (string dirname)
		{
			DirectoryWalker dw = new DirectoryWalker ();
			DirectoryInfo dirInfo = new DirectoryInfo (dirname);
			FileCount = 0;
			Files.Clear ();
#if DEBUG
			Console.Error.WriteLine ("Reading all files ...");
			dw.walk (dirInfo, this.handleFile, null);
			Console.Error.WriteLine ("{0} files found.", FileCount);
#else
			dw.walk (dirInfo, this.handleFile, null);
#endif
		}
	}
}

