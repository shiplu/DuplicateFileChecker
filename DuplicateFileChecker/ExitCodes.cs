using System;

namespace DuplicateFileChecker
{
	[Flags]
	public enum ExitCodes : int
	{
		Success = 0,
		NotEnoughArguments = 1,
		NotEnoughMemory = 2,
		AccessDenied = 4,
		InvalidArgument = 8,
		UnknownError = 16
	}
}

