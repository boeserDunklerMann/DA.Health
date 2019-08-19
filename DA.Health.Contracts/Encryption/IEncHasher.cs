using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Health.Contracts.Encryption
{
	/// <summary>
	/// Die implentierende Klasse erzeugt einen Hash aus einem Input-String (mittels MD5, CRC, etc.)
	/// </summary>
	public interface IEncHasher
	{
		byte[] HashUserPasswort(string username, string plainPasswort);
	}
}
