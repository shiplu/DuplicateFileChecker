using System;
using DuplicateFileChecker;
using System.Security.Cryptography;
using System.IO;
using DuplicateStrategyAddin;

namespace DuplicateFileChecker.Strategies
{
	public class SHA256Duplicate: IStrategy
	{
		public bool check (FileInfo a, FileInfo b)
		{
			/// Sha256 calculator
			SHA256 sha = new SHA256Managed();
			
			/// place to store sha256 sum
			byte[] resultA, resultB;
			
			/// read the sha256 of the first file and store data
			resultA = sha.ComputeHash(a.OpenRead());
			
			/// read the sha256 of the second file and store data
			resultB = sha.ComputeHash(b.OpenRead());
			
			
			for(int i=0; i<resultA.Length;i++){
				if(resultA[i]!=resultB[i]) return false;
			}
			
			return true;
		}
	}
}

