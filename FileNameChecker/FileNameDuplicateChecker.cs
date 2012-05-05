// 
//  FileNameDuplicateChecker.cs
//  
//  Author:
//       Shiplu Mokaddim <shiplu@mokadd.im>
//  
//  Copyright (c) 2012 Shiplu Mokaddim
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.IO;
using DuplicateStrategyAddin;

namespace FileNameChecker
{
	public class FileNameDuplicateChecker : DuplicateStrategyAddin.IStrategy
	{
		public bool check (FileInfo a, FileInfo b)
		{
			char[] ar =  a.Name.ToCharArray();
			String aName = new String(Array.FindAll<char>(ar, (c => char.IsLetter(c))));
			char[] br = b.Name.ToCharArray();
			String bName = new String(Array.FindAll<char>(br, (c => char.IsLetter(c))));

			// checking the whole file name
			return aName == bName;
		}
	}
}

