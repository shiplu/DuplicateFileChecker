// 
//  IDuplicate.cs
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

namespace DuplicateStrategyAddin
{
	public class IDuplicate
	{
		/// <summary>
		/// Checks whether the specified file a and b are duplicate copy of each other
		/// It should check a signle criteria
		/// </summary>
		/// <param name='a'>
		/// FileInfo a
		/// </param>
		/// <param name='b'>
		/// FileInfo b
		/// </param>
		bool check (FileInfo a, FileInfo b);
	}
}

