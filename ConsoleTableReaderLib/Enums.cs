using System;

namespace MyConsoleAppAsignment
{
	/// <summary>
	/// Describes the way program represents results
	/// </summary>
	[Flags]
	public enum ActionFlags : byte
	{
		None = 0x0,
		Count = 0x1,
		Names = 0x2,
		Sheets = 0x4,
		Accurate = 0x8,
		Unrestrict = 0x10,
	}	

	/// <summary>
	/// Discribes resrictions for a flag verification
	/// </summary>
	[Flags]
	public enum VerifyOptions : byte
	{
		None = 0x0,
		ForbidRepeatingArgs = 0x1,
		ForbidExtraChars = 0x2,
	}

	/// <summary>
	/// Discribes result of an argument verification
	/// </summary>
	public enum VerifyResult : byte
	{
		Fail,
		Success,
		NotEnoughArguments,
		InvalidFilePath,
		InvalidArguments
	}

	/// <summary>
	/// Discribes restrictions for a flie reading
	/// </summary>
	[Flags]
	public enum ReadOptions
	{
		None = 0x0,
		RestrictFileType = 0x1,
	}
}