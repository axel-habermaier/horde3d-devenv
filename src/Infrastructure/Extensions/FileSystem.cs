using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

/// <summary>
/// Helper class that generates a unique file name by adding a number to the
/// end of the file name if the file already exists.
/// </summary>
public static class FileSystem
{
	/// <summary>
	/// Generates a unique file name for a file with the given name and extension in the
	/// given path. This is achieved by adding a number to the end of the file name.
	/// </summary>
	/// <param name="path">The path in which the file name should be unique.</param>
	/// <param name="fileName">The original file name.</param>
	/// <param name="extension">The file's extension.</param>
	/// <returns>The original file name, if it is unique, or the original file name with
	/// a number at the end that makes it unique. Null, if an error occurred.</returns>
	public static string GenerateUniqueName(string path, string fileName, string extension)
	{
		if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(extension))
			return null;

		if (!extension.StartsWith("."))
			extension = "." + extension;

		try
		{
			if (File.Exists(Path.Combine(path, fileName + extension)))
			{
				int i = 1;
				while (File.Exists(Path.Combine(path, fileName + " (" + i + ")" + extension)))
					++i;
				return fileName + " (" + i + ")";
			}

			return fileName;
		}
		catch (Exception e)
		{
			Trace.WriteLine(e.ToString());
			return null;
		}
	}

	// Fixme: Always crashes the CLR; used to work on Vista and XP
	//[DllImport("shlwapi.dll")]
	//static extern bool PathCompactPathEx([Out] StringBuilder pszOut, string szPath, int cchMax, int dwFlags);

	/// <summary>
	/// Truncates the given path to the specified length.
	/// </summary>
	/// <param name="path">The path that should be truncated.</param>
	/// <param name="length">The maximum length of the path.</param>
	/// <returns>Returns the truncated path.</returns>
	public static string TruncatePath(string path, int length)
	{
		var sb = new StringBuilder();
		// Fixme: Always crashes the CLR; used to work on Vista and XP
		//PathCompactPathEx(sb, path, length, 0);
		sb.Append(path);
		return sb.ToString();
	}
}

