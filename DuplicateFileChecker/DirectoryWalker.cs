using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace DuplicateFileChecker
{
	
	/// <summary>
	/// Directory info delegate.
	/// </summary>
	public delegate void DirectoryInfoDelegate (DirectoryInfo di);
	/// <summary>
	/// File info delegate.
	/// </summary>
	public delegate void FileInfoDelegate (FileInfo fi);
	
	public class DirectoryWalker
	{
		private StringCollection log;
		private List<String> fileNames;
		
		/// <summary>
		/// Gets or sets the file names.
		/// </summary>
		/// <value>
		/// The file names.
		/// </value>
		public List<String> FileNames {
			get { return this.fileNames;}
			set { fileNames = value;}
		}

		/// <summary>
		/// Collects all the log
		/// </summary>
		public StringCollection Log {
			get { return this.log;}
			set { log = value;}
		}

		public DirectoryWalker ()
		{
			this.Log = new StringCollection ();
			this.FileNames = new List<string> (100);
		}
		
		/// <summary>
		/// Walk the specified directory, file info and directory info delegate
		/// </summary>
		/// <param name='rootDirectory'>
		/// Root directory.
		/// </param>
		/// <param name='fid'>
		/// a file info delegate
		/// </param>
		/// <param name='did'>
		/// a directory info delegate
		/// </param>
		public void walk (DirectoryInfo rootDirectory, FileInfoDelegate fid, DirectoryInfoDelegate did)
		{
			FileInfo[] files = null;
			DirectoryInfo[] directories = null;
			
			try {
				files = rootDirectory.GetFiles ();
			} catch (UnauthorizedAccessException ue) {
				this.Log.Add (ue.Message);
			} catch (DirectoryNotFoundException dnfe) {
				this.Log.Add (dnfe.Message);
			} catch (Exception e) {
				this.Log.Add (e.Message);
			}
			
			if (files != null) {
				if (fid == null) {
					foreach (FileInfo fi in files) {
					
						this.FileNames.Add (fi.FullName);
					}
				} else {
					foreach (FileInfo fi in files) {
						fid (fi);
						this.FileNames.Add (fi.FullName);
					}
				}
			}
			
			directories = rootDirectory.GetDirectories ();
			
			if (directories != null) {
				if (did == null) {
					foreach (DirectoryInfo di in directories) {
						this.walk (di, fid, did);
					}
				} else {
					foreach (DirectoryInfo di in directories) {
						did (di);
						this.walk (di, fid, did);
					}
				}
			}
		}
	}
}

