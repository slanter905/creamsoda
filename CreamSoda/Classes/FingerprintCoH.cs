using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

/************************************************************************
*  This class exists for two purposes: either give it a path and it     *
*  will automatically load a file size and md5 checsum, or give         *
*  it all the size and checksum data in the constructor to package      *
*  pre-defined checksums, loaded possibly from a file.                  *
************************************************************************/
public class FingerprintCoH
{
    private string m_FileName;
    private long m_Size;
    private string m_Checksum;
    private bool m_mismatch = false;

    /**********************************************************************/
    public string FileName { get { return m_FileName; } }
    public long Size { get { return m_Size; } }
    public string Checksum { get { return m_Checksum; } }
    public bool Mismatch { get { return m_mismatch; } set { m_mismatch = value; } }

    /**********************************************************************/

    public FingerprintCoH(string FileName) {
        
		if(FileName.Contains(":\\")) {
			// Make sure the file name has propper direction slashes for Windows
			m_FileName = FileName.Replace("/", "\\");
		} else {
			// Make sure the file name has propper direction slashes for OSX
			m_FileName = FileName.Replace("\\", "/");
		}


        // Load size from the file info
        m_Size = (new FileInfo(FileName)).Length;

        // Nuff said
        m_Checksum = GenerateHash();
    }
    
    
    public FingerprintCoH(string FileName, string Checksum)
    {
		if(FileName.Contains(":\\")) {
			// Make sure the file name has propper direction slashes for Windows
			m_FileName = FileName.Replace("/", "\\");
		} else {
			// Make sure the file name has propper direction slashes for OSX
			m_FileName = FileName.Replace("\\", "/");
		}

        // Load size from the file info
        m_Size = (new FileInfo(FileName)).Length;

        // Make sure the checksum is uppercase
        m_Checksum = Checksum.ToUpper();
    }

    public FingerprintCoH(string FileName, int Size, string Checksum)
    {
		if(FileName.Contains(":\\")) {
			// Make sure the file name has propper direction slashes for Windows
			m_FileName = FileName.Replace("/", "\\");
		} else {
			// Make sure the file name has propper direction slashes for OSX
			m_FileName = FileName.Replace("\\", "/");
		}

        // Make sure the checksum is uppercase
        m_Checksum = Checksum.ToUpper();

        // ... yea... overcommenting!
        m_Size = Size;
    }

    /**********************************************************************/

    /// <summary>
    /// Compare to another Fingerprint object
    /// </summary>
    /// <param name="other">The object to compare to</param>
    /// <returns>True if they are equal, false otherwise.</returns>

    public bool Equals(Fingerprint other)
    {
        if (this.FileName != other.FileName) return false;
        if (this.Size != other.Size) return false;
        if (this.Checksum != other.Checksum) return false;
        return true;
    }

    /// <summary>
    /// Generates idiotic md5 checksum.
    /// </summary>
    /// <returns>An md5 checksum, split in 4 chunks, each chunk inverted.</returns>
    public string GenerateHash(string path)
    {
        MD5 md5Hash = MD5.Create();

        var buffer = md5Hash.ComputeHash(File.ReadAllBytes(path));

        // We define 4 variables, one for each of the 4 chunks
        var cs1 = new StringBuilder();
        var cs2 = new StringBuilder();
        var cs3 = new StringBuilder();
        var cs4 = new StringBuilder();
        
        // We we do our looping backwards, and we will only do 4 loops.
        for (int i = 4; i > 0; i--)
        {
            // Use the index multiplied by an offset to get 
            // the byte from the buffer and append it to it's 
            // respective group
            cs1.Append(buffer[i + 4 * 0 - 1].ToString("x2"));
            cs2.Append(buffer[i + 4 * 1 - 1].ToString("x2"));
            cs3.Append(buffer[i + 4 * 2 - 1].ToString("x2"));
            cs4.Append(buffer[i + 4 * 3 - 1].ToString("x2"));
        }

        // Append spaces to the first 3 groups
        cs1.Append(" "); cs2.Append(" "); cs3.Append(" ");

        // Consolidate all the blocks into one single checksum
        var cs = new StringBuilder();
        cs.Append(cs1); cs.Append(cs2); cs.Append(cs3); cs.Append(cs4);

        // Return an uppercase version of the consolidated string.
        return cs.ToString().ToUpper();
    }

    /// <summary>
    /// Short form overload that will use the member variable instead of taking it as a parameter.
    /// </summary>
    /// <returns>An md5 checksum, split in 4 chunks, each chunk inverted.</returns>
    public string GenerateHash()
    {
        return GenerateHash(FileName);
    }
    
}