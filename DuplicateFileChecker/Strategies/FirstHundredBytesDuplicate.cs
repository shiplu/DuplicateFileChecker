using System;
using System.IO;
using System.Text;
using DuplicateFileChecker;
using DuplicateStrategyAddin;

namespace DuplicateFileChecker.Strategies
{
	public class FirstHundredBytesDuplicate: IStrategy
	{
		public bool check (FileInfo a, FileInfo b)
		{
			int len = a.Length < b.Length ? (int)a.Length : (int)b.Length;
			
			len = len > 100 ? 100 : len;
			
			FileStream fsa = a.OpenRead ();
			byte[] ba = new byte[len];
				
			FileStream fsb = b.OpenRead ();
			byte[] bb = new byte[len];
				
			fsa.Read (ba, 0, len);
			fsb.Read (bb, 0, len);
				
			fsa.Close ();
			fsb.Close ();
				
			for (int i=0; i<len; i++) {
				if (ba [i] != bb [i])
					return false;
			}
				
			return true;
			
		}
	}
}

