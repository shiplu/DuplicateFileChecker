using System;
using System.IO;
using System.Collections.Generic;
using DuplicateFileChecker.Strategies;
using DuplicateStrategyAddin;

namespace DuplicateFileChecker
{
	public class DuplicateStrategy
	{
		private FileInfo a;
		private FileInfo b;
		private StrategyProvider provider; 
		
		public DuplicateStrategy (FileInfo A, FileInfo B, StrategyProvider sp)
		{
			this.a = A;
			this.b = B;
			this.provider = sp;
			
		}
				
		/// <summary>
		/// Gets the duplicate probablity
		/// </summary>
		/// <returns>
		/// The duplicate probablity. The value is between 0-100. 100 means 100% duplicate. 
		/// </returns>
		public int GetDuplicateProbablity ()
		{
			int countCheck = 0;
			bool isDuplicate = false;
		
			
			
			foreach (IStrategy dc in this.provider.Strategies) {
				isDuplicate = dc.check (this.a, this.b);
				if (!isDuplicate) {
					break;
				}
				countCheck++;
			}
			return (countCheck / this.provider.Strategies.Length) * 100;
		}
	}
}

